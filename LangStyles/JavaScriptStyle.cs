using ScintillaNET;

namespace Notepadv.LangStyles;

public class JavaScriptStyle : ILangStyle
{
    public string Name => "JavaScript";

    public void Apply(Scintilla scintilla)
    {
        scintilla.LexerName = "javascript";

        scintilla.SetKeywords(0, "async await break case catch class const continue debugger default delete do else export extends finally for function if import in instanceof let new of return static super switch this throw try typeof var void while with yield");
        scintilla.SetKeywords(1, "null undefined true false NaN Infinity");

        ApplyStyles(scintilla);
    }

    private static void ApplyStyles(Scintilla scintilla)
    {
        var baseIdx = Style.JavaScript.Start;

        scintilla.Styles[baseIdx + Style.JavaScript.Default].ForeColor = Color.FromArgb(212, 212, 212);
        scintilla.Styles[baseIdx + Style.JavaScript.Comment].ForeColor = Color.FromArgb(106, 153, 85);
        scintilla.Styles[baseIdx + Style.JavaScript.CommentLine].ForeColor = Color.FromArgb(106, 153, 85);
        scintilla.Styles[baseIdx + Style.JavaScript.CommentDoc].ForeColor = Color.FromArgb(106, 153, 85);
        scintilla.Styles[baseIdx + Style.JavaScript.Number].ForeColor = Color.FromArgb(181, 206, 168);
        scintilla.Styles[baseIdx + Style.JavaScript.Word].ForeColor = Color.FromArgb(86, 156, 214);
        scintilla.Styles[baseIdx + Style.JavaScript.Keyword].ForeColor = Color.FromArgb(197, 134, 192);
        scintilla.Styles[baseIdx + Style.JavaScript.DoubleString].ForeColor = Color.FromArgb(206, 145, 120);
        scintilla.Styles[baseIdx + Style.JavaScript.SingleString].ForeColor = Color.FromArgb(206, 145, 120);
        scintilla.Styles[baseIdx + Style.JavaScript.Symbols].ForeColor = Color.FromArgb(212, 212, 212);
        scintilla.Styles[baseIdx + Style.JavaScript.Regex].ForeColor = Color.FromArgb(214, 157, 133);
    }
}
