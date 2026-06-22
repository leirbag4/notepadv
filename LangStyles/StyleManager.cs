using ScintillaNET;

namespace Notepadv.LangStyles;

public class StyleManager
{
    private readonly Dictionary<string, ILangStyle> _styles = new();
    private ILangStyle? _current;
    private readonly Scintilla _scintilla;

    public ILangStyle? Current => _current;

    public StyleManager(Scintilla scintilla)
    {
        _scintilla = scintilla;
        Register(new NoneStyle());
        Register(new CSharpStyle());
        Register(new CppStyle());
        Register(new JavaScriptStyle());
        Register(new PythonStyle());
        Register(new JavaStyle());
        Register(new PhpStyle());
        Register(new HtmlStyle());
        Register(new CssStyle());
        Register(new MarkdownStyle());
    }

    public void Register(ILangStyle style)
    {
        _styles[style.Name.ToLowerInvariant()] = style;
    }

    public bool Apply(string name)
    {
        if (_styles.TryGetValue(name.ToLowerInvariant(), out var style))
        {
            _current = style;
            style.Apply(_scintilla);
            return true;
        }
        return false;
    }

    public IEnumerable<string> GetNames()
    {
        return _styles.Keys;
    }
}
