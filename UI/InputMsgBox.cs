using Notepadv.UI.Controls;
using Notepadv.UI.Controls.Events;

namespace Notepadv.UI;

public partial class InputMsgBox : DarkForm
{
    public static string InputText => _inputText;
    private static string _inputText = "";

    public InputMsgBox()
    {
        InitializeComponent();
    }

    private void ModuleInitialize(ContainerControl? parent, string title, string inputText, string okButtonText, string cancelButtonText, string description)
    {
        Text = title;
        inputLabel.Text = inputText;
        descLabel.Text = description;
        okButton.Text = okButtonText;
        cancelButton.Text = cancelButtonText;
    }

    public static DialogResult Show(ContainerControl? parent, string title, string inputText, string description)
    {
        return Show(parent, title, inputText, description, "OK", "Cancel");
    }

    public static DialogResult Show(ContainerControl? parent, string title, string inputText, string description, string okButtonText, string cancelButtonText)
    {
        var inputMsgBox = new InputMsgBox();
        inputMsgBox.ModuleInitialize(parent, title, inputText, okButtonText, cancelButtonText, description);
        inputMsgBox.ShowMe(parent);
        return inputMsgBox.DialogResult;
    }

    private void OnOkPressed(object? sender, EventArgs e)
    {
        DialogResult = DialogResult.OK;
        _inputText = input.Text;
        Close();
    }

    private void OnCancelPressed(object? sender, EventArgs e)
    {
        DialogResult = DialogResult.Cancel;
        _inputText = "";
        Close();
    }

    private void OnEnterPressed(object? sender, KeyPressedEventArgs e)
    {
        OnOkPressed(null, EventArgs.Empty);
    }
}
