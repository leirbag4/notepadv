using ScintillaNET;

namespace Notepadv.UI;

public partial class GoToUI : UserControl
{
    public delegate void CloseEvent();
    public event CloseEvent? Close;

    private Scintilla _editor;
    private int _borderSize = 2;
    private Color _borderColor = Color.FromArgb(139, 70, 166);

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
        if (int.TryParse(lineInput.Text.Trim(), out int lineNum))
        {
            int totalLines = _editor.Lines.Count;

            if (lineNum >= 1 && lineNum <= totalLines)
            {
                int lineIndex = lineNum - 1;
                int pos = _editor.Lines[lineIndex].Position;
                _editor.SetSel(pos, pos);
                _editor.ScrollRange(pos, pos);
                Exit();
            }
            else
            {
                Exit();
                MsgBox.Show("Go To Line", "Line doesn't exist.", DialogButtons.OK, DialogIcon.Info);
            }
        }
        else
        {
            lineInput.Focus();
        }
    }

    private void OnCancelPressed(object? sender, EventArgs e)
    {
        Exit();
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
            Exit();
            e.SuppressKeyPress = true;
        }
    }

    private void Exit()
    {
        if (Close != null)
            Close();
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
