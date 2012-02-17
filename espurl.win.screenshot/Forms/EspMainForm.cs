using System.Windows.Forms;
using Greenshot;

namespace espurl.win.screenshot.Forms
{
	public partial class EspMainForm : Form
	{
		public EspMainForm()
		{
			InitializeComponent();
			InitializeApplication();
		}

		private void InitializeApplication()
		{
			
		}

		public static void Start(string[] args)
		{
			MainForm.Start(args);
		}

		private void contextmenu_settings_Click(object sender, System.EventArgs e)
		{
			(new SettingsForm()).ShowDialog();
		}

	}
}
