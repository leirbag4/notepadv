using ScintillaNET;

namespace Notepadv.LangStyles;

public class CppStyle : LangStyleBase
{
    public override string Name => "C++";

    private const string CPP_STD_COMMON_CLASSES_STRUCTS = "string_view string vector fstream ifstream ofstream rotl rotr pair tuple map set list array deque queue stack priority_queue forward_list unordered_map unordered_set unordered_multimap unordered_multiset multimap multiset iterator function unique_ptr shared_ptr weak_ptr atomic mutex condition_variable";
    private const string CPP_CONTROL_STATEMENTS = "if else goto case break continue for do while return switch default ";
    private const string CPP_COMMONS = "malloc free cout endl cin nullptr null";
    private const string CPP_TYPES = "bool int double float short signed long void char wchar_t ";
    private const string CPP_TYPES_2 = "uint8_t int8_t uint16_t int16_t uint32_t int32_t uint64_t int64_t size_t ";
    private const string CPP_STRUCT_AND_ARR = "this class delete new using struct enum namespace ";
    private const string CPP_QUALIFIERS = "public private protected static virtual override ";
    private const string CPP_OTHERS_1 = "false true try catch inline throw ";
    private const string CPP_OTHERS_2 = "unsigned const ";
    private const string CPP_OTHERS_3 = "decltype constexpr volatile asm friend operator template mutable explicit static_cast const_cast dynamic_cast typeid typename auto register sizeof typedef union extern reinterpret_cast";
    private const string CPP_LANG_KEYWORDS = CPP_TYPES + CPP_TYPES_2 + CPP_STRUCT_AND_ARR + CPP_QUALIFIERS + CPP_OTHERS_1 + CPP_OTHERS_2 + CPP_OTHERS_3;
    private static readonly List<string> CPP_EXTRA_CLASSES = [];

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
        Styles[Style.Cpp.Word].ForeColor = CColor(170, 60, 85);
        Styles[Style.Cpp.Word2].ForeColor = CColor(61, 201, 176);
        Styles[Style.Cpp.String].ForeColor = CColor(214, 157, 65);
        Styles[Style.Cpp.StringEol].ForeColor = CColor(214, 175, 90);
        Styles[Style.Cpp.Character].ForeColor = CColor(163, 21, 21);
        Styles[Style.Cpp.Verbatim].ForeColor = CColor(214, 157, 65);
        Styles[Style.Cpp.Operator].ForeColor = CColor(170, 170, 200);
        Styles[Style.Cpp.Preprocessor].ForeColor = CColor(110, 88, 205);
        Styles[19].ForeColor = CColor(179, 153, 255);

        SetInactivePreprocessor(CColor(100, 100, 100));

        Editor.SetKeywords(0, CPP_LANG_KEYWORDS);
        Editor.SetKeywords(3, CPP_CONTROL_STATEMENTS + CPP_COMMONS);

        var classes = string.Join(" ", CPP_EXTRA_CLASSES);
        Editor.SetKeywords(1, classes + " " + CPP_STD_COMMON_CLASSES_STRUCTS);

        SetFoldMarginStyle();
        EnableCodeFolding();
        SetSelectionStyle();
        SetLinesNumber(true, 40);
    }
}
