using Notepadv.UI.Controls.Events;

namespace Notepadv.UI.Controls;

public class ComboBoxAdv : ComboBox
{
    private Color _borderColor = Color.FromArgb(100, 100, 100);
    private int _borderSize = 2;
    private Color _buttonColor = SystemColors.Control;

    public Color BorderColor { get => _borderColor; set { _borderColor = value; Invalidate(); } }
    public int BorderSize { get => _borderSize; set { _borderSize = value; Invalidate(); } }
    public Color ButtonColor { get => _buttonColor; set => _buttonColor = value; }

    public delegate void KeyPressedEventHandler(object sender, KeyPressedEventArgs e);
    public event KeyPressedEventHandler? EnterPressed;

    public ComboBoxAdv()
    {
        BackColor = Color.FromArgb(52, 52, 52);
        ForeColor = Color.Silver;
        FlatStyle = FlatStyle.Flat;
        DropDownStyle = ComboBoxStyle.DropDown;
    }

    protected override void OnKeyPress(KeyPressEventArgs e)
    {
        if (e.KeyChar == (char)Keys.Return)
        {
            EnterPressed?.Invoke(this, new KeyPressedEventArgs());
            e.Handled = true;
        }
        base.OnKeyPress(e);
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        if (BorderSize > 0)
        {
            using var borderPen = new Pen(BorderColor, BorderSize);
            e.Graphics.DrawRectangle(borderPen,
                ClientRectangle.X, ClientRectangle.Y,
                ClientRectangle.Width - BorderSize, ClientRectangle.Height - BorderSize);
        }
        base.OnPaint(e);
    }
}
