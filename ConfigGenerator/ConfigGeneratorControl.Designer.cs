using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace ConfigGenerator
{
    partial class ConfigGeneratorControl
    {
        private Label S12;
        private Label Url;
        private TextBox textBoxUrl1;
        private ComboBox comboBox1;
        private Button Save;
        private Label label2;
        private TextBox txtboxName;
        private Label label3;
        private TextBox textBoxExe;
        private Label label4;
        private TextBox textBoxUrl2;
        private Label label1;
        private ComboBox comboBox2;
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
            S12 = new Label();
            Url = new Label();
            textBoxUrl1 = new TextBox();
            comboBox1 = new ComboBox();
            Save = new Button();
            label2 = new Label();
            txtboxName = new TextBox();
            label3 = new Label();
            textBoxExe = new TextBox();
            label4 = new Label();
            textBoxUrl2 = new TextBox();
            label1 = new Label();
            comboBox2 = new ComboBox();
            SuspendLayout();
            // 
            // S12
            // 
            S12.AutoSize = true;
            S12.Location = new Point(9, 14);
            S12.Name = "S12";
            S12.Size = new Size(74, 13);
            S12.TabIndex = 0;
            S12.Text = "Client Version:";
            // 
            // Url
            // 
            Url.AutoSize = true;
            Url.Location = new Point(9, 41);
            Url.Name = "Url";
            Url.Size = new Size(61, 13);
            Url.TabIndex = 2;
            Url.Text = "Update Url:";
            Url.Click += Url_Click;
            // 
            // textBoxUrl1
            // 
            textBoxUrl1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            textBoxUrl1.Location = new Point(112, 38);
            textBoxUrl1.Name = "textBoxUrl1";
            textBoxUrl1.Size = new Size(237, 20);
            textBoxUrl1.TabIndex = 3;
            textBoxUrl1.Text = "http://127.0.0.1/update/";
            // 
            // comboBox1
            // 
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "Season 6", "Season 12" });
            comboBox1.Location = new Point(112, 11);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(121, 21);
            comboBox1.TabIndex = 1;
            // 
            // Save
            // 
            Save.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            Save.Location = new Point(274, 169);
            Save.Name = "Save";
            Save.Size = new Size(75, 23);
            Save.TabIndex = 12;
            Save.Text = "Generate";
            Save.UseVisualStyleBackColor = true;
            Save.Click += Save_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(9, 68);
            label2.Name = "label2";
            label2.Size = new Size(83, 13);
            label2.TabIndex = 4;
            label2.Text = "Launcher Name:";
            // 
            // txtboxName
            // 
            txtboxName.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtboxName.Location = new Point(112, 65);
            txtboxName.Name = "txtboxName";
            txtboxName.Size = new Size(237, 20);
            txtboxName.TabIndex = 5;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(9, 94);
            label3.Name = "label3";
            label3.Size = new Size(97, 13);
            label3.TabIndex = 6;
            label3.Text = "Launcher EXE file:";
            // 
            // textBoxExe
            // 
            textBoxExe.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            textBoxExe.Location = new Point(112, 91);
            textBoxExe.Name = "textBoxExe";
            textBoxExe.Size = new Size(237, 20);
            textBoxExe.TabIndex = 7;
            textBoxExe.Text = "main.exe";
            textBoxExe.TextChanged += textBox3_TextChanged;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(9, 120);
            label4.Name = "label4";
            label4.Size = new Size(92, 13);
            label4.TabIndex = 8;
            label4.Text = "Launcher News Url:";
            // 
            // textBoxUrl2
            // 
            textBoxUrl2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            textBoxUrl2.Location = new Point(112, 117);
            textBoxUrl2.Name = "textBoxUrl2";
            textBoxUrl2.Size = new Size(237, 20);
            textBoxUrl2.TabIndex = 9;
            textBoxUrl2.Text = "http://127.0.0.1/update/index.php";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(9, 146);
            label1.Name = "label1";
            label1.Size = new Size(96, 13);
            label1.TabIndex = 10;
            label1.Text = "Launcher Language:";
            // 
            // comboBox2
            // 
            comboBox2.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox2.FormattingEnabled = true;
            comboBox2.Items.AddRange(new object[] { "Auto", "English", "Spanish", "Portuguese" });
            comboBox2.Location = new Point(112, 143);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new Size(121, 21);
            comboBox2.TabIndex = 11;
            // 
            // ConfigGeneratorControl
            // 
            AutoScaleDimensions = new SizeF(6F, 13F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(comboBox2);
            Controls.Add(label1);
            Controls.Add(textBoxUrl2);
            Controls.Add(label4);
            Controls.Add(textBoxExe);
            Controls.Add(label3);
            Controls.Add(txtboxName);
            Controls.Add(label2);
            Controls.Add(Save);
            Controls.Add(comboBox1);
            Controls.Add(textBoxUrl1);
            Controls.Add(Url);
            Controls.Add(S12);
            Name = "ConfigGeneratorControl";
            Size = new Size(362, 205);
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
