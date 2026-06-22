using ScintillaNET;

namespace Notepadv.LangStyles;

public class MarkdownStyle : LangStyleBase
{
    public override string Name => "Markdown";

    protected override void OnActivate()
    {
        Editor.LexerName = "markdown";
        SetFontStyle();
        Styles[Style.Default].BackColor = CColor(39, 40, 34);
        Editor.StyleClearAll();

        Styles[Style.Markdown.Default].ForeColor = CColor(215, 215, 215);
        Styles[Style.Markdown.Header1].ForeColor = CColor(205, 131, 255);
        Styles[Style.Markdown.Header1].Bold = true;
        Styles[Style.Markdown.Header2].ForeColor = CColor(205, 131, 255);
        Styles[Style.Markdown.Header2].Bold = true;
        Styles[Style.Markdown.Header3].ForeColor = CColor(205, 131, 255);
        Styles[Style.Markdown.Header3].Bold = true;
        Styles[Style.Markdown.Header4].ForeColor = CColor(205, 131, 255);
        Styles[Style.Markdown.Header5].ForeColor = CColor(205, 131, 255);
        Styles[Style.Markdown.Header6].ForeColor = CColor(205, 131, 255);
        Styles[Style.Markdown.Strong1].ForeColor = CColor(215, 215, 215);
        Styles[Style.Markdown.Strong1].Bold = true;
        Styles[Style.Markdown.Strong2].ForeColor = CColor(215, 215, 215);
        Styles[Style.Markdown.Strong2].Bold = true;
        Styles[Style.Markdown.Em1].ForeColor = CColor(215, 215, 215);
        Styles[Style.Markdown.Em2].ForeColor = CColor(215, 215, 215);
        Styles[Style.Markdown.Code].ForeColor = CColor(214, 157, 65);
        Styles[Style.Markdown.Code2].ForeColor = CColor(214, 157, 65);
        Styles[Style.Markdown.CodeBk].ForeColor = CColor(214, 157, 65);
        Styles[Style.Markdown.Link].ForeColor = CColor(61, 201, 176);
        Styles[Style.Markdown.BlockQuote].ForeColor = CColor(0, 178, 45);
        Styles[Style.Markdown.HRule].ForeColor = CColor(128, 128, 128);
        Styles[Style.Markdown.UListItem].ForeColor = CColor(215, 215, 215);
        Styles[Style.Markdown.OListItem].ForeColor = CColor(215, 215, 215);
        Styles[Style.Markdown.PreChar].ForeColor = CColor(214, 157, 65);
        Styles[Style.Markdown.Strikeout].ForeColor = CColor(128, 128, 128);

        SetFoldMarginStyle();
        EnableCodeFolding();
        SetSelectionStyle();
        SetLinesNumber(true, 40);
    }
}
