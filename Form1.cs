using System.Text;
using ScintillaNET;
using Notepadv.LangStyles;
using Notepadv.SaveData;
using Notepadv.UI;
using Notepadv.UI.Style;

namespace Notepadv;

public class NotepadvColorTable : ProfessionalColorTable
{
    private static readonly Color DarkBg = Color.FromArgb(37, 37, 38);
    private static readonly Color DarkerBg = Color.FromArgb(30, 30, 30);
    private static readonly Color LightGray = Color.FromArgb(60, 60, 60);
    private static readonly Color Violet = Color.FromArgb(138, 98, 185);
    private static readonly Color SelGray = Color.FromArgb(62, 62, 64);
    private static readonly Color Fg = Color.FromArgb(212, 212, 212);

    public override Color MenuBorder => Violet;
    public override Color MenuItemBorder => SelGray;
    public override Color MenuItemSelected => SelGray;
    public override Color MenuItemSelectedGradientBegin => SelGray;
    public override Color MenuItemSelectedGradientEnd => SelGray;
    public override Color MenuItemPressedGradientBegin => DarkBg;
    public override Color MenuItemPressedGradientEnd => DarkBg;
    public override Color ToolStripDropDownBackground => DarkBg;
    public override Color ImageMarginGradientBegin => DarkBg;
    public override Color ImageMarginGradientEnd => DarkBg;
    public override Color ImageMarginGradientMiddle => DarkBg;
    public override Color ImageMarginRevealedGradientBegin => DarkBg;
    public override Color ImageMarginRevealedGradientEnd => DarkBg;
    public override Color SeparatorDark => LightGray;
    public override Color SeparatorLight => LightGray;
    public override Color CheckBackground => DarkBg;
    public override Color CheckPressedBackground => SelGray;
    public override Color CheckSelectedBackground => SelGray;
    public override Color ButtonCheckedGradientBegin => DarkBg;
    public override Color ButtonCheckedGradientEnd => DarkBg;
    public override Color ButtonCheckedGradientMiddle => DarkBg;
    public override Color ButtonSelectedGradientBegin => SelGray;
    public override Color ButtonSelectedGradientEnd => SelGray;
    public override Color OverflowButtonGradientBegin => DarkBg;
    public override Color OverflowButtonGradientEnd => DarkBg;
    public override Color StatusStripGradientBegin => DarkerBg;
    public override Color StatusStripGradientEnd => DarkerBg;
    public override Color MenuStripGradientBegin => DarkBg;
    public override Color MenuStripGradientEnd => DarkBg;
}

public class NotepadvRenderer : ToolStripProfessionalRenderer
{
    private static readonly Color VioletLine = Color.FromArgb(0x4A, 0x36, 0x5E);

    public NotepadvRenderer() : base(new NotepadvColorTable()) { }

    protected override void OnRenderToolStripBorder(ToolStripRenderEventArgs e)
    {
        if (e.ToolStrip is StatusStrip)
        {
            using var pen = new Pen(Color.FromArgb(0x30, 0x23, 0x3D));
            e.Graphics.DrawLine(pen, 0, 0, e.ToolStrip.Width, 0);
        }
        else if (e.ToolStrip is MenuStrip)
        {
            using var pen = new Pen(VioletLine, 2);
            e.Graphics.DrawLine(pen, 0, e.ToolStrip.Height - 1, e.ToolStrip.Width, e.ToolStrip.Height - 1);
        }
        else
        {
            base.OnRenderToolStripBorder(e);
        }
    }

    protected override void OnRenderItemCheck(ToolStripItemImageRenderEventArgs e)
    {
        var rect = e.ImageRectangle;
        var centerX = rect.X + rect.Width / 2;
        var centerY = rect.Y + rect.Height / 2;
        var radius = 4;
        using var brush = new SolidBrush(Color.FromArgb(0x93, 0x26, 0xFF));
        e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
        e.Graphics.FillEllipse(brush, centerX - radius, centerY - radius, radius * 2, radius * 2);
    }
}

public partial class Form1 : Form
{
    private string? _currentFilePath;
    private bool _isModified;
    private Encoding _currentEncoding = Encoding.UTF8;
    private StyleManager _styleManager = null!;
    private LanguageDetector _languageDetector = null!;
    private bool _pendingDetection;
    private FindUI? _findUI;
    private GoToUI? _goToUI;

    public Form1()
    {
        Config.Load();
        InitializeComponent();
        DarkTitleBarHelper.UseImmersiveDarkMode(Handle, true);
        _styleManager = new StyleManager(scintilla);
        _styleManager.Apply("none");
        langNone.Checked = true;
        _languageDetector = new LanguageDetector();
        scintilla.BiDirectionality = BiDirectionalDisplayType.Disabled;
        Width = Config.Width;
        Height = Config.Height;
        scintilla.Zoom = Config.ZoomSize;

        scintilla.ClearCmdKey(Keys.Control | Keys.F);
        scintilla.ClearCmdKey(Keys.Control | Keys.H);
        scintilla.ClearCmdKey(Keys.Control | Keys.G);
    }

