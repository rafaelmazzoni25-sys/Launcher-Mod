using System;
using System.IO;
using System.Windows.Forms;
using ConfigGenerator;
using LauncherSuite.Core.Build;
using LauncherSuite.Core.Configuration;
using LauncherSuite.Core.Design;
using LauncherSuite.Core.Updates;
using Update.Maker;

namespace LauncherSuite.App
{
    public partial class BuildWorkflowControl : UserControl
    {
        private readonly ConfigGeneratorControl _configControl;
        private readonly UpdateGeneratorControl _updateControl;
        private readonly DesignManagerControl _designControl;
        private readonly BuildPipeline _pipeline;
        private readonly UpdateManifestBuilder _manifestBuilder;

        public BuildWorkflowControl(ConfigGeneratorControl configControl, UpdateGeneratorControl updateControl, DesignManagerControl designControl)
        {
            _configControl = configControl ?? throw new ArgumentNullException(nameof(configControl));
            _updateControl = updateControl ?? throw new ArgumentNullException(nameof(updateControl));
            _designControl = designControl ?? throw new ArgumentNullException(nameof(designControl));

            _manifestBuilder = new UpdateManifestBuilder();
            _pipeline = new BuildPipeline(_manifestBuilder);

            InitializeComponent();
            InitializeDefaults();
        }

        private void InitializeDefaults()
        {
            configPathTextBox.Text = MuConfiguration.DefaultFileName;
            updateOutputTextBox.Text = Path.Combine(Environment.CurrentDirectory, "update");
            manifestPathTextBox.Text = Path.Combine(updateOutputTextBox.Text, "update.txt");
            includeThemeCheckBox.Checked = true;
            includeDefaultAssetsCheckBox.Checked = true;
            themeRootTextBox.Text = Path.Combine(Environment.CurrentDirectory, "Themes");
            ToggleThemeInputs();
        }

        private void browseConfigButton_Click(object sender, EventArgs e)
        {
            configSaveFileDialog.FileName = Path.GetFileName(configPathTextBox.Text);
            configSaveFileDialog.InitialDirectory = GetInitialDirectory(configPathTextBox.Text);
            if (configSaveFileDialog.ShowDialog() == DialogResult.OK)
            {
                configPathTextBox.Text = configSaveFileDialog.FileName;
            }
        }

        private void browseUpdateSourceButton_Click(object sender, EventArgs e)
        {
            folderBrowserDialog.SelectedPath = updateSourceTextBox.Text;
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                updateSourceTextBox.Text = folderBrowserDialog.SelectedPath;
            }
        }

