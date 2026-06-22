using ScintillaNET;

namespace Notepadv.LangStyles;

public abstract class LangStyleBase : ILangStyle
{
    public abstract string Name { get; }
    protected Scintilla Editor { get; private set; } = null!;
    protected StyleCollection Styles => Editor.Styles;
    protected MarkerCollection Markers => Editor.Markers;
    protected MarginCollection Margins => Editor.Margins;

    public void Apply(Scintilla scintilla)
    {
        Editor = scintilla;
        OnActivate();
    }

    protected abstract void OnActivate();

    protected Color CColor(int r, int g, int b) => Color.FromArgb(r, g, b);

    protected void SetKeywords(int set, string keywords) => Editor.SetKeywords(set, keywords);

    protected void SetFontStyle()
    {
        int fontSize = 10;
        Styles[Style.Default].Font = "Consolas";
        Styles[Style.Default].Size = fontSize;
    }

    protected void SetSelectionStyle()
    {
        Editor.SetSelectionBackColor(true, CColor(53, 46, 66));
        Editor.CaretLineBackColor = CColor(34, 33, 30);
        Editor.CaretForeColor = CColor(102, 51, 153);
        Editor.CaretWidth = 2;
        Editor.AdditionalSelectionTyping = true;
        Editor.AdditionalCaretForeColor = CColor(81, 69, 93);
        Styles[Style.BraceLight].BackColor = CColor(71, 46, 94);
        Styles[Style.BraceLight].ForeColor = CColor(170, 170, 170);
        Styles[Style.BraceBad].BackColor = CColor(80, 78, 76);
        Styles[Style.BraceBad].ForeColor = CColor(170, 170, 170);
    }

    protected void SetFoldMarginStyle()
    {
        Styles[Style.LineNumber].BackColor = CColor(28, 32, 37);
        Styles[Style.LineNumber].ForeColor = CColor(70, 60, 50);
        var col = CColor(36, 37, 34);
        Editor.SetFoldMarginColor(true, col);
        Editor.SetFoldMarginHighlightColor(true, col);
    }

    protected void EnableCodeFolding()
    {
        Editor.SetProperty("fold", "1");
        Editor.SetProperty("fold.compact", "1");
        Margins[2].Type = MarginType.Symbol;
        Margins[2].Mask = Marker.MaskFolders;
        Margins[2].Sensitive = true;
        Margins[2].Width = 16;
        var fg = Color.FromArgb(70, 70, 70);
        var bg = Color.FromArgb(28, 32, 37);
        for (int i = 25; i <= 31; i++)
        {
            Markers[i].SetForeColor(fg);
            Markers[i].SetBackColor(bg);
        }
        Markers[Marker.FolderEnd].Symbol = MarkerSymbol.Minus;
        Markers[Marker.FolderOpenMid].Symbol = MarkerSymbol.Plus;
        Markers[Marker.FolderMidTail].Symbol = MarkerSymbol.TCorner;
        Markers[Marker.FolderTail].Symbol = MarkerSymbol.LCorner;
        Markers[Marker.FolderSub].Symbol = MarkerSymbol.VLine;
        Markers[Marker.Folder].Symbol = MarkerSymbol.BoxPlus;
        Markers[Marker.FolderOpen].Symbol = MarkerSymbol.BoxMinus;
        Editor.AutomaticFold = AutomaticFold.Show | AutomaticFold.Click | AutomaticFold.Change;
    }

    protected void SetLinesNumber(bool visible, int width)
    {
        Margins[0].Width = visible ? width : 0;
    }

    protected Style PreprocessStyle(int index) => Styles[64 + index];

    protected Style PreprocessStyle(int startIndex, int index) => Styles[startIndex + index];

    protected void SetInactivePreprocessor(Color color)
    {
        int[] arr =
        [
            Style.Cpp.Identifier, Style.Cpp.Comment, Style.Cpp.CommentLine, Style.Cpp.CommentLineDoc,
            Style.Cpp.Number, Style.Cpp.Word, Style.Cpp.Word2, Style.Cpp.String, Style.Cpp.Character,
            Style.Cpp.Verbatim, Style.Cpp.StringEol, Style.Cpp.Operator, Style.Cpp.Preprocessor, 19
        ];
        foreach (int i in arr)
            PreprocessStyle(i).ForeColor = color;
    }
}
