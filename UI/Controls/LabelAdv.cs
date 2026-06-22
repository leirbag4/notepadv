namespace Notepadv.UI.Controls;

public class LabelAdv : Label
{
    public enum CustomStyle { NORMAL, SOLID }

    private CustomStyle _customStyle = CustomStyle.NORMAL;
    private Color _borderColor = Color.DarkGray;
    private int _borderSize = 1;
    private float _modifyScale = 1f;
    private float _modifyClampMin;
    private float _modifyClampMax;
    private string _modifyControlName = "";

    public CustomStyle CStyle { get => _customStyle; set { _customStyle = value; Invalidate(); } }
    public Color BorderColor { get => _borderColor; set { _borderColor = value; Invalidate(); } }
    public int BorderSize { get => _borderSize; set { _borderSize = value; Invalidate(); } }
    public float ModifyScale { get => _modifyScale; set => _modifyScale = value; }
    public float ModifyClampMin { get => _modifyClampMin; set => _modifyClampMin = value; }
    public float ModifyClampMax { get => _modifyClampMax; set => _modifyClampMax = value; }
    public string ModifyControlName { get => _modifyControlName; set => _modifyControlName = value; }

    public LabelAdv()
    {
        ForeColor = Color.Silver;
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        if (CStyle == CustomStyle.SOLID)
        {
            using var borderPen = new Pen(BorderColor, BorderSize);
            using var backBrush = new SolidBrush(BackColor);
            e.Graphics.FillRectangle(backBrush, ClientRectangle);
            e.Graphics.DrawRectangle(borderPen,
                ClientRectangle.X, ClientRectangle.Y,
                ClientRectangle.Width - BorderSize, ClientRectangle.Height - BorderSize);
        }
        base.OnPaint(e);
    }
}
