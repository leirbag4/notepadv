namespace Notepadv.UI.Controls;

public class GroupBoxAdv : GroupBox
{
    public enum CustomStyle { NORMAL, SOLID, SOLID_NO_BORDERS }

    private CustomStyle _customStyle = CustomStyle.NORMAL;
    private Color _borderColor = Color.DarkGray;
    private int _borderSize = 2;

    public CustomStyle CStyle { get => _customStyle; set { _customStyle = value; Invalidate(); } }
    public Color BorderColor { get => _borderColor; set { _borderColor = value; Invalidate(); } }
    public int BorderSize { get => _borderSize; set { _borderSize = value; Invalidate(); } }

    public GroupBoxAdv()
    {
        BackColor = Color.FromArgb(52, 52, 52);
        ForeColor = Color.Silver;
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        if (CStyle == CustomStyle.SOLID)
        {
            var rect = ClientRectangle;
            using var backBrush = new SolidBrush(BackColor);
            using var borderPen = new Pen(BorderColor, BorderSize);
            e.Graphics.FillRectangle(backBrush, rect);
            e.Graphics.DrawRectangle(borderPen, rect.X, rect.Y, rect.Width - BorderSize, rect.Height - BorderSize);

            if (Text.Length > 0)
            {
                TextRenderer.DrawText(e.Graphics, Text, Font,
                    new Point(rect.X + 8, rect.Y + 4), ForeColor);
            }
        }
        else if (CStyle == CustomStyle.SOLID_NO_BORDERS)
        {
            using var backBrush = new SolidBrush(BackColor);
            e.Graphics.FillRectangle(backBrush, ClientRectangle);
        }
        else
        {
            base.OnPaint(e);
        }
    }
}
