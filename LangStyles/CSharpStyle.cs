using ScintillaNET;

namespace Notepadv.LangStyles;

public class CSharpStyle : LangStyleBase
{
    public override string Name => "C#";

    private const string CSHARP_LANG_KEYWORDS_CONTROL_FLOW = "if else do while for foreach switch case break continue return goto try";
    private const string CSHARP_COMMON_CLASSES = "Dictionary List String Object Boolean Decimal Double Char Int16 Int32 Int64 UInt16 UInt32 UInt64";
    private const string CSHARP_COMMON_CLASSES_2 = "Console File Math DateTime Exception IO Thread";
    private const string CSHARP_LANG_KEYWORDS = "where var get set value bool byte char class const decimal double enum float int long sbyte short static string struct uint ulong ushort void abstract as base checked default delegate event explicit extern false finally fixed implicit in interface internal is lock namespace new null object operator out override params private protected public readonly ref sealed sizeof stackalloc this throw true typeof unchecked unsafe using virtual";
    private static readonly List<string> CSHARP_EXTRA_CLASSES = [];

    protected override void OnActivate()
    {
        Editor.LexerName = "cpp";
        SetFontStyle();
        Styles[Style.Default].BackColor = CColor(39, 40, 34);
        Editor.StyleClearAll();

        Styles[Style.Cpp.Identifier].ForeColor = CColor(215, 215, 215);
        Styles[Style.Cpp.Comment].ForeColor = CColor(0, 178, 45);
        Styles[Style.Cpp.CommentLine].ForeColor = CColor(0, 178, 45);
        Styles[Style.Cpp.CommentLineDoc].ForeColor = CColor(128, 128, 128);
        Styles[Style.Cpp.Number].ForeColor = CColor(166, 226, 46);
        Styles[Style.Cpp.Word].ForeColor = CColor(140, 100, 235);
        Styles[Style.Cpp.Word2].ForeColor = CColor(61, 201, 176);
        Styles[Style.Cpp.String].ForeColor = CColor(214, 157, 65);
        Styles[Style.Cpp.StringEol].ForeColor = CColor(214, 175, 90);
        Styles[Style.Cpp.Character].ForeColor = CColor(163, 21, 21);
        Styles[Style.Cpp.Verbatim].ForeColor = CColor(214, 157, 65);
        Styles[Style.Cpp.Operator].ForeColor = CColor(170, 170, 200);
        Styles[Style.Cpp.Preprocessor].ForeColor = Color.Maroon;
        Styles[19].ForeColor = CColor(200, 153, 255);

        SetInactivePreprocessor(CColor(100, 100, 100));

        Editor.SetKeywords(0, CSHARP_LANG_KEYWORDS);
        Editor.SetKeywords(3, CSHARP_LANG_KEYWORDS_CONTROL_FLOW);

        var classes = string.Join(" ", CSHARP_EXTRA_CLASSES);
        Editor.SetKeywords(1, classes + " " + CSHARP_COMMON_CLASSES + " " + CSHARP_COMMON_CLASSES_2);

        SetFoldMarginStyle();
        EnableCodeFolding();
        SetSelectionStyle();
        SetLinesNumber(true, 40);
    }
}
