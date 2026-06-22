using System.Diagnostics;
using Notepadv.UI.Controls;

namespace Notepadv.UI;

public partial class AboutUI : DarkForm
{
    public AboutUI()
    {
        InitializeComponent();
    }

    protected override void OnLoad(EventArgs e)
    {
        versionLabel.Text = "version: " + SaveData.Config.Version;
        base.OnLoad(e);
    }

    private void OnClosePressed(object? sender, EventArgs e)
    {
        Close();
    }

    private void OnLinkPressed(object? sender, LinkLabelLinkClickedEventArgs e)
    {
        if (sender is LinkLabel link && link.Tag is string url)
        {
            try
            {
                Process.Start(new ProcessStartInfo { FileName = url, UseShellExecute = true });
            }
            catch
            {
                MsgBox.Show("Error", "Can't open url", DialogButtons.OK, DialogIcon.Error);
            }
        }
    }
}
