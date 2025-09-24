using System.Windows.Forms;
using ConfigGenerator;
using Update.Maker;

namespace LauncherSuite.App
{
    public partial class MainForm : Form
    {
        private readonly ConfigGeneratorControl _configControl;
        private readonly UpdateGeneratorControl _updateControl;
        private readonly DesignManagerControl _designControl;
        private readonly BuildWorkflowControl _buildControl;

        public MainForm()
        {
            InitializeComponent();
            _configControl = new ConfigGeneratorControl { Dock = DockStyle.Fill };
            _updateControl = new UpdateGeneratorControl { Dock = DockStyle.Fill };
            _designControl = new DesignManagerControl { Dock = DockStyle.Fill };
            configTabPage.Controls.Add(_configControl);
            updatesTabPage.Controls.Add(_updateControl);
            designTabPage.Controls.Add(_designControl);

            _buildControl = new BuildWorkflowControl(_configControl, _updateControl, _designControl)
            {
                Dock = DockStyle.Fill
            };

            buildTabPage.Controls.Add(_buildControl);
        }
    }
}
