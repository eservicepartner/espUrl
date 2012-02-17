using Microsoft.Win32;

namespace espurl.win.screenshot.Infrastructure
{
	public class AutoStart
	{
		private const string RunLocation = @"Software\Microsoft\Windows\CurrentVersion\Run";

		private readonly string _keyName;
		private readonly string _assemblyLocation;

		public AutoStart(string keyName, string assemblyLocation)
		{
			_keyName = keyName;
			_assemblyLocation = assemblyLocation;
		}

		public void Enable()
		{
			RegistryKey key = Registry.CurrentUser.CreateSubKey(RunLocation);

			if (key != null)
				key.SetValue(_keyName, _assemblyLocation);
		}

		public bool IsEnabled()
		{
			RegistryKey key = Registry.CurrentUser.OpenSubKey(RunLocation);

			if (key == null)
				return false;

			var value = (string)key.GetValue(_keyName);

			if (value == null)
				return false;

			return (value == _assemblyLocation);
		}

		public void Disable()
		{
			RegistryKey key = Registry.CurrentUser.CreateSubKey(RunLocation);

			if (key == null)
				return;

			if (key.GetValue(_keyName) != null)
				key.DeleteValue(_keyName);
		}

		public void SetEnabled(bool autostartWithWindows)
		{
			if (autostartWithWindows)
				Enable();
			else
				Disable();
		}
	}
}