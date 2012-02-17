/*
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
using System;
using System.Drawing;
using System.Windows.Forms;

using GreenshotPlugin.UnmanagedHelpers;

namespace Greenshot.Helpers {
	/// <summary>
	/// Description of MouseHelper.
	/// </summary>
	public class MouseHelper {
		private enum FixMode {None, Initiated, Horizontal, Vertical};

		private static Point previousMousePos = Point.Empty;
		private static FixMode fixMode = FixMode.None;
		
		public static bool CheckKeyUpForFixing(Keys keys) {
			if (keys == Keys.ShiftKey) {
				fixMode = FixMode.None;
				return true;
			}
			return false;
		}
		public static bool CheckKeyDownForFixing(Keys keys) {
			if (keys == Keys.ShiftKey) {
				if (fixMode == FixMode.None) {
					fixMode = FixMode.Initiated;
					return true;
				}
			}
			return false;
		}

		/// <summary>
		/// This method will store the fixmode depending on the key presses
		/// </summary>
		/// <param name="msg">Message with the key information</param>
		/// <returns>true if the message is handled</returns>
		public static bool ProcessKeyPreviewForFixing(ref Message msg) {
			Keys keys = (Keys)msg.WParam;
			if (msg.Msg == (int)WindowsMessages.WM_KEYDOWN) {
				if (CheckKeyDownForFixing(keys)) {
					return true;
				}
			}
			if (msg.Msg == (int)WindowsMessages.WM_KEYUP) {
				if (CheckKeyUpForFixing(keys)) {
					return true;
				}
			}
			return false;
		}

		public static Point FixMouseCoordinates(MouseEventArgs e) {
			return FixMouseCoordinates(new Point(e.X, e.Y));
		}

		public static Point FixMouseCoordinates(Point currentMouse) {
			if (fixMode == FixMode.Initiated) {
				if (previousMousePos.X != currentMouse.X) {
					fixMode = FixMode.Vertical;
				} else if (previousMousePos.Y != currentMouse.Y) {
					fixMode = FixMode.Horizontal;
				}
			} else if (fixMode == FixMode.Vertical) {
				currentMouse = new Point(currentMouse.X, previousMousePos.Y);
			} else if (fixMode == FixMode.Horizontal) {
				currentMouse = new Point(previousMousePos.X, currentMouse.Y);
			}
			previousMousePos = currentMouse;
			return currentMouse;
		}
	}
}
