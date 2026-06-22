using ScintillaNET;

namespace Notepadv.LangStyles;

public class HtmlStyle : ILangStyle
{
    public string Name => "HTML";

    public void Apply(Scintilla scintilla)
    {
        scintilla.LexerName = "hypertext";

        ApplyStyles(scintilla);
    }

    private static void ApplyStyles(Scintilla scintilla)
    {
        scintilla.Styles[Style.Html.Default].ForeColor = Color.FromArgb(212, 212, 212);
        scintilla.Styles[Style.Html.Tag].ForeColor = Color.FromArgb(86, 156, 214);
        scintilla.Styles[Style.Html.TagEnd].ForeColor = Color.FromArgb(86, 156, 214);
        scintilla.Styles[Style.Html.TagUnknown].ForeColor = Color.FromArgb(86, 156, 214);
        scintilla.Styles[Style.Html.Attribute].ForeColor = Color.FromArgb(206, 145, 120);
        scintilla.Styles[Style.Html.AttributeUnknown].ForeColor = Color.FromArgb(206, 145, 120);
        scintilla.Styles[Style.Html.Number].ForeColor = Color.FromArgb(181, 206, 168);
        scintilla.Styles[Style.Html.DoubleString].ForeColor = Color.FromArgb(206, 145, 120);
        scintilla.Styles[Style.Html.SingleString].ForeColor = Color.FromArgb(206, 145, 120);
        scintilla.Styles[Style.Html.Other].ForeColor = Color.FromArgb(212, 212, 212);
        scintilla.Styles[Style.Html.Comment].ForeColor = Color.FromArgb(106, 153, 85);
        scintilla.Styles[Style.Html.Entity].ForeColor = Color.FromArgb(209, 105, 105);
        scintilla.Styles[Style.Html.Script].ForeColor = Color.FromArgb(212, 212, 212);
        scintilla.Styles[Style.Html.Asp].ForeColor = Color.FromArgb(197, 134, 192);
        scintilla.Styles[Style.Html.Value].ForeColor = Color.FromArgb(206, 145, 120);
    }
}
