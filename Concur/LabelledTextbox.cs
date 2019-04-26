using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Concur
{
	class LabelledTextbox : TextBox
	{
		public string PlaceholderText { private get; set; }
		public string LabelText
		{
			get { return Label.Text; }
			set { Label.Text = value; }
		}
		private Label Label { get; set; }

		public LabelledTextbox()
		{
			Label = new Label();
			Label.LocationChanged += (sender, e) => { PositionTextbox(); };
			this.LocationChanged += (sender, e) => { PositionLabel(); };
			this.GotFocus += RemoveText;
			this.LostFocus += AddText;
			PositionTextbox();
		}

		private void PositionTextbox()
		{
			if (this.Top != Label.Top + 10)
				this.Top = Label.Top + 10;
		}

		private void PositionLabel()
		{
			if (Label.Top != this.Top - 10)
				Label.Top = this.Top - 10;
		}

		private void RemoveText(object sender, EventArgs e)
		{
			if (((TextBox)sender).Text == PlaceholderText)
				((TextBox)sender).Text = "";

			((TextBox)sender).ForeColor = System.Drawing.Color.Black;
		}

		private void AddText(object sender, EventArgs e)
		{
			if (string.IsNullOrWhiteSpace(((TextBox)sender).Text))
			{
				((TextBox)sender).Text = PlaceholderText;
				((TextBox)sender).ForeColor = System.Drawing.Color.DarkGray;
			}
		}
	}
}
