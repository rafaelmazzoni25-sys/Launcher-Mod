using System;
using System.IO;
using System.Windows.Forms;
using LauncherSuite.Core.Configuration;

namespace ConfigGenerator
{
    public partial class ConfigGeneratorControl : UserControl
    {
        private MuConfiguration _configuration;

        public ConfigGeneratorControl()
        {
            InitializeComponent();
            _configuration = MuConfiguration.Load();
            BindConfigurationToUi(_configuration);
        }

        private void Save_Click(object sender, EventArgs e)
        {
            try
            {
                SaveConfiguration();
                MessageBox.Show("Created mu.ini", "NOTICE");
            }
            catch (IOException ex)
            {
                MessageBox.Show($"Failed to save configuration: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public MuConfiguration GetConfiguration()
        {
            UpdateConfigurationFromUi();
            return _configuration;
        }

        public void LoadConfiguration(MuConfiguration configuration)
        {
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
            BindConfigurationToUi(_configuration);
        }

        public void SaveConfiguration(string? path = null)
        {
            UpdateConfigurationFromUi();
            _configuration.Save(path ?? MuConfiguration.DefaultFileName);
        }

        private void BindConfigurationToUi(MuConfiguration configuration)
        {
            comboBox1.SelectedIndex = ClampIndex(configuration.SeasonIndex, comboBox1.Items.Count);
            comboBox2.SelectedIndex = ClampIndex(configuration.LanguageIndex, comboBox2.Items.Count);
            txtboxName.Text = configuration.LauncherName;
            textBoxUrl1.Text = configuration.UpdateUrl;
            textBoxExe.Text = configuration.ExecutableName;
            textBoxUrl2.Text = configuration.PageUrl;
        }

        private void UpdateConfigurationFromUi()
        {
            _configuration.SeasonIndex = comboBox1.SelectedIndex;
            _configuration.LanguageIndex = comboBox2.SelectedIndex;
            _configuration.LauncherName = txtboxName.Text;
            _configuration.UpdateUrl = textBoxUrl1.Text;
            _configuration.ExecutableName = textBoxExe.Text;
            _configuration.PageUrl = textBoxUrl2.Text;
        }

        private static int ClampIndex(int value, int count)
        {
            if (count <= 0)
            {
                return -1;
            }

            if (value < 0)
            {
                return 0;
            }

            if (value >= count)
            {
                return count - 1;
            }

            return value;
        }

        private void Url_Click(object sender, EventArgs e)
        {
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
        }
    }
}
