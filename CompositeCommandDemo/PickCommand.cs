using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace CompositeCommandDemo
{
	/// <summary>
	/// Summary description for PickCommand.
	/// </summary>
	public class PickCommand : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Button OK;
		private System.Windows.Forms.Button cancel;
		private System.Windows.Forms.ListBox listBox1;
		Type[] _types;
		Type selectedType = null;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public PickCommand(Type[] types)
		{
			_types = types;
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			listBox1.Items.AddRange(_types);
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.OK = new System.Windows.Forms.Button();
			this.cancel = new System.Windows.Forms.Button();
			this.listBox1 = new System.Windows.Forms.ListBox();
			this.SuspendLayout();
			// 
			// OK
			// 
			this.OK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.OK.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.OK.Enabled = false;
			this.OK.Location = new System.Drawing.Point(308, 520);
			this.OK.Name = "OK";
			this.OK.TabIndex = 0;
			this.OK.Text = "OK";
			this.OK.Click += new System.EventHandler(this.OK_Click);
			// 
			// cancel
			// 
			this.cancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.cancel.Location = new System.Drawing.Point(204, 520);
			this.cancel.Name = "cancel";
			this.cancel.TabIndex = 1;
			this.cancel.Text = "Cancel";
			// 
			// listBox1
			// 
			this.listBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.listBox1.Location = new System.Drawing.Point(0, 0);
			this.listBox1.Name = "listBox1";
			this.listBox1.Size = new System.Drawing.Size(396, 498);
			this.listBox1.TabIndex = 2;
			this.listBox1.DoubleClick += new System.EventHandler(this.listBox1_DoubleClick);
			this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
			// 
			// PickCommand
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.CancelButton = this.cancel;
			this.ClientSize = new System.Drawing.Size(392, 558);
			this.Controls.Add(this.listBox1);
			this.Controls.Add(this.cancel);
			this.Controls.Add(this.OK);
			this.MaximizeBox = false;
			this.Name = "PickCommand";
			this.Text = "Select Image Command";
			this.TopMost = true;
			this.ResumeLayout(false);

		}
		#endregion

		private void listBox1_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			OK.Enabled = listBox1.SelectedIndex != -1;
			selectedType = listBox1.SelectedIndex == -1 ? null : _types[listBox1.SelectedIndex];
		}

		private void OK_Click(object sender, System.EventArgs e)
		{
			
		}

		private void listBox1_DoubleClick(object sender, System.EventArgs e)
		{
			if (listBox1.SelectedIndex != -1) 
			{
				selectedType = _types[listBox1.SelectedIndex];
				this.DialogResult = DialogResult.OK;
				this.Close();
			}
		}

		public Type SelectedType { get { return selectedType; } }
	}
}
