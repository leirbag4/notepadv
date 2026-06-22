using ScintillaNET;

namespace Notepadv.LangStyles;

public class HtmlStyle : LangStyleBase
{
    public override string Name => "HTML";

    protected override void OnActivate()
    {
        Editor.LexerName = "xml";
        SetFontStyle();
        Styles[Style.Default].BackColor = CColor(39, 40, 34);
        Editor.StyleClearAll();

        Styles[Style.Html.Default].ForeColor = CColor(255, 255, 255);
        Styles[Style.Html.Tag].ForeColor = CColor(205, 131, 255);
        Styles[Style.Html.TagUnknown].ForeColor = CColor(255, 255, 255);
        Styles[Style.Html.Attribute].ForeColor = CColor(162, 255, 91);
        Styles[Style.Html.AttributeUnknown].ForeColor = CColor(255, 255, 255);
        Styles[Style.Html.Number].ForeColor = CColor(255, 255, 255);
        Styles[Style.Html.DoubleString].ForeColor = CColor(0, 255, 172);
        Styles[Style.Html.SingleString].ForeColor = CColor(0, 255, 172);
        Styles[Style.Html.Other].ForeColor = CColor(255, 255, 255);
        Styles[Style.Html.Comment].ForeColor = CColor(121, 119, 131);
        Styles[Style.Html.Entity].ForeColor = CColor(255, 255, 255);
        Styles[Style.Html.TagEnd].ForeColor = CColor(205, 131, 255);
        Styles[Style.Html.XmlStart].ForeColor = CColor(255, 255, 255);
        Styles[Style.Html.XmlEnd].ForeColor = CColor(255, 255, 255);
        Styles[Style.Html.Script].ForeColor = CColor(255, 255, 255);
        Styles[Style.Html.Asp].ForeColor = CColor(255, 255, 255);
        Styles[Style.Html.AspAt].ForeColor = CColor(255, 255, 255);
        Styles[Style.Html.CData].ForeColor = CColor(255, 167, 165);
        Styles[Style.Html.Question].ForeColor = CColor(255, 255, 255);
        Styles[Style.Html.Value].ForeColor = CColor(255, 255, 255);
        Styles[Style.Html.XcComment].ForeColor = CColor(255, 255, 255);

        Styles[Style.JavaScript.Default].ForeColor = CColor(215, 215, 215);
        Styles[Style.JavaScript.Comment].ForeColor = CColor(128, 233, 88);
        Styles[Style.JavaScript.CommentLine].ForeColor = CColor(128, 233, 88);
        Styles[Style.JavaScript.Number].ForeColor = CColor(166, 226, 46);
        Styles[Style.JavaScript.Word].ForeColor = CColor(224, 226, 255);
        Styles[Style.JavaScript.Keyword].ForeColor = CColor(255, 60, 85);
        Styles[Style.JavaScript.DoubleString].ForeColor = CColor(86, 226, 145);
        Styles[Style.JavaScript.SingleString].ForeColor = CColor(86, 226, 145);
        Styles[Style.JavaScript.Symbols].ForeColor = CColor(215, 215, 215);
        Styles[Style.JavaScript.StringEol].ForeColor = Color.LightCoral;
        Styles[Style.JavaScript.Regex].ForeColor = Color.LightPink;

        const string JS_KEYWORDS = "get set constructor of async do if in for let new try var case else enum eval null this true void with await break catch class const false super throw while yield delete export import public return static switch typeof default extends finally package private continue debugger function arguments interface protected implements instanceof";
        Editor.SetKeywords(1, JS_KEYWORDS);

        Editor.Indicators[8].Style = IndicatorStyle.CompositionThick;
        Editor.Indicators[8].Under = true;
        Editor.Indicators[8].ForeColor = Color.FromArgb(38, 147, 255);
        Editor.Indicators[8].OutlineAlpha = 90;
        Editor.Indicators[8].Alpha = 40;

        Editor.UpdateUI += OnEditorUpdateUI;

        SetFoldMarginStyle();
        EnableCodeFolding();
        SetSelectionStyle();
        SetLinesNumber(true, 40);
    }

    private void OnEditorUpdateUI(object? sender, UpdateUIEventArgs e)
    {
        var scintilla = (Scintilla)sender!;
        ClearHighlight(scintilla);
        int pos = scintilla.CurrentPosition;
        int style = scintilla.GetStyleAt(pos);
        if (style == Style.Html.Tag || style == Style.Html.TagUnknown)
            HighlightMatchingTag(scintilla, pos);
    }

    private static void ClearHighlight(Scintilla scintilla)
    {
        scintilla.IndicatorCurrent = 8;
        scintilla.IndicatorClearRange(0, scintilla.TextLength);
    }

    private static void HighlightMatchingTag(Scintilla scintilla, int currentPos)
    {
        string text = scintilla.Text;
        int tagStart = text.LastIndexOf('<', currentPos);
        if (tagStart == -1) return;
        int tagEnd = text.IndexOf('>', tagStart);
        if (tagEnd == -1) return;
        string tag = text[tagStart..(tagEnd + 1)];
        bool isClosing = tag.StartsWith("</");

        if (isClosing)
        {
            string openingTag = tag.Replace("</", "<").TrimEnd('>');
            int openPos = text.LastIndexOf(openingTag, tagStart - 1);
            if (openPos == -1) return;
            string newOpen = text.Substring(openPos, openingTag.Length + 1);
            if (newOpen.Contains(' '))
                HighlightRange(scintilla, openPos, openingTag.Length);
            else
                HighlightRange(scintilla, openPos, openingTag.Length + 1);
            HighlightRange(scintilla, tagStart, tagEnd - tagStart + 1);
        }
        else
        {
            int spaceIdx = tag.IndexOf(' ');
            if (spaceIdx != -1)
            {
                string tagName = tag[1..spaceIdx];
                string closingTag = $"</{tagName}>";
                int closePos = text.IndexOf(closingTag, tagEnd);
                if (closePos == -1) return;
                HighlightRange(scintilla, tagStart, tagName.Length + 1);
                HighlightRange(scintilla, closePos, closingTag.Length);
            }
            else
            {
                string closingTag = tag.Insert(1, "/");
                int closePos = text.IndexOf(closingTag, tagEnd);
                if (closePos == -1) return;
                HighlightRange(scintilla, tagStart, tagEnd - tagStart + 1);
                HighlightRange(scintilla, closePos, closingTag.Length);
            }
        }
    }

    private static void HighlightRange(Scintilla scintilla, int start, int length)
    {
        scintilla.IndicatorCurrent = 8;
        scintilla.IndicatorFillRange(start, length);
    }
}
