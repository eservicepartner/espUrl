using espurl.win.screenshot.Properties;

namespace espurl.win.screenshot.Infrastructure
{
	class SettingsManager
	{
		private AutoStart _autoStart;

		public void Init()
		{
			_autoStart = new AutoStart("espUrl", System.Reflection.Assembly.GetExecutingAssembly().Location);
			Settings.Default.AutostartWithWindows = _autoStart.IsEnabled();
		}

		public void DetermineSettings()
		{
			Settings.Default.AutostartWithWindows = _autoStart.IsEnabled();
		}

		public void ApplySettings()
		{
			_autoStart.SetEnabled(Settings.Default.AutostartWithWindows);
		}
	}
}
