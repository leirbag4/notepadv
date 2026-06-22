using ScintillaNET;

namespace Notepadv.LangStyles;

public class MarkdownStyle : ILangStyle
{
    public string Name => "Markdown";

    public void Apply(Scintilla scintilla)
    {
        scintilla.LexerName = "markdown";

        ApplyStyles(scintilla);
    }

    private static void ApplyStyles(Scintilla scintilla)
    {
        scintilla.Styles[Style.Markdown.Default].ForeColor = Color.FromArgb(212, 212, 212);
        scintilla.Styles[Style.Markdown.Header1].ForeColor = Color.FromArgb(86, 156, 214);
        scintilla.Styles[Style.Markdown.Header1].Bold = true;
        scintilla.Styles[Style.Markdown.Header2].ForeColor = Color.FromArgb(86, 156, 214);
        scintilla.Styles[Style.Markdown.Header2].Bold = true;
        scintilla.Styles[Style.Markdown.Header3].ForeColor = Color.FromArgb(86, 156, 214);
        scintilla.Styles[Style.Markdown.Header3].Bold = true;
        scintilla.Styles[Style.Markdown.Header4].ForeColor = Color.FromArgb(86, 156, 214);
        scintilla.Styles[Style.Markdown.Header5].ForeColor = Color.FromArgb(86, 156, 214);
        scintilla.Styles[Style.Markdown.Header6].ForeColor = Color.FromArgb(86, 156, 214);
        scintilla.Styles[Style.Markdown.Strong1].ForeColor = Color.FromArgb(212, 212, 212);
        scintilla.Styles[Style.Markdown.Strong1].Bold = true;
        scintilla.Styles[Style.Markdown.Strong2].ForeColor = Color.FromArgb(212, 212, 212);
        scintilla.Styles[Style.Markdown.Strong2].Bold = true;
        scintilla.Styles[Style.Markdown.Em1].ForeColor = Color.FromArgb(212, 212, 212);
        scintilla.Styles[Style.Markdown.Em2].ForeColor = Color.FromArgb(212, 212, 212);
        scintilla.Styles[Style.Markdown.Code].ForeColor = Color.FromArgb(206, 145, 120);
        scintilla.Styles[Style.Markdown.Code2].ForeColor = Color.FromArgb(206, 145, 120);
        scintilla.Styles[Style.Markdown.CodeBk].ForeColor = Color.FromArgb(206, 145, 120);
        scintilla.Styles[Style.Markdown.Link].ForeColor = Color.FromArgb(86, 156, 214);
        scintilla.Styles[Style.Markdown.BlockQuote].ForeColor = Color.FromArgb(106, 153, 85);
        scintilla.Styles[Style.Markdown.HRule].ForeColor = Color.FromArgb(155, 155, 155);
        scintilla.Styles[Style.Markdown.UListItem].ForeColor = Color.FromArgb(212, 212, 212);
        scintilla.Styles[Style.Markdown.OListItem].ForeColor = Color.FromArgb(212, 212, 212);
        scintilla.Styles[Style.Markdown.PreChar].ForeColor = Color.FromArgb(206, 145, 120);
        scintilla.Styles[Style.Markdown.Strikeout].ForeColor = Color.FromArgb(155, 155, 155);
    }
}
