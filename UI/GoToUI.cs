using ScintillaNET;

namespace Notepadv.UI;

public partial class GoToUI : Form
{
    private Scintilla _editor;
    private int? _lineNumber;
    private int _borderSize = 2;
    private Color _borderColor = Color.FromArgb(139, 70, 166);

    public int? LineNumber => _lineNumber;

    public GoToUI(Scintilla editor)
    {
        InitializeComponent();
        _editor = editor;
    }

    protected override void OnLoad(EventArgs e)
    {
        base.OnLoad(e);
        lineInput.Focus();
    }

    private void OnOkPressed(object? sender, EventArgs e)
    {
        string text = lineInput.Text.Trim();

        if (text.Length == 0 || !int.TryParse(text, out int lineNum))
        {
            lineInput.Focus();
            return;
        }

        int totalLines = _editor.Lines.Count;

        if (lineNum < 1 || lineNum > totalLines)
        {
            DialogResult = DialogResult.Cancel;
            Close();
            MsgBox.Show("Go To Line", "Line doesn't exist.", DialogButtons.OK, DialogIcon.Info);
            return;
        }

        _lineNumber = lineNum;
        DialogResult = DialogResult.OK;
        Close();
    }

    private void OnCancelPressed(object? sender, EventArgs e)
    {
        DialogResult = DialogResult.Cancel;
        Close();
    }

    private void OnInputKeyDown(object? sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.Enter)
        {
            OnOkPressed(sender, e);
            e.SuppressKeyPress = true;
        }
        else if (e.KeyCode == Keys.Escape)
        {
            OnCancelPressed(sender, e);
            e.SuppressKeyPress = true;
        }
    }

    private void OnInputKeyPress(object? sender, KeyPressEventArgs e)
    {
        if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            e.Handled = true;
    }

    protected override bool ProcessDialogKey(Keys keyData)
    {
        if (ModifierKeys == Keys.None && keyData == Keys.Escape)
        {
            DialogResult = DialogResult.Cancel;
            Close();
            return true;
        }
        return base.ProcessDialogKey(keyData);
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        if (_borderSize > 0)
        {
            e.Graphics.FillRectangle(new SolidBrush(_borderColor), ClientRectangle);
            e.Graphics.FillRectangle(new SolidBrush(BackColor),
                new Rectangle(_borderSize, _borderSize,
                              Width - _borderSize * 2, Height - _borderSize * 2));
        }
        base.OnPaint(e);
    }
}
