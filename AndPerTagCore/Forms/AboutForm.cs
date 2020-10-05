using System.Windows.Forms;

namespace AndPerTagCore.Forms
{
    public partial class AboutForm : Form
    {
        private readonly WebBrowser webBrowser = new WebBrowser();
        public AboutForm()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, System.EventArgs e)
        {
            webBrowser.Navigate("https://github.com/likefurnis/AndPerTag", true);
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            webBrowser.Navigate("https://www.flaticon.com/authors/freepik", true);
        }

        private void editButtonLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            webBrowser.Navigate("https://www.flaticon.com/authors/becris", true);
        }
    }
}
