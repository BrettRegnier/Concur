using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Concur
{
	public partial class Test : Form
	{
		public Test()
		{
			InitializeComponent();
		}

		private void Test_Load(object sender, EventArgs e)
		{
			LabelledTextbox txt = new LabelledTextbox();
			txt.PlaceholderText = "Dicks";
			LabelledTextbox txt2 = new LabelledTextbox();
			txt2.PlaceholderText = "Dicks";
			txt2.Top = 50;
			this.Controls.Add(txt);
			this.Controls.Add(txt2);
		}
	}
}
