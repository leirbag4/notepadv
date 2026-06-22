using ScintillaNET;

namespace Notepadv.LangStyles;

public class CssStyle : LangStyleBase
{
    public override string Name => "CSS";

    protected override void OnActivate()
    {
        Editor.LexerName = "css";
        SetFontStyle();
        Styles[Style.Default].BackColor = CColor(39, 40, 34);
        Editor.StyleClearAll();

        Styles[Style.Css.Default].ForeColor = CColor(215, 215, 215);
        Styles[Style.Css.Tag].ForeColor = CColor(205, 131, 255);
        Styles[Style.Css.Class].ForeColor = CColor(220, 220, 170);
        Styles[Style.Css.PseudoClass].ForeColor = CColor(220, 220, 170);
        Styles[Style.Css.PseudoElement].ForeColor = CColor(220, 220, 170);
        Styles[Style.Css.Id].ForeColor = CColor(220, 220, 170);
        Styles[Style.Css.Operator].ForeColor = CColor(170, 170, 200);
        Styles[Style.Css.Identifier].ForeColor = CColor(162, 255, 91);
        Styles[Style.Css.Identifier2].ForeColor = CColor(162, 255, 91);
        Styles[Style.Css.Identifier3].ForeColor = CColor(162, 255, 91);
        Styles[Style.Css.Value].ForeColor = CColor(0, 255, 172);
        Styles[Style.Css.Comment].ForeColor = CColor(121, 119, 131);
        Styles[Style.Css.DoubleString].ForeColor = CColor(0, 255, 172);
        Styles[Style.Css.SingleString].ForeColor = CColor(0, 255, 172);
        Styles[Style.Css.Important].ForeColor = CColor(255, 60, 85);
        Styles[Style.Css.Directive].ForeColor = CColor(205, 131, 255);
        Styles[Style.Css.Media].ForeColor = CColor(205, 131, 255);
        Styles[Style.Css.Variable].ForeColor = CColor(220, 220, 170);
        Styles[Style.Css.Attribute].ForeColor = CColor(162, 255, 91);

        SetFoldMarginStyle();
        EnableCodeFolding();
        SetSelectionStyle();
        SetLinesNumber(true, 40);
    }
}
