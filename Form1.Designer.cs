namespace Notepadv;

partial class Form1
{
    private System.ComponentModel.IContainer components = null;
    private MenuStrip menuStrip;
    private ToolStripMenuItem fileMenu;
    private ToolStripMenuItem newMenuItem;
    private ToolStripMenuItem openMenuItem;
    private ToolStripMenuItem saveMenuItem;
    private ToolStripMenuItem saveAsMenuItem;
    private ToolStripSeparator fileSep1;
    private ToolStripMenuItem toolStripMenuItem1;
    private ToolStripMenuItem helpMenu;
    private ToolStripMenuItem aboutMenuItem;
    private ToolStripMenuItem editMenu;
    private ToolStripMenuItem undoMenuItem;
    private ToolStripMenuItem redoMenuItem;
    private ToolStripSeparator editSep0;
    private ToolStripMenuItem copyMenuItem;
    private ToolStripMenuItem cutMenuItem;
    private ToolStripMenuItem pasteMenuItem;
    private ToolStripSeparator editSep1;
    private ToolStripMenuItem findMenuItem;
    private ToolStripMenuItem goToMenuItem;
    private ToolStripMenuItem viewMenu;
    private ToolStripMenuItem resetZoomMenuItem;
    private ToolStripMenuItem languageMenu;
    private ToolStripMenuItem langNone;
    private ToolStripMenuItem langCSharp;
    private ToolStripMenuItem langCpp;
    private ToolStripMenuItem langJavaScript;
    private ToolStripMenuItem langPython;
    private ToolStripMenuItem langJava;
    private ToolStripMenuItem langPhp;
    private ToolStripMenuItem langHtml;
    private ToolStripMenuItem langCss;
    private ToolStripMenuItem langBatch;
    private ToolStripMenuItem langMarkdown;
    private StatusStrip statusStrip;
    private ToolStripStatusLabel encodingLabel;
    private ToolStripStatusLabel lineColLabel;
    private Notepadv.VampEditor.VampirioEditor scintilla;

    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
        components = new System.ComponentModel.Container();
        menuStrip = new MenuStrip();
        fileMenu = new ToolStripMenuItem();
        newMenuItem = new ToolStripMenuItem();
        openMenuItem = new ToolStripMenuItem();
        saveMenuItem = new ToolStripMenuItem();
        saveAsMenuItem = new ToolStripMenuItem();
        fileSep1 = new ToolStripSeparator();
        toolStripMenuItem1 = new ToolStripMenuItem();
        helpMenu = new ToolStripMenuItem();
        aboutMenuItem = new ToolStripMenuItem();
        editMenu = new ToolStripMenuItem();
        undoMenuItem = new ToolStripMenuItem();
        redoMenuItem = new ToolStripMenuItem();
        editSep0 = new ToolStripSeparator();
        copyMenuItem = new ToolStripMenuItem();
        cutMenuItem = new ToolStripMenuItem();
        pasteMenuItem = new ToolStripMenuItem();
        editSep1 = new ToolStripSeparator();
        findMenuItem = new ToolStripMenuItem();
        goToMenuItem = new ToolStripMenuItem();
        viewMenu = new ToolStripMenuItem();
        resetZoomMenuItem = new ToolStripMenuItem();
        languageMenu = new ToolStripMenuItem();
        langNone = new ToolStripMenuItem();
        langCSharp = new ToolStripMenuItem();
        langCpp = new ToolStripMenuItem();
        langJavaScript = new ToolStripMenuItem();
        langPython = new ToolStripMenuItem();
        langJava = new ToolStripMenuItem();
        langPhp = new ToolStripMenuItem();
        langHtml = new ToolStripMenuItem();
        langCss = new ToolStripMenuItem();
        langBatch = new ToolStripMenuItem();
        langMarkdown = new ToolStripMenuItem();
        statusStrip = new StatusStrip();
        encodingLabel = new ToolStripStatusLabel();
        lineColLabel = new ToolStripStatusLabel();
        scintilla = new Notepadv.VampEditor.VampirioEditor();

        menuStrip.SuspendLayout();
        statusStrip.SuspendLayout();
        SuspendLayout();

        // menuStrip
        menuStrip.Items.AddRange(new ToolStripItem[] { fileMenu, editMenu, viewMenu, languageMenu, helpMenu });
        menuStrip.Location = new System.Drawing.Point(0, 0);
        menuStrip.Name = "menuStrip";
        menuStrip.Size = new System.Drawing.Size(984, 24);
        menuStrip.TabIndex = 0;
        menuStrip.Text = "menuStrip";
        menuStrip.BackColor = System.Drawing.Color.FromArgb(45, 45, 45);
        menuStrip.ForeColor = System.Drawing.Color.FromArgb(212, 212, 212);
        menuStrip.Padding = new System.Windows.Forms.Padding(0, 0, 0, 2);
        menuStrip.Renderer = new NotepadvRenderer();

