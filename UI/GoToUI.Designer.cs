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
        okButton = new Button();
        cancelButton = new Button();
        SuspendLayout();
        // 
        // lineInput
        // 
        lineInput.BackColor = Color.FromArgb(52, 52, 52);
        lineInput.BorderStyle = BorderStyle.FixedSingle;
        lineInput.Font = new Font("Segoe UI", 11f);
        lineInput.ForeColor = Color.Silver;
        lineInput.Location = new Point(30, 25);
        lineInput.MaxLength = 10;
        lineInput.Name = "lineInput";
        lineInput.Size = new Size(180, 32);
        lineInput.TabIndex = 0;
        lineInput.TextAlign = HorizontalAlignment.Center;
        lineInput.KeyDown += OnInputKeyDown;
        lineInput.KeyPress += OnInputKeyPress;
        // 
        // okButton
        // 
        okButton.BackColor = Color.FromArgb(52, 52, 52);
        okButton.FlatStyle = FlatStyle.Flat;
        okButton.FlatAppearance.BorderSize = 0;
        okButton.ForeColor = Color.Silver;
        okButton.Location = new Point(140, 70);
        okButton.Name = "okButton";
        okButton.Size = new Size(70, 28);
        okButton.TabIndex = 2;
        okButton.Text = "OK";
        okButton.UseVisualStyleBackColor = false;
        okButton.Click += OnOkPressed;
        // 
        // cancelButton
        // 
        cancelButton.BackColor = Color.FromArgb(52, 52, 52);
        cancelButton.FlatStyle = FlatStyle.Flat;
        cancelButton.FlatAppearance.BorderSize = 0;
        cancelButton.ForeColor = Color.Silver;
        cancelButton.Location = new Point(30, 70);
        cancelButton.Name = "cancelButton";
        cancelButton.Size = new Size(70, 28);
        cancelButton.TabIndex = 1;
        cancelButton.Text = "Cancel";
        cancelButton.UseVisualStyleBackColor = false;
        cancelButton.Click += OnCancelPressed;
        // 
        // GoToUI
        // 
        AutoScaleDimensions = new SizeF(8F, 20F);
        AutoScaleMode = AutoScaleMode.Font;
        BackColor = Color.FromArgb(45, 45, 45);
        ClientSize = new Size(240, 110);
        ControlBox = false;
        Controls.Add(cancelButton);
        Controls.Add(okButton);
        Controls.Add(lineInput);
        FormBorderStyle = FormBorderStyle.None;
        MaximizeBox = false;
        MinimizeBox = false;
        Name = "GoToUI";
        ShowInTaskbar = false;
        StartPosition = FormStartPosition.Manual;
        ResumeLayout(false);
        PerformLayout();
    }

    private TextBox lineInput;
    private Button okButton;
    private Button cancelButton;
}
