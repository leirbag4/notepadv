namespace Notepadv.UI.Controls.Events;

public class KeyPressedEventArgs : EventArgs
{
    public bool valueChanged;
    public bool highlighted;

    public KeyPressedEventArgs(bool valueChanged, bool highlighted)
    {
        this.valueChanged = valueChanged;
        this.highlighted = highlighted;
    }
}
