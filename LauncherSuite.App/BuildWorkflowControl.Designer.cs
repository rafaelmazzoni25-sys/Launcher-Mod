using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace LauncherSuite.App
{
    partial class BuildWorkflowControl
    {
        private TableLayoutPanel inputsTableLayout;
        private TextBox configPathTextBox;
        private TextBox updateSourceTextBox;
        private TextBox updateOutputTextBox;
        private TextBox manifestPathTextBox;
        private TextBox themeRootTextBox;
        private Button browseConfigButton;
        private Button browseUpdateSourceButton;
        private Button browseUpdateOutputButton;
        private Button browseManifestButton;
        private Button browseThemeRootButton;
        private CheckBox includeThemeCheckBox;
        private CheckBox includeDefaultAssetsCheckBox;
        private Button syncButton;
        private Button runButton;
        private ProgressBar manifestProgressBar;
        private TextBox logTextBox;
        private Label statusLabel;
        private FolderBrowserDialog folderBrowserDialog;
        private SaveFileDialog manifestSaveFileDialog;
        private SaveFileDialog configSaveFileDialog;
        private IContainer components;

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                components?.Dispose();
            }

            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            components = new Container();
            inputsTableLayout = new TableLayoutPanel();
            configPathTextBox = new TextBox();
            updateSourceTextBox = new TextBox();
            updateOutputTextBox = new TextBox();
            manifestPathTextBox = new TextBox();
            themeRootTextBox = new TextBox();
            browseConfigButton = new Button();
            browseUpdateSourceButton = new Button();
            browseUpdateOutputButton = new Button();
            browseManifestButton = new Button();
            browseThemeRootButton = new Button();
            includeThemeCheckBox = new CheckBox();
            includeDefaultAssetsCheckBox = new CheckBox();
            syncButton = new Button();
            runButton = new Button();
            manifestProgressBar = new ProgressBar();
            logTextBox = new TextBox();
            statusLabel = new Label();
            folderBrowserDialog = new FolderBrowserDialog();
            manifestSaveFileDialog = new SaveFileDialog();
            configSaveFileDialog = new SaveFileDialog();
            inputsTableLayout.SuspendLayout();
            SuspendLayout();
            // 
            // inputsTableLayout
            // 
            inputsTableLayout.ColumnCount = 3;
            inputsTableLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 28F));
            inputsTableLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 52F));
            inputsTableLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            inputsTableLayout.Controls.Add(new Label { Text = "Arquivo mu.ini", Anchor = AnchorStyles.Left, AutoSize = true }, 0, 0);
            inputsTableLayout.Controls.Add(configPathTextBox, 1, 0);
            inputsTableLayout.Controls.Add(browseConfigButton, 2, 0);
            inputsTableLayout.Controls.Add(new Label { Text = "Pasta de origem (updates)", Anchor = AnchorStyles.Left, AutoSize = true }, 0, 1);
            inputsTableLayout.Controls.Add(updateSourceTextBox, 1, 1);
            inputsTableLayout.Controls.Add(browseUpdateSourceButton, 2, 1);
            inputsTableLayout.Controls.Add(new Label { Text = "Saída dos arquivos", Anchor = AnchorStyles.Left, AutoSize = true }, 0, 2);
            inputsTableLayout.Controls.Add(updateOutputTextBox, 1, 2);
            inputsTableLayout.Controls.Add(browseUpdateOutputButton, 2, 2);
            inputsTableLayout.Controls.Add(new Label { Text = "Manifesto (update.txt)", Anchor = AnchorStyles.Left, AutoSize = true }, 0, 3);
            inputsTableLayout.Controls.Add(manifestPathTextBox, 1, 3);
            inputsTableLayout.Controls.Add(browseManifestButton, 2, 3);
            inputsTableLayout.Controls.Add(new Label { Text = "Diretório base do tema", Anchor = AnchorStyles.Left, AutoSize = true }, 0, 4);
            inputsTableLayout.Controls.Add(themeRootTextBox, 1, 4);
            inputsTableLayout.Controls.Add(browseThemeRootButton, 2, 4);
            inputsTableLayout.Controls.Add(includeThemeCheckBox, 1, 5);
            inputsTableLayout.Controls.Add(includeDefaultAssetsCheckBox, 2, 5);
            inputsTableLayout.Dock = DockStyle.Top;
            inputsTableLayout.Location = new Point(16, 16);
            inputsTableLayout.Name = "inputsTableLayout";
            inputsTableLayout.RowCount = 6;
            for (int row = 0; row < 6; row++)
            {
                inputsTableLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 32F));
            }
            inputsTableLayout.Size = new Size(700, 192);
            inputsTableLayout.TabIndex = 0;
            // 
            // configPathTextBox
            // 
            configPathTextBox.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            configPathTextBox.TabIndex = 1;
            // 
            // updateSourceTextBox
            // 
            updateSourceTextBox.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            updateSourceTextBox.TabIndex = 3;
            // 
            // updateOutputTextBox
            // 
            updateOutputTextBox.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            updateOutputTextBox.TabIndex = 5;
            // 
            // manifestPathTextBox
            // 
            manifestPathTextBox.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            manifestPathTextBox.TabIndex = 7;
            // 
            // themeRootTextBox
            // 
            themeRootTextBox.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            themeRootTextBox.TabIndex = 9;
            // 
            // browse buttons
            // 
            browseConfigButton.Text = "Selecionar";
            browseConfigButton.TabIndex = 2;
            browseConfigButton.Click += browseConfigButton_Click;

            browseUpdateSourceButton.Text = "Selecionar";
            browseUpdateSourceButton.TabIndex = 4;
            browseUpdateSourceButton.Click += browseUpdateSourceButton_Click;

            browseUpdateOutputButton.Text = "Selecionar";
            browseUpdateOutputButton.TabIndex = 6;
            browseUpdateOutputButton.Click += browseUpdateOutputButton_Click;

            browseManifestButton.Text = "Salvar";
            browseManifestButton.TabIndex = 8;
            browseManifestButton.Click += browseManifestButton_Click;

            browseThemeRootButton.Text = "Selecionar";
            browseThemeRootButton.TabIndex = 10;
            browseThemeRootButton.Click += browseThemeRootButton_Click;
            // 
            // includeThemeCheckBox
            // 
            includeThemeCheckBox.Anchor = AnchorStyles.Left;
            includeThemeCheckBox.AutoSize = true;
            includeThemeCheckBox.Text = "Gerar pacote de tema";
            includeThemeCheckBox.TabIndex = 11;
            includeThemeCheckBox.CheckedChanged += includeThemeCheckBox_CheckedChanged;
            // 
            // includeDefaultAssetsCheckBox
            // 
            includeDefaultAssetsCheckBox.Anchor = AnchorStyles.Left;
            includeDefaultAssetsCheckBox.AutoSize = true;
            includeDefaultAssetsCheckBox.Text = "Incluir assets padrão";
            includeDefaultAssetsCheckBox.TabIndex = 12;
            // 
            // syncButton
            // 
            syncButton.Location = new Point(16, 224);
            syncButton.Name = "syncButton";
            syncButton.Size = new Size(160, 32);
            syncButton.TabIndex = 13;
            syncButton.Text = "Sincronizar abas";
            syncButton.UseVisualStyleBackColor = true;
            syncButton.Click += syncButton_Click;
            // 
            // runButton
            // 
            runButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            runButton.Location = new Point(556, 224);
            runButton.Name = "runButton";
            runButton.Size = new Size(160, 32);
            runButton.TabIndex = 14;
            runButton.Text = "Executar fluxo";
            runButton.UseVisualStyleBackColor = true;
            runButton.Click += runButton_Click;
            // 
            // manifestProgressBar
            // 
            manifestProgressBar.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            manifestProgressBar.Location = new Point(16, 272);
            manifestProgressBar.Name = "manifestProgressBar";
            manifestProgressBar.Size = new Size(700, 18);
            manifestProgressBar.TabIndex = 15;
            // 
            // logTextBox
            // 
            logTextBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            logTextBox.Location = new Point(16, 296);
            logTextBox.Multiline = true;
            logTextBox.ReadOnly = true;
            logTextBox.ScrollBars = ScrollBars.Vertical;
            logTextBox.Size = new Size(700, 176);
            logTextBox.TabIndex = 16;
            // 
            // statusLabel
            // 
            statusLabel.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            statusLabel.AutoSize = true;
            statusLabel.Location = new Point(16, 480);
            statusLabel.Name = "statusLabel";
            statusLabel.Size = new Size(104, 13);
            statusLabel.TabIndex = 17;
            statusLabel.Text = "Fluxo aguardando...";
            // 
            // manifestSaveFileDialog
            // 
            manifestSaveFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
            manifestSaveFileDialog.Title = "Salvar manifesto";
            // 
            // configSaveFileDialog
            // 
            configSaveFileDialog.Filter = "INI files (*.ini)|*.ini|All files (*.*)|*.*";
            configSaveFileDialog.Title = "Salvar mu.ini";
            // 
            // BuildWorkflowControl
            // 
            AutoScaleDimensions = new SizeF(6F, 13F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(statusLabel);
            Controls.Add(logTextBox);
            Controls.Add(manifestProgressBar);
            Controls.Add(runButton);
            Controls.Add(syncButton);
            Controls.Add(inputsTableLayout);
            Name = "BuildWorkflowControl";
            Padding = new Padding(16);
            Size = new Size(732, 510);
            inputsTableLayout.ResumeLayout(false);
            inputsTableLayout.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
