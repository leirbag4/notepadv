using Notepadv.UI.Controls.Events;

namespace Notepadv.UI.Controls;

public class TextBoxAdv : TextBox
{
    private string? _excludeCharacters;
    private string? _includeOnlyCharacters;
    private bool _allowBackspace = true;
    private bool _autoEdition;
    private bool _allowTextEdition = true;
    private char _leftLeadingChar;
    private bool _autoSelect;
    public bool enableEvents = true;

    public delegate void KeyPressedEventHandler(object sender, KeyPressedEventArgs e);
    public event KeyPressedEventHandler? EnterPressed;

    public string? ExcludeCharacters { get => _excludeCharacters; set => _excludeCharacters = value; }
    public string? IncludeOnlyCharacters { get => _includeOnlyCharacters; set => _includeOnlyCharacters = value; }
    public bool AllowBackspace { get => _allowBackspace; set => _allowBackspace = value; }
    public bool AllowTextEdition { get => _allowTextEdition; set => _allowTextEdition = value; }
    public bool AutoEdition { get => _autoEdition; set => _autoEdition = value; }
    public char LeftLeadingCharacter { get => _leftLeadingChar; set => _leftLeadingChar = value; }
    public bool AutoSelect { get => _autoSelect; set => _autoSelect = value; }

    public TextBoxAdv()
    {
        BackColor = Color.FromArgb(80, 80, 80);
        ForeColor = SystemColors.ScrollBar;
        BorderStyle = BorderStyle.FixedSingle;
    }

    protected override void OnKeyPress(KeyPressEventArgs e)
    {
        if (!_allowTextEdition) { e.Handled = true; return; }
        if (!_allowBackspace && e.KeyChar == (char)Keys.Back) { e.Handled = true; return; }
        if (_excludeCharacters != null && _excludeCharacters.Contains(e.KeyChar)) { e.Handled = true; return; }
        if (_includeOnlyCharacters != null && !_includeOnlyCharacters.Contains(e.KeyChar) && !char.IsControl(e.KeyChar)) { e.Handled = true; return; }

        if (e.KeyChar == (char)Keys.Return && enableEvents)
        {
            EnterPressed?.Invoke(this, new KeyPressedEventArgs(false, false));
            e.Handled = true;
        }

        base.OnKeyPress(e);
    }

    protected override void OnClick(EventArgs e)
    {
        if (_autoEdition && _leftLeadingChar != '\0')
        {
            if (Text.Length == 1 && Text[0] == _leftLeadingChar)
                Text = "";
        }
        base.OnClick(e);
    }

    protected override void OnGotFocus(EventArgs e)
    {
        if (_autoEdition && _leftLeadingChar != '\0' && Text.Length == 1 && Text[0] == _leftLeadingChar)
            Text = "";
        base.OnGotFocus(e);
    }

    protected override void OnLostFocus(EventArgs e)
    {
        if (_autoEdition && _leftLeadingChar != '\0' && (Text.Length == 0 || Text == ""))
            Text = _leftLeadingChar.ToString();
        base.OnLostFocus(e);
    }

    protected override void OnMouseUp(MouseEventArgs e)
    {
        if (_autoSelect)
            SelectAll();
        base.OnMouseUp(e);
    }
}
