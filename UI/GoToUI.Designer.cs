using Notepadv.UI.Controls;

namespace Notepadv.UI;

partial class GoToUI
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
        lineInput = new TextBox();
        okButton = new ButtonAdv();
        cancelButton = new ButtonAdv();
        SuspendLayout();
        // 
        // lineInput
        // 
        lineInput.BackColor = Color.FromArgb(52, 52, 52);
        lineInput.BorderStyle = BorderStyle.FixedSingle;
        lineInput.Font = new Font("Segoe UI", 11f);
        lineInput.ForeColor = Color.Silver;
        lineInput.Location = new Point(20, 35);
        lineInput.Name = "lineInput";
        lineInput.Size = new Size(180, 32);
        lineInput.TabIndex = 0;
        lineInput.TextAlign = HorizontalAlignment.Center;
        lineInput.KeyDown += OnInputKeyDown;
        // 
        // okButton
        // 
        okButton.BorderColor = Color.DarkGray;
        okButton.BorderSize = 1;
        okButton.CStyle = ButtonAdv.CustomStyle.SOLID_NO_BORDERS;
        okButton.FocusColor = Color.FromArgb(0, 122, 204);
        okButton.FocusEnabled = true;
        okButton.ForeColor = Color.FromArgb(224, 224, 224);
        okButton.Location = new Point(125, 75);
        okButton.Name = "okButton";
        okButton.processEnterKey = true;
        okButton.SelectedColor = Color.FromArgb(0, 122, 204);
        okButton.Size = new Size(75, 28);
        okButton.TabIndex = 2;
        okButton.Text = "OK";
        okButton.UseVisualStyleBackColor = true;
        okButton.Click += OnOkPressed;
        // 
        // cancelButton
        // 
        cancelButton.BorderColor = Color.DarkGray;
        cancelButton.BorderSize = 1;
        cancelButton.CStyle = ButtonAdv.CustomStyle.SOLID_NO_BORDERS;
        cancelButton.FocusColor = Color.FromArgb(0, 122, 204);
        cancelButton.FocusEnabled = true;
        cancelButton.ForeColor = Color.FromArgb(224, 224, 224);
        cancelButton.Location = new Point(20, 75);
        cancelButton.Name = "cancelButton";
        cancelButton.processEnterKey = true;
        cancelButton.SelectedColor = Color.FromArgb(0, 122, 204);
        cancelButton.Size = new Size(75, 28);
        cancelButton.TabIndex = 1;
        cancelButton.Text = "Cancel";
        cancelButton.UseVisualStyleBackColor = true;
        cancelButton.Click += OnCancelPressed;
        // 
        // GoToUI
        // 
        AutoScaleDimensions = new SizeF(8F, 20F);
        AutoScaleMode = AutoScaleMode.Font;
        BackColor = Color.FromArgb(45, 45, 45);
        Controls.Add(cancelButton);
        Controls.Add(okButton);
        Controls.Add(lineInput);
        Name = "GoToUI";
        Size = new Size(220, 110);
        ResumeLayout(false);
        PerformLayout();
    }

    private TextBox lineInput;
    private ButtonAdv okButton;
    private ButtonAdv cancelButton;
}
