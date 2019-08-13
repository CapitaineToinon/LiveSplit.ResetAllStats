using System;
using System.Reflection;
using System.Windows.Forms;
using System.Xml;

namespace LiveSplit.ResetAllStats.UI
{
    public partial class RASSettings : UserControl
    {
        private const uint DEFAULT_APP_ID = 0;

        public uint AppId { get; set; }

        public RASSettings()
        {
            InitializeComponent();
            this.Dock = DockStyle.Fill;

            this.numAppID.Minimum = UInt32.MinValue;
            this.numAppID.Maximum = UInt32.MaxValue;
            this.numAppID.DataBindings.Add("Value", this, nameof(AppId), false, DataSourceUpdateMode.OnPropertyChanged);
            this.AppId = DEFAULT_APP_ID;
            this.lblVersion.Text = Assembly.GetExecutingAssembly().GetName().Version.ToString();
            this.linkStreamDB.Click += LinkStreamDB_Click;
        }

        private void LinkStreamDB_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://steamdb.info");
        }

        public XmlNode GetSettings(XmlDocument document)
        {
            XmlElement settingsNode = document.CreateElement("Settings");
            settingsNode.AppendChild(ToElement(document, nameof(this.AppId), this.AppId));
            return settingsNode;
        }

        public void SetSettings(XmlNode settings)
        {
            this.AppId = settings[nameof(this.AppId)] != null 
                ? Convert.ToUInt32(settings[nameof(this.AppId)].InnerText)
                : DEFAULT_APP_ID;
        }

        static XmlElement ToElement<T>(XmlDocument document, string name, T value)
        {
            XmlElement str = document.CreateElement(name);
            str.InnerText = value.ToString();
            return str;
        }
    }
}