        // fileMenu
        fileMenu.Text = "File";
        fileMenu.DropDownItems.AddRange(new ToolStripItem[] {
            newMenuItem, openMenuItem, saveMenuItem, saveAsMenuItem, fileSep1, toolStripMenuItem1
        });
        fileMenu.ForeColor = System.Drawing.Color.FromArgb(212, 212, 212);

        // newMenuItem
        newMenuItem.Text = "New";
        newMenuItem.ShortcutKeys = Keys.Control | Keys.N;
        newMenuItem.Click += NewMenuItem_Click;
        newMenuItem.BackColor = System.Drawing.Color.FromArgb(45, 45, 45);
        newMenuItem.ForeColor = System.Drawing.Color.FromArgb(212, 212, 212);

        // openMenuItem
        openMenuItem.Text = "Open";
        openMenuItem.ShortcutKeys = Keys.Control | Keys.O;
        openMenuItem.Click += OpenMenuItem_Click;
        openMenuItem.BackColor = System.Drawing.Color.FromArgb(45, 45, 45);
        openMenuItem.ForeColor = System.Drawing.Color.FromArgb(212, 212, 212);

        // saveMenuItem
        saveMenuItem.Text = "Save";
        saveMenuItem.ShortcutKeys = Keys.Control | Keys.S;
        saveMenuItem.Click += SaveMenuItem_Click;
        saveMenuItem.BackColor = System.Drawing.Color.FromArgb(45, 45, 45);
        saveMenuItem.ForeColor = System.Drawing.Color.FromArgb(212, 212, 212);

        // saveAsMenuItem
        saveAsMenuItem.Text = "Save As...";
        saveAsMenuItem.ShortcutKeys = Keys.Control | Keys.Shift | Keys.S;
        saveAsMenuItem.Click += SaveAsMenuItem_Click;
        saveAsMenuItem.BackColor = System.Drawing.Color.FromArgb(45, 45, 45);
        saveAsMenuItem.ForeColor = System.Drawing.Color.FromArgb(212, 212, 212);

        // fileSep1
        fileSep1.ForeColor = System.Drawing.Color.FromArgb(212, 212, 212);

        // toolStripMenuItem1 (Exit)
        toolStripMenuItem1.Text = "Exit";
        toolStripMenuItem1.Click += ExitMenuItem_Click;
        toolStripMenuItem1.BackColor = System.Drawing.Color.FromArgb(45, 45, 45);
        toolStripMenuItem1.ForeColor = System.Drawing.Color.FromArgb(212, 212, 212);

        // helpMenu
        helpMenu.Text = "Help";
        helpMenu.DropDownItems.AddRange(new ToolStripItem[] {
            aboutMenuItem
        });
        helpMenu.ForeColor = System.Drawing.Color.FromArgb(212, 212, 212);

        // aboutMenuItem
        aboutMenuItem.Text = "About";
        aboutMenuItem.Click += AboutMenuItem_Click;
        aboutMenuItem.BackColor = System.Drawing.Color.FromArgb(45, 45, 45);
        aboutMenuItem.ForeColor = System.Drawing.Color.FromArgb(212, 212, 212);

        // editMenu
        editMenu.Text = "Edit";
        editMenu.DropDownItems.AddRange(new ToolStripItem[] {
            undoMenuItem, redoMenuItem, editSep0, copyMenuItem, cutMenuItem, pasteMenuItem, editSep1, findMenuItem, goToMenuItem
        });
        editMenu.ForeColor = System.Drawing.Color.FromArgb(212, 212, 212);

        // undoMenuItem
        undoMenuItem.Text = "Undo";
        undoMenuItem.ShortcutKeys = Keys.Control | Keys.Z;
        undoMenuItem.Click += UndoMenuItem_Click;
        undoMenuItem.BackColor = System.Drawing.Color.FromArgb(45, 45, 45);
        undoMenuItem.ForeColor = System.Drawing.Color.FromArgb(212, 212, 212);

        // redoMenuItem
        redoMenuItem.Text = "Redo";
        redoMenuItem.ShortcutKeys = Keys.Control | Keys.Shift | Keys.Z;
        redoMenuItem.Click += RedoMenuItem_Click;
        redoMenuItem.BackColor = System.Drawing.Color.FromArgb(45, 45, 45);
        redoMenuItem.ForeColor = System.Drawing.Color.FromArgb(212, 212, 212);

