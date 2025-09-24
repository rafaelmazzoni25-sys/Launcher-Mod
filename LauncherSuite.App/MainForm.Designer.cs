namespace LauncherSuite.App
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TabControl modulesTabControl;
        private System.Windows.Forms.TabPage configTabPage;
        private System.Windows.Forms.TabPage updatesTabPage;
        private System.Windows.Forms.TabPage designTabPage;

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
            this.modulesTabControl = new System.Windows.Forms.TabControl();
            this.configTabPage = new System.Windows.Forms.TabPage();
            this.updatesTabPage = new System.Windows.Forms.TabPage();
            this.designTabPage = new System.Windows.Forms.TabPage();
            this.modulesTabControl.SuspendLayout();
            this.SuspendLayout();
            // 
            // modulesTabControl
            // 
            this.modulesTabControl.Controls.Add(this.configTabPage);
            this.modulesTabControl.Controls.Add(this.updatesTabPage);
            this.modulesTabControl.Controls.Add(this.designTabPage);
            this.modulesTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.modulesTabControl.Location = new System.Drawing.Point(0, 0);
            this.modulesTabControl.Name = "modulesTabControl";
            this.modulesTabControl.SelectedIndex = 0;
            this.modulesTabControl.Size = new System.Drawing.Size(984, 561);
            this.modulesTabControl.TabIndex = 0;
            // 
            // configTabPage
            // 
            this.configTabPage.Location = new System.Drawing.Point(4, 22);
            this.configTabPage.Name = "configTabPage";
            this.configTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.configTabPage.Size = new System.Drawing.Size(976, 535);
            this.configTabPage.TabIndex = 0;
            this.configTabPage.Text = "Configuração";
            this.configTabPage.UseVisualStyleBackColor = true;
            // 
            // updatesTabPage
            // 
            this.updatesTabPage.Location = new System.Drawing.Point(4, 22);
            this.updatesTabPage.Name = "updatesTabPage";
            this.updatesTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.updatesTabPage.Size = new System.Drawing.Size(976, 535);
            this.updatesTabPage.TabIndex = 1;
            this.updatesTabPage.Text = "Updates";
            this.updatesTabPage.UseVisualStyleBackColor = true;
            // 
            // designTabPage
            // 
            this.designTabPage.Location = new System.Drawing.Point(4, 22);
            this.designTabPage.Name = "designTabPage";
            this.designTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.designTabPage.Size = new System.Drawing.Size(976, 535);
            this.designTabPage.TabIndex = 2;
            this.designTabPage.Text = "Design";
            this.designTabPage.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 561);
            this.Controls.Add(this.modulesTabControl);
            this.MinimumSize = new System.Drawing.Size(800, 500);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Launcher Suite";
            this.modulesTabControl.ResumeLayout(false);
            this.ResumeLayout(false);
        }
    }
}
