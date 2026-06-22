using ScintillaNET;

namespace Notepadv.LangStyles;

public class PythonStyle : LangStyleBase
{
    public override string Name => "Python";

    private const string PYTHON_KEYWORDS = "False None True and as assert async await break class continue def del elif else except finally for from global if import in is lambda nonlocal not or pass raise return try while with yield";
    private const string PYTHON_BUILTINS = "abs all any bin bool bytearray bytes chr complex dict divmod enumerate eval exec filter float format frozenset getattr globals hasattr hash hex id input int isinstance issubclass iter len list locals map max memoryview min next object oct open ord pow print property range repr reversed round set setattr slice sorted staticmethod str sum super tuple type vars zip __import__";
    private static readonly List<string> PYTHON_EXTRA_CLASSES = [];

    protected override void OnActivate()
    {
        Editor.LexerName = "python";
        SetFontStyle();
        Styles[Style.Default].BackColor = CColor(39, 40, 34);
        Editor.StyleClearAll();

        Styles[Style.Python.Default].ForeColor = CColor(215, 215, 215);
        Styles[Style.Python.CommentLine].ForeColor = CColor(0, 178, 45);
        Styles[Style.Python.CommentBlock].ForeColor = CColor(0, 178, 45);
        Styles[Style.Python.Number].ForeColor = CColor(166, 226, 46);
        Styles[Style.Python.String].ForeColor = CColor(214, 157, 65);
        Styles[Style.Python.Character].ForeColor = CColor(214, 157, 65);
        Styles[Style.Python.Triple].ForeColor = CColor(214, 157, 65);
        Styles[Style.Python.TripleDouble].ForeColor = CColor(214, 157, 65);
        Styles[Style.Python.Word].ForeColor = CColor(140, 100, 235);
        Styles[Style.Python.Word2].ForeColor = CColor(61, 201, 176);
        Styles[Style.Python.ClassName].ForeColor = CColor(61, 201, 176);
        Styles[Style.Python.DefName].ForeColor = CColor(220, 220, 170);
        Styles[Style.Python.Operator].ForeColor = CColor(170, 170, 200);
        Styles[Style.Python.Decorator].ForeColor = CColor(220, 220, 170);

        var classes = string.Join(" ", PYTHON_EXTRA_CLASSES);
        Editor.SetKeywords(0, PYTHON_KEYWORDS);
        Editor.SetKeywords(1, classes + " " + PYTHON_BUILTINS);

        SetFoldMarginStyle();
        EnableCodeFolding();
        SetSelectionStyle();
        SetLinesNumber(true, 40);
    }
}
