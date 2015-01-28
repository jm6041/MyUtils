using System;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Text.RegularExpressions;
using System.Web.Configuration;
using System.Windows.Forms;

namespace ProtectConfig
{
    public partial class MainForm : Form
    {
        public static readonly string DefaultSection = "connectionStrings";
        public static readonly string CurDir = Path.GetDirectoryName(Process.GetCurrentProcess().MainModule.FileName);

        private Configuration config;

        public MainForm()
        {
            InitializeComponent();
            InitTextBox();
            InitToolTip();
        }

        private void InitToolTip()
        {
            this.toolTip.SetToolTip(this.textFile, this.textFile.Text);
            this.toolTip.SetToolTip(this.textSection, this.textSection.Text);
        }

        private void InitTextBox()
        {
            textSection.Text = DefaultSection;
        }

        private void btnFindFile_Click(object sender, EventArgs e)
        {
            string file = textFile.Text.Trim();
            if (IsValideConfigFile(file))
            {
                string dir = Path.GetDirectoryName(file);
                if (Directory.Exists(dir))
                {
                    openFileDialog.InitialDirectory = dir;
                }
            }
            openFileDialog.ShowDialog(this);
            textFile.Text = openFileDialog.FileName;
            config = CreateConfig(openFileDialog.FileName, true);
            InitProviderNames(config);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            string[] arr = Directory.GetFiles(CurDir, "*.config");
            if (arr.Length > 0)
            {
                string defaultConfig = arr[0];
                textFile.Text = defaultConfig;
                openFileDialog.FileName = defaultConfig;
                config = CreateConfig(defaultConfig, false);
                InitProviderNames(config);
            }
        }

        private void btnEncrypt_Click(object sender, EventArgs e)
        {
            string sectionName = textSection.Text.Trim();
            if (string.IsNullOrEmpty(sectionName))
            {
                textBoxError.Text = "请填写Section";
            }

            string providerName = cBProviderNames.SelectedItem as string;
            if (string.IsNullOrEmpty(providerName))
            {
                textBoxError.Text = "请选择加密提供程序";
            }

            ConfigurationSection section = config.GetSection(sectionName);
            if (section == null)
            {
                textBoxError.Text = "没有找到配置文件中包含的块";
            }

            if (section.SectionInformation.IsProtected)
            {
                textBoxError.Text = "配置文件的所选块除以保护中，不需要加密";
            }
            else
            {
                section.SectionInformation.ProtectSection(providerName);
                config.Save();
                textBoxError.Text = "加密成功";
            }
        }

        private void btnDecrypt_Click(object sender, EventArgs e)
        {
            string sectionName = textSection.Text.Trim();
            if (string.IsNullOrEmpty(sectionName))
            {
                textBoxError.Text = "请填写Section";
            }

            ConfigurationSection section = config.GetSection(sectionName);
            if (section == null)
            {
                textBoxError.Text = "没有找到配置文件中包含的块";
            }

            if (section.SectionInformation.IsProtected)
            {
                section.SectionInformation.UnprotectSection();
                config.Save();
                textBoxError.Text = "解密成功";
            }
        }

        private void InitProviderNames(Configuration config)
        {
            cBProviderNames.Items.Clear();
            if (config == null)
            {
                return;
            }

            ProtectedConfigurationSection pcs = config.GetSection("configProtectedData") as ProtectedConfigurationSection;
            if (pcs == null)
            {
                return;
            }
            foreach (ProviderSettings ps in pcs.Providers)
            {
                cBProviderNames.Items.Add(ps.Name);
            }
            cBProviderNames.SelectedItem = pcs.DefaultProvider;
        }

        private Configuration CreateConfig(string configFullName, bool isShowError)
        {
            textBoxError.Text = "";
            if (!IsValideConfigFile(configFullName) && true == isShowError)
            {
                textBoxError.Text = "配置文件非法，不能创建Configuration对象，无法进行操作。 ";
                return null;
            }
            try
            {
                btnEncrypt.Enabled = true;
                btnDecrypt.Enabled = true;
                if (string.Equals(Path.GetFileName(configFullName), "web.config", StringComparison.OrdinalIgnoreCase))
                {
                    FileInfo configFile = new FileInfo(configFullName);
                    VirtualDirectoryMapping vdm = new VirtualDirectoryMapping(configFile.DirectoryName, true, configFile.Name);
                    WebConfigurationFileMap wcfm = new WebConfigurationFileMap();
                    wcfm.VirtualDirectories.Add("/", vdm);
                    return WebConfigurationManager.OpenMappedWebConfiguration(wcfm, "/");
                }
                string exePath = configFullName.Remove(configFullName.LastIndexOf("."));
                return ConfigurationManager.OpenExeConfiguration(exePath);
            }
            catch (Exception ex)
            {
                if (true == isShowError)
                {
                    textBoxError.Text = "不能创建Configuration对象，无法进行操作。 " + ex.Message;
                }
                btnEncrypt.Enabled = false;
                btnDecrypt.Enabled = false;
            }
            return null;
        }

        private void textFile_TextChanged(object sender, EventArgs e)
        {
            string configFile = this.textFile.Text.Trim();
            if (IsValideConfigFile(configFile))
            {
                this.config = this.CreateConfig(configFile, true);
                InitProviderNames(config);
            }
        }

        /// <summary>
        /// 确定配置文件是否合法
        /// </summary>
        /// <param name="fileName">配置文件名</param>
        /// <returns>如果合法返回true，否则为false</returns>
        private bool IsValideConfigFile(string fileName)
        {
            if (fileName == null)
            {
                return false;
            }
            fileName = fileName.Trim();
            return !string.IsNullOrEmpty(fileName) && IsConfigFile(fileName) && File.Exists(fileName);
        }

        private bool IsConfigFile(string fileName)
        {
            if (fileName == null || string.IsNullOrEmpty(fileName.Trim()))
            {
                return false;
            }
            string p = @".*?\.config$";
            Regex regex = new Regex(p, RegexOptions.IgnoreCase);
            return regex.IsMatch(fileName);
        }
    }
}
