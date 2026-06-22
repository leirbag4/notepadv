using ScintillaNET;

namespace Notepadv.LangStyles;

public class CSharpStyle : ILangStyle
{
    public string Name => "C#";

    public void Apply(Scintilla scintilla)
    {
        scintilla.LexerName = "cpp";

        scintilla.SetKeywords(0, "abstract as base break case catch checked continue default delegate do else event explicit extern finally fixed for foreach goto if implicit in interface internal is lock namespace new object operator out override params private protected public readonly ref return sealed sizeof stackalloc switch this throw try typeof unchecked unsafe using virtual volatile while async await yield");
        scintilla.SetKeywords(1, "bool byte char class const decimal double enum float int long sbyte short static string struct uint ulong ushort void null true false var dynamic");
        scintilla.SetKeywords(2, "where select from join on equals group by order into let ascending descending");

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
        scintilla.Styles[Style.Cpp.Word2].ForeColor = Color.FromArgb(86, 156, 214);
        scintilla.Styles[Style.Cpp.String].ForeColor = Color.FromArgb(206, 145, 120);
        scintilla.Styles[Style.Cpp.Character].ForeColor = Color.FromArgb(206, 145, 120);
        scintilla.Styles[Style.Cpp.Verbatim].ForeColor = Color.FromArgb(206, 145, 120);
        scintilla.Styles[Style.Cpp.TripleVerbatim].ForeColor = Color.FromArgb(206, 145, 120);
        scintilla.Styles[Style.Cpp.Operator].ForeColor = Color.FromArgb(212, 212, 212);
        scintilla.Styles[Style.Cpp.Preprocessor].ForeColor = Color.FromArgb(155, 155, 155);
        scintilla.Styles[Style.Cpp.GlobalClass].ForeColor = Color.FromArgb(78, 201, 176);
    }
}