        private void browseUpdateOutputButton_Click(object sender, EventArgs e)
        {
            folderBrowserDialog.SelectedPath = updateOutputTextBox.Text;
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                updateOutputTextBox.Text = folderBrowserDialog.SelectedPath;
            }
        }

        private void browseManifestButton_Click(object sender, EventArgs e)
        {
            manifestSaveFileDialog.FileName = Path.GetFileName(manifestPathTextBox.Text);
            manifestSaveFileDialog.InitialDirectory = GetInitialDirectory(manifestPathTextBox.Text);
            if (manifestSaveFileDialog.ShowDialog() == DialogResult.OK)
            {
                manifestPathTextBox.Text = manifestSaveFileDialog.FileName;
            }
        }

        private void browseThemeRootButton_Click(object sender, EventArgs e)
        {
            folderBrowserDialog.SelectedPath = themeRootTextBox.Text;
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                themeRootTextBox.Text = folderBrowserDialog.SelectedPath;
            }
        }

        private void includeThemeCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            ToggleThemeInputs();
        }

        private void ToggleThemeInputs()
        {
            var enabled = includeThemeCheckBox.Checked;
            themeRootTextBox.Enabled = enabled;
            browseThemeRootButton.Enabled = enabled;
            includeDefaultAssetsCheckBox.Enabled = enabled;
        }

        private void syncButton_Click(object sender, EventArgs e)
        {
            updateSourceTextBox.Text = _updateControl.SelectedPath ?? updateSourceTextBox.Text;
            includeDefaultAssetsCheckBox.Checked = _designControl.IncludeDefaults;
            if (!string.IsNullOrWhiteSpace(_designControl.TargetDirectory))
            {
                themeRootTextBox.Text = _designControl.TargetDirectory;
            }

            statusLabel.Text = "Dados sincronizados das abas.";
        }

        private void runButton_Click(object sender, EventArgs e)
        {
            try
            {
                runButton.Enabled = false;
                syncButton.Enabled = false;
                manifestProgressBar.Value = 0;
                logTextBox.Clear();
                statusLabel.Text = "Executando fluxo...";

                var options = BuildOptionsFromInputs();
                var progress = new Progress<ManifestProgress>(ReportProgress);
                var result = _pipeline.Run(options, progress);

                logTextBox.AppendText($"Manifesto salvo em: {result.ManifestPath}{Environment.NewLine}");
                if (!string.IsNullOrEmpty(result.ThemeManifestPath))
                {
                    logTextBox.AppendText($"Tema exportado para: {result.ThemeManifestPath}{Environment.NewLine}");
                }

                _configControl.SaveConfiguration(options.ConfigurationPath);
                statusLabel.Text = $"Fluxo concluído. {result.Manifest.Entries.Count} arquivos listados.";
            }
            catch (Exception ex)
            {
                statusLabel.Text = "Falha na automação: " + ex.Message;
            }
            finally
            {
                runButton.Enabled = true;
                syncButton.Enabled = true;
            }
        }

        private BuildPipelineOptions BuildOptionsFromInputs()
        {
            var updateSource = updateSourceTextBox.Text.Trim();
            if (string.IsNullOrWhiteSpace(updateSource) && _updateControl.SelectedPath != null)
            {
                updateSource = _updateControl.SelectedPath;
            }

            if (string.IsNullOrWhiteSpace(updateSource))
            {
                throw new InvalidOperationException("Selecione uma pasta de origem para o gerador de updates.");
            }

            var configuration = _configControl.GetConfiguration();
            var configurationPath = configPathTextBox.Text.Trim();
            if (string.IsNullOrWhiteSpace(configurationPath))
            {
                configurationPath = MuConfiguration.DefaultFileName;
            }

            var updateOutput = updateOutputTextBox.Text.Trim();
            if (string.IsNullOrWhiteSpace(updateOutput))
            {
                updateOutput = Path.Combine(Environment.CurrentDirectory, "update");
            }

            var manifestPath = manifestPathTextBox.Text.Trim();
            if (string.IsNullOrWhiteSpace(manifestPath))
            {
                manifestPath = Path.Combine(updateOutput, "update.txt");
            }

            var options = new BuildPipelineOptions
            {
                Configuration = configuration,
                ConfigurationPath = configurationPath,
                UpdateSourcePath = updateSource,
                UpdateOutputDirectory = updateOutput,
                ManifestPath = manifestPath,
                CreateThemePackage = includeThemeCheckBox.Checked,
                IncludeDefaultThemeAssets = includeDefaultAssetsCheckBox.Checked
            };

            if (options.CreateThemePackage)
            {
                var root = themeRootTextBox.Text.Trim();
                var manifest = _designControl.GetManifest();
                var themeDirectory = _designControl.GetThemeDirectory(root);
                options.ThemeManifest = manifest;
                options.ThemeName = manifest.Name;
                options.ThemeOutputDirectory = themeDirectory;

                if (options.IncludeDefaultThemeAssets)
                {
                    var baseRoot = root;
                    options.DefaultThemeExporter = (directory, themeManifest) =>
                    {
                        var result = _designControl.CreateThemePackage(baseRoot, includeDefaultAssetsCheckBox.Checked);
                        return Path.Combine(result.Directory, ThemeManifest.ManifestFileName);
                    };
                }
            }

            return options;
        }

        private void ReportProgress(ManifestProgress progress)
        {
            var percentage = Math.Max(manifestProgressBar.Minimum, Math.Min(manifestProgressBar.Maximum, progress.Percentage));
            manifestProgressBar.Value = percentage;
            logTextBox.AppendText(progress.Entry.ToManifestLine() + Environment.NewLine);
        }

        private static string GetInitialDirectory(string path)
        {
            if (string.IsNullOrWhiteSpace(path))
            {
                return Environment.CurrentDirectory;
            }

            try
            {
                var directory = Path.GetDirectoryName(path);
                return string.IsNullOrEmpty(directory) ? Environment.CurrentDirectory : directory;
            }
            catch
            {
                return Environment.CurrentDirectory;
            }
        }
    }
}