    private string FileTitle => _currentFilePath != null ? Path.GetFileName(_currentFilePath) : "Untitled";

    private void UpdateTitle()
    {
        var mark = _isModified ? " *" : "";
        Text = $"Notepadv - {FileTitle}{mark}";
    }

    private void OpenFile(string filePath)
    {
        try
        {
            var bytes = File.ReadAllBytes(filePath);
            _currentEncoding = DetectEncoding(bytes);
            scintilla.Text = _currentEncoding.GetString(bytes);
            _currentFilePath = filePath;
            _isModified = false;
            encodingLabel.Text = _currentEncoding.EncodingName;
            UpdateTitle();
            ApplyLanguageByExtension(filePath);
        }
        catch (Exception ex)
        {
            MsgBox.Show(this, "Error", $"Could not open file: {ex.Message}", DialogButtons.OK, DialogIcon.Error);
        }
    }

    private static readonly Dictionary<string, string> _extLangMap = new(StringComparer.OrdinalIgnoreCase)
    {
        [".cs"] = "C#",
        [".cpp"] = "C++", [".cc"] = "C++", [".cxx"] = "C++", [".h"] = "C++", [".hpp"] = "C++",
        [".js"] = "JavaScript", [".jsx"] = "JavaScript", [".ts"] = "JavaScript", [".tsx"] = "JavaScript", [".mjs"] = "JavaScript",
        [".py"] = "Python",
        [".java"] = "Java",
        [".php"] = "PHP",
        [".html"] = "HTML", [".htm"] = "HTML",
        [".css"] = "CSS",
        [".md"] = "Markdown", [".markdown"] = "Markdown",
    };

    private void ApplyLanguageByExtension(string? filePath)
    {
        if (filePath == null) return;
        string? ext = Path.GetExtension(filePath);
        string? lang = ext != null && _extLangMap.TryGetValue(ext, out var mapped) ? mapped : null;
        foreach (ToolStripMenuItem item in languageMenu.DropDownItems)
        {
            if (string.Equals(item.Text, lang ?? "None", StringComparison.OrdinalIgnoreCase) && item.Text is { } name)
            {
                _styleManager.Apply(name);
                foreach (ToolStripMenuItem i in languageMenu.DropDownItems)
                    i.Checked = false;
                item.Checked = true;
                break;
            }
        }
    }

    private bool SaveFile()
    {
        if (_currentFilePath == null)
            return SaveFileAs();

        try
        {
            var text = scintilla.Text;
            File.WriteAllBytes(_currentFilePath, _currentEncoding.GetBytes(text));
            _isModified = false;
            UpdateTitle();
            return true;
        }
        catch (Exception ex)
        {
            MsgBox.Show(this, "Error", $"Could not save file: {ex.Message}", DialogButtons.OK, DialogIcon.Error);
            return false;
        }
    }

    private bool SaveFileAs()
    {
        using var dialog = new SaveFileDialog();
        dialog.Filter = "All Files (*.*)|*.*";
        dialog.RestoreDirectory = true;

        if (dialog.ShowDialog() != DialogResult.OK)
            return false;

        _currentFilePath = dialog.FileName;
        return SaveFile();
    }

    private bool PromptSaveIfModified()
    {
        if (!_isModified)
            return true;

        var result = MsgBox.Show(this, "Notepadv", $"Do you want to save changes to {FileTitle}?", DialogButtons.YesNoCancel, DialogIcon.Question);

        return result switch
        {
            DialogResult.Yes => SaveFile(),
            DialogResult.No => true,
            _ => false
        };
    }

    private static Encoding DetectEncoding(byte[] bytes)
    {
        if (bytes.Length >= 4 && bytes[0] == 0xFF && bytes[1] == 0xFE && bytes[2] == 0x00 && bytes[3] == 0x00)
            return Encoding.UTF32;
        if (bytes.Length >= 2 && bytes[0] == 0xFE && bytes[1] == 0xFF)
            return Encoding.BigEndianUnicode;
        if (bytes.Length >= 2 && bytes[0] == 0xFF && bytes[1] == 0xFE)
            return Encoding.Unicode;
        if (bytes.Length >= 3 && bytes[0] == 0xEF && bytes[1] == 0xBB && bytes[2] == 0xBF)
            return Encoding.UTF8;

        return new UTF8Encoding(false);
    }

    private void OpenMenuItem_Click(object? sender, EventArgs e)
    {
        if (!PromptSaveIfModified())
            return;

        using var dialog = new OpenFileDialog();
        dialog.Filter = "All Files (*.*)|*.*";
        dialog.RestoreDirectory = true;

        if (dialog.ShowDialog() == DialogResult.OK)
            OpenFile(dialog.FileName);
    }

    private void SaveMenuItem_Click(object? sender, EventArgs e)
    {
        SaveFile();
    }

    private void SaveAsMenuItem_Click(object? sender, EventArgs e)
    {
        SaveFileAs();
    }

    private void ExitMenuItem_Click(object? sender, EventArgs e)
    {
        Close();
    }

    private void AboutMenuItem_Click(object? sender, EventArgs e)
    {
        using var about = new AboutUI();
        about.ShowMe(this);
    }

