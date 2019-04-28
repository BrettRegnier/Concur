using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Concur
{
	public partial class Configuration : Form
	{
		private int timeSeconds;
		private int timeMinutes;
		private int timeHours;

		public Configuration()
		{
			InitializeComponent();
		}

		private void Configuration_Load(object sender, EventArgs e)
		{
			txtInterval.GotFocus += removeTextPlaceHolder;
			txtInterval.LostFocus += addTextPlaceHolder;
		}

		private void txtInterval_TextChanged(object sender, EventArgs e)
		{
			validate();
		}
		
		private bool validate()
		{
			if (txtInterval.Text != "0h 0m 0s" && txtInterval.Text != "")
			{
				if (Regex.Match(txtInterval.Text, @"^(\d{1,}[hms]?){1,3}$").Success)
				{
					// sucess
					txtInterval.BackColor = Color.FromArgb(44, 238, 144);
					return true;
				}
				else
				{
					txtInterval.BackColor = Color.PaleVioletRed;
					return false;
				}
			}
			else
			{
				txtInterval.BackColor = Color.FromKnownColor(KnownColor.Window);
			}
			return false; // maybe
		}

		private void removeTextPlaceHolder(object sender, EventArgs e)
		{
			TextBox curText = (TextBox)sender;
			if (curText.Text == (string)curText.Tag)
			{
				curText.Text = "";
				curText.ForeColor = Color.Black;
			}
		}

		private void addTextPlaceHolder(object sender, EventArgs e)
		{
			TextBox curText = (TextBox)sender;
			setPlaceHolder(curText);
		}

		private void setPlaceHolder(TextBox txt)
		{
			if (string.IsNullOrWhiteSpace(txt.Text))
			{
				txt.Text = (string)txt.Tag;
				txt.ForeColor = Color.DarkSlateGray;
			}
		}

		private void ParseInterval()
		{
			if (validate())
			{
				// Parse the string into 3 compontents based on where seconds (s), minutes (m) and hours (h) are placed.
				string parsee = txtInterval.Text;
				int lastChar = 0;

				int tmpSeconds = 0;
				int tmpMinutes = 0;
				int tmpHours = 0;

				for (int i = 0; i < parsee.Length; i++)
				{
					string sub = parsee.Substring(i, 1);
					if (parsee.Substring(i, 1).ToLower() == "h")
					{
						tmpHours = Convert.ToInt32(parsee.Substring(0, i));
						parsee = parsee.Substring(i + 1, parsee.Length - (i + 1));
						lastChar = i;
						i = 0;
					}
					else if (parsee.Substring(i, 1).ToLower() == "m")
					{
						tmpMinutes = Convert.ToInt32(parsee.Substring(0, i));
						parsee = parsee.Substring(i + 1, parsee.Length - (i + 1));
						lastChar = i;
						i = 0;
					}
					else if (parsee.Substring(i, 1).ToLower() == "s")
					{
						tmpSeconds = Convert.ToInt32(parsee.Substring(0, i));
						parsee = parsee.Substring(i + 1, parsee.Length - (i + 1));
						i = 0;
					}
					else
					{
						if (i >= parsee.Length - 1)
						{
							tmpSeconds = Convert.ToInt32(parsee.Substring(0, i + 1));
						}
					}
				}

				// Convert hours, minutes and seconds
				tmpMinutes += tmpSeconds / 60;
				tmpSeconds %= 60;

				tmpHours += tmpMinutes / 60;
				tmpMinutes %= 60;

				if (tmpHours != timeHours || tmpMinutes != timeMinutes || tmpSeconds != timeSeconds)
				{
					timeHours = tmpHours;
					timeMinutes = tmpMinutes;
					timeSeconds = tmpSeconds;
				}

				txtInterval.Text = timeHours.ToString() + "h" + timeMinutes.ToString() + "m" + timeSeconds.ToString() + "s";
				txtInterval.BackColor = Color.FromKnownColor(KnownColor.Window);

				txtInterval.Enabled = true;
			}
		}

		private void btnApply_Click(object sender, EventArgs e)
		{
			
		}
	}
}
