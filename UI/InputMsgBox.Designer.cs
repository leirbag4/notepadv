using Notepadv.UI.Controls;

namespace Notepadv.UI;

partial class InputMsgBox
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
        okButton = new ButtonAdv();
        cancelButton = new ButtonAdv();
        groupBoxAdv1 = new GroupBoxAdv();
        descLabel = new LabelAdv();
        groupBoxAdv2 = new GroupBoxAdv();
        inputLabel = new LabelAdv();
        input = new TextBoxAdv();
        groupBoxAdv1.SuspendLayout();
        groupBoxAdv2.SuspendLayout();
        SuspendLayout();
        // 
        // okButton
        // 
        okButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
        okButton.BackColor = Color.FromArgb(30, 30, 30);
        okButton.BorderColor = Color.FromArgb(25, 25, 25);
        okButton.BorderSize = 2;
        okButton.CStyle = ButtonAdv.CustomStyle.SOLID;
        okButton.FocusEnabled = true;
        okButton.ForeColor = Color.FromArgb(224, 224, 224);
        okButton.Location = new Point(316, 202);
        okButton.Margin = new Padding(4, 5, 4, 5);
        okButton.Name = "okButton";
        okButton.processEnterKey = true;
        okButton.SelectedColor = Color.FromArgb(0, 122, 204);
        okButton.Size = new Size(108, 32);
        okButton.TabIndex = 9;
        okButton.Text = "Ok";
        okButton.UseVisualStyleBackColor = false;
        okButton.Click += OnOkPressed;
        // 
        // cancelButton
        // 
        cancelButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
        cancelButton.BackColor = Color.FromArgb(30, 30, 30);
        cancelButton.BorderColor = Color.FromArgb(25, 25, 25);
        cancelButton.BorderSize = 2;
        cancelButton.CStyle = ButtonAdv.CustomStyle.SOLID;
        cancelButton.FocusEnabled = true;
        cancelButton.ForeColor = Color.FromArgb(224, 224, 224);
        cancelButton.Location = new Point(432, 202);
        cancelButton.Margin = new Padding(4, 5, 4, 5);
        cancelButton.Name = "cancelButton";
        cancelButton.processEnterKey = true;
        cancelButton.SelectedColor = Color.FromArgb(0, 122, 204);
        cancelButton.Size = new Size(108, 32);
        cancelButton.TabIndex = 8;
        cancelButton.Text = "Cancel";
        cancelButton.UseVisualStyleBackColor = false;
        cancelButton.Click += OnCancelPressed;
        // 
        // groupBoxAdv1
        // 
        groupBoxAdv1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        groupBoxAdv1.BackColor = Color.FromArgb(52, 52, 52);
        groupBoxAdv1.BorderColor = Color.FromArgb(64, 64, 64);
        groupBoxAdv1.BorderSize = 2;
        groupBoxAdv1.Controls.Add(descLabel);
        groupBoxAdv1.CStyle = GroupBoxAdv.CustomStyle.SOLID;
        groupBoxAdv1.Location = new Point(11, 11);
        groupBoxAdv1.Margin = new Padding(4, 5, 4, 5);
        groupBoxAdv1.Name = "groupBoxAdv1";
        groupBoxAdv1.Padding = new Padding(4, 5, 4, 5);
        groupBoxAdv1.Size = new Size(528, 129);
        groupBoxAdv1.TabIndex = 10;
        groupBoxAdv1.TabStop = false;
        // 
        // descLabel
        // 
        descLabel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        descLabel.BorderColor = Color.DarkGray;
        descLabel.BorderSize = 1;
        descLabel.CStyle = LabelAdv.CustomStyle.NORMAL;
        descLabel.ForeColor = Color.Silver;
        descLabel.Location = new Point(8, 9);
        descLabel.Margin = new Padding(4, 0, 4, 0);
        descLabel.Name = "descLabel";
        descLabel.Size = new Size(509, 111);
        descLabel.TabIndex = 3;
        descLabel.Text = "...";
        // 
        // groupBoxAdv2
        // 
        groupBoxAdv2.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        groupBoxAdv2.BackColor = Color.FromArgb(52, 52, 52);
        groupBoxAdv2.BorderColor = Color.FromArgb(64, 64, 64);
        groupBoxAdv2.BorderSize = 2;
        groupBoxAdv2.Controls.Add(inputLabel);
        groupBoxAdv2.Controls.Add(input);
        groupBoxAdv2.CStyle = GroupBoxAdv.CustomStyle.SOLID;
        groupBoxAdv2.Location = new Point(11, 145);
        groupBoxAdv2.Margin = new Padding(4, 5, 4, 5);
        groupBoxAdv2.Name = "groupBoxAdv2";
        groupBoxAdv2.Padding = new Padding(4, 5, 4, 5);
        groupBoxAdv2.Size = new Size(528, 49);
        groupBoxAdv2.TabIndex = 11;
        groupBoxAdv2.TabStop = false;
        // 
        // inputLabel
        // 
        inputLabel.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        inputLabel.BorderColor = Color.DarkGray;
        inputLabel.BorderSize = 1;
        inputLabel.CStyle = LabelAdv.CustomStyle.NORMAL;
        inputLabel.ForeColor = Color.Silver;
        inputLabel.Location = new Point(19, 14);
        inputLabel.Name = "inputLabel";
        inputLabel.RightToLeft = RightToLeft.Yes;
        inputLabel.Size = new Size(100, 25);
        inputLabel.TabIndex = 1;
        inputLabel.Text = "input";
        // 
        // input
        // 
        input.AllowBackspace = true;
        input.AllowTextEdition = true;
        input.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        input.AutoEdition = false;
        input.AutoSelect = false;
        input.BackColor = Color.FromArgb(80, 80, 80);
        input.BorderStyle = BorderStyle.FixedSingle;
        input.ForeColor = SystemColors.ScrollBar;
        input.Location = new Point(140, 11);
        input.Margin = new Padding(4, 5, 4, 5);
        input.Name = "input";
        input.Size = new Size(379, 23);
        input.TabIndex = 0;
        input.EnterPressed += OnEnterPressed;
        // 
        // InputMsgBox
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        BackColor = Color.FromArgb(45, 45, 45);
        ClientSize = new Size(551, 244);
        Controls.Add(groupBoxAdv2);
        Controls.Add(groupBoxAdv1);
        Controls.Add(okButton);
        Controls.Add(cancelButton);
        Margin = new Padding(4);
        MinimizeBox = false;
        Name = "InputMsgBox";
        StartPosition = FormStartPosition.CenterParent;
        Text = "Input";
        groupBoxAdv1.ResumeLayout(false);
        groupBoxAdv1.PerformLayout();
        groupBoxAdv2.ResumeLayout(false);
        groupBoxAdv2.PerformLayout();
        ResumeLayout(false);
    }

    private ButtonAdv okButton;
    private ButtonAdv cancelButton;
    private GroupBoxAdv groupBoxAdv1;
    private LabelAdv descLabel;
    private GroupBoxAdv groupBoxAdv2;
    private LabelAdv inputLabel;
    private TextBoxAdv input;
}
