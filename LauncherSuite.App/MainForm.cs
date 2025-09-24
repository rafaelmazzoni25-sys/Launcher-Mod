using System;
using System.Windows.Forms;
using ConfigGenerator;
using Update.Maker;

namespace LauncherSuite.App
{
    public partial class MainForm : Form
    {
        private readonly Form _configGeneratorForm;
        private readonly Form _updateGeneratorForm;

        public MainForm()
        {
            InitializeComponent();
            _configGeneratorForm = new Form1();
            _updateGeneratorForm = new lForm();
            EmbedModule(_configGeneratorForm, configTabPage);
            EmbedModule(_updateGeneratorForm, updatesTabPage);
            var designManager = new DesignManagerControl { Dock = DockStyle.Fill };
            designTabPage.Controls.Add(designManager);
        }

        private static void EmbedModule(Form module, TabPage host)
        {
            module.TopLevel = false;
            module.FormBorderStyle = FormBorderStyle.None;
            module.Dock = DockStyle.Fill;
            host.Controls.Add(module);
            module.Show();
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            base.OnFormClosed(e);
            DisposeModule(_configGeneratorForm);
            DisposeModule(_updateGeneratorForm);
        }

        private static void DisposeModule(Form module)
        {
            if (module == null)
            {
                return;
            }

            if (!module.IsDisposed)
            {
                module.Dispose();
            }
        }
    }
}
