using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Launcher.Design;
using LauncherSuite.Core.Design;

namespace LauncherSuite.App
{
    public partial class DesignManagerControl : UserControl
    {
        public DesignManagerControl()
        {
            InitializeComponent();
        }

        private void BrowseButton_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(outputPathTextBox.Text))
            {
                folderBrowserDialog.SelectedPath = outputPathTextBox.Text;
            }

            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                outputPathTextBox.Text = folderBrowserDialog.SelectedPath;
            }
        }

        private void CreateButton_Click(object sender, EventArgs e)
        {
            try
            {
                CreateThemePackage();
            }
            catch (Exception ex)
            {
                statusLabel.Text = "Erro ao criar tema: " + ex.Message;
            }
        }

        private void CreateThemePackage()
        {
            var themeName = themeNameTextBox.Text.Trim();
            if (string.IsNullOrEmpty(themeName))
            {
                throw new InvalidOperationException("Informe um nome para o tema.");
            }

            if (string.IsNullOrWhiteSpace(outputPathTextBox.Text))
            {
                throw new InvalidOperationException("Selecione um diretório de destino.");
            }

            var sanitizedThemeName = string.Concat(themeName.Split(Path.GetInvalidFileNameChars()))
                .Trim();
            if (string.IsNullOrEmpty(sanitizedThemeName))
            {
                throw new InvalidOperationException("O nome do tema contém caracteres inválidos.");
            }

            var manifest = ThemeManifest.CreateDefault(themeName);
            manifest.Author = authorTextBox.Text.Trim();
            manifest.Version = versionTextBox.Text.Trim();
            manifest.Description = descriptionTextBox.Text.Trim();
            manifest.SeasonCompatibility = compatibilityTextBox.Text.Trim();

            var targetDirectory = Path.Combine(outputPathTextBox.Text, sanitizedThemeName);
            if (Directory.Exists(targetDirectory) && Directory.EnumerateFileSystemEntries(targetDirectory).Any())
            {
                throw new InvalidOperationException("O diretório selecionado já contém arquivos. Escolha uma pasta vazia.");
            }

            if (includeDefaultsCheckBox.Checked)
            {
                ThemeManager.ExportBuiltinAssets(targetDirectory, manifest);
                statusLabel.Text = "Tema criado com os assets padrão.";
            }
            else
            {
                CreateSkeleton(targetDirectory, manifest);
                statusLabel.Text = "Estrutura do tema criada. Adicione suas imagens e edite o theme.xml.";
            }
        }

        private static void CreateSkeleton(string targetDirectory, ThemeManifest manifest)
        {
            Directory.CreateDirectory(targetDirectory);
            var assets = manifest.Assets ?? Array.Empty<ThemeAsset>();
            foreach (var asset in assets)
            {
                var assetPath = Path.Combine(targetDirectory, asset.RelativePath);
                var folder = Path.GetDirectoryName(assetPath);
                if (!string.IsNullOrEmpty(folder))
                {
                    Directory.CreateDirectory(folder);
                }
            }

            manifest.Save(targetDirectory);
        }
    }
}
