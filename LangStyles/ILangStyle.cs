using ScintillaNET;

namespace Notepadv.LangStyles;

public interface ILangStyle
{
    string Name { get; }
    void Apply(Scintilla scintilla);
}
