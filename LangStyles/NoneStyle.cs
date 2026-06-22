using ScintillaNET;

namespace Notepadv.LangStyles;

public class NoneStyle : LangStyleBase
{
    public override string Name => "None";

    protected override void OnActivate()
    {
        Editor.LexerName = null;

        var bg = Color.FromArgb(30, 30, 30);
        var fg = Color.FromArgb(212, 212, 212);

        Styles[Style.Default].BackColor = bg;
        Styles[Style.Default].ForeColor = fg;
        Styles[Style.Default].Font = "Consolas";
        Styles[Style.Default].Size = 10;
        Editor.StyleClearAll();

        Styles[Style.LineNumber].BackColor = Color.FromArgb(37, 37, 38);
        Styles[Style.LineNumber].ForeColor = Color.FromArgb(0x55, 0x55, 0x55);

        Editor.Margins[0].Type = MarginType.Number;
        Editor.Margins[0].Width = 45;
        Editor.Margins[0].BackColor = Color.FromArgb(37, 37, 38);
        Editor.Margins[1].Width = 0;
        Editor.Margins[2].Width = 0;

        SetSelectionStyle();
    }
}
