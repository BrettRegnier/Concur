using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Concur
{
	class LabelledTextbox : Panel
	{
		private string _placeholder;
		public string PlaceholderText
		{
			get
			{
				return _placeholder;
			}
			set
			{
				_placeholder = value;	
				Textbox.Text = _placeholder;
			}
		}
		public string LabelText
		{
			get { return Label.Text; }
			set { Label.Text = value; }
		}

		public TextBox Textbox { get; private set; }
		public Label Label { get; private set; }

		public LabelledTextbox()
		{
			InitializeComponent();
			Textbox.GotFocus += RemoveText;
			Textbox.LostFocus += AddText;
		}

		public void UpdatePlaceHolder(string txt)
		{
			_placeholder = txt;
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

		private void InitializeComponent()
		{
			this.Label = new System.Windows.Forms.Label();
			this.Textbox = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// descriptor
			// 
			this.Label.AutoSize = true;
			this.Label.Location = new System.Drawing.Point(0, 0);
			this.Label.Name = "descriptor";
			this.Label.Size = new System.Drawing.Size(33, 13);
			this.Label.TabIndex = 0;
			this.Label.Text = "Label";
			// 
			// txtBox
			// 
			this.Textbox.Location = new System.Drawing.Point(1, 13);
			this.Textbox.Name = "txtBox";
			this.Textbox.Size = new System.Drawing.Size(100, 20);
			this.Textbox.ForeColor = System.Drawing.Color.DarkGray;
			this.Textbox.TabIndex = 0;
			// 
			// LabelledTextbox
			// 
			this.Controls.Add(this.Label);
			this.Controls.Add(this.Textbox);
			this.Height = 33;
			this.Width = 101;
			//this.BorderStyle = BorderStyle.FixedSingle;
			this.ResumeLayout(false);
			this.PerformLayout();
		}
	}
}
