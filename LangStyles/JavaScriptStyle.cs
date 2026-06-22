using ScintillaNET;

namespace Notepadv.LangStyles;

public class JavaScriptStyle : LangStyleBase
{
    public override string Name => "JavaScript";

    private const string JS_VALUE_PROPERTIES = "Infinity NaN undefined null ";
    private const string JS_FUNCTION_PROPERTIES = "btoa atob eval uneval isFinite isNaN parseFloat parseInt decodeURI decodeURIComponent encodeURI encodeURIComponent ";
    private const string JS_FUNDAMENTAL_OBJECTS = "Object Function Boolean Symbol EvalError InternalError ReferenceError SyntaxError TypeError URIError ";
    private const string JS_NUMBER_AND_DATES = "Number Math Date ";
    private const string JS_COMMON_TEXT_PROCESSING = "String RegExp ";
    private const string JS_INDEXED_COLLECTIONS = "Array Int8Array Uint8Array Uint8ClampedArray Int16Array Uint16Array Int32Array Uint32Array Float32Array Float64Array ";
    private const string JS_KEYED_COLLECTIONS = "Map Set WeakMap WeakSet ";
    private const string JS_STRUCTURED_DATA = "ArrayBuffer DataView JSON ";
    private const string JS_CONTROL_ABSTRACTION_OBJECTS = "Promise Generator GeneratorFunction ";
    private const string JS_REFLECTION = "Reflect Proxy ";
    private const string JS_INTERNATIONALIZATION = "Intl Intl.Collator Intl.DateTimeFormat Intl.NumberFormat ";
    private const string JS_OTHERS = "console arguments alert";
    private const string JS_COMMON_CLASSES = JS_VALUE_PROPERTIES + JS_FUNCTION_PROPERTIES + JS_FUNDAMENTAL_OBJECTS + JS_NUMBER_AND_DATES + JS_COMMON_TEXT_PROCESSING + JS_INDEXED_COLLECTIONS + JS_KEYED_COLLECTIONS + JS_STRUCTURED_DATA + JS_CONTROL_ABSTRACTION_OBJECTS + JS_REFLECTION + JS_INTERNATIONALIZATION + JS_OTHERS;
    private const string JS_LANG_KEYWORDS = "get set constructor of async do if in for let new try var case else enum eval null this true void with await break catch class const false super throw while yield delete export import public return static switch typeof default extends finally package private continue debugger function arguments interface protected implements instanceof";
    private static readonly List<string> JS_EXTRA_CLASSES = [];

    protected override void OnActivate()
    {
        Editor.LexerName = "cpp";
        SetFontStyle();
        Styles[Style.Default].BackColor = CColor(39, 40, 34);
        Editor.StyleClearAll();

        Styles[Style.Cpp.Identifier].ForeColor = CColor(215, 215, 215);
        Styles[Style.Cpp.Comment].ForeColor = CColor(128, 233, 88);
        Styles[Style.Cpp.CommentLine].ForeColor = CColor(128, 233, 88);
        Styles[Style.Cpp.CommentLineDoc].ForeColor = CColor(128, 128, 128);
        Styles[Style.Cpp.Number].ForeColor = CColor(166, 226, 46);
        Styles[Style.Cpp.Word].ForeColor = CColor(255, 60, 85);
        Styles[Style.Cpp.Word2].ForeColor = CColor(61, 201, 176);
        Styles[Style.Cpp.String].ForeColor = CColor(86, 226, 145);
        Styles[Style.Cpp.StringEol].ForeColor = CColor(214, 175, 90);
        Styles[Style.Cpp.Character].ForeColor = CColor(109, 205, 172);
        Styles[Style.Cpp.Verbatim].ForeColor = CColor(214, 157, 65);
        Styles[Style.Cpp.Operator].ForeColor = CColor(195, 171, 243);
        Styles[Style.Cpp.Preprocessor].ForeColor = Color.Maroon;

        Editor.SetKeywords(0, JS_LANG_KEYWORDS);

        var classes = string.Join(" ", JS_EXTRA_CLASSES);
        Editor.SetKeywords(1, classes + " " + JS_COMMON_CLASSES);

        SetFoldMarginStyle();
        EnableCodeFolding();
        SetSelectionStyle();
        SetLinesNumber(true, 40);
    }
}
