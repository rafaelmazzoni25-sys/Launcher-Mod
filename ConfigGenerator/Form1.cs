using System.Windows.Forms;

namespace ConfigGenerator
{
    public sealed class Form1 : Form
    {
        public Form1()
        {
            Text = "Config Generator";
            StartPosition = FormStartPosition.CenterScreen;
            Width = 640;
            Height = 480;

            var control = new ConfigGeneratorControl
            {
                Dock = DockStyle.Fill
            };

            Controls.Add(control);
        }
    }
}
