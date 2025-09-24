using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Update.Maker
{
    public partial class lForm
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
            var componentResourceManager = new ComponentResourceManager(typeof(lForm));
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
            Progress.Location = new Point(224, 305);
            Progress.Name = "Progress";
            Progress.Size = new Size(457, 19);
            Progress.TabIndex = 2;
            Progress.Click += Progress_Click;
            // 
            // saveButton
            // 
            saveButton.Enabled = false;
            saveButton.Location = new Point(25, 92);
            saveButton.Name = "saveButton";
            saveButton.Size = new Size(154, 44);
            saveButton.TabIndex = 3;
            saveButton.Text = "2. Save List";
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
            filePath.Location = new Point(25, 227);
            filePath.MaxLength = 256;
            filePath.Name = "filePath";
            filePath.Size = new Size(154, 20);
            filePath.TabIndex = 4;
            filePath.Visible = false;
            filePath.TextChanged += filePath_TextChanged;
            // 
            // removeButton
            // 
            removeButton.Enabled = false;
            removeButton.Location = new Point(71, 253);
            removeButton.Name = "removeButton";
            removeButton.Size = new Size(58, 23);
            removeButton.TabIndex = 5;
            removeButton.Text = "Remove";
            removeButton.UseVisualStyleBackColor = true;
            removeButton.Visible = false;
            removeButton.Click += removeButton_Click;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(groupBox2);
            groupBox1.Controls.Add(Result);
            groupBox1.Controls.Add(removeButton);
            groupBox1.Controls.Add(saveButton);
            groupBox1.Controls.Add(Progress);
            groupBox1.Controls.Add(browseButton);
            groupBox1.Controls.Add(filePath);
            groupBox1.Location = new Point(15, 5);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(703, 332);
            groupBox1.TabIndex = 100;
            groupBox1.TabStop = false;
            // 
            // groupBox2
            // 
            groupBox2.Location = new Point(203, 10);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(5, 314);
            groupBox2.TabIndex = 6;
            groupBox2.TabStop = false;
            // 
            // lForm
            // 
            AutoScaleDimensions = new SizeF(6F, 13F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(730, 349);
            Controls.Add(groupBox1);
            Icon = (Icon)componentResourceManager.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "lForm";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Update Generator";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }
    }
}
