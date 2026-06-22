using ScintillaNET;

namespace Notepadv.LangStyles;

public class CssStyle : ILangStyle
{
    public string Name => "CSS";

    public void Apply(Scintilla scintilla)
    {
        scintilla.LexerName = "css";

        ApplyStyles(scintilla);
    }

    private static void ApplyStyles(Scintilla scintilla)
    {
        scintilla.Styles[Style.Css.Default].ForeColor = Color.FromArgb(212, 212, 212);
        scintilla.Styles[Style.Css.Tag].ForeColor = Color.FromArgb(86, 156, 214);
        scintilla.Styles[Style.Css.Class].ForeColor = Color.FromArgb(220, 220, 170);
        scintilla.Styles[Style.Css.PseudoClass].ForeColor = Color.FromArgb(220, 220, 170);
        scintilla.Styles[Style.Css.Id].ForeColor = Color.FromArgb(220, 220, 170);
        scintilla.Styles[Style.Css.Operator].ForeColor = Color.FromArgb(212, 212, 212);
        scintilla.Styles[Style.Css.Identifier].ForeColor = Color.FromArgb(212, 212, 212);
        scintilla.Styles[Style.Css.Value].ForeColor = Color.FromArgb(206, 145, 120);
        scintilla.Styles[Style.Css.Comment].ForeColor = Color.FromArgb(106, 153, 85);
        scintilla.Styles[Style.Css.DoubleString].ForeColor = Color.FromArgb(206, 145, 120);
        scintilla.Styles[Style.Css.SingleString].ForeColor = Color.FromArgb(206, 145, 120);
        scintilla.Styles[Style.Css.Important].ForeColor = Color.FromArgb(197, 134, 192);
        scintilla.Styles[Style.Css.Directive].ForeColor = Color.FromArgb(197, 134, 192);
        scintilla.Styles[Style.Css.Variable].ForeColor = Color.FromArgb(220, 220, 170);
        scintilla.Styles[Style.Css.Media].ForeColor = Color.FromArgb(197, 134, 192);
        scintilla.Styles[Style.Css.Identifier2].ForeColor = Color.FromArgb(212, 212, 212);
        scintilla.Styles[Style.Css.Identifier3].ForeColor = Color.FromArgb(212, 212, 212);
    }
}
