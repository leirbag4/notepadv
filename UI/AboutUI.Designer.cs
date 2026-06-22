using Notepadv.UI.Controls;

namespace Notepadv.UI;

partial class AboutUI
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
        titleLabel = new Label();
        githubLinkLabel = new LinkLabel();
        pictureBoxAdv1 = new PictureBoxAdv();
        copyrightLabel = new Label();
        devNameLabel = new Label();
        versionLabel = new LabelAdv();
        closeButton = new ButtonAdv();
        developedByLabel = new LabelAdv();
        studioLabel = new LabelAdv();
        studioLink = new LinkLabel();
        codeLabel = new LabelAdv();
        codeLink = new LinkLabel();
        githubLabel = new LabelAdv();
        githubLink = new LinkLabel();
        SuspendLayout();
        // 
        // titleLabel
        // 
        titleLabel.AutoSize = true;
        titleLabel.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        titleLabel.ForeColor = Color.Silver;
        titleLabel.Location = new Point(34, 57);
        titleLabel.Name = "titleLabel";
        titleLabel.Size = new Size(87, 15);
        titleLabel.TabIndex = 0;
        titleLabel.Text = "Notepadv - LE";
        // 
        // githubLinkLabel
        // 
        githubLinkLabel.ActiveLinkColor = Color.MediumOrchid;
        githubLinkLabel.AutoSize = true;
        githubLinkLabel.LinkColor = Color.BlueViolet;
        githubLinkLabel.Location = new Point(157, 106);
        githubLinkLabel.Name = "githubLinkLabel";
        githubLinkLabel.Size = new Size(88, 15);
        githubLinkLabel.TabIndex = 1;
        githubLinkLabel.TabStop = true;
        githubLinkLabel.Tag = "https://github.com/leirbag4/notepadv";
        githubLinkLabel.Text = "Project Website";
        githubLinkLabel.LinkClicked += OnLinkPressed;
        // 
        // pictureBoxAdv1
        // 
        pictureBoxAdv1.Image = null;
        pictureBoxAdv1.Location = new Point(33, 18);
        pictureBoxAdv1.Margin = new Padding(3, 2, 3, 2);
        pictureBoxAdv1.Name = "pictureBoxAdv1";
        pictureBoxAdv1.Size = new Size(78, 27);
        pictureBoxAdv1.SizeMode = PictureBoxSizeMode.StretchImage;
        pictureBoxAdv1.TabIndex = 2;
        pictureBoxAdv1.TabStop = false;
        // 
        // copyrightLabel
        // 
        copyrightLabel.AutoSize = true;
        copyrightLabel.ForeColor = Color.FromArgb(150, 150, 150);
        copyrightLabel.Location = new Point(207, 28);
        copyrightLabel.Name = "copyrightLabel";
        copyrightLabel.Size = new Size(63, 15);
        copyrightLabel.TabIndex = 3;
        copyrightLabel.Text = "Copyright:";
        // 
        // devNameLabel
        // 
        devNameLabel.AutoSize = true;
        devNameLabel.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        devNameLabel.ForeColor = Color.FromArgb(130, 130, 130);
        devNameLabel.Location = new Point(363, 18);
        devNameLabel.Name = "devNameLabel";
        devNameLabel.Size = new Size(52, 15);
        devNameLabel.TabIndex = 4;
        devNameLabel.Text = "Leirbag4";
        // 
        // versionLabel
        // 
        versionLabel.AutoSize = true;
        versionLabel.BorderColor = Color.DarkGray;
        versionLabel.BorderSize = 1;
        versionLabel.CStyle = LabelAdv.CustomStyle.NORMAL;
        versionLabel.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        versionLabel.ForeColor = Color.FromArgb(130, 130, 130);
        versionLabel.Location = new Point(361, 38);
        versionLabel.Name = "versionLabel";
        versionLabel.Size = new Size(59, 15);
        versionLabel.TabIndex = 5;
        versionLabel.Text = "version: -";
        // 
        // closeButton
        // 
        closeButton.BackColor = Color.FromArgb(30, 30, 30);
        closeButton.BorderColor = Color.FromArgb(10, 10, 10);
        closeButton.BorderSize = 1;
        closeButton.CStyle = ButtonAdv.CustomStyle.SOLID;
        closeButton.FocusEnabled = false;
        closeButton.ForeColor = Color.FromArgb(120, 120, 120);
        closeButton.Location = new Point(198, 191);
        closeButton.Margin = new Padding(3, 2, 3, 2);
        closeButton.Name = "closeButton";
        closeButton.processEnterKey = true;
        closeButton.SelectedColor = Color.FromArgb(0, 122, 204);
        closeButton.Size = new Size(82, 22);
        closeButton.TabIndex = 6;
        closeButton.Text = "close";
        closeButton.UseVisualStyleBackColor = false;
        closeButton.Click += OnClosePressed;
        // 
        // developedByLabel
        // 
        developedByLabel.AutoSize = true;
        developedByLabel.BorderColor = Color.DarkGray;
        developedByLabel.BorderSize = 1;
        developedByLabel.CStyle = LabelAdv.CustomStyle.NORMAL;
        developedByLabel.ForeColor = Color.FromArgb(150, 150, 150);
        developedByLabel.Location = new Point(157, 57);
        developedByLabel.Name = "developedByLabel";
        developedByLabel.Size = new Size(155, 30);
        developedByLabel.TabIndex = 7;
        developedByLabel.Text = "Developed by Gabriel Frasca\r\nalso known as Leirbag4";
        developedByLabel.TextAlign = ContentAlignment.TopCenter;
        // 
        // studioLabel
        // 
        studioLabel.AutoSize = true;
        studioLabel.BorderColor = Color.DarkGray;
        studioLabel.BorderSize = 1;
        studioLabel.CStyle = LabelAdv.CustomStyle.NORMAL;
        studioLabel.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        studioLabel.ForeColor = Color.Silver;
        studioLabel.Location = new Point(24, 106);
        studioLabel.Name = "studioLabel";
        studioLabel.Size = new Size(87, 15);
        studioLabel.TabIndex = 8;
        studioLabel.Text = "Notepadv LE";
        // 
        // studioLink
        // 
        studioLink.ActiveLinkColor = Color.MediumOrchid;
        studioLink.AutoSize = true;
        studioLink.LinkColor = Color.BlueViolet;
        studioLink.Location = new Point(157, 131);
        studioLink.Name = "studioLink";
        studioLink.Size = new Size(88, 15);
        studioLink.TabIndex = 9;
        studioLink.TabStop = true;
        studioLink.Tag = "https://github.com/leirbag4/notepadv";
        studioLink.Text = "Project Website";
        studioLink.LinkClicked += OnLinkPressed;
        // 
        // codeLabel
        // 
        codeLabel.AutoSize = true;
        codeLabel.BorderColor = Color.DarkGray;
        codeLabel.BorderSize = 1;
        codeLabel.CStyle = LabelAdv.CustomStyle.NORMAL;
        codeLabel.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        codeLabel.ForeColor = Color.Silver;
        codeLabel.Location = new Point(24, 160);
        codeLabel.Name = "codeLabel";
        codeLabel.Size = new Size(45, 15);
        codeLabel.TabIndex = 12;
        codeLabel.Text = "Github";
        // 
        // githubLink
        // 
        githubLink.ActiveLinkColor = Color.MediumOrchid;
        githubLink.AutoSize = true;
        githubLink.LinkColor = Color.BlueViolet;
        githubLink.Location = new Point(157, 160);
        githubLink.Name = "githubLink";
        githubLink.Size = new Size(40, 15);
        githubLink.TabIndex = 11;
        githubLink.TabStop = true;
        githubLink.Tag = "https://github.com/leirbag4/notepadv";
        githubLink.Text = "Github";
        githubLink.LinkClicked += OnLinkPressed;
        // 
        // AboutUI
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        BorderColor = Color.FromArgb(50, 50, 50);
        BorderSize = 2;
        ClientSize = new Size(470, 224);
        Controls.Add(codeLabel);
        Controls.Add(githubLink);
        Controls.Add(studioLink);
        Controls.Add(studioLabel);
        Controls.Add(developedByLabel);
        Controls.Add(closeButton);
        Controls.Add(versionLabel);
        Controls.Add(devNameLabel);
        Controls.Add(copyrightLabel);
        Controls.Add(pictureBoxAdv1);
        Controls.Add(githubLinkLabel);
        Controls.Add(titleLabel);
        FormBorderStyle = FormBorderStyle.None;
        Margin = new Padding(3, 2, 3, 2);
        Name = "AboutUI";
        StartPosition = FormStartPosition.CenterParent;
        Text = "About";
        ResumeLayout(false);
        PerformLayout();
    }

    private Label titleLabel;
    private LinkLabel githubLinkLabel;
    private PictureBoxAdv pictureBoxAdv1;
    private Label copyrightLabel;
    private Label devNameLabel;
    private LabelAdv versionLabel;
    private ButtonAdv closeButton;
    private LabelAdv developedByLabel;
    private LabelAdv studioLabel;
    private LinkLabel studioLink;
    private LabelAdv codeLabel;
    private LinkLabel codeLink;
    private LabelAdv githubLabel;
    private LinkLabel githubLink;
}
