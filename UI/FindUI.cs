using ScintillaNET;
using Notepadv.UI.Controls;
using Notepadv.UI.Controls.Events;

namespace Notepadv.UI;

public partial class FindUI : UserControl
{
    enum Mode { Find, FindAndReplace }

    public delegate void CloseEvent();
    public event CloseEvent? Close;

    private static List<string> _lastSearchList = [];
    private static List<string> _lastReplaceList = [];

    private string FindText { get => findInput.Text; set => findInput.Text = value; }
    private string ReplaceText { get => replaceInput.Text; set => replaceInput.Text = value; }
    private ComboBoxAdv? _lastFocusedInput;


    public bool OptionsVisible
    {
        get => optionsGBox.Visible;
        set
        {
            optionsGBox.Visible = value;
            if (optionsGBox.Visible)
                Height = _mode == Mode.Find ? SizeFindOptions : SizeFindAndReplaceOptions;
            else
                Height = _mode == Mode.Find ? SizeFind : SizeFindAndReplace;
            Invalidate();
        }
    }

    private Scintilla _editor;
    private int _borderSize = 2;
    private Color _borderColor = Color.FromArgb(139, 70, 166);
    private Mode _mode = Mode.Find;

    private const int SizeFind = 42;
    private const int SizeFindAndReplace = 78;
    private const int SizeFindOptions = 120;
    private const int SizeFindAndReplaceOptions = 156;

    public FindUI(Scintilla editor, bool replace = false)
    {
        InitializeComponent();

        _mode = replace ? Mode.FindAndReplace : Mode.Find;
        _editor = editor;

        _editor.KeyDown += OnKeyDown;
        findInput.KeyDown += OnKeyDown;
        replaceInput.KeyDown += OnKeyDown;
        closeButton.KeyDown += OnKeyDown;
        replaceAllButton.KeyDown += OnKeyDown;

        findInput.GotFocus += OnInputsGotFocus;
        replaceInput.GotFocus += OnInputsGotFocus;

        matchCaseCKBox.CheckedChanged += OnOptionCheckedChanged;
        matchWholeWordCKBox.CheckedChanged += OnOptionCheckedChanged;
        useRegexCKBox.CheckedChanged += OnOptionCheckedChanged;

        if (_mode == Mode.Find)
        {
            replaceInput.Visible = false;
            replaceAllButton.Visible = false;
            Height = 42;
        }

        OptionsVisible = false;
        FindText = _editor.SelectedText;
    }

    private void OnOptionCheckedChanged(object? sender, EventArgs e)
    {
        RestoreFocusToInput();
    }

    private void OnInputsGotFocus(object? sender, EventArgs e)
    {
        _lastFocusedInput = sender as ComboBoxAdv;
    }

    protected override void OnLoad(EventArgs e)
    {
        base.OnLoad(e);

        if (_mode == Mode.Find)
            findInput.Focus();
        else
            replaceInput.Focus();

        ResetPointer();
        Find();
    }

    public void Find()
    {
        ProcessLastList(FindText.Trim(), _lastSearchList);
        ProcessLastList(ReplaceText.Trim(), _lastReplaceList);

        int pos = FindNext(FindText);

        if (pos == -1)
        {
            _editor.SetSel(0, 0);
            pos = FindNext(FindText);

            if (pos == -1)
                MsgBox.Show("Find", "No more occurrences.", DialogButtons.OK, DialogIcon.Info);
        }
    }

    private int FindNext(string text)
    {
        StartHighlight(FindText);

        _editor.SearchFlags = GetFlags();
        _editor.TargetStart = Math.Max(_editor.CurrentPosition, _editor.AnchorPosition);
        _editor.TargetEnd = _editor.TextLength;

        var pos = _editor.SearchInTarget(text);
        if (pos >= 0)
            _editor.SetSel(_editor.TargetStart, _editor.TargetEnd);

        return pos;
    }

    private void StartHighlight(string str)
    {
        if (string.IsNullOrEmpty(str))
            return;

        _editor.IndicatorCurrent = 8;
        _editor.Indicators[8].Style = IndicatorStyle.RoundBox;
        _editor.Indicators[8].Under = false;
        _editor.Indicators[8].ForeColor = Color.FromArgb(38, 147, 255);
        _editor.Indicators[8].OutlineAlpha = 70;
        _editor.Indicators[8].Alpha = 40;

        _editor.IndicatorClearRange(0, _editor.TextLength);

        _editor.TargetStart = 0;
        _editor.TargetEnd = _editor.TextLength;
        _editor.SearchFlags = GetFlags();

        while (_editor.SearchInTarget(str) != -1)
        {
            _editor.IndicatorFillRange(_editor.TargetStart, _editor.TargetEnd - _editor.TargetStart);
            _editor.TargetStart = _editor.TargetEnd;
            _editor.TargetEnd = _editor.TextLength;
        }
    }

