using ScintillaNET;

namespace Notepadv.LangStyles;

public class NoneStyle : ILangStyle
{
    public string Name => "None";

    public void Apply(Scintilla scintilla)
    {
        scintilla.LexerName = null;
        scintilla.StyleClearAll();
    }
}
