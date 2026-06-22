using Notepadv.UI.Controls;

namespace Notepadv.UI;

partial class FindUI
{
    private System.ComponentModel.IContainer components = null;

    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
            components.Dispose();
        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
        findInput = new ComboBoxAdv();
        closeButton = new ButtonAdv();
        replaceInput = new ComboBoxAdv();
        optionsGBox = new GroupBoxAdv();
        useRegexCKBox = new CheckBox();
        matchWholeWordCKBox = new CheckBox();
        matchCaseCKBox = new CheckBox();
        optionsButton = new ButtonAdv();
        replaceAllButton = new ButtonAdv();
        optionsGBox.SuspendLayout();
        SuspendLayout();
        // 
        // findInput
        // 
        findInput.BackColor = Color.FromArgb(52, 52, 52);
        findInput.BorderColor = Color.FromArgb(100, 100, 100);
        findInput.BorderSize = 2;
        findInput.ForeColor = Color.Silver;
        findInput.FormattingEnabled = true;
        findInput.Location = new Point(35, 7);
        findInput.Name = "findInput";
        findInput.Size = new Size(151, 28);
        findInput.TabIndex = 0;
        findInput.EnterPressed += OnFindEnterPressed;
        // 
        // closeButton
        // 
        closeButton.BorderColor = Color.DarkGray;
        closeButton.BorderSize = 1;
        closeButton.CStyle = ButtonAdv.CustomStyle.SOLID_NO_BORDERS;
        closeButton.FocusColor = Color.FromArgb(0, 122, 204);
        closeButton.FocusEnabled = true;
        closeButton.Location = new Point(192, 6);
        closeButton.Name = "closeButton";
        closeButton.processEnterKey = true;
        closeButton.SelectedColor = Color.FromArgb(0, 122, 204);
        closeButton.Size = new Size(30, 30);
        closeButton.TabIndex = 3;
        closeButton.UseVisualStyleBackColor = true;
        closeButton.Click += OnCloseButtonPressed;
        // 
        // replaceInput
        // 
        replaceInput.BackColor = Color.FromArgb(52, 52, 52);
        replaceInput.BorderColor = Color.FromArgb(100, 100, 100);
        replaceInput.BorderSize = 2;
        replaceInput.ForeColor = Color.Silver;
        replaceInput.FormattingEnabled = true;
        replaceInput.Location = new Point(35, 43);
        replaceInput.Name = "replaceInput";
        replaceInput.Size = new Size(151, 28);
        replaceInput.TabIndex = 1;
        replaceInput.EnterPressed += OnReplaceEnterPressed;
        // 
        // optionsGBox
        // 
        optionsGBox.BorderColor = Color.DarkGray;
        optionsGBox.BorderSize = 1;
        optionsGBox.Controls.Add(useRegexCKBox);
        optionsGBox.Controls.Add(matchWholeWordCKBox);
        optionsGBox.Controls.Add(matchCaseCKBox);
        optionsGBox.CStyle = GroupBoxAdv.CustomStyle.SOLID_NO_BORDERS;
        optionsGBox.Location = new Point(30, 56);
        optionsGBox.Name = "optionsGBox";
        optionsGBox.Size = new Size(188, 75);
        optionsGBox.TabIndex = 5;
        optionsGBox.TabStop = false;
        // 
        // useRegexCKBox
        // 
        useRegexCKBox.AutoSize = true;
        useRegexCKBox.Font = new Font("Segoe UI", 7.2f);
        useRegexCKBox.ForeColor = Color.FromArgb(224, 224, 224);
        useRegexCKBox.Location = new Point(5, 51);
        useRegexCKBox.Name = "useRegexCKBox";
        useRegexCKBox.Size = new Size(171, 21);
        useRegexCKBox.TabIndex = 7;
        useRegexCKBox.Text = "Use regular expressions";
        useRegexCKBox.UseVisualStyleBackColor = true;
        // 
        // matchWholeWordCKBox
        // 
        matchWholeWordCKBox.AutoSize = true;
        matchWholeWordCKBox.Font = new Font("Segoe UI", 7.2f);
        matchWholeWordCKBox.ForeColor = Color.FromArgb(224, 224, 224);
        matchWholeWordCKBox.Location = new Point(6, 26);
        matchWholeWordCKBox.Name = "matchWholeWordCKBox";
        matchWholeWordCKBox.Size = new Size(138, 21);
        matchWholeWordCKBox.TabIndex = 6;
        matchWholeWordCKBox.Text = "Match whole word";
        matchWholeWordCKBox.UseVisualStyleBackColor = true;
        // 
        // matchCaseCKBox
        // 
        matchCaseCKBox.AutoSize = true;
        matchCaseCKBox.Font = new Font("Segoe UI", 7.2f);
        matchCaseCKBox.ForeColor = Color.FromArgb(224, 224, 224);
        matchCaseCKBox.Location = new Point(6, 3);
        matchCaseCKBox.Name = "matchCaseCKBox";
        matchCaseCKBox.Size = new Size(96, 21);
        matchCaseCKBox.TabIndex = 5;
        matchCaseCKBox.Text = "Match case";
        matchCaseCKBox.UseVisualStyleBackColor = true;
        // 
        // optionsButton
        // 
        optionsButton.BorderColor = Color.DarkGray;
        optionsButton.BorderSize = 1;
        optionsButton.CStyle = ButtonAdv.CustomStyle.SOLID_NO_BORDERS;
        optionsButton.FocusColor = Color.FromArgb(24, 81, 115);
        optionsButton.FocusEnabled = false;
        optionsButton.Location = new Point(6, 8);
        optionsButton.Name = "optionsButton";
        optionsButton.processEnterKey = true;
        optionsButton.SelectedColor = Color.FromArgb(0, 122, 204);
        optionsButton.Size = new Size(26, 26);
        optionsButton.TabIndex = 6;
        optionsButton.UseVisualStyleBackColor = true;
        optionsButton.Click += OnOptionsPressed;
        // 
        // replaceAllButton
        // 
        replaceAllButton.BackColor = Color.FromArgb(34, 34, 34);
        replaceAllButton.BorderColor = Color.FromArgb(57, 57, 57);
        replaceAllButton.BorderSize = 2;
        replaceAllButton.CStyle = ButtonAdv.CustomStyle.SOLID;
        replaceAllButton.extraText = "all";
        replaceAllButton.extraTextAlign = ContentAlignment.MiddleCenter;
        replaceAllButton.extraTextColor = Color.FromArgb(130, 130, 130);
        replaceAllButton.extraTextFont = new Font("Segoe UI", 7f);
        replaceAllButton.FocusColor = Color.FromArgb(0, 122, 204);
        replaceAllButton.FocusEnabled = true;
        replaceAllButton.ForeColor = SystemColors.ControlText;
        replaceAllButton.Location = new Point(194, 43);
        replaceAllButton.Name = "replaceAllButton";
        replaceAllButton.processEnterKey = true;
        replaceAllButton.SelectedColor = Color.FromArgb(0, 122, 204);
        replaceAllButton.Size = new Size(28, 28);
        replaceAllButton.TabIndex = 2;
        replaceAllButton.UseVisualStyleBackColor = false;
        replaceAllButton.Click += OnReplaceAllPressed;
        // 
        // FindUI
        // 
        AutoScaleDimensions = new SizeF(8F, 20F);
        AutoScaleMode = AutoScaleMode.Font;
        BackColor = Color.FromArgb(45, 45, 45);
        Controls.Add(replaceAllButton);
        Controls.Add(optionsButton);
        Controls.Add(optionsGBox);
        Controls.Add(replaceInput);
        Controls.Add(closeButton);
        Controls.Add(findInput);
        Name = "FindUI";
        Size = new Size(229, 78);
        optionsGBox.ResumeLayout(false);
        optionsGBox.PerformLayout();
        ResumeLayout(false);
    }

    private ComboBoxAdv findInput;
    private ButtonAdv closeButton;
    private ComboBoxAdv replaceInput;
    private GroupBoxAdv optionsGBox;
    private CheckBox matchWholeWordCKBox;
    private CheckBox matchCaseCKBox;
    private CheckBox useRegexCKBox;
    private ButtonAdv optionsButton;
    private ButtonAdv replaceAllButton;
}
