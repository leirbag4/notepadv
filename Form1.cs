using System.Text;
using ScintillaNET;
using Notepadv.LangStyles;
using Notepadv.SaveData;
using Notepadv.UI;
using Notepadv.UI.Controls;
using Notepadv.UI.Controls.ScrollBarAdvance;
using Notepadv.UI.Style;
using Notepadv.VampEditor;

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

    private ScrollBarAdv vertScrollBar;
    private ScrollBarAdv horScrollBar;
    private Control scrollBarCorner;

    public Form1(string? filePath = null)
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

        scintilla.VerticalScrollChanged += OnVerticalScrollChanged;
        scintilla.HorizontalScrollChanged += OnHorizontalScrollChanged;
        scintilla.ContextItemPressed += OnEditorContextItemPressed;

        CreateCustomScrollBars();

        if (filePath != null)
            OpenFile(filePath);
    }

    private string FileTitle => _currentFilePath != null ? Path.GetFileName(_currentFilePath) : "Untitled";

    private void CreateCustomScrollBars()
    {
        vertScrollBar =                     new ScrollBarAdv();
        vertScrollBar.ThumbPaddingX =       5;
        vertScrollBar.ThumbPaddingY =       4;
        vertScrollBar.MinThumbSize =        20;
        vertScrollBar.ThumbNormalColor =    Color.FromArgb(65, 65, 65);
        vertScrollBar.ThumbOverColor =      Color.FromArgb(75, 75, 75);
        vertScrollBar.ButtonSize =          SystemInformation.VerticalScrollBarWidth;
        vertScrollBar.Width =               SystemInformation.VerticalScrollBarWidth;
        vertScrollBar.Anchor =              AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
        vertScrollBar.Scroll +=             OnVertScroll;

        horScrollBar =                      new ScrollBarAdv();
        horScrollBar.Orientation =          ScrollBarOrientation.Horizontal;
        horScrollBar.AllowMouseScrolling =  false;
        horScrollBar.ThumbPaddingX =        4;
        horScrollBar.ThumbPaddingY =        5;
        horScrollBar.MinThumbSize =         20;
        horScrollBar.ThumbNormalColor =     Color.FromArgb(65, 65, 65);
        horScrollBar.ThumbOverColor =       Color.FromArgb(75, 75, 75);
        horScrollBar.ButtonSize =           SystemInformation.HorizontalScrollBarHeight;
        horScrollBar.Height =               SystemInformation.HorizontalScrollBarHeight;
        horScrollBar.Anchor =               AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom;
        horScrollBar.Scroll +=              OnHorScroll;

        scrollBarCorner =                   new Control();
        scrollBarCorner.BackColor =         Color.FromArgb(60, 60, 60);
        scrollBarCorner.Size =              new Size(SystemInformation.VerticalScrollBarWidth, SystemInformation.HorizontalScrollBarHeight);
        scrollBarCorner.Location =          new Point(scintilla.Right - scrollBarCorner.Width, scintilla.Bottom - scrollBarCorner.Height);
        scrollBarCorner.Anchor =            AnchorStyles.Bottom | AnchorStyles.Right;

        scintilla.SizeChanged += (s, e) =>
        {
            OnVerticalScrollChanged(scintilla.GetVScrollInfo(), scintilla.FirstVisibleLine);
            OnHorizontalScrollChanged(scintilla.GetHScrollInfo(), scintilla.XOffset);
            RefreshScrollBarsVisibility();
        };

        Controls.Add(vertScrollBar);
        Controls.Add(horScrollBar);
        Controls.Add(scrollBarCorner);
        vertScrollBar.BringToFront();
        horScrollBar.BringToFront();
        scrollBarCorner.BringToFront();

        RefreshScrollBarsVisibility();
    }

    private void RefreshScrollBarsVisibility()
    {
        bool vscrollVisible =   scintilla.IsVerticalScrollVisible;
        bool hscrollVisible =   scintilla.IsHorizontalScrollVisible;

        vertScrollBar.Height =  scintilla.Height - (hscrollVisible ? horScrollBar.Height : 0);
        horScrollBar.Width =    scintilla.Width  - (vscrollVisible ? vertScrollBar.Width : 0);

        vertScrollBar.Location =    new Point(scintilla.Right - vertScrollBar.Width, scintilla.Top);
        horScrollBar.Location =     new Point(scintilla.Left, scintilla.Bottom - horScrollBar.Height);
        scrollBarCorner.Location =  new Point(scintilla.Right - scrollBarCorner.Width, scintilla.Bottom - scrollBarCorner.Height);

        vertScrollBar.Visible =     vscrollVisible;
        horScrollBar.Visible =      hscrollVisible;
        scrollBarCorner.Visible =   vscrollVisible && hscrollVisible;
    }

    private void OnVertScroll(int newValue, int oldValue)
    {
        scintilla.FirstVisibleLine = vertScrollBar.Value;
    }

    private void OnHorScroll(int newValue, int oldValue)
    {
        scintilla.XOffset = horScrollBar.Value;
    }

    private void OnVerticalScrollChanged(ScrollInfo scrollInfo, int position)
    {
        ScrollBarAdv scroll = vertScrollBar;
        if (scroll.Minimum != scrollInfo.min) scroll.Minimum = scrollInfo.min;
        if (scroll.Maximum != scrollInfo.max) scroll.Maximum = scrollInfo.max;
        if (scroll.LargeChange != scrollInfo.nPage) scroll.LargeChange = scrollInfo.nPage;
        if (scroll.Value != position) scroll.Value = position;
        RefreshScrollBarsVisibility();
    }

    private void OnHorizontalScrollChanged(ScrollInfo scrollInfo, int position)
    {
        ScrollBarAdv scroll = horScrollBar;
        if (scroll.Minimum != scrollInfo.min) scroll.Minimum = scrollInfo.min;
        if (scroll.Maximum != scrollInfo.max) scroll.Maximum = scrollInfo.max;
        if (scroll.LargeChange != scrollInfo.nPage) scroll.LargeChange = scrollInfo.nPage;
        if (scroll.Value != position) scroll.Value = position;
        RefreshScrollBarsVisibility();
    }

    private void OnEditorContextItemPressed(EditorEventType eventType)
    {
        if (eventType == EditorEventType.OpenFileLocation && _currentFilePath != null)
            System.Diagnostics.Process.Start("explorer.exe", "/select,\"" + _currentFilePath + "\"");
    }

    private void NewMenuItem_Click(object? sender, EventArgs e)
    {
        NewFile();
    }

    private void NewFile()
    {
        if (!PromptSaveIfModified())
            return;

        scintilla.Text = "";
        _currentFilePath = null;
        scintilla.HasFilePath = false;
        _currentEncoding = Encoding.UTF8;
        _isModified = false;
        encodingLabel.Text = _currentEncoding.EncodingName;

        _styleManager.Apply("none");
        foreach (ToolStripMenuItem item in languageMenu.DropDownItems)
            item.Checked = false;
        langNone.Checked = true;

        UpdateTitle();
    }

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
            scintilla.HasFilePath = true;
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
        scintilla.HasFilePath = true;
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

    private void FindMenuItem_Click(object? sender, EventArgs e)
    {
        ShowFindUI(false);
    }

    private void GoToMenuItem_Click(object? sender, EventArgs e)
    {
        ShowGoToUI();
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
        vertScrollBar.BringToFront();
        horScrollBar.BringToFront();
        scrollBarCorner.BringToFront();
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
        using var dialog = new GoToUI(scintilla);
        dialog.Location = PointToScreen(new Point(
            scintilla.Left + (scintilla.Width - dialog.Width) / 2,
            scintilla.Top + (scintilla.Height - dialog.Height) / 2));

        SimpleOverlay.ShowFX(this);
        var result = dialog.ShowDialog(this);
        SimpleOverlay.HideFX();

        if (result == DialogResult.OK && dialog.LineNumber.HasValue)
        {
            int lineIndex = dialog.LineNumber.Value - 1;
            int pos = scintilla.Lines[lineIndex].Position;
            scintilla.SetSel(pos, pos);
            scintilla.ScrollRange(pos, pos);
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
