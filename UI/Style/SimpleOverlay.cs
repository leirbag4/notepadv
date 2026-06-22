using System.Runtime.InteropServices;

namespace Notepadv.UI.Style;

public class SimpleOverlay : Form
{
    public static bool ENABLE = true;

    private static List<SimpleOverlay?>? OVERLAYS;

    public static void ShowFX(ContainerControl? applyTo)
    {
        if (!ENABLE)
            return;

        if (OVERLAYS == null)
            OVERLAYS = new List<SimpleOverlay?>();

        if (applyTo == null)
            OVERLAYS.Add(null);
        else
            OVERLAYS.Add(new SimpleOverlay(applyTo));
    }

    public static void HideFX()
    {
        if (OVERLAYS == null)
            return;

        if (OVERLAYS.Count <= 0)
            return;

        if (OVERLAYS[OVERLAYS.Count - 1] is SimpleOverlay overlay)
            overlay.Close();
        OVERLAYS.RemoveAt(OVERLAYS.Count - 1);
    }

    private SimpleOverlay(ContainerControl tocover)
    {
        BackColor = Color.Black;
        Opacity = 0.50;
        FormBorderStyle = FormBorderStyle.None;
        ControlBox = false;
        ShowInTaskbar = false;
        StartPosition = FormStartPosition.Manual;
        AutoScaleMode = AutoScaleMode.None;
        Location = tocover.PointToScreen(Point.Empty);
        ClientSize = tocover.ClientSize;
        tocover.LocationChanged += Cover_LocationChanged;
        tocover.ClientSizeChanged += Cover_ClientSizeChanged;
        Show(tocover);
        tocover.Focus();
        if (Environment.OSVersion.Version.Major >= 6)
        {
            int value = 1;
            DwmSetWindowAttribute(tocover.Handle, DWMWA_TRANSITIONS_FORCEDISABLED, ref value, 4);
        }
    }

    private void Cover_LocationChanged(object? sender, EventArgs e)
    {
        if (Owner != null)
            Location = Owner.PointToScreen(Point.Empty);
    }

    private void Cover_ClientSizeChanged(object? sender, EventArgs e)
    {
        if (Owner != null)
            ClientSize = Owner.ClientSize;
    }

    protected override void OnFormClosing(FormClosingEventArgs e)
    {
        if (Owner != null)
        {
            Owner.LocationChanged -= Cover_LocationChanged;
            Owner.ClientSizeChanged -= Cover_ClientSizeChanged;
            if (!Owner.IsDisposed && Environment.OSVersion.Version.Major >= 6)
            {
                int value = 1;
                DwmSetWindowAttribute(Owner.Handle, DWMWA_TRANSITIONS_FORCEDISABLED, ref value, 4);
            }
        }
        base.OnFormClosing(e);
    }

    private const int DWMWA_TRANSITIONS_FORCEDISABLED = 3;
    [DllImport("dwmapi.dll")]
    private static extern int DwmSetWindowAttribute(IntPtr hWnd, int attr, ref int value, int attrLen);
}
