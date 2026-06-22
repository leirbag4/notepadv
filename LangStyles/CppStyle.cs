using ScintillaNET;

namespace Notepadv.LangStyles;

public class CppStyle : ILangStyle
{
    public string Name => "C++";

    public void Apply(Scintilla scintilla)
    {
        scintilla.LexerName = "cpp";

        scintilla.SetKeywords(0, "alignas alignof auto break case catch class const consteval constexpr constinit continue decltype default delete do else enum explicit export extern false for friend goto if inline mutable namespace new noexcept nullptr operator override private protected public register return signed sizeof static static_cast struct switch template this throw true try typedef typeid typename union unsigned using virtual volatile while");
        scintilla.SetKeywords(1, "int char bool float double void wchar_t short long signed char16_t char32_t int8_t int16_t int32_t int64_t uint8_t uint16_t uint32_t uint64_t size_t ptrdiff_t string vector map set list pair");

        ApplyStyles(scintilla);
    }

    private static void ApplyStyles(Scintilla scintilla)
    {
        scintilla.Styles[Style.Cpp.Default].ForeColor = Color.FromArgb(212, 212, 212);
        scintilla.Styles[Style.Cpp.Comment].ForeColor = Color.FromArgb(106, 153, 85);
        scintilla.Styles[Style.Cpp.CommentLine].ForeColor = Color.FromArgb(106, 153, 85);
        scintilla.Styles[Style.Cpp.CommentDoc].ForeColor = Color.FromArgb(106, 153, 85);
        scintilla.Styles[Style.Cpp.CommentLineDoc].ForeColor = Color.FromArgb(106, 153, 85);
        scintilla.Styles[Style.Cpp.Number].ForeColor = Color.FromArgb(181, 206, 168);
        scintilla.Styles[Style.Cpp.Word].ForeColor = Color.FromArgb(86, 156, 214);
        scintilla.Styles[Style.Cpp.Word2].ForeColor = Color.FromArgb(78, 201, 176);
        scintilla.Styles[Style.Cpp.String].ForeColor = Color.FromArgb(206, 145, 120);
        scintilla.Styles[Style.Cpp.Character].ForeColor = Color.FromArgb(206, 145, 120);
        scintilla.Styles[Style.Cpp.Operator].ForeColor = Color.FromArgb(212, 212, 212);
        scintilla.Styles[Style.Cpp.Preprocessor].ForeColor = Color.FromArgb(155, 155, 155);
        scintilla.Styles[Style.Cpp.GlobalClass].ForeColor = Color.FromArgb(78, 201, 176);
    }
}
