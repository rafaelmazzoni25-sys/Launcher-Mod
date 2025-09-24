using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Update.Maker
{
    partial class UpdateGeneratorControl
    {
        private TextBox Result;
        private Button browseButton;
        private ProgressBar Progress;
        private Button saveButton;
        private BackgroundWorker backgroundWorker;
        private FolderBrowserDialog folderBrowserDialog;
        private TextBox filePath;
        private Button removeButton;
        private SaveFileDialog saveFileDialog;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
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
            Result = new TextBox();
            browseButton = new Button();
            Progress = new ProgressBar();
            saveButton = new Button();
            backgroundWorker = new BackgroundWorker();
            components.Add(backgroundWorker);
            folderBrowserDialog = new FolderBrowserDialog();
            filePath = new TextBox();
            removeButton = new Button();
            saveFileDialog = new SaveFileDialog();
            groupBox1 = new GroupBox();
            groupBox2 = new GroupBox();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // Result
            // 
            Result.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            Result.BorderStyle = BorderStyle.FixedSingle;
            Result.Font = new Font("Microsoft Sans Serif", 8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Result.Location = new Point(224, 19);
            Result.Multiline = true;
            Result.Name = "Result";
            Result.ScrollBars = ScrollBars.Vertical;
            Result.Size = new Size(473, 280);
            Result.TabIndex = 0;
            // 
            // browseButton
            // 
            browseButton.Location = new Point(25, 28);
            browseButton.Name = "browseButton";
            browseButton.Size = new Size(154, 47);
            browseButton.TabIndex = 1;
            browseButton.Text = "1. Select Folder";
            browseButton.UseVisualStyleBackColor = true;
            browseButton.Click += browseButton_Click;
            // 
            // Progress
            // 
            Progress.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            Progress.Location = new Point(224, 305);
            Progress.Name = "Progress";
            Progress.Size = new Size(473, 19);
            Progress.TabIndex = 2;
            Progress.Click += Progress_Click;
            // 
            // saveButton
            // 
            saveButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            saveButton.Enabled = false;
            saveButton.Location = new Point(25, 265);
            saveButton.Name = "saveButton";
            saveButton.Size = new Size(154, 47);
            saveButton.TabIndex = 3;
            saveButton.Text = "3. Save Manifest";
            saveButton.UseVisualStyleBackColor = true;
            saveButton.Click += saveButton_Click;
            // 
            // backgroundWorker
            // 
            backgroundWorker.WorkerReportsProgress = true;
            backgroundWorker.DoWork += backgroundWorker_DoWork;
            backgroundWorker.ProgressChanged += backgroundWorker_ProgressChanged;
            backgroundWorker.RunWorkerCompleted += backgroundWorker_RunWorkerCompleted;
            // 
            // filePath
            // 
            filePath.BorderStyle = BorderStyle.FixedSingle;
            filePath.Location = new Point(25, 31);
            filePath.Name = "filePath";
            filePath.ReadOnly = true;
            filePath.Size = new Size(488, 20);
            filePath.TabIndex = 0;
            filePath.TextChanged += filePath_TextChanged;
            // 
            // removeButton
            // 
            removeButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            removeButton.Enabled = false;
            removeButton.Location = new Point(25, 195);
            removeButton.Name = "removeButton";
            removeButton.Size = new Size(154, 47);
            removeButton.TabIndex = 2;
            removeButton.Text = "2. Clear";
            removeButton.UseVisualStyleBackColor = true;
            removeButton.Click += removeButton_Click;
            // 
            // groupBox1
            // 
            groupBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            groupBox1.Controls.Add(saveButton);
            groupBox1.Controls.Add(removeButton);
            groupBox1.Controls.Add(browseButton);
            groupBox1.Location = new Point(14, 77);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(195, 332);
            groupBox1.TabIndex = 4;
            groupBox1.TabStop = false;
            groupBox1.Text = "Steps";
            // 
            // groupBox2
            // 
            groupBox2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            groupBox2.Controls.Add(filePath);
            groupBox2.Location = new Point(14, 8);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(705, 63);
            groupBox2.TabIndex = 5;
            groupBox2.TabStop = false;
            groupBox2.Text = "Selected Folder";
            // 
            // UpdateGeneratorControl
            // 
            AutoScaleDimensions = new SizeF(6F, 13F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Controls.Add(Progress);
            Controls.Add(Result);
            Name = "UpdateGeneratorControl";
            Size = new Size(736, 428);
            groupBox1.ResumeLayout(false);
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
