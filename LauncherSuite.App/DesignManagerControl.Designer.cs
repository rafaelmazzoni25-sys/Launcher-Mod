namespace LauncherSuite.App
{
    partial class DesignManagerControl
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label themeNameLabel;
        private System.Windows.Forms.TextBox themeNameTextBox;
        private System.Windows.Forms.Label authorLabel;
        private System.Windows.Forms.TextBox authorTextBox;
        private System.Windows.Forms.Label versionLabel;
        private System.Windows.Forms.TextBox versionTextBox;
        private System.Windows.Forms.Label descriptionLabel;
        private System.Windows.Forms.TextBox descriptionTextBox;
        private System.Windows.Forms.Label compatibilityLabel;
        private System.Windows.Forms.TextBox compatibilityTextBox;
        private System.Windows.Forms.Label outputPathLabel;
        private System.Windows.Forms.TextBox outputPathTextBox;
        private System.Windows.Forms.Button browseButton;
        private System.Windows.Forms.CheckBox includeDefaultsCheckBox;
        private System.Windows.Forms.Button createButton;
        private System.Windows.Forms.Label statusLabel;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;

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
            this.components = new System.ComponentModel.Container();
            this.themeNameLabel = new System.Windows.Forms.Label();
            this.themeNameTextBox = new System.Windows.Forms.TextBox();
            this.authorLabel = new System.Windows.Forms.Label();
            this.authorTextBox = new System.Windows.Forms.TextBox();
            this.versionLabel = new System.Windows.Forms.Label();
            this.versionTextBox = new System.Windows.Forms.TextBox();
            this.descriptionLabel = new System.Windows.Forms.Label();
            this.descriptionTextBox = new System.Windows.Forms.TextBox();
            this.compatibilityLabel = new System.Windows.Forms.Label();
            this.compatibilityTextBox = new System.Windows.Forms.TextBox();
            this.outputPathLabel = new System.Windows.Forms.Label();
            this.outputPathTextBox = new System.Windows.Forms.TextBox();
            this.browseButton = new System.Windows.Forms.Button();
            this.includeDefaultsCheckBox = new System.Windows.Forms.CheckBox();
            this.createButton = new System.Windows.Forms.Button();
            this.statusLabel = new System.Windows.Forms.Label();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.SuspendLayout();
            // 
            // themeNameLabel
            // 
            this.themeNameLabel.AutoSize = true;
            this.themeNameLabel.Location = new System.Drawing.Point(16, 16);
            this.themeNameLabel.Name = "themeNameLabel";
            this.themeNameLabel.Size = new System.Drawing.Size(77, 13);
            this.themeNameLabel.TabIndex = 0;
            this.themeNameLabel.Text = "Nome do tema";
            // 
            // themeNameTextBox
            // 
            this.themeNameTextBox.Location = new System.Drawing.Point(19, 32);
            this.themeNameTextBox.Name = "themeNameTextBox";
            this.themeNameTextBox.Size = new System.Drawing.Size(240, 20);
            this.themeNameTextBox.TabIndex = 1;
            // 
            // authorLabel
            // 
            this.authorLabel.AutoSize = true;
            this.authorLabel.Location = new System.Drawing.Point(16, 64);
            this.authorLabel.Name = "authorLabel";
            this.authorLabel.Size = new System.Drawing.Size(35, 13);
            this.authorLabel.TabIndex = 2;
            this.authorLabel.Text = "Autor";
            // 
            // authorTextBox
            // 
            this.authorTextBox.Location = new System.Drawing.Point(19, 80);
            this.authorTextBox.Name = "authorTextBox";
            this.authorTextBox.Size = new System.Drawing.Size(240, 20);
            this.authorTextBox.TabIndex = 3;
            // 
            // versionLabel
            // 
            this.versionLabel.AutoSize = true;
            this.versionLabel.Location = new System.Drawing.Point(16, 112);
            this.versionLabel.Name = "versionLabel";
            this.versionLabel.Size = new System.Drawing.Size(42, 13);
            this.versionLabel.TabIndex = 4;
            this.versionLabel.Text = "Versão";
            // 
            // versionTextBox
            // 
            this.versionTextBox.Location = new System.Drawing.Point(19, 128);
            this.versionTextBox.Name = "versionTextBox";
            this.versionTextBox.Size = new System.Drawing.Size(240, 20);
            this.versionTextBox.TabIndex = 5;
            this.versionTextBox.Text = "1.0.0";
            // 
            // descriptionLabel
            // 
            this.descriptionLabel.AutoSize = true;
            this.descriptionLabel.Location = new System.Drawing.Point(16, 160);
            this.descriptionLabel.Name = "descriptionLabel";
            this.descriptionLabel.Size = new System.Drawing.Size(55, 13);
            this.descriptionLabel.TabIndex = 6;
            this.descriptionLabel.Text = "Descrição";
            // 
            // descriptionTextBox
            // 
            this.descriptionTextBox.Location = new System.Drawing.Point(19, 176);
            this.descriptionTextBox.Multiline = true;
            this.descriptionTextBox.Name = "descriptionTextBox";
            this.descriptionTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.descriptionTextBox.Size = new System.Drawing.Size(360, 96);
            this.descriptionTextBox.TabIndex = 7;
            // 
            // compatibilityLabel
            // 
            this.compatibilityLabel.AutoSize = true;
            this.compatibilityLabel.Location = new System.Drawing.Point(16, 280);
            this.compatibilityLabel.Name = "compatibilityLabel";
            this.compatibilityLabel.Size = new System.Drawing.Size(91, 13);
            this.compatibilityLabel.TabIndex = 8;
            this.compatibilityLabel.Text = "Compatibilidade";
            // 
            // compatibilityTextBox
            // 
            this.compatibilityTextBox.Location = new System.Drawing.Point(19, 296);
            this.compatibilityTextBox.Name = "compatibilityTextBox";
            this.compatibilityTextBox.Size = new System.Drawing.Size(240, 20);
            this.compatibilityTextBox.TabIndex = 9;
            this.compatibilityTextBox.Text = "Any";
            // 
            // outputPathLabel
            // 
            this.outputPathLabel.AutoSize = true;
            this.outputPathLabel.Location = new System.Drawing.Point(16, 328);
            this.outputPathLabel.Name = "outputPathLabel";
            this.outputPathLabel.Size = new System.Drawing.Size(107, 13);
            this.outputPathLabel.TabIndex = 10;
            this.outputPathLabel.Text = "Diretório de destino";
            // 
            // outputPathTextBox
            // 
            this.outputPathTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.outputPathTextBox.Location = new System.Drawing.Point(19, 344);
            this.outputPathTextBox.Name = "outputPathTextBox";
            this.outputPathTextBox.Size = new System.Drawing.Size(464, 20);
            this.outputPathTextBox.TabIndex = 11;
            // 
            // browseButton
            // 
            this.browseButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.browseButton.Location = new System.Drawing.Point(489, 342);
            this.browseButton.Name = "browseButton";
            this.browseButton.Size = new System.Drawing.Size(75, 23);
            this.browseButton.TabIndex = 12;
            this.browseButton.Text = "Procurar";
            this.browseButton.UseVisualStyleBackColor = true;
            this.browseButton.Click += new System.EventHandler(this.BrowseButton_Click);
            // 
            // includeDefaultsCheckBox
            // 
            this.includeDefaultsCheckBox.AutoSize = true;
            this.includeDefaultsCheckBox.Location = new System.Drawing.Point(19, 376);
            this.includeDefaultsCheckBox.Name = "includeDefaultsCheckBox";
            this.includeDefaultsCheckBox.Size = new System.Drawing.Size(218, 17);
            this.includeDefaultsCheckBox.TabIndex = 13;
            this.includeDefaultsCheckBox.Text = "Copiar imagens padrão do Launcher";
            this.includeDefaultsCheckBox.UseVisualStyleBackColor = true;
            // 
            // createButton
            // 
            this.createButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.createButton.Location = new System.Drawing.Point(489, 372);
            this.createButton.Name = "createButton";
            this.createButton.Size = new System.Drawing.Size(75, 23);
            this.createButton.TabIndex = 14;
            this.createButton.Text = "Criar";
            this.createButton.UseVisualStyleBackColor = true;
            this.createButton.Click += new System.EventHandler(this.CreateButton_Click);
            // 
            // statusLabel
            // 
            this.statusLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.statusLabel.Location = new System.Drawing.Point(16, 408);
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(548, 40);
            this.statusLabel.TabIndex = 15;
            this.statusLabel.Text = "Selecione um diretório de saída para gerar um novo tema.";
            // 
            // DesignManagerControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.statusLabel);
            this.Controls.Add(this.createButton);
            this.Controls.Add(this.includeDefaultsCheckBox);
            this.Controls.Add(this.browseButton);
            this.Controls.Add(this.outputPathTextBox);
            this.Controls.Add(this.outputPathLabel);
            this.Controls.Add(this.compatibilityTextBox);
            this.Controls.Add(this.compatibilityLabel);
            this.Controls.Add(this.descriptionTextBox);
            this.Controls.Add(this.descriptionLabel);
            this.Controls.Add(this.versionTextBox);
            this.Controls.Add(this.versionLabel);
            this.Controls.Add(this.authorTextBox);
            this.Controls.Add(this.authorLabel);
            this.Controls.Add(this.themeNameTextBox);
            this.Controls.Add(this.themeNameLabel);
            this.Name = "DesignManagerControl";
            this.Size = new System.Drawing.Size(580, 460);
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
