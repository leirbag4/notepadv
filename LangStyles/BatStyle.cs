using ScintillaNET;

namespace Notepadv.LangStyles;

public class BatStyle : LangStyleBase
{
    public override string Name => "Batch";

    private const string KW_CONTROL =
        "if else for in do goto call exit set echo rem " +
        "shift setlocal endlocal pushd popd pause cls title color chcp verify choice timeout " +
        "defined not exist errorlevel cmdextversion";

    private const string KW_COMMANDS =
        "dir copy move del erase ren rename cd chdir md mkdir rd rmdir " +
        "type find findstr sort more attrib xcopy robocopy icacls takeown " +
        "wmic tasklist taskkill reg regedit schtasks net sc start where " +
        "tree fc comp subst vol label chkdsk defrag format convert dism sfc " +
        "bcdedit bootrec mklink assoc ftype path prompt break " +
        "powerShell msiexec logoff shutdown rundll32 regsvr32 " +
        "cscript wscript eventcreate eventtriggers wevtutil " +
        "cacls attrib cipher compact compact extract " +
        "openfiles pagefileconfig defrag vssadmin wbadmin " +
        "mountvol diskpart driverquery systeminfo ver " +
        "ipconfig ping tracert nslookup netstat nbtstat " +
        "route arp nbtstat netsh ";

    protected override void OnActivate()
    {
        Editor.LexerName = "batch";
        SetFontStyle();
        Styles[Style.Default].BackColor = CColor(39, 40, 34);
        Editor.StyleClearAll();

        Styles[Style.Batch.Default].ForeColor = CColor(215, 215, 215);
        Styles[Style.Batch.Comment].ForeColor = CColor(0, 178, 45);
        Styles[Style.Batch.Word].ForeColor = CColor(170, 60, 85);
        Styles[Style.Batch.Label].ForeColor = CColor(61, 201, 176);
        Styles[Style.Batch.Hide].ForeColor = CColor(128, 128, 128);
        Styles[Style.Batch.Command].ForeColor = CColor(61, 201, 176);
        Styles[Style.Batch.Identifier].ForeColor = CColor(215, 215, 215);
        Styles[Style.Batch.Operator].ForeColor = CColor(170, 170, 200);

        Editor.SetKeywords(0, KW_CONTROL);
        Editor.SetKeywords(1, KW_COMMANDS);

        SetFoldMarginStyle();
        SetSelectionStyle();
        SetLinesNumber(true, 40);
    }
}
