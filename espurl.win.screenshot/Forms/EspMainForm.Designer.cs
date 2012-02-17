namespace espurl.win.screenshot.Forms
{
	partial class EspMainForm
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EspMainForm));
			this.backgroundWorkerTimer = new System.Windows.Forms.Timer(this.components);
			this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
			this.contextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.contextmenu_capturearea = new System.Windows.Forms.ToolStripMenuItem();
			this.contextmenu_capturelastregion = new System.Windows.Forms.ToolStripMenuItem();
			this.contextmenu_capturewindow = new System.Windows.Forms.ToolStripMenuItem();
			this.contextmenu_capturefullscreen = new System.Windows.Forms.ToolStripMenuItem();
			this.contextmenu_captureie = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
			this.contextmenu_captureclipboard = new System.Windows.Forms.ToolStripMenuItem();
			this.contextmenu_openfile = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.contextmenu_openrecentcapture = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
			this.contextmenu_quicksettings = new System.Windows.Forms.ToolStripMenuItem();
			this.contextmenu_settings = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
			this.contextmenu_help = new System.Windows.Forms.ToolStripMenuItem();
			this.contextmenu_donate = new System.Windows.Forms.ToolStripMenuItem();
			this.contextmenu_about = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.contextmenu_exit = new System.Windows.Forms.ToolStripMenuItem();
			this.contextMenu.SuspendLayout();
			this.SuspendLayout();
			// 
			// backgroundWorkerTimer
			// 
			this.backgroundWorkerTimer.Enabled = true;
			this.backgroundWorkerTimer.Interval = 300000;
			// 
			// notifyIcon
			// 
			this.notifyIcon.ContextMenuStrip = this.contextMenu;
			this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
			this.notifyIcon.Text = "espUrl";
			// 
			// contextMenu
			// 
			this.contextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.contextmenu_capturearea,
            this.contextmenu_capturelastregion,
            this.contextmenu_capturewindow,
            this.contextmenu_capturefullscreen,
            this.contextmenu_captureie,
            this.toolStripSeparator4,
            this.contextmenu_captureclipboard,
            this.contextmenu_openfile,
            this.toolStripSeparator2,
            this.contextmenu_openrecentcapture,
            this.toolStripSeparator5,
            this.contextmenu_quicksettings,
            this.contextmenu_settings,
            this.toolStripSeparator3,
            this.contextmenu_help,
            this.contextmenu_donate,
            this.contextmenu_about,
            this.toolStripSeparator1,
            this.contextmenu_exit});
			this.contextMenu.Name = "contextMenu";
			this.contextMenu.Size = new System.Drawing.Size(304, 392);
			// 
			// contextmenu_capturearea
			// 
			this.contextmenu_capturearea.Name = "contextmenu_capturearea";
			this.contextmenu_capturearea.ShortcutKeyDisplayString = "Print";
			this.contextmenu_capturearea.Size = new System.Drawing.Size(303, 24);
			this.contextmenu_capturearea.Text = "Capture region";
			// 
			// contextmenu_capturelastregion
			// 
			this.contextmenu_capturelastregion.Enabled = false;
			this.contextmenu_capturelastregion.Name = "contextmenu_capturelastregion";
			this.contextmenu_capturelastregion.ShortcutKeyDisplayString = "Shift + Print";
			this.contextmenu_capturelastregion.Size = new System.Drawing.Size(303, 24);
			this.contextmenu_capturelastregion.Text = "Capture last region";
			// 
			// contextmenu_capturewindow
			// 
			this.contextmenu_capturewindow.Name = "contextmenu_capturewindow";
			this.contextmenu_capturewindow.ShortcutKeyDisplayString = "Alt + Print";
			this.contextmenu_capturewindow.Size = new System.Drawing.Size(303, 24);
			this.contextmenu_capturewindow.Text = "Capture window";
			// 
			// contextmenu_capturefullscreen
			// 
			this.contextmenu_capturefullscreen.Name = "contextmenu_capturefullscreen";
			this.contextmenu_capturefullscreen.ShortcutKeyDisplayString = "Ctrl + Print";
			this.contextmenu_capturefullscreen.Size = new System.Drawing.Size(303, 24);
			this.contextmenu_capturefullscreen.Text = "Capture full screen";
			// 
			// contextmenu_captureie
			// 
			this.contextmenu_captureie.Name = "contextmenu_captureie";
			this.contextmenu_captureie.ShortcutKeyDisplayString = "Ctrl + Shift + Print";
			this.contextmenu_captureie.Size = new System.Drawing.Size(303, 24);
			this.contextmenu_captureie.Text = "Capture IE Tab";
			// 
			// toolStripSeparator4
			// 
			this.toolStripSeparator4.Name = "toolStripSeparator4";
			this.toolStripSeparator4.Size = new System.Drawing.Size(300, 6);
			this.toolStripSeparator4.Visible = false;
			// 
			// contextmenu_captureclipboard
			// 
			this.contextmenu_captureclipboard.Name = "contextmenu_captureclipboard";
			this.contextmenu_captureclipboard.Size = new System.Drawing.Size(303, 24);
			this.contextmenu_captureclipboard.Text = "Capture clipboard";
			this.contextmenu_captureclipboard.Visible = false;
			// 
			// contextmenu_openfile
			// 
			this.contextmenu_openfile.Name = "contextmenu_openfile";
			this.contextmenu_openfile.Size = new System.Drawing.Size(303, 24);
			this.contextmenu_openfile.Text = "Open File";
			this.contextmenu_openfile.Visible = false;
			// 
			// toolStripSeparator2
			// 
			this.toolStripSeparator2.Name = "toolStripSeparator2";
			this.toolStripSeparator2.Size = new System.Drawing.Size(300, 6);
			this.toolStripSeparator2.Visible = false;
			// 
			// contextmenu_openrecentcapture
			// 
			this.contextmenu_openrecentcapture.Name = "contextmenu_openrecentcapture";
			this.contextmenu_openrecentcapture.Size = new System.Drawing.Size(303, 24);
			this.contextmenu_openrecentcapture.Text = "Open recent capture location";
			this.contextmenu_openrecentcapture.Visible = false;
			// 
			// toolStripSeparator5
			// 
			this.toolStripSeparator5.Name = "toolStripSeparator5";
			this.toolStripSeparator5.Size = new System.Drawing.Size(300, 6);
			this.toolStripSeparator5.Visible = false;
			// 
			// contextmenu_quicksettings
			// 
			this.contextmenu_quicksettings.Name = "contextmenu_quicksettings";
			this.contextmenu_quicksettings.Size = new System.Drawing.Size(303, 24);
			this.contextmenu_quicksettings.Text = "Quick settings";
			this.contextmenu_quicksettings.Visible = false;
			// 
			// contextmenu_settings
			// 
			this.contextmenu_settings.Image = ((System.Drawing.Image)(resources.GetObject("contextmenu_settings.Image")));
			this.contextmenu_settings.Name = "contextmenu_settings";
			this.contextmenu_settings.Size = new System.Drawing.Size(303, 24);
			this.contextmenu_settings.Text = "Settings";
			this.contextmenu_settings.Visible = false;
			this.contextmenu_settings.Click += new System.EventHandler(this.contextmenu_settings_Click);
			// 
			// toolStripSeparator3
			// 
			this.toolStripSeparator3.Name = "toolStripSeparator3";
			this.toolStripSeparator3.Size = new System.Drawing.Size(300, 6);
			this.toolStripSeparator3.Visible = false;
			// 
			// contextmenu_help
			// 
			this.contextmenu_help.Image = ((System.Drawing.Image)(resources.GetObject("contextmenu_help.Image")));
			this.contextmenu_help.Name = "contextmenu_help";
			this.contextmenu_help.Size = new System.Drawing.Size(303, 24);
			this.contextmenu_help.Text = "Help";
			this.contextmenu_help.Visible = false;
			// 
			// contextmenu_donate
			// 
			this.contextmenu_donate.Image = ((System.Drawing.Image)(resources.GetObject("contextmenu_donate.Image")));
			this.contextmenu_donate.Name = "contextmenu_donate";
			this.contextmenu_donate.Size = new System.Drawing.Size(303, 24);
			this.contextmenu_donate.Text = "Support espUrl";
			this.contextmenu_donate.Visible = false;
			// 
			// contextmenu_about
			// 
			this.contextmenu_about.Name = "contextmenu_about";
			this.contextmenu_about.Size = new System.Drawing.Size(303, 24);
			this.contextmenu_about.Text = "About";
			this.contextmenu_about.Visible = false;
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(300, 6);
			// 
			// contextmenu_exit
			// 
			this.contextmenu_exit.Image = ((System.Drawing.Image)(resources.GetObject("contextmenu_exit.Image")));
			this.contextmenu_exit.Name = "contextmenu_exit";
			this.contextmenu_exit.Size = new System.Drawing.Size(303, 24);
			this.contextmenu_exit.Text = "Exit";
			// 
			// EspMainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(282, 255);
			this.Name = "EspMainForm";
			this.Text = "EspMainForm";
			this.contextMenu.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Timer backgroundWorkerTimer;
		public System.Windows.Forms.NotifyIcon notifyIcon;
		private System.Windows.Forms.ContextMenuStrip contextMenu;
		private System.Windows.Forms.ToolStripMenuItem contextmenu_capturearea;
		private System.Windows.Forms.ToolStripMenuItem contextmenu_capturelastregion;
		private System.Windows.Forms.ToolStripMenuItem contextmenu_capturewindow;
		private System.Windows.Forms.ToolStripMenuItem contextmenu_capturefullscreen;
		private System.Windows.Forms.ToolStripMenuItem contextmenu_captureie;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
		private System.Windows.Forms.ToolStripMenuItem contextmenu_captureclipboard;
		private System.Windows.Forms.ToolStripMenuItem contextmenu_openfile;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
		private System.Windows.Forms.ToolStripMenuItem contextmenu_openrecentcapture;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
		private System.Windows.Forms.ToolStripMenuItem contextmenu_quicksettings;
		private System.Windows.Forms.ToolStripMenuItem contextmenu_settings;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
		private System.Windows.Forms.ToolStripMenuItem contextmenu_help;
		private System.Windows.Forms.ToolStripMenuItem contextmenu_donate;
		private System.Windows.Forms.ToolStripMenuItem contextmenu_about;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripMenuItem contextmenu_exit;
	}
}