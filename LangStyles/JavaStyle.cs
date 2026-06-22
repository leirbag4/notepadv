using ScintillaNET;

namespace Notepadv.LangStyles;

public class JavaStyle : ILangStyle
{
    public string Name => "Java";

    public void Apply(Scintilla scintilla)
    {
        scintilla.LexerName = "cpp";

        scintilla.SetKeywords(0, "abstract assert break case catch class continue default do else enum extends final finally for if implements import instanceof interface native new package private protected public return static strictfp super switch synchronized this throw throws transient try volatile while");
        scintilla.SetKeywords(1, "boolean byte char double float int long short void null true false var");
        scintilla.SetKeywords(2, "record sealed permits yield");

        ApplyStyles(scintilla);
    }

    private static void ApplyStyles(Scintilla scintilla)
    {
        scintilla.Styles[Style.Cpp.Default].ForeColor = Color.FromArgb(212, 212, 212);
        scintilla.Styles[Style.Cpp.Comment].ForeColor = Color.FromArgb(106, 153, 85);
        scintilla.Styles[Style.Cpp.CommentLine].ForeColor = Color.FromArgb(106, 153, 85);
        scintilla.Styles[Style.Cpp.CommentDoc].ForeColor = Color.FromArgb(106, 153, 85);
        scintilla.Styles[Style.Cpp.CommentLineDoc].ForeColor = Color.FromArgb(106, 153, 85);
        scintilla.Styles[Style.Cpp.Number].ForeColor = Color.FromArgb(181, 206, 168);
        scintilla.Styles[Style.Cpp.Word].ForeColor = Color.FromArgb(86, 156, 214);
        scintilla.Styles[Style.Cpp.Word2].ForeColor = Color.FromArgb(78, 201, 176);
        scintilla.Styles[Style.Cpp.String].ForeColor = Color.FromArgb(206, 145, 120);
        scintilla.Styles[Style.Cpp.Character].ForeColor = Color.FromArgb(206, 145, 120);
        scintilla.Styles[Style.Cpp.Verbatim].ForeColor = Color.FromArgb(206, 145, 120);
        scintilla.Styles[Style.Cpp.Operator].ForeColor = Color.FromArgb(212, 212, 212);
        scintilla.Styles[Style.Cpp.Preprocessor].ForeColor = Color.FromArgb(155, 155, 155);
        scintilla.Styles[Style.Cpp.GlobalClass].ForeColor = Color.FromArgb(78, 201, 176);
    }
}
