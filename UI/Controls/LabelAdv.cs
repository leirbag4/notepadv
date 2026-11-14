using System.ComponentModel;

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

    [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
    public CustomStyle CStyle { get => _customStyle; set { _customStyle = value; Invalidate(); } }
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
    public Color BorderColor { get => _borderColor; set { _borderColor = value; Invalidate(); } }
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
    public int BorderSize { get => _borderSize; set { _borderSize = value; Invalidate(); } }
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
    public float ModifyScale { get => _modifyScale; set => _modifyScale = value; }
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
    public float ModifyClampMin { get => _modifyClampMin; set => _modifyClampMin = value; }
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
    public float ModifyClampMax { get => _modifyClampMax; set => _modifyClampMax = value; }
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
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
