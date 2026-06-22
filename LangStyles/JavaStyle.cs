using ScintillaNET;

namespace Notepadv.LangStyles;

public class JavaStyle : LangStyleBase
{
    public override string Name => "Java";

    private const string JAVA_LANG_KEYWORDS_CONTROL_FLOW = "if else do while for continue return goto try catch finally switch case break default";
    private const string JAVA_COMMON_CLASSES = "String Integer Double Float Boolean Character Object Thread ArrayList HashMap Exception HashSet StringBuilder Arrays Collections LocalDate LocalDateTime Files File Scanner System Iterator Runnable Class IOException LinkedList Executors Optional Stream Vector List";
    private const string JAVA_COMMON_CLASSES_2 = "Math Date Calendar Random FileReader FileWriter BufferedReader BufferedWriter InputStreamReader OutputStreamWriter StringBuffer Pattern Matcher TimeZone BigDecimal BigInteger Stack Queue PriorityQueue BitSet Hashtable Properties UUID Process Runtime ProcessBuilder InetAddress URL HttpURLConnection URLConnection Socket ServerSocket DatagramSocket URI HttpClient HttpRequest HttpResponse Charset CharsetEncoder CharsetDecoder Base64 Comparator Enumeration ListIterator Comparable Cloneable Serializable ObjectInputStream ObjectOutputStream InputStream OutputStream FileInputStream FileOutputStream ByteArrayInputStream ByteArrayOutputStream DataInputStream DataOutputStream ObjectInput ObjectOutput ZipFile ZipEntry JarFile JarEntry SimpleDateFormat DateFormat DecimalFormat MessageFormat NumberFormat Locale ResourceBundle Timer";
    private const string JAVA_LANG_KEYWORDS = "int float boolean byte char short double long var void new const class private protected public static abstract final enum throw throws this assert exports extends implements import instanceof interface module native package requires strictfp super synchronized transient volatile true false null permits provides record sealed to transitive uses when with yield";
    private static readonly List<string> JAVA_EXTRA_CLASSES = [];

    protected override void OnActivate()
    {
        Editor.LexerName = "cpp";
        SetFontStyle();
        Styles[Style.Default].BackColor = CColor(39, 40, 34);
        Editor.StyleClearAll();

        Styles[Style.Cpp.Identifier].ForeColor = CColor(215, 215, 215);
        Styles[Style.Cpp.Comment].ForeColor = CColor(81, 198, 45);
        Styles[Style.Cpp.CommentLine].ForeColor = CColor(67, 198, 45);
        Styles[Style.Cpp.CommentLineDoc].ForeColor = CColor(128, 128, 128);
        Styles[Style.Cpp.Number].ForeColor = CColor(184, 121, 214);
        Styles[Style.Cpp.Word].ForeColor = CColor(115, 70, 235);
        Styles[Style.Cpp.Word2].ForeColor = CColor(0, 255, 186);
        Styles[Style.Cpp.String].ForeColor = CColor(236, 131, 255);
        Styles[Style.Cpp.StringEol].ForeColor = CColor(216, 111, 255);
        Styles[Style.Cpp.Character].ForeColor = CColor(60, 198, 135);
        Styles[Style.Cpp.Verbatim].ForeColor = CColor(214, 157, 65);
        Styles[Style.Cpp.Operator].ForeColor = CColor(170, 170, 200);
        Styles[Style.Cpp.Preprocessor].ForeColor = Color.Maroon;
        Styles[19].ForeColor = CColor(229, 0, 98);

        SetInactivePreprocessor(CColor(100, 100, 100));

        Editor.SetKeywords(0, JAVA_LANG_KEYWORDS);
        Editor.SetKeywords(3, JAVA_LANG_KEYWORDS_CONTROL_FLOW);

        var classes = string.Join(" ", JAVA_EXTRA_CLASSES);
        Editor.SetKeywords(1, classes + " " + JAVA_COMMON_CLASSES + " " + JAVA_COMMON_CLASSES_2);

        SetFoldMarginStyle();
        EnableCodeFolding();
        SetSelectionStyle();
        SetLinesNumber(true, 40);
    }
}
