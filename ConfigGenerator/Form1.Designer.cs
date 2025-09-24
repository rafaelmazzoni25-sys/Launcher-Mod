using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace ConfigGenerator
{
    public partial class Form1
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
            var componentResourceManager = new ComponentResourceManager(typeof(Form1));
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
            S12.Location = new Point(9, 41);
            S12.Name = "S12";
            S12.Size = new Size(74, 13);
            S12.TabIndex = 0;
            S12.Text = "Client Version:";
            // 
            // Url
            // 
            Url.AutoSize = true;
            Url.Location = new Point(9, 68);
            Url.Name = "Url";
            Url.Size = new Size(61, 13);
            Url.TabIndex = 2;
            Url.Text = "Update Url:";
            Url.Click += Url_Click;
            // 
            // textBoxUrl1
            // 
            textBoxUrl1.Location = new Point(77, 65);
            textBoxUrl1.Name = "textBoxUrl1";
            textBoxUrl1.Size = new Size(198, 20);
            textBoxUrl1.TabIndex = 3;
            textBoxUrl1.Text = "http://127.0.0.1/update/";
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "Season 6", "Season 9", "Season 12" });
            comboBox1.Location = new Point(99, 38);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(176, 21);
            comboBox1.TabIndex = 4;
            // 
            // Save
            // 
            Save.Location = new Point(99, 169);
            Save.Name = "Save";
            Save.Size = new Size(75, 23);
            Save.TabIndex = 5;
            Save.Text = "Save";
            Save.UseVisualStyleBackColor = true;
            Save.Click += Save_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(9, 15);
            label2.Name = "label2";
            label2.Size = new Size(38, 13);
            label2.TabIndex = 7;
            label2.Text = "Name:";
            // 
            // txtboxName
            // 
            txtboxName.Enabled = false;
            txtboxName.Location = new Point(77, 12);
            txtboxName.Name = "txtboxName";
            txtboxName.Size = new Size(198, 20);
            txtboxName.TabIndex = 8;
            txtboxName.Text = "Mu Launcher";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(9, 120);
            label3.Name = "label3";
            label3.Size = new Size(57, 13);
            label3.TabIndex = 9;
            label3.Text = "Exe name:";
            // 
            // textBoxExe
            // 
            textBoxExe.Location = new Point(77, 117);
            textBoxExe.Name = "textBoxExe";
            textBoxExe.Size = new Size(198, 20);
            textBoxExe.TabIndex = 10;
            textBoxExe.Text = "main.exe";
            textBoxExe.TextChanged += textBox3_TextChanged;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(9, 94);
            label4.Name = "label4";
            label4.Size = new Size(51, 13);
            label4.TabIndex = 11;
            label4.Text = "Page Url:";
            // 
            // textBoxUrl2
            // 
            textBoxUrl2.Location = new Point(77, 91);
            textBoxUrl2.Name = "textBoxUrl2";
            textBoxUrl2.Size = new Size(198, 20);
            textBoxUrl2.TabIndex = 12;
            textBoxUrl2.Text = "http://127.0.0.1/update/index.php";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(9, 145);
            label1.Name = "label1";
            label1.Size = new Size(106, 13);
            label1.TabIndex = 13;
            label1.Text = "Launcher Language:";
            // 
            // comboBox2
            // 
            comboBox2.Enabled = false;
            comboBox2.FormattingEnabled = true;
            comboBox2.Items.AddRange(new object[] { "Auto", "Eng", "Spn", "Por" });
            comboBox2.Location = new Point(121, 142);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new Size(154, 21);
            comboBox2.TabIndex = 14;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(6F, 13F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(287, 201);
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
            Icon = (Icon)componentResourceManager.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "Form1";
            Text = "Launcher Config";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