    private void StopHighlight()
    {
        _editor.IndicatorCurrent = 8;
        _editor.IndicatorClearRange(0, _editor.TextLength);
    }

    private void Replace()
    {
        if (FindText == "")
            return;

        ProcessLastList(FindText.Trim(), _lastSearchList);
        ProcessLastList(ReplaceText.Trim(), _lastReplaceList);

        ResetPointer();

        int pos = ReplaceNext(FindText, ReplaceText);
        if (pos == -1)
            MsgBox.Show("Find", "No more occurrences.", DialogButtons.OK, DialogIcon.Info);
        else
            Find();
    }

    private int ReplaceNext(string findText, string replaceText)
    {
        var pos = FindNext(findText);
        if (pos >= 0)
            _editor.ReplaceSelection(replaceText);
        return pos;
    }

    private void ResetPointer()
    {
        if (_editor.SelectionStart < _editor.SelectionEnd)
            _editor.SelectionEnd = _editor.SelectionStart;
        else
            _editor.SelectionStart = _editor.SelectionEnd;
    }

    private SearchFlags GetFlags()
    {
        var flags = SearchFlags.None;
        if (matchCaseCKBox.Checked) flags |= SearchFlags.MatchCase;
        if (matchWholeWordCKBox.Checked) flags |= SearchFlags.WholeWord;
        if (useRegexCKBox.Checked) flags |= SearchFlags.Regex;
        return flags;
    }

    private string ProcessLastList(string inText, List<string> list)
    {
        string toFind;

        if (inText != "")
        {
            toFind = inText;
            for (int a = 0; a < list.Count; a++)
            {
                if (list[a] == toFind)
                {
                    list.RemoveAt(a);
                    break;
                }
            }
            list.Insert(0, toFind);
        }
        else
        {
            toFind = list.Count > 0 ? list[0] : "";
        }

        if (list.Count > 12)
            list.RemoveAt(list.Count - 1);

        if (list == _lastSearchList)
        {
            findInput.Items.Clear();
            findInput.Items.AddRange(list.ToArray());
        }
        else if (list == _lastReplaceList)
        {
            replaceInput.Items.Clear();
            replaceInput.Items.AddRange(list.ToArray());
        }

        return toFind;
    }

    private void OnKeyDown(object? sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.Escape)
            Exit();
    }

    private void OnCloseButtonPressed(object? sender, EventArgs e)
    {
        Exit();
    }

    private void OnFindEnterPressed(object? sender, KeyPressedEventArgs e)
    {
        Find();
    }

    private void OnReplaceEnterPressed(object? sender, KeyPressedEventArgs e)
    {
        Replace();
    }

    private void OnReplaceAllPressed(object? sender, EventArgs e)
    {
        if (FindText == "")
            return;

        int currentPos = _editor.CurrentPosition;
        int currentAnchorPos = _editor.AnchorPosition;
        int count = 0;

        _editor.CurrentPosition = 0;
        _editor.AnchorPosition = 0;

        while (ReplaceNext(FindText, ReplaceText) >= 0)
            count++;

        _editor.CurrentPosition = currentPos;
        _editor.AnchorPosition = currentAnchorPos;

        RestoreFocusToInput();
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        if (_borderSize > 0)
        {
            using var borderBrush = new SolidBrush(_borderColor);
            using var backBrush = new SolidBrush(BackColor);
            e.Graphics.FillRectangle(borderBrush, ClientRectangle);
            e.Graphics.FillRectangle(backBrush,
                new Rectangle(_borderSize, _borderSize,
                    Width - (_borderSize * 2), Height - (_borderSize * 2)));
        }
        base.OnPaint(e);
    }

    private void RestoreFocusToInput()
    {
        if (_lastFocusedInput == findInput) findInput.Focus();
        else if (_lastFocusedInput == replaceInput) replaceInput.Focus();
    }

    private void Exit()
    {
        StopHighlight();
        _editor.SearchFlags = SearchFlags.None;

        _editor.KeyDown -= OnKeyDown;
        findInput.KeyDown -= OnKeyDown;
        replaceInput.KeyDown -= OnKeyDown;

        Close?.Invoke();
    }

    private void OnOptionsPressed(object? sender, EventArgs e)
    {
        OptionsVisible = !OptionsVisible;
        RestoreFocusToInput();
    }
}
