using ScintillaNET;

namespace Notepadv.LangStyles;

public class JsonStyle : LangStyleBase
{
    public override string Name => "JSON";

    protected override void OnActivate()
    {
        Editor.LexerName = "json";
        SetFontStyle();
        Styles[Style.Default].BackColor = CColor(39, 40, 34);
        Editor.StyleClearAll();

        Styles[Style.Json.Default].ForeColor = CColor(215, 215, 215);
        Styles[Style.Json.Number].ForeColor = CColor(181, 206, 168);
        Styles[Style.Json.String].ForeColor = CColor(209, 154, 102);
        Styles[Style.Json.StringEol].ForeColor = CColor(209, 154, 102);
        Styles[Style.Json.PropertyName].ForeColor = CColor(97, 175, 239);
        Styles[Style.Json.EscapeSequence].ForeColor = CColor(229, 192, 123);
        Styles[Style.Json.LineComment].ForeColor = CColor(106, 153, 85);
        Styles[Style.Json.BlockComment].ForeColor = CColor(106, 153, 85);
        Styles[Style.Json.Operator].ForeColor = CColor(174, 174, 174);
        Styles[Style.Json.Keyword].ForeColor = CColor(198, 120, 221);
        Styles[Style.Json.Error].ForeColor = CColor(255, 0, 0);

        SetFoldMarginStyle();
        SetSelectionStyle();
        SetLinesNumber(true, 40);
    }
}
