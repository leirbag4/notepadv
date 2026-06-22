using System.Text.RegularExpressions;

namespace Notepadv.LangStyles;

public class LanguageDetector
{
    private readonly struct LangInfo
    {
        public readonly string Name;
        public readonly Regex[] Primary;
        public readonly Regex[] Secondary;
        public LangInfo(string name, Regex[] primary, Regex[] secondary)
        {
            Name = name;
            Primary = primary;
            Secondary = secondary;
        }
    }

    private static readonly LangInfo[] _langs;

    static LanguageDetector()
    {
        _langs =
        [
            new("c#",
            [
                new Regex(@"\busing\s+(System|Microsoft|Windows|Forms|Data|Text|IO|Collections|Linq|Net|Threading|Tasks?|Security|Drawing|Web|Configuration|Reflection|Globalization)\b", RegexOptions.Multiline),
                new Regex(@"\bConsole\.\s*(Write|Read|Log|WriteLine|ReadLine)\b", RegexOptions.Multiline),
                new Regex(@"\b(public|private|protected|internal)\s+(static\s+)?(class|struct|interface|enum|record)\s+\w+", RegexOptions.Multiline),
                new Regex(@"\b(namespace|using\s+static|async|await|yield\s+return|var\s+\w+\s*=\s*new)\b", RegexOptions.Multiline),
                new Regex(@"\b(void|int|string|bool|double|float|long|decimal|char|byte)\[\]\s+\w+\s*=\s*(new|null)\b", RegexOptions.Multiline),
            ],
            [
                new Regex(@"\b(throw|try|catch|finally)\s", RegexOptions.Multiline),
                new Regex(@"\b(Linq|var|dynamic|record|init|set|get|value|async|await)\b", RegexOptions.Multiline),
                new Regex(@"\[.*(HttpGet|HttpPost|Route|Serializable|DataContract).*\]", RegexOptions.Multiline),
            ]),
            new("c++",
            [
                new Regex(@"#\s*(include|define|ifdef|ifndef|pragma|endif|undef)\b", RegexOptions.Multiline),
                new Regex(@"\b(std::|std::\w+)\b", RegexOptions.Multiline),
                new Regex(@"\b(int\s+main|void\s+main|wmain)\s*\(", RegexOptions.Multiline),
                new Regex(@"\b(cout|cin|cerr|endl)\s*(<<|>>)", RegexOptions.Multiline),
                new Regex(@"\b(template|typename|class\s+\w+\s*[:{]|constexpr|noexcept|override|virtual)\b", RegexOptions.Multiline),
            ],
            [
                new Regex(@"\b(->|::)\s*\w+\s*\(", RegexOptions.Multiline),
                new Regex(@"\b(public|private|protected):", RegexOptions.Multiline),
                new Regex(@"\b(nullptr|NULL|true|false)\b", RegexOptions.Multiline),
                new Regex(@"\b(vector|string|map|set|list|array|unique_ptr|shared_ptr)\s*[<(]", RegexOptions.Multiline),
            ]),
            new("javascript",
            [
                new Regex(@"\b(const|let|var)\s+\w+\s*=?\s*(function|=>|require|import|export)\b", RegexOptions.Multiline),
                new Regex(@"\b(function\s+\w+\s*\(|=>\s*[{(]|async\s+function)", RegexOptions.Multiline),
                new Regex(@"\b(document|window|console|alert|prompt|fetch|axios)\b", RegexOptions.Multiline),
                new Regex(@"\b(import\s+.*\s+from|export\s+(default|const|function|class))\b", RegexOptions.Multiline),
                new Regex(@"\b(module\.exports|exports\.|require\()", RegexOptions.Multiline),
            ],
            [
                new Regex(@"\b(const|let|var)\s+\w+\s*=", RegexOptions.Multiline),
                new Regex(@"\b(null|undefined|NaN|true|false)\b", RegexOptions.Multiline),
                new Regex(@"\b(this\.|prototype\.|\.length|\.push|\.map)\b", RegexOptions.Multiline),
                new Regex(@"\b(=>|===|!==)\b", RegexOptions.Multiline),
            ]),
            new("python",
            [
                new Regex(@"\b(def\s+\w+\s*\(|class\s+\w+\s*:|async\s+def)", RegexOptions.Multiline),
                new Regex(@"\b(import\s+\w+|from\s+\w+\s+import)\b", RegexOptions.Multiline),
                new Regex(@"\b(if\s+__name__\s*==\s*[""']__main__[""']|print\s*\()", RegexOptions.Multiline),
                new Regex(@"\b(self|cls)\s*[,)]", RegexOptions.Multiline),
                new Regex(@"^\s*(import|from|def|class|if|elif|else|while|for|with|try|except|finally|raise|return|yield|lambda|pass|break|continue)\s", RegexOptions.Multiline),
            ],
            [
                new Regex(@"\b(True|False|None|self|__init__|__str__|__repr__)\b", RegexOptions.Multiline),
                new Regex(@"\b(len|range|zip|map|filter|list|dict|set|tuple|str|int|float|bool|print|input|open|type|isinstance|hasattr)\s*\(", RegexOptions.Multiline),
                new Regex(@"^\s*@\w+", RegexOptions.Multiline),
                new Regex(@"\b(with\s+\w+\s+as|except\s+\w+\s+as)\b", RegexOptions.Multiline),
            ]),
            new("java",
            [
                new Regex(@"\b(public\s+(static\s+)?void\s+main)\s*\(String", RegexOptions.Multiline),
                new Regex(@"\b(import\s+java\.|import\s+javax\.|import\s+org\.)\b", RegexOptions.Multiline),
                new Regex(@"\b(System\.(out|in|err)\.(println|print|read|write))\b", RegexOptions.Multiline),
                new Regex(@"\b(@Override|@Deprecated|@SuppressWarnings|@FunctionalInterface)\b", RegexOptions.Multiline),
                new Regex(@"\b(extends\s+\w+|implements\s+\w+\s*[,<]|throws\s+\w+)\b", RegexOptions.Multiline),
            ],
            [
                new Regex(@"\b(String\[\]|void\s+\w+\s*\(|new\s+\w+\(\))", RegexOptions.Multiline),
                new Regex(@"\b(public|private|protected)\s+\w+\s+\w+\s*\([^)]*\)\s*{", RegexOptions.Multiline),
                new Regex(@"\b(ArrayList|HashMap|HashSet|List|Map|Set|Optional|Stream|Collectors)\s*[<]", RegexOptions.Multiline),
                new Regex(@"\b(this\.|super\(|\.length|\.equals|\.toString)\b", RegexOptions.Multiline),
            ]),
            new("php",
            [
                new Regex(@"<\?php", RegexOptions.Multiline),
                new Regex(@"\$\w+\s*=", RegexOptions.Multiline),
                new Regex(@"\b(echo|print|var_dump|print_r)\s*\(?", RegexOptions.Multiline),
                new Regex(@"\b(function\s+\w+\s*\(.*\)\s*[{:]|(public|private|protected)\s+function)", RegexOptions.Multiline),
                new Regex(@"\b(use\s+(Illuminate|App|Database|namespace|trait|interface))\b", RegexOptions.Multiline),
            ],
            [
                new Regex(@"\$_?(GET|POST|SESSION|COOKIE|SERVER|REQUEST|FILES|ENV)\b", RegexOptions.Multiline),
                new Regex(@"\b(->|=>)\s*\w+\s*\(", RegexOptions.Multiline),
                new Regex(@"\b(new\s+\w+|self::|parent::|static::)\b", RegexOptions.Multiline),
                new Regex(@"\b(abstract|final|static|public|private|protected)\s+(class|function|trait|interface)", RegexOptions.Multiline),
            ]),
            new("html",
            [
                new Regex(@"<!DOCTYPE\s+html", RegexOptions.Multiline),
                new Regex(@"<(html|head|body|div|span|p|a|img|ul|ol|li|table|tr|td|th|form|input|button|script|style|link|meta|title|h[1-6])(\s|>)", RegexOptions.Multiline),
                new Regex(@"</(html|head|body|div|span|p|a|ul|ol|li|table|tr|td|th|form|script|style|h[1-6])>", RegexOptions.Multiline),
                new Regex(@"\b(href|src|class|id|style|onclick|onload|alt|title|rel|type)\s*=\s*[""']", RegexOptions.Multiline),
            ],
            [
                new Regex(@"&(amp|lt|gt|quot|nbsp|copy|reg);", RegexOptions.Multiline),
                new Regex(@"<!--.*-->", RegexOptions.Multiline),
                new Regex(@"<br\s*/?>", RegexOptions.Multiline),
                new Regex(@"\b(content|charset|viewport|utf-8|utf8)\b", RegexOptions.Multiline),
            ]),
            new("css",
            [
                new Regex(@"\.[\w-]+\s*\{|#[\w-]+\s*\{", RegexOptions.Multiline),
                new Regex(@"(color|background|margin|padding|font-size|font-family|width|height|display|position|border|text-align|overflow|opacity|z-index|flex|grid|transform|transition|animation)\s*:", RegexOptions.Multiline),
                new Regex(@"@(import|media|keyframes|font-face|supports|charset)\b", RegexOptions.Multiline),
                new Regex(@"\b(px|em|rem|vh|vw|%|!important)\b", RegexOptions.Multiline),
            ],
            [
                new Regex(@"::(before|after|placeholder|selection)", RegexOptions.Multiline),
                new Regex(@":[a-z-]+\((.*?)\)", RegexOptions.Multiline),
                new Regex(@"\b(rgb|rgba|hsl|hsla|hex|url)\s*\(", RegexOptions.Multiline),
                new Regex(@"\b(grid|flex|block|inline|absolute|relative|fixed|sticky|none|hidden)\b", RegexOptions.Multiline),
            ]),
            new("markdown",
            [
                new Regex(@"^#{1,6}\s+\w", RegexOptions.Multiline),
                new Regex(@"(\*\*|__).*?(\*\*|__)", RegexOptions.Multiline),
                new Regex(@"^[-*+]\s", RegexOptions.Multiline),
                new Regex(@"^\d+\.\s", RegexOptions.Multiline),
                new Regex(@"!?\[.*?\]\(.*?\)", RegexOptions.Multiline),
            ],
            [
                new Regex(@"^>\s", RegexOptions.Multiline),
                new Regex(@"```\w*", RegexOptions.Multiline),
                new Regex(@"^---+$", RegexOptions.Multiline),
                new Regex(@"~~.*?~~", RegexOptions.Multiline),
            ]),
        ];
    }

    public string Detect(string text)
    {
        if (string.IsNullOrWhiteSpace(text))
            return "none";

        var scores = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase);

        foreach (var lang in _langs)
        {
            int total = 0;
            foreach (var p in lang.Primary)
            {
                if (p.IsMatch(text))
                    total += 5;
            }
            foreach (var p in lang.Secondary)
            {
                if (p.IsMatch(text))
                    total += 2;
            }
            if (total > 0)
                scores[lang.Name] = total;
        }

        if (scores.Count == 0)
            return "none";

        var best = scores.MaxBy(kv => kv.Value);
        var second = scores.OrderByDescending(kv => kv.Value).Skip(1).FirstOrDefault();

        int bestScore = best.Value;

        if (bestScore >= 6 && (second.Value == 0 || bestScore >= second.Value * 2))
            return best.Key;

        return "none";
    }
}