        // editSep0
        editSep0.BackColor = System.Drawing.Color.FromArgb(45, 45, 45);
        editSep0.ForeColor = System.Drawing.Color.FromArgb(45, 45, 45);

        // copyMenuItem
        copyMenuItem.Text = "Copy";
        copyMenuItem.ShortcutKeys = Keys.Control | Keys.C;
        copyMenuItem.Click += CopyMenuItem_Click;
        copyMenuItem.BackColor = System.Drawing.Color.FromArgb(45, 45, 45);
        copyMenuItem.ForeColor = System.Drawing.Color.FromArgb(212, 212, 212);

        // cutMenuItem
        cutMenuItem.Text = "Cut";
        cutMenuItem.ShortcutKeys = Keys.Control | Keys.X;
        cutMenuItem.Click += CutMenuItem_Click;
        cutMenuItem.BackColor = System.Drawing.Color.FromArgb(45, 45, 45);
        cutMenuItem.ForeColor = System.Drawing.Color.FromArgb(212, 212, 212);

        // pasteMenuItem
        pasteMenuItem.Text = "Paste";
        pasteMenuItem.ShortcutKeys = Keys.Control | Keys.V;
        pasteMenuItem.Click += PasteMenuItem_Click;
        pasteMenuItem.BackColor = System.Drawing.Color.FromArgb(45, 45, 45);
        pasteMenuItem.ForeColor = System.Drawing.Color.FromArgb(212, 212, 212);

        // editSep1
        editSep1.BackColor = System.Drawing.Color.FromArgb(45, 45, 45);
        editSep1.ForeColor = System.Drawing.Color.FromArgb(45, 45, 45);

        // findMenuItem
        findMenuItem.Text = "Find";
        findMenuItem.ShortcutKeys = Keys.Control | Keys.F;
        findMenuItem.Click += FindMenuItem_Click;
        findMenuItem.BackColor = System.Drawing.Color.FromArgb(45, 45, 45);
        findMenuItem.ForeColor = System.Drawing.Color.FromArgb(212, 212, 212);

        // goToMenuItem
        goToMenuItem.Text = "Go To";
        goToMenuItem.ShortcutKeys = Keys.Control | Keys.G;
        goToMenuItem.Click += GoToMenuItem_Click;
        goToMenuItem.BackColor = System.Drawing.Color.FromArgb(45, 45, 45);
        goToMenuItem.ForeColor = System.Drawing.Color.FromArgb(212, 212, 212);

        // viewMenu
        viewMenu.Text = "View";
        viewMenu.DropDownItems.AddRange(new ToolStripItem[] {
            resetZoomMenuItem
        });
        viewMenu.ForeColor = System.Drawing.Color.FromArgb(212, 212, 212);

        // resetZoomMenuItem
        resetZoomMenuItem.Text = "Reset Zoom";
        resetZoomMenuItem.Click += ResetZoomMenuItem_Click;
        resetZoomMenuItem.BackColor = System.Drawing.Color.FromArgb(45, 45, 45);
        resetZoomMenuItem.ForeColor = System.Drawing.Color.FromArgb(212, 212, 212);

        // languageMenu
        languageMenu.Text = "Language";
        languageMenu.DropDownItems.AddRange(new ToolStripItem[] {
            langNone, langCSharp, langCpp, langJavaScript, langPython,
            langJava, langPhp, langHtml, langCss, langBatch, langMarkdown
        });
        languageMenu.ForeColor = System.Drawing.Color.FromArgb(212, 212, 212);

        langNone.Text = "None";
        langNone.Click += LangMenuItem_Click;
        langNone.BackColor = System.Drawing.Color.FromArgb(45, 45, 45);
        langNone.ForeColor = System.Drawing.Color.FromArgb(212, 212, 212);

        langCSharp.Text = "C#";
        langCSharp.Click += LangMenuItem_Click;
        langCSharp.BackColor = System.Drawing.Color.FromArgb(45, 45, 45);
        langCSharp.ForeColor = System.Drawing.Color.FromArgb(212, 212, 212);

        langCpp.Text = "C++";
        langCpp.Click += LangMenuItem_Click;
        langCpp.BackColor = System.Drawing.Color.FromArgb(45, 45, 45);
        langCpp.ForeColor = System.Drawing.Color.FromArgb(212, 212, 212);

        langJavaScript.Text = "JavaScript";
        langJavaScript.Click += LangMenuItem_Click;
        langJavaScript.BackColor = System.Drawing.Color.FromArgb(45, 45, 45);
        langJavaScript.ForeColor = System.Drawing.Color.FromArgb(212, 212, 212);

