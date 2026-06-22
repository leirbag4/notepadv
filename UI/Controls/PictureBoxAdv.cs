using System.Drawing.Imaging;

namespace Notepadv.UI.Controls;

public class PictureBoxAdv : PictureBox
{
    public event EventHandler? ImageChanged;

    private Bitmap? _originalColorImage;
    private Bitmap? _grayscaleImage;

    public new Image? Image
    {
        get => base.Image;
        set
        {
            _originalColorImage = value as Bitmap;
            _grayscaleImage = null;
            base.Image = value;
            ImageChanged?.Invoke(this, EventArgs.Empty);
        }
    }

    public new bool Enabled
    {
        get => base.Enabled;
        set
        {
            base.Enabled = value;
            if (_originalColorImage != null)
            {
                _grayscaleImage ??= ToGrayScale(_originalColorImage);
                base.Image = value ? _originalColorImage : _grayscaleImage;
            }
        }
    }

    private static Bitmap ToGrayScale(Bitmap original)
    {
        var gray = new Bitmap(original.Width, original.Height);
        using var g = Graphics.FromImage(gray);
        var colorMatrix = new ColorMatrix(new float[][]
        {
            new[] { 0.3f, 0.3f, 0.3f, 0f, 0f },
            new[] { 0.59f, 0.59f, 0.59f, 0f, 0f },
            new[] { 0.11f, 0.11f, 0.11f, 0f, 0f },
            new[] { 0f, 0f, 0f, 1f, 0f },
            new[] { 0f, 0f, 0f, 0f, 1f }
        });
        using var attrs = new ImageAttributes();
        attrs.SetColorMatrix(colorMatrix);
        g.DrawImage(original, new Rectangle(0, 0, original.Width, original.Height),
            0, 0, original.Width, original.Height, GraphicsUnit.Pixel, attrs);
        return gray;
    }
}
