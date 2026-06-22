namespace Notepadv.UI.VampGraphics;

public static class VampirioGraphics
{
    public static void FillRect(Graphics g, Color backColor, Color borderColor, int borderSize, Rectangle rect)
    {
        using var backBrush = new SolidBrush(backColor);
        using var borderBrush = new SolidBrush(borderColor);
        g.FillRectangle(borderBrush, rect);
        g.FillRectangle(backBrush,
            new Rectangle(rect.X + borderSize, rect.Y + borderSize,
                          rect.Width - borderSize * 2, rect.Height - borderSize * 2));
    }
}
