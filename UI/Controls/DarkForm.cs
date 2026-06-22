using Notepadv.UI.Style;
using Notepadv.UI.VampGraphics;

namespace Notepadv.UI.Controls;

public class DarkForm : Form
{
    public Color BorderColor { get; set; } = Color.FromArgb(20, 20, 20);
    public int BorderSize { get; set; }

    public DarkForm()
    {
        BackColor = Color.FromArgb(40, 40, 40);
        FormBorderStyle = FormBorderStyle.FixedToolWindow;
        MaximizeBox = false;
        StartPosition = FormStartPosition.CenterParent;
    }

    public void ShowMe(ContainerControl? parent)
    {
        if (parent != null) SimpleOverlay.ShowFX(parent);
        ShowDialog(parent);
        if (parent != null) SimpleOverlay.HideFX();
    }

    protected override bool ProcessDialogKey(Keys keyData)
    {
        if (ModifierKeys == Keys.None && keyData == Keys.Escape)
        {
            DialogResult = DialogResult.Cancel;
            Close();
            return true;
        }
        return base.ProcessDialogKey(keyData);
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        VampirioGraphics.FillRect(e.Graphics, BackColor, BorderColor, BorderSize, ClientRectangle);
        base.OnPaint(e);
    }
}
