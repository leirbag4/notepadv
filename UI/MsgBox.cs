using Notepadv.UI.Controls;

namespace Notepadv.UI;

public enum DialogButtons
{
    AbortRetryIgnore,
    OK,
    OKCancel,
    RetryCancel,
    YesNo,
    YesNoCancel
}

public enum DialogIcon
{
    Question,
    Info,
    Warning,
    Error
}

public enum OptionResult
{
    None,
    OptionA,
    OptionB,
    OptionC
}

public partial class MsgBox : DarkForm
{
    private static ContainerControl? _mainControl;

    private DialogButtons _currButtons;
    private OptionResult _currOptionResult = OptionResult.None;
    private bool _customMode;

    private static readonly string[] _buttonsStr =
        ["Abort", "Cancel", "Ignore", "No", "OK", "Retry", "Yes"];

    private const int _abort = 0, _cancel = 1, _ignore = 2, _no = 3,
                      _ok = 4, _retry = 5, _yes = 6;

    public static void Setup(ContainerControl control)
    {
        _mainControl = control;
    }

    public MsgBox()
    {
        InitializeComponent();
    }

    private void ModuleInitialize(string title, string description, DialogButtons buttons, DialogIcon dialogIcon)
    {
        Text = title;
        descLabel.Text = description;
        _currButtons = buttons;
        DialogResult = DialogResult.Cancel;
        SetupIcon(dialogIcon);
        SetupButtons(buttons);
    }

    public static DialogResult Show(string description, DialogButtons buttons = DialogButtons.OK, DialogIcon dialogIcon = DialogIcon.Question)
    {
        return Show(null, "", description, buttons, dialogIcon);
    }

    public static DialogResult Show(ContainerControl? parent, string description, DialogButtons buttons = DialogButtons.OK, DialogIcon dialogIcon = DialogIcon.Question)
    {
        return Show(parent, "", description, buttons, dialogIcon);
    }

    public static DialogResult Show(string title, string description, DialogButtons buttons = DialogButtons.OK, DialogIcon dialogIcon = DialogIcon.Question)
    {
        return Show(_mainControl, title, description, buttons, dialogIcon);
    }

    public static DialogResult Show(ContainerControl? parent, string title, string description, DialogButtons buttons = DialogButtons.OK, DialogIcon dialogIcon = DialogIcon.Question)
    {
        var msgBox = new MsgBox();
        msgBox.ModuleInitialize(title, description, buttons, dialogIcon);
        msgBox.ShowMe(parent);
        return msgBox.DialogResult;
    }

    public static OptionResult Show(string title, string description, string optionA, DialogIcon dialogIcon = DialogIcon.Question)
    {
        return Show(_mainControl, title, description, optionA, dialogIcon);
    }

    public static OptionResult Show(ContainerControl? parent, string title, string description, string optionA, DialogIcon dialogIcon = DialogIcon.Question)
    {
        return _ShowCustom(parent, title, description, [optionA], dialogIcon);
    }

    public static OptionResult Show(string title, string description, string optionA, string optionB, DialogIcon dialogIcon = DialogIcon.Question)
    {
        return Show(_mainControl, title, description, optionA, optionB, dialogIcon);
    }

    public static OptionResult Show(ContainerControl? parent, string title, string description, string optionA, string optionB, DialogIcon dialogIcon = DialogIcon.Question)
    {
        return _ShowCustom(parent, title, description, [optionA, optionB], dialogIcon);
    }

    public static OptionResult Show(string title, string description, string optionA, string optionB, string optionC, DialogIcon dialogIcon = DialogIcon.Question)
    {
        return Show(_mainControl, title, description, optionA, optionB, optionC, dialogIcon);
    }

    public static OptionResult Show(ContainerControl? parent, string title, string description, string optionA, string optionB, string optionC, DialogIcon dialogIcon = DialogIcon.Question)
    {
        return _ShowCustom(parent, title, description, [optionA, optionB, optionC], dialogIcon);
    }

    private static OptionResult _ShowCustom(ContainerControl? parent, string title, string description, string[] buttonsText, DialogIcon dialogIcon = DialogIcon.Question)
    {
        var msgBox = new MsgBox();
        msgBox._customMode = true;

        if (buttonsText.Length == 1)
        {
            msgBox.ModuleInitialize(title, description, DialogButtons.OK, dialogIcon);
            msgBox.button0.Text = buttonsText[0]; msgBox.button0.Tag = OptionResult.OptionA;
        }
        else if (buttonsText.Length == 2)
        {
            msgBox.ModuleInitialize(title, description, DialogButtons.YesNo, dialogIcon);
            msgBox.button0.Text = buttonsText[0]; msgBox.button0.Tag = OptionResult.OptionA;
            msgBox.button2.Text = buttonsText[1]; msgBox.button2.Tag = OptionResult.OptionB;
        }
        else if (buttonsText.Length == 3)
        {
            msgBox.ModuleInitialize(title, description, DialogButtons.YesNoCancel, dialogIcon);
            msgBox.button0.Text = buttonsText[0]; msgBox.button0.Tag = OptionResult.OptionA;
            msgBox.button1.Text = buttonsText[1]; msgBox.button1.Tag = OptionResult.OptionB;
            msgBox.button2.Text = buttonsText[2]; msgBox.button2.Tag = OptionResult.OptionC;
        }

        msgBox.ShowMe(parent);
        return msgBox._currOptionResult;
    }