    private void ResetZoomMenuItem_Click(object? sender, EventArgs e)
    {
        scintilla.Zoom = 0;
    }

    private void CopyMenuItem_Click(object? sender, EventArgs e)
    {
        if (scintilla.SelectionEnd > scintilla.SelectionStart)
            scintilla.Copy();
    }

    private void CutMenuItem_Click(object? sender, EventArgs e)
    {
        if (scintilla.SelectionEnd > scintilla.SelectionStart)
            scintilla.Cut();
    }

    private void PasteMenuItem_Click(object? sender, EventArgs e)
    {
        _pendingDetection = true;
        scintilla.Paste();
    }

    private void LangMenuItem_Click(object? sender, EventArgs e)
    {
        if (sender is ToolStripMenuItem item && item.Text is { } lang)
        {
            _styleManager.Apply(lang);

            foreach (ToolStripMenuItem langItem in languageMenu.DropDownItems)
                langItem.Checked = false;

            item.Checked = true;
        }
    }



    private void Scintilla_TextChanged(object? sender, EventArgs e)
    {
        _isModified = true;
        UpdateTitle();

        if (_pendingDetection)
        {
            _pendingDetection = false;
            AutoDetectLanguage();
        }
    }

    private void AutoDetectLanguage()
    {
        string detected = _languageDetector.Detect(scintilla.Text);
        if (detected != "none" && !string.Equals(detected, _styleManager.Current?.Name, StringComparison.OrdinalIgnoreCase))
        {
            foreach (ToolStripMenuItem item in languageMenu.DropDownItems)
            {
                if (string.Equals(item.Text, detected, StringComparison.OrdinalIgnoreCase) && item.Text is { } lang)
                {
                    _styleManager.Apply(lang);
                    foreach (ToolStripMenuItem langItem in languageMenu.DropDownItems)
                        langItem.Checked = false;
                    item.Checked = true;
                    break;
                }
            }
        }
    }

    private void Scintilla_UpdateUI(object? sender, UpdateUIEventArgs e)
    {
        var line = scintilla.LineFromPosition(scintilla.CurrentPosition) + 1;
        var col = scintilla.GetColumn(scintilla.CurrentPosition) + 1;
        lineColLabel.Text = $"Ln {line}, Col {col}";
    }

    private void Form1_DragEnter(object? sender, DragEventArgs e)
    {
        if (e.Data is { } data && data.GetDataPresent(DataFormats.FileDrop))
            e.Effect = DragDropEffects.Copy;
    }

    private void Form1_DragDrop(object? sender, DragEventArgs e)
    {
        if (e.Data is { } data && data.GetData(DataFormats.FileDrop) is string[] files && files.Length > 0)
        {
            if (!PromptSaveIfModified())
                return;
            OpenFile(files[0]);
        }
    }

    protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
    {
        if (keyData == (Keys.Control | Keys.F))
        {
            ShowFindUI(false);
            return true;
        }
        if (keyData == (Keys.Control | Keys.H))
        {
            ShowFindUI(true);
            return true;
        }
        if (keyData == (Keys.Control | Keys.G))
        {
            ShowGoToUI();
            return true;
        }
        return base.ProcessCmdKey(ref msg, keyData);
    }

    private void ShowFindUI(bool replace)
    {
        if (_findUI != null)
        {
            Controls.Remove(_findUI);
            _findUI.Dispose();
        }

        _findUI = new FindUI(scintilla, replace);
        _findUI.Location = new Point(ClientSize.Width - _findUI.Width - SystemInformation.VerticalScrollBarWidth, scintilla.Top);
        _findUI.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        _findUI.Close += OnFindUIClose;
        Controls.Add(_findUI);
        _findUI.BringToFront();
    }

    private void OnFindUIClose()
    {
        if (_findUI != null)
        {
            Controls.Remove(_findUI);
            _findUI.Dispose();
            _findUI = null;
            scintilla.Focus();
        }
    }

    private void ShowGoToUI()
    {
        if (_goToUI != null)
        {
            Controls.Remove(_goToUI);
            _goToUI.Dispose();
        }

        _goToUI = new GoToUI(scintilla);
        _goToUI.Location = new Point(
            scintilla.Left + (scintilla.Width - _goToUI.Width) / 2,
            scintilla.Top + (scintilla.Height - _goToUI.Height) / 2);
        _goToUI.Close += OnGoToUIClose;
        Controls.Add(_goToUI);
        _goToUI.BringToFront();
    }

    private void OnGoToUIClose()
    {
        if (_goToUI != null)
        {
            Controls.Remove(_goToUI);
            _goToUI.Dispose();
            _goToUI = null;
            scintilla.Focus();
        }
    }

    protected override void OnFormClosing(FormClosingEventArgs e)
    {
        if (!PromptSaveIfModified())
            e.Cancel = true;
        if (e.Cancel)
            return;
        Config.Width = Width;
        Config.Height = Height;
        Config.ZoomSize = scintilla.Zoom;
        Config.Save();
        base.OnFormClosing(e);
    }
}
