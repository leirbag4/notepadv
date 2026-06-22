using System.Drawing.Imaging;

namespace Notepadv.UI.VampGraphics;

public class ImageFX
{
    public static Bitmap ToGrayScale(Bitmap original)
    {
        Bitmap newBitmap = new Bitmap(original.Width, original.Height);
        Graphics g = Graphics.FromImage(newBitmap);

        ColorMatrix colorMatrix = new ColorMatrix(
           new float[][]
          {
                 new float[] {.3f, .3f, .3f, 0, 0},
                 new float[] {.59f, .59f, .59f, 0, 0},
                 new float[] {.11f, .11f, .11f, 0, 0},
                 new float[] {0, 0, 0, 1, 0},
                 new float[] {0, 0, 0, 0, 1}
          });

        ImageAttributes attributes = new ImageAttributes();
        attributes.SetColorMatrix(colorMatrix);

        g.DrawImage(original, new Rectangle(0, 0, original.Width, original.Height),
           0, 0, original.Width, original.Height, GraphicsUnit.Pixel, attributes);

        g.Dispose();
        return newBitmap;
    }

    public static Bitmap TintImage(Bitmap original, float red, float green, float blue)
    {
        Bitmap newBitmap = new Bitmap(original.Width, original.Height);
        Graphics g = Graphics.FromImage(newBitmap);

        ColorMatrix colorMatrix = new ColorMatrix(
           new float[][]
          {
                 new float[] { 1, 0, 0, 0, 0 },
                 new float[] { 0, 1, 0, 0, 0 },
                 new float[] { 0, 0, 1, 0, 0 },
                 new float[] { 0, 0, 0, 1, 0 },
                 new float[] { red, green, blue, 0, 1 }
          });

        ImageAttributes attributes = new ImageAttributes();
        attributes.SetColorMatrix(colorMatrix);

        g.DrawImage(original, new Rectangle(0, 0, original.Width, original.Height),
           0, 0, original.Width, original.Height, GraphicsUnit.Pixel, attributes);

        g.Dispose();
        return newBitmap;
    }

    public static Bitmap ColorLevelsImage(Bitmap original, float red, float green, float blue)
    {
        Bitmap newBitmap = new Bitmap(original.Width, original.Height);
        Graphics g = Graphics.FromImage(newBitmap);

        ColorMatrix colorMatrix = new ColorMatrix(
           new float[][]
          {
                 new float[] { 1 * red, 0, 0, 0, 0 },
                 new float[] { 0, 1 * green, 0, 0, 0 },
                 new float[] { 0, 0, 1 * blue, 0, 0 },
                 new float[] { 0, 0, 0, 1, 0 },
                 new float[] { 0, 0, 0, 0, 1 }
          });

        ImageAttributes attributes = new ImageAttributes();
        attributes.SetColorMatrix(colorMatrix);

        g.DrawImage(original, new Rectangle(0, 0, original.Width, original.Height),
           0, 0, original.Width, original.Height, GraphicsUnit.Pixel, attributes);

        g.Dispose();
        return newBitmap;
    }

    public static Color Tint(Color source, Color tint, float alpha)
    {
        var red = Convert.ToInt32((tint.R - source.R) * alpha + source.R);
        var blue = Convert.ToInt32((tint.B - source.B) * alpha + source.B);
        var green = Convert.ToInt32((tint.G - source.G) * alpha + source.G);
        return Color.FromArgb(255, red, green, blue);
    }

    public static void DrawWithAlpha(Graphics g, Image img, float alpha, int x, int y, int width, int height)
    {
        ColorMatrix cm = new ColorMatrix();
        cm.Matrix33 = alpha;
        ImageAttributes ia = new ImageAttributes();
        ia.SetColorMatrix(cm);
        g.DrawImage(img, new Rectangle(0, 0, width, height), 0, 0, img.Width, img.Height, GraphicsUnit.Pixel, ia);
    }
}
