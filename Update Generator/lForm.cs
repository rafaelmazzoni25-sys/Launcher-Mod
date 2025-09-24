using System;
using System.ComponentModel;
using System.IO;
using System.Windows.Forms;

namespace Update.Maker
{
    public partial class lForm : Form
    {
        private readonly UpdateManifestBuilder _manifestBuilder = new UpdateManifestBuilder();
        private ManifestBuildResult _lastBuild = new ManifestBuildResult(Array.Empty<UpdateManifestEntry>());
        private string _selectedPath = string.Empty;

        public lForm()
        {
            InitializeComponent();
        }

        private void browseButton_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            _selectedPath = folderBrowserDialog.SelectedPath;
            filePath.Text = NormalizePath(_selectedPath);
            BeginBuild();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            SaveManifest();
        }

        private void removeButton_Click(object sender, EventArgs e)
        {
            ClearSelection();
        }

        private void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            var path = (string)e.Argument;
            var updateDirectory = Path.Combine(Directory.GetCurrentDirectory(), "update");
            var progress = new Progress<ManifestProgress>(p => backgroundWorker.ReportProgress(p.Percentage, p));
            Directory.CreateDirectory(updateDirectory);
            e.Result = _manifestBuilder.Build(path, updateDirectory, progress);
        }

        private void backgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if (e.UserState is ManifestProgress progress)
            {
                UpdateProgress(progress);
            }
        }

        private void backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            EnableButtons();

            if (e.Error != null)
            {
                Result.Clear();
                MessageBox.Show($"Failed to generate update list: {e.Error.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (e.Result is ManifestBuildResult buildResult)
            {
                _lastBuild = buildResult;
            }
        }

        private void BeginBuild()
        {
            if (string.IsNullOrEmpty(_selectedPath))
            {
                return;
            }

            if (backgroundWorker.IsBusy)
            {
                return;
            }

            DisableButtons();
            Result.Clear();
            Progress.Value = 0;
            backgroundWorker.RunWorkerAsync(_selectedPath);
        }

        private void UpdateProgress(ManifestProgress progress)
        {
            Result.AppendText(progress.Entry.ToManifestLine() + Environment.NewLine);
            Progress.Value = Clamp(progress.Percentage, 0, 100);
        }

        private void SaveManifest()
        {
            if (_lastBuild.Entries.Count == 0)
            {
                MessageBox.Show("Nothing to save. Generate the manifest first.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            saveFileDialog.FileName = "update.txt";
            saveFileDialog.InitialDirectory = Path.Combine(Directory.GetCurrentDirectory(), "update");
            saveFileDialog.RestoreDirectory = true;
            saveFileDialog.Filter = "Text files (*.txt)|*.txt|Every file (*.*)|*.*";

            if (saveFileDialog.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            File.WriteAllText(saveFileDialog.FileName, _lastBuild.ToManifestText());
        }

        private void ClearSelection()
        {
            _selectedPath = string.Empty;
            filePath.Clear();
            Result.Clear();
            Progress.Value = 0;
            _lastBuild = new ManifestBuildResult(Array.Empty<UpdateManifestEntry>());
            DisableSaveButtons();
        }

        private void DisableButtons()
        {
            browseButton.Enabled = false;
            DisableSaveButtons();
        }

        private void EnableButtons()
        {
            browseButton.Enabled = true;
            saveButton.Enabled = _lastBuild.Entries.Count > 0;
            removeButton.Enabled = !string.IsNullOrEmpty(_selectedPath);
        }

        private void DisableSaveButtons()
        {
            saveButton.Enabled = false;
            removeButton.Enabled = false;
        }

        private static int Clamp(int value, int min, int max) => Math.Max(min, Math.Min(max, value));

        private static string NormalizePath(string path) => path.Replace("\\", "/");

        private void filePath_TextChanged(object sender, EventArgs e)
        {
        }

        private void Progress_Click(object sender, EventArgs e)
        {
        }
    }
}
