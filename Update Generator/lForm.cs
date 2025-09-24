using System.Windows.Forms;

namespace Update.Maker
{
    public sealed class lForm : Form
    {
        public lForm()
        {
            Text = "Update Generator";
            StartPosition = FormStartPosition.CenterScreen;
            Width = 800;
            Height = 600;

            var control = new UpdateGeneratorControl
            {
                Dock = DockStyle.Fill
            };

            Controls.Add(control);
        }
    }
}
