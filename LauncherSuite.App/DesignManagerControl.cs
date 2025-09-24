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

        public string ThemeName => themeNameTextBox.Text.Trim();

        public string TargetDirectory => outputPathTextBox.Text.Trim();

        public bool IncludeDefaults => includeDefaultsCheckBox.Checked;

        public ThemeManifest GetManifest()
        {
            var manifest = ThemeManifest.CreateDefault(ThemeName);
            manifest.Author = authorTextBox.Text.Trim();
            manifest.Version = versionTextBox.Text.Trim();
            manifest.Description = descriptionTextBox.Text.Trim();
            manifest.SeasonCompatibility = compatibilityTextBox.Text.Trim();
            return manifest;
        }

        public ThemeCreationResult CreateThemePackage()
        {
            return CreateThemePackage(TargetDirectory, IncludeDefaults);
        }

        public ThemeCreationResult CreateThemePackage(string targetDirectory, bool includeDefaults)
        {
            var themeName = ThemeName;
            if (string.IsNullOrEmpty(themeName))
            {
                throw new InvalidOperationException("Informe um nome para o tema.");
            }

            if (string.IsNullOrWhiteSpace(targetDirectory))
            {
                throw new InvalidOperationException("Selecione um diretório de destino.");
            }

            var sanitizedThemeName = string.Concat(themeName.Split(Path.GetInvalidFileNameChars()))
                .Trim();
            if (string.IsNullOrEmpty(sanitizedThemeName))
            {
                throw new InvalidOperationException("O nome do tema contém caracteres inválidos.");
            }

            var manifest = GetManifest();
            var fullDirectory = Path.Combine(targetDirectory, sanitizedThemeName);
            if (Directory.Exists(fullDirectory) && Directory.EnumerateFileSystemEntries(fullDirectory).Any())
            {
                throw new InvalidOperationException("O diretório selecionado já contém arquivos. Escolha uma pasta vazia.");
            }

            if (includeDefaults)
            {
                ThemeManager.ExportBuiltinAssets(fullDirectory, manifest);
                statusLabel.Text = "Tema criado com os assets padrão.";
            }
            else
            {
                CreateSkeleton(fullDirectory, manifest);
                statusLabel.Text = "Estrutura do tema criada. Adicione suas imagens e edite o theme.xml.";
            }

            return new ThemeCreationResult(fullDirectory, manifest);
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

        public string GetThemeDirectory(string rootDirectory)
        {
            if (string.IsNullOrWhiteSpace(rootDirectory))
            {
                throw new InvalidOperationException("Selecione um diretório de destino.");
            }

            var themeName = ThemeName;
            if (string.IsNullOrEmpty(themeName))
            {
                throw new InvalidOperationException("Informe um nome para o tema.");
            }

            var sanitizedThemeName = string.Concat(themeName.Split(Path.GetInvalidFileNameChars())).Trim();
            if (string.IsNullOrEmpty(sanitizedThemeName))
            {
                throw new InvalidOperationException("O nome do tema contém caracteres inválidos.");
            }

            return Path.Combine(rootDirectory, sanitizedThemeName);
        }
    }

    public sealed record ThemeCreationResult(string Directory, ThemeManifest Manifest);
}
