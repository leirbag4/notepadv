using ScintillaNET;

namespace Notepadv.LangStyles;

public class PythonStyle : ILangStyle
{
    public string Name => "Python";

    public void Apply(Scintilla scintilla)
    {
        scintilla.LexerName = "python";

        scintilla.SetKeywords(0, "False None True and as assert async await break class continue def del elif else except finally for from global if import in is lambda nonlocal not or pass raise return try while with yield");
        scintilla.SetKeywords(1, "abs all any bin bool bytearray bytes chr complex dict divmod enumerate eval exec filter float format frozenset getattr globals hasattr hash hex id input int isinstance issubclass iter len list locals map max memoryview min next object oct open ord pow print property range repr reversed round set setattr slice sorted staticmethod str sum super tuple type vars zip __import__");

        ApplyStyles(scintilla);
    }

    private static void ApplyStyles(Scintilla scintilla)
    {
        scintilla.Styles[Style.Python.Default].ForeColor = Color.FromArgb(212, 212, 212);
        scintilla.Styles[Style.Python.CommentLine].ForeColor = Color.FromArgb(106, 153, 85);
        scintilla.Styles[Style.Python.CommentBlock].ForeColor = Color.FromArgb(106, 153, 85);
        scintilla.Styles[Style.Python.Number].ForeColor = Color.FromArgb(181, 206, 168);
        scintilla.Styles[Style.Python.String].ForeColor = Color.FromArgb(206, 145, 120);
        scintilla.Styles[Style.Python.Character].ForeColor = Color.FromArgb(206, 145, 120);
        scintilla.Styles[Style.Python.Triple].ForeColor = Color.FromArgb(206, 145, 120);
        scintilla.Styles[Style.Python.TripleDouble].ForeColor = Color.FromArgb(206, 145, 120);
        scintilla.Styles[Style.Python.Word].ForeColor = Color.FromArgb(86, 156, 214);
        scintilla.Styles[Style.Python.Word2].ForeColor = Color.FromArgb(197, 134, 192);
        scintilla.Styles[Style.Python.ClassName].ForeColor = Color.FromArgb(78, 201, 176);
        scintilla.Styles[Style.Python.DefName].ForeColor = Color.FromArgb(220, 220, 170);
        scintilla.Styles[Style.Python.Operator].ForeColor = Color.FromArgb(212, 212, 212);
        scintilla.Styles[Style.Python.Decorator].ForeColor = Color.FromArgb(220, 220, 170);
    }
}