        langPython.Text = "Python";
        langPython.Click += LangMenuItem_Click;
        langPython.BackColor = System.Drawing.Color.FromArgb(45, 45, 45);
        langPython.ForeColor = System.Drawing.Color.FromArgb(212, 212, 212);

        langJava.Text = "Java";
        langJava.Click += LangMenuItem_Click;
        langJava.BackColor = System.Drawing.Color.FromArgb(45, 45, 45);
        langJava.ForeColor = System.Drawing.Color.FromArgb(212, 212, 212);

        langPhp.Text = "PHP";
        langPhp.Click += LangMenuItem_Click;
        langPhp.BackColor = System.Drawing.Color.FromArgb(45, 45, 45);
        langPhp.ForeColor = System.Drawing.Color.FromArgb(212, 212, 212);

        langHtml.Text = "HTML";
        langHtml.Click += LangMenuItem_Click;
        langHtml.BackColor = System.Drawing.Color.FromArgb(45, 45, 45);
        langHtml.ForeColor = System.Drawing.Color.FromArgb(212, 212, 212);

        langCss.Text = "CSS";
        langCss.Click += LangMenuItem_Click;
        langCss.BackColor = System.Drawing.Color.FromArgb(45, 45, 45);
        langCss.ForeColor = System.Drawing.Color.FromArgb(212, 212, 212);

        langBatch.Text = "Batch";
        langBatch.Click += LangMenuItem_Click;
        langBatch.BackColor = System.Drawing.Color.FromArgb(45, 45, 45);
        langBatch.ForeColor = System.Drawing.Color.FromArgb(212, 212, 212);

        langMarkdown.Text = "Markdown";
        langMarkdown.Click += LangMenuItem_Click;
        langMarkdown.BackColor = System.Drawing.Color.FromArgb(45, 45, 45);
        langMarkdown.ForeColor = System.Drawing.Color.FromArgb(212, 212, 212);

        // statusStrip
        statusStrip.Items.AddRange(new ToolStripItem[] { encodingLabel, lineColLabel });
        statusStrip.Location = new System.Drawing.Point(0, 528);
        statusStrip.Name = "statusStrip";
        statusStrip.Size = new System.Drawing.Size(984, 22);
        statusStrip.TabIndex = 1;
        statusStrip.Text = "statusStrip";
        statusStrip.BackColor = System.Drawing.Color.FromArgb(30, 30, 30);
        statusStrip.ForeColor = System.Drawing.Color.FromArgb(212, 212, 212);
        statusStrip.Renderer = new NotepadvRenderer();

        // encodingLabel
        encodingLabel.Text = "UTF-8";
        encodingLabel.Spring = true;
        encodingLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        encodingLabel.ForeColor = System.Drawing.Color.FromArgb(212, 212, 212);

        // lineColLabel
        lineColLabel.Text = "Ln 1, Col 1";
        lineColLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
        lineColLabel.ForeColor = System.Drawing.Color.FromArgb(212, 212, 212);

        // scintilla
        scintilla.BorderStyle = ScintillaNET.BorderStyle.None;
        scintilla.Dock = DockStyle.Fill;
        scintilla.Location = new System.Drawing.Point(0, 24);
        scintilla.Name = "scintilla";
        scintilla.Size = new System.Drawing.Size(984, 504);
        scintilla.TabIndex = 2;
        scintilla.Text = "";
        scintilla.WrapMode = ScintillaNET.WrapMode.None;
        scintilla.ScrollWidth = 1;
        scintilla.Margins[0].Width = 50;
        scintilla.Margins[1].Width = 0;
        scintilla.Margins[2].Width = 0;
        scintilla.TextChanged += Scintilla_TextChanged;
        scintilla.UpdateUI += Scintilla_UpdateUI;

        // Form1
        AllowDrop = true;
        DragEnter += Form1_DragEnter;
        DragDrop += Form1_DragDrop;
        AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new System.Drawing.Size(984, 550);
        Controls.Add(scintilla);
        Controls.Add(statusStrip);
        Controls.Add(menuStrip);
        MainMenuStrip = menuStrip;
        Name = "Form1";
        Text = "Notepadv";
        StartPosition = FormStartPosition.CenterScreen;
        BackColor = System.Drawing.Color.FromArgb(30, 30, 30);
        ForeColor = System.Drawing.Color.FromArgb(212, 212, 212);
        Icon = Properties.Resources.app_icon;
        menuStrip.ResumeLayout(false);
        menuStrip.PerformLayout();
        statusStrip.ResumeLayout(false);
        statusStrip.PerformLayout();
        ResumeLayout(false);
        PerformLayout();
    }
}
