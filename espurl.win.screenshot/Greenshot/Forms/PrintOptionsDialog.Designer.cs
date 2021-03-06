﻿/*
 * Greenshot - a free and open source screenshot tool
 * Copyright (C) 2007-2011  Thomas Braun, Jens Klingen, Robin Krom
 * 
 * For more information see: http://getgreenshot.org/
 * The Greenshot project is hosted on Sourceforge: http://sourceforge.net/projects/greenshot/
 * 
 * This program is free software: you can redistribute it and/or modify
 * it under the terms of the GNU General Public License as published by
 * the Free Software Foundation, either version 1 of the License, or
 * (at your option) any later version.
 * 
 * This program is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU General Public License for more details.
 * 
 * You should have received a copy of the GNU General Public License
 * along with this program.  If not, see <http://www.gnu.org/licenses/>.
 */
namespace Greenshot.Forms
{
	partial class PrintOptionsDialog
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
			this.checkbox_dontaskagain = new System.Windows.Forms.CheckBox();
			this.checkboxAllowShrink = new System.Windows.Forms.CheckBox();
			this.checkboxAllowEnlarge = new System.Windows.Forms.CheckBox();
			this.checkboxAllowCenter = new System.Windows.Forms.CheckBox();
			this.checkboxAllowRotate = new System.Windows.Forms.CheckBox();
			this.button_ok = new System.Windows.Forms.Button();
			this.checkboxDateTime = new System.Windows.Forms.CheckBox();
			this.button_cancel = new System.Windows.Forms.Button();
			this.checkboxPrintInverted = new System.Windows.Forms.CheckBox();
			this.SuspendLayout();
			// 
			// checkbox_dontaskagain
			// 
			this.checkbox_dontaskagain.AutoSize = true;
			this.checkbox_dontaskagain.CheckAlign = System.Drawing.ContentAlignment.TopLeft;
			this.checkbox_dontaskagain.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
			this.checkbox_dontaskagain.Location = new System.Drawing.Point(12, 152);
			this.checkbox_dontaskagain.Name = "checkbox_dontaskagain";
			this.checkbox_dontaskagain.Size = new System.Drawing.Size(206, 17);
			this.checkbox_dontaskagain.TabIndex = 19;
			this.checkbox_dontaskagain.Text = "Save as default and do not ask again.";
			this.checkbox_dontaskagain.TextAlign = System.Drawing.ContentAlignment.TopLeft;
			this.checkbox_dontaskagain.UseVisualStyleBackColor = true;
			// 
			// checkboxAllowShrink
			// 
			this.checkboxAllowShrink.AutoSize = true;
			this.checkboxAllowShrink.CheckAlign = System.Drawing.ContentAlignment.TopLeft;
			this.checkboxAllowShrink.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
			this.checkboxAllowShrink.Location = new System.Drawing.Point(12, 20);
			this.checkboxAllowShrink.Name = "checkboxAllowShrink";
			this.checkboxAllowShrink.Size = new System.Drawing.Size(191, 17);
			this.checkboxAllowShrink.TabIndex = 21;
			this.checkboxAllowShrink.Text = "Shrink large printouts to paper size.";
			this.checkboxAllowShrink.TextAlign = System.Drawing.ContentAlignment.TopLeft;
			this.checkboxAllowShrink.UseVisualStyleBackColor = true;
			// 
			// checkboxAllowEnlarge
			// 
			this.checkboxAllowEnlarge.AutoSize = true;
			this.checkboxAllowEnlarge.CheckAlign = System.Drawing.ContentAlignment.TopLeft;
			this.checkboxAllowEnlarge.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
			this.checkboxAllowEnlarge.Location = new System.Drawing.Point(12, 43);
			this.checkboxAllowEnlarge.Name = "checkboxAllowEnlarge";
			this.checkboxAllowEnlarge.Size = new System.Drawing.Size(197, 17);
			this.checkboxAllowEnlarge.TabIndex = 22;
			this.checkboxAllowEnlarge.Text = "Enlarge small printouts to paper size.";
			this.checkboxAllowEnlarge.TextAlign = System.Drawing.ContentAlignment.TopLeft;
			this.checkboxAllowEnlarge.UseVisualStyleBackColor = true;
			// 
			// checkboxAllowCenter
			// 
			this.checkboxAllowCenter.AutoSize = true;
			this.checkboxAllowCenter.CheckAlign = System.Drawing.ContentAlignment.TopLeft;
			this.checkboxAllowCenter.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
			this.checkboxAllowCenter.Location = new System.Drawing.Point(12, 89);
			this.checkboxAllowCenter.Name = "checkboxAllowCenter";
			this.checkboxAllowCenter.Size = new System.Drawing.Size(200, 17);
			this.checkboxAllowCenter.TabIndex = 24;
			this.checkboxAllowCenter.Text = "Align printouts centered on the page.";
			this.checkboxAllowCenter.TextAlign = System.Drawing.ContentAlignment.TopLeft;
			this.checkboxAllowCenter.UseVisualStyleBackColor = true;
			// 
			// checkboxAllowRotate
			// 
			this.checkboxAllowRotate.AutoSize = true;
			this.checkboxAllowRotate.CheckAlign = System.Drawing.ContentAlignment.TopLeft;
			this.checkboxAllowRotate.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
			this.checkboxAllowRotate.Location = new System.Drawing.Point(12, 66);
			this.checkboxAllowRotate.Name = "checkboxAllowRotate";
			this.checkboxAllowRotate.Size = new System.Drawing.Size(195, 17);
			this.checkboxAllowRotate.TabIndex = 23;
			this.checkboxAllowRotate.Text = "Rotate printouts to page orientation.";
			this.checkboxAllowRotate.TextAlign = System.Drawing.ContentAlignment.TopLeft;
			this.checkboxAllowRotate.UseVisualStyleBackColor = true;
			// 
			// button_ok
			// 
			this.button_ok.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.button_ok.Location = new System.Drawing.Point(187, 179);
			this.button_ok.Name = "button_ok";
			this.button_ok.Size = new System.Drawing.Size(75, 23);
			this.button_ok.TabIndex = 25;
			this.button_ok.Text = "OK";
			this.button_ok.UseVisualStyleBackColor = true;
			this.button_ok.Click += new System.EventHandler(this.Button_okClick);
			// 
			// checkboxDateTime
			// 
			this.checkboxDateTime.AutoSize = true;
			this.checkboxDateTime.CheckAlign = System.Drawing.ContentAlignment.TopLeft;
			this.checkboxDateTime.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
			this.checkboxDateTime.Location = new System.Drawing.Point(12, 112);
			this.checkboxDateTime.Name = "checkboxDateTime";
			this.checkboxDateTime.Size = new System.Drawing.Size(187, 17);
			this.checkboxDateTime.TabIndex = 26;
			this.checkboxDateTime.Text = "Print date / time at bottom of page";
			this.checkboxDateTime.TextAlign = System.Drawing.ContentAlignment.TopLeft;
			this.checkboxDateTime.UseVisualStyleBackColor = true;
			// 
			// button_cancel
			// 
			this.button_cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.button_cancel.Location = new System.Drawing.Point(268, 179);
			this.button_cancel.Name = "button_cancel";
			this.button_cancel.Size = new System.Drawing.Size(75, 23);
			this.button_cancel.TabIndex = 27;
			this.button_cancel.Text = "Cancel";
			this.button_cancel.UseVisualStyleBackColor = true;
			// 
			// checkBox1
			// 
			this.checkboxPrintInverted.AutoSize = true;
			this.checkboxPrintInverted.CheckAlign = System.Drawing.ContentAlignment.TopLeft;
			this.checkboxPrintInverted.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
			this.checkboxPrintInverted.Location = new System.Drawing.Point(12, 132);
			this.checkboxPrintInverted.Name = "checkBox1";
			this.checkboxPrintInverted.Size = new System.Drawing.Size(88, 17);
			this.checkboxPrintInverted.TabIndex = 28;
			this.checkboxPrintInverted.Text = "Print inverted";
			this.checkboxPrintInverted.TextAlign = System.Drawing.ContentAlignment.TopLeft;
			this.checkboxPrintInverted.UseVisualStyleBackColor = true;
			// 
			// PrintOptionsDialog
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
			this.ClientSize = new System.Drawing.Size(355, 212);
			this.Controls.Add(this.checkboxPrintInverted);
			this.Controls.Add(this.button_cancel);
			this.Controls.Add(this.checkboxDateTime);
			this.Controls.Add(this.button_ok);
			this.Controls.Add(this.checkbox_dontaskagain);
			this.Controls.Add(this.checkboxAllowCenter);
			this.Controls.Add(this.checkboxAllowRotate);
			this.Controls.Add(this.checkboxAllowEnlarge);
			this.Controls.Add(this.checkboxAllowShrink);
			this.Icon = GreenshotPlugin.Core.GreenshotResources.getGreenshotIcon();
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "PrintOptionsDialog";
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
			this.Text = "PrintOptionsDialog";
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		private System.Windows.Forms.CheckBox checkboxPrintInverted;
		private System.Windows.Forms.Button button_cancel;
		private System.Windows.Forms.CheckBox checkboxDateTime;
		private System.Windows.Forms.Button button_ok;
		private System.Windows.Forms.CheckBox checkboxAllowRotate;
		private System.Windows.Forms.CheckBox checkboxAllowCenter;
		private System.Windows.Forms.CheckBox checkboxAllowEnlarge;
		private System.Windows.Forms.CheckBox checkboxAllowShrink;
		private System.Windows.Forms.CheckBox checkbox_dontaskagain;
	}
}