    public static DialogResult Error(string description)
    {
        return Error(_mainControl, description);
    }

    public static DialogResult Error(string description, Exception e)
    {
        return Error(_mainControl, description + "\n\nException: " + e.Message + "\n\nStackTrace: " + e.StackTrace);
    }

    public static DialogResult Error(ContainerControl? parent, string description)
    {
        var msgBox = new MsgBox();
        msgBox.ModuleInitialize("Error", description, DialogButtons.OK, DialogIcon.Error);
        msgBox.ShowMe(parent);
        return msgBox.DialogResult;
    }

    public static DialogResult Warning(string description)
    {
        return Warning(_mainControl, description);
    }

    public static DialogResult Warning(ContainerControl? parent, string description)
    {
        var msgBox = new MsgBox();
        msgBox.ModuleInitialize("Warning", description, DialogButtons.OK, DialogIcon.Warning);
        msgBox.ShowMe(parent);
        return msgBox.DialogResult;
    }

    private void SetupIcon(DialogIcon dialogIcon)
    {
        icon.Image = dialogIcon switch
        {
            DialogIcon.Question => Properties.Resources.dialog_question_med,
            DialogIcon.Info => Properties.Resources.dialog_info_med,
            DialogIcon.Warning => Properties.Resources.dialog_warning_info_med,
            DialogIcon.Error => Properties.Resources.dialog_error_info_med,
            _ => Properties.Resources.dialog_question_med
        };
    }

    private void SetupButtons(DialogButtons buttons)
    {
        switch (buttons)
        {
            case DialogButtons.AbortRetryIgnore: _SetButtons(DialogResult.Abort, DialogResult.Retry, DialogResult.Ignore); break;
            case DialogButtons.OK: _SetButtons(DialogResult.OK); break;
            case DialogButtons.OKCancel: _SetButtons(DialogResult.OK, DialogResult.Cancel); break;
            case DialogButtons.RetryCancel: _SetButtons(DialogResult.Retry, DialogResult.Cancel); break;
            case DialogButtons.YesNo: _SetButtons(DialogResult.Yes, DialogResult.No); break;
            case DialogButtons.YesNoCancel: _SetButtons(DialogResult.Yes, DialogResult.No, DialogResult.Cancel); break;
        }
    }

    private void _SetButtons(DialogResult btn01)
    {
        ShowButtons(button0, true);
        Assign(button0, btn01);
        button0.Select();
    }

    private void _SetButtons(DialogResult btn01, DialogResult btn02)
    {
        ShowButtons(button1, button2);
        Assign(button1, btn01);
        Assign(button2, btn02);
    }

    private void _SetButtons(DialogResult btn01, DialogResult btn02, DialogResult btn03)
    {
        ShowButtons(button0, button1, button2);
        Assign(button0, btn01);
        Assign(button1, btn02);
        Assign(button2, btn03);
    }

    private void ShowButtons(Controls.ButtonAdv butA, bool center = false)
    {
        HideButtons();
        butA.Visible = true;
        if (center)
            butA.Location = new Point((Width >> 1) - (butA.Width >> 1), butA.Location.Y);
    }

    private void ShowButtons(Controls.ButtonAdv butA, Controls.ButtonAdv butB)
    {
        HideButtons();
        butA.Visible = butB.Visible = true;
    }

    private void ShowButtons(Controls.ButtonAdv butA, Controls.ButtonAdv butB, Controls.ButtonAdv butC)
    {
        HideButtons();
        butA.Visible = butB.Visible = butC.Visible = true;
    }

    private void HideButtons()
    {
        button0.Visible = button1.Visible = button2.Visible = false;
    }

    private void Assign(Controls.ButtonAdv button, DialogResult buttonType)
    {
        button.DialogResult = buttonType;

        if (_customMode)
            button.Click += OnCustomButtonPressed;
        else
            button.Click += OnButtonPressed;

        button.Text = buttonType switch
        {
            DialogResult.Abort => _buttonsStr[_abort],
            DialogResult.Cancel => _buttonsStr[_cancel],
            DialogResult.Ignore => _buttonsStr[_ignore],
            DialogResult.No => _buttonsStr[_no],
            DialogResult.OK => _buttonsStr[_ok],
            DialogResult.Retry => _buttonsStr[_retry],
            DialogResult.Yes => _buttonsStr[_yes],
            _ => button.Text
        };
    }

    private void OnButtonPressed(object? sender, EventArgs e)
    {
        if (sender is Button btn)
            DialogResult = btn.DialogResult;
        Close();
    }

    private void OnCustomButtonPressed(object? sender, EventArgs e)
    {
        if (sender is Control ctrl && ctrl.Tag is OptionResult opt)
            _currOptionResult = opt;
        Close();
    }
}
