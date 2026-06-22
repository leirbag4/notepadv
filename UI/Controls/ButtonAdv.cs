namespace Notepadv.UI.Controls;

public class ButtonAdv : Button
{
    public enum CustomStyle { NORMAL, SOLID, SOLID_NO_BORDERS }

    private CustomStyle _customStyle = CustomStyle.NORMAL;
    private Color _borderColor = Color.FromArgb(25, 25, 25);
    private int _borderSize = 2;
    private Color _selectedColor = Color.FromArgb(0, 122, 204);
    private bool _selected;
    private Color _focusColor = Color.FromArgb(24, 81, 115);
    private bool _focusEnabled = true;
    private bool _paintImageOnSelected = true;
    private string _extraText = "";
    private ContentAlignment _extraTextAlign = ContentAlignment.MiddleCenter;
    private Point _extraTextOffset;
    private Font? _extraTextFont;
    private Color _extraTextColor = Color.Black;
    private Point _resizeImage;
    private bool _expandImage;
    private bool _processEnterKey = true;

    public CustomStyle CStyle { get => _customStyle; set { _customStyle = value; Invalidate(); } }
    public Color BorderColor { get => _borderColor; set { _borderColor = value; Invalidate(); } }
    public int BorderSize { get => _borderSize; set { _borderSize = value; Invalidate(); } }
    public Color SelectedColor { get => _selectedColor; set => _selectedColor = value; }
    public bool Selected { get => _selected; set { _selected = value; Invalidate(); } }
    public Color FocusColor { get => _focusColor; set => _focusColor = value; }
    public bool FocusEnabled { get => _focusEnabled; set => _focusEnabled = value; }
    public bool PaintImageOnSelected { get => _paintImageOnSelected; set => _paintImageOnSelected = value; }
    public string extraText { get => _extraText; set { _extraText = value; Invalidate(); } }
    public ContentAlignment extraTextAlign { get => _extraTextAlign; set { _extraTextAlign = value; Invalidate(); } }
    public Point extraTextOffset { get => _extraTextOffset; set { _extraTextOffset = value; Invalidate(); } }
    public Font? extraTextFont { get => _extraTextFont; set { _extraTextFont = value; Invalidate(); } }
    public Color extraTextColor { get => _extraTextColor; set { _extraTextColor = value; Invalidate(); } }
    public Point resizeImage { get => _resizeImage; set => _resizeImage = value; }
    public bool expandImage { get => _expandImage; set => _expandImage = value; }
    public bool processEnterKey { get => _processEnterKey; set => _processEnterKey = value; }

    public ButtonAdv()
    {
        BackColor = Color.FromArgb(30, 30, 30);
        ForeColor = Color.FromArgb(224, 224, 224);
        UseVisualStyleBackColor = false;
        FlatStyle = FlatStyle.Flat;
        FlatAppearance.BorderSize = 0;
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        var g = e.Graphics;
        var rect = ClientRectangle;
        var back = Selected ? SelectedColor : BackColor;

        if (CStyle == CustomStyle.SOLID)
        {
            using var borderPen = new Pen(BorderColor, BorderSize);
            using var backBrush = new SolidBrush(back);
            g.FillRectangle(backBrush, rect);
            g.DrawRectangle(borderPen,
                rect.X + BorderSize / 2, rect.Y + BorderSize / 2,
                rect.Width - BorderSize, rect.Height - BorderSize);
        }
        else if (CStyle == CustomStyle.SOLID_NO_BORDERS)
        {
            using var backBrush = new SolidBrush(back);
            g.FillRectangle(backBrush, rect);
        }
        else
        {
            using var backBrush = new SolidBrush(back);
            g.FillRectangle(backBrush, rect);
        }

        TextRenderer.DrawText(g, Text, Font, rect, ForeColor,
            TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter | TextFormatFlags.SingleLine);

        if (_extraText.Length > 0)
        {
            var extraFont = _extraTextFont ?? Font;
            TextRenderer.DrawText(g, _extraText, extraFont,
                new Rectangle(rect.Location + (Size)_extraTextOffset, rect.Size),
                _extraTextColor, _extraTextAlign.ToTextFormatFlags());
        }

        if (_focusEnabled && Focused)
        {
            using var focusPen = new Pen(_focusColor, 2);
            g.DrawRectangle(focusPen, rect.X + 1, rect.Y + 1, rect.Width - 3, rect.Height - 3);
        }
    }
}

internal static class ContentAlignmentExtensions
{
    public static TextFormatFlags ToTextFormatFlags(this ContentAlignment alignment)
    {
        var flags = TextFormatFlags.Default;
        if (alignment.HasFlag(ContentAlignment.TopLeft)) flags |= TextFormatFlags.Top | TextFormatFlags.Left;
        else if (alignment.HasFlag(ContentAlignment.TopCenter)) flags |= TextFormatFlags.Top | TextFormatFlags.HorizontalCenter;
        else if (alignment.HasFlag(ContentAlignment.TopRight)) flags |= TextFormatFlags.Top | TextFormatFlags.Right;
        else if (alignment.HasFlag(ContentAlignment.MiddleLeft)) flags |= TextFormatFlags.VerticalCenter | TextFormatFlags.Left;
        else if (alignment.HasFlag(ContentAlignment.MiddleCenter)) flags |= TextFormatFlags.VerticalCenter | TextFormatFlags.HorizontalCenter;
        else if (alignment.HasFlag(ContentAlignment.MiddleRight)) flags |= TextFormatFlags.VerticalCenter | TextFormatFlags.Right;
        else if (alignment.HasFlag(ContentAlignment.BottomLeft)) flags |= TextFormatFlags.Bottom | TextFormatFlags.Left;
        else if (alignment.HasFlag(ContentAlignment.BottomCenter)) flags |= TextFormatFlags.Bottom | TextFormatFlags.HorizontalCenter;
        else if (alignment.HasFlag(ContentAlignment.BottomRight)) flags |= TextFormatFlags.Bottom | TextFormatFlags.Right;
        return flags;
    }
}
