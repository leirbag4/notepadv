using ScintillaNET;

namespace Notepadv.LangStyles;

public class PhpStyle : ILangStyle
{
    public string Name => "PHP";

    public void Apply(Scintilla scintilla)
    {
        scintilla.LexerName = "phpscript";

        scintilla.SetKeywords(0, "abstract and as break callable case catch class clone const continue declare default die do echo else elseif empty enddeclare endfor endforeach endif endswitch endwhile eval exit extends final finally fn for foreach function global goto if implements include include_once instanceof insteadof interface isset list match namespace new or print private protected public readonly require require_once return static switch throw trait try unset use var while xor yield");

        ApplyStyles(scintilla);
    }

    private static void ApplyStyles(Scintilla scintilla)
    {
        scintilla.Styles[Style.PhpScript.Default].ForeColor = Color.FromArgb(212, 212, 212);
        scintilla.Styles[Style.PhpScript.Word].ForeColor = Color.FromArgb(86, 156, 214);
        scintilla.Styles[Style.PhpScript.Number].ForeColor = Color.FromArgb(181, 206, 168);
        scintilla.Styles[Style.PhpScript.Variable].ForeColor = Color.FromArgb(220, 220, 170);
        scintilla.Styles[Style.PhpScript.SimpleString].ForeColor = Color.FromArgb(206, 145, 120);
        scintilla.Styles[Style.PhpScript.HString].ForeColor = Color.FromArgb(206, 145, 120);
        scintilla.Styles[Style.PhpScript.HStringVariable].ForeColor = Color.FromArgb(220, 220, 170);
        scintilla.Styles[Style.PhpScript.Comment].ForeColor = Color.FromArgb(106, 153, 85);
        scintilla.Styles[Style.PhpScript.CommentLine].ForeColor = Color.FromArgb(106, 153, 85);
        scintilla.Styles[Style.PhpScript.Operator].ForeColor = Color.FromArgb(212, 212, 212);
        scintilla.Styles[Style.PhpScript.ComplexVariable].ForeColor = Color.FromArgb(220, 220, 170);
    }
}
