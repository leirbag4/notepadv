using System.ComponentModel;
using System.Drawing.Drawing2D;
using Notepadv.UI.Controls.Events;

namespace Notepadv.UI.Controls;

public class ComboBoxAdv : ComboBox
{
    [Localizable(true)]
    [Category("Extra Properties")]
    [Description("Border Color")]
    [Browsable(true)]
    public Color BorderColor
    {
        get { return _borderColor; }
        set { _borderColor = value; Invalidate(); }
    }

    [Localizable(true)]
    [Category("Extra Properties")]
    [Description("Border Size")]
    [Browsable(true)]
    public int BorderSize
    {
        get { return _borderSize; }
        set { _borderSize = value; Invalidate(); }
    }

    [Category("Extra Events")]
    [Description("Event on ENTER key pressed")]
    [Browsable(true)]
    public event KeyPressedEventHandler EnterPressed;

    public Color ButtonColor
    {
        get { return _ButtonColor; }
        set
        {
            _ButtonColor = value;
            DropButtonBrush = new SolidBrush(this.ButtonColor);
            this.Invalidate();
        }
    }

    public delegate void KeyPressedEventHandler(Object sender, KeyPressedEventArgs e);

    public bool enableEvents = true;

    private Brush BorderBrush = new SolidBrush(SystemColors.Window);
    private Brush ArrowBrush = new SolidBrush(SystemColors.ControlText);
    private Brush DropButtonBrush = new SolidBrush(SystemColors.Control);
    private StringFormat stringFormat;

    private Color _ButtonColor = SystemColors.Control;
    private Color _borderColor = Color.FromArgb(100, 100, 100);
    private int _borderSize = 2;

    const int arrow_right_y = 15;

    public ComboBoxAdv()
    {
        stringFormat = new StringFormat();
        stringFormat.LineAlignment = StringAlignment.Center;
        BackColor = Color.FromArgb(52, 52, 52);
        ForeColor = Color.Silver;
    }

    protected override void WndProc(ref Message m)
    {
        base.WndProc(ref m);

        switch (m.Msg)
        {
            case 0xf:
                Graphics g = this.CreateGraphics();
                Pen p = new Pen(Color.White, 2);

                g.FillRectangle(new SolidBrush(_borderColor), this.ClientRectangle);
                g.FillRectangle(new SolidBrush(BackColor), new Rectangle(_borderSize, _borderSize, Width - (_borderSize * 2), Height - (_borderSize * 2)));

                Rectangle fontRect = new Rectangle(ClientRectangle.X + _borderSize + 2, ClientRectangle.Y, ClientRectangle.Width - ((_borderSize + 2) * 2) - arrow_right_y, ClientRectangle.Height);

                TextFormatFlags flags = TextFormatFlags.Left | TextFormatFlags.VerticalCenter | TextFormatFlags.EndEllipsis;
                TextRenderer.DrawText(g, Text, this.Font, fontRect, this.ForeColor, flags);

                Rectangle rect = new Rectangle(this.Width - 15, 3, 12, this.Height - 6);
                g.FillRectangle(Brushes.Gray, rect);

                GraphicsPath pth = new GraphicsPath();
                PointF TopLeft = new PointF(this.Width - 13, (this.Height - 5) / 2);
                PointF TopRight = new PointF(this.Width - 6, (this.Height - 5) / 2);
                PointF Bottom = new PointF(this.Width - 9, (this.Height + 2) / 2);
                pth.AddLine(TopLeft, TopRight);
                pth.AddLine(TopRight, Bottom);

                g.SmoothingMode = SmoothingMode.HighQuality;

                if (this.DroppedDown)
                    ArrowBrush = new SolidBrush(SystemColors.HighlightText);
                else
                    ArrowBrush = new SolidBrush(SystemColors.ControlText);

                g.FillPath(ArrowBrush, pth);

                break;
            default:
                break;
        }
    }

    protected override void OnKeyPress(KeyPressEventArgs e)
    {
        String prevTxt;

        if (e.KeyChar == (char)Keys.Enter)
        {
            prevTxt = Text;
            BeginInvoke((Action)delegate
            {
                SelectAll();
            });
            e.Handled = true;

            if (EnterPressed != null)
                EnterPressed(this, new KeyPressedEventArgs(prevTxt != Text, SelectionLength != 0));
        }
        else if (e.KeyChar == (char)Keys.Escape)
        {
            e.Handled = true;
        }

        base.OnKeyPress(e);
    }
}
