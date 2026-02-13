using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Reflection;
using System.Data;
using Atalasoft.Imaging.WinControls;
using Atalasoft.Imaging;
using Atalasoft.Imaging.ImageProcessing;
using Atalasoft.Imaging.Codec;
using WinDemoHelperMethods;

namespace CompositeCommandDemo
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private CompositeCommand compositeCommand = new CompositeCommand();
		private Type[] allImageCommands;

		private System.Windows.Forms.ListBox listBox1;
		private System.Windows.Forms.Splitter splitter1;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Button addCommand;
		private System.Windows.Forms.Button removeCommand;
		private System.Windows.Forms.Button properties;
		private System.Windows.Forms.Button chooseImage;
		private System.Windows.Forms.Button doCommand;
		private Atalasoft.Imaging.WinControls.ImageViewer imageViewer1;
		private System.Windows.Forms.Button clearCommands;
		private System.Windows.Forms.ProgressBar progressBar1;
		private System.Windows.Forms.Button btnAbout;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public Form1()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			allImageCommands = GetAllImageCommands(new Assembly[] {
																	  Assembly.GetAssembly(typeof(AtalaImage))
																  });

			compositeCommand.Progress = new ProgressEventHandler(Form1_Progress);

			// Ensure decoders are setup
			HelperMethods.PopulateDecoders(Atalasoft.Imaging.Codec.RegisteredDecoders.Decoders);
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
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
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnAbout = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.clearCommands = new System.Windows.Forms.Button();
            this.doCommand = new System.Windows.Forms.Button();
            this.chooseImage = new System.Windows.Forms.Button();
            this.properties = new System.Windows.Forms.Button();
            this.removeCommand = new System.Windows.Forms.Button();
            this.addCommand = new System.Windows.Forms.Button();
            this.imageViewer1 = new Atalasoft.Imaging.WinControls.ImageViewer();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // listBox1
            // 
            this.listBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.listBox1.Location = new System.Drawing.Point(0, 0);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(184, 589);
            this.listBox1.TabIndex = 0;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            this.listBox1.DoubleClick += new System.EventHandler(this.listBox1_DoubleClick);
            // 
            // splitter1
            // 
            this.splitter1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitter1.Location = new System.Drawing.Point(184, 0);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(6, 590);
            this.splitter1.TabIndex = 1;
            this.splitter1.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.btnAbout);
            this.panel1.Controls.Add(this.progressBar1);
            this.panel1.Controls.Add(this.clearCommands);
            this.panel1.Controls.Add(this.doCommand);
            this.panel1.Controls.Add(this.chooseImage);
            this.panel1.Controls.Add(this.properties);
            this.panel1.Controls.Add(this.removeCommand);
            this.panel1.Controls.Add(this.addCommand);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(190, 490);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(522, 100);
            this.panel1.TabIndex = 2;
            // 
            // btnAbout
            // 
            this.btnAbout.Location = new System.Drawing.Point(184, 8);
            this.btnAbout.Name = "btnAbout";
            this.btnAbout.Size = new System.Drawing.Size(75, 23);
            this.btnAbout.TabIndex = 8;
            this.btnAbout.Text = "About";
            this.btnAbout.Click += new System.EventHandler(this.btnAbout_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(192, 56);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(312, 23);
            this.progressBar1.TabIndex = 7;
            // 
            // clearCommands
            // 
            this.clearCommands.Location = new System.Drawing.Point(96, 56);
            this.clearCommands.Name = "clearCommands";
            this.clearCommands.Size = new System.Drawing.Size(75, 23);
            this.clearCommands.TabIndex = 6;
            this.clearCommands.Text = "Clear All";
            this.clearCommands.Click += new System.EventHandler(this.clearCommands_Click);
            // 
            // doCommand
            // 
            this.doCommand.Enabled = false;
            this.doCommand.Location = new System.Drawing.Point(400, 8);
            this.doCommand.Name = "doCommand";
            this.doCommand.Size = new System.Drawing.Size(104, 23);
            this.doCommand.TabIndex = 4;
            this.doCommand.Text = "Apply Commands";
            this.doCommand.Click += new System.EventHandler(this.doCommand_Click);
            // 
            // chooseImage
            // 
            this.chooseImage.Location = new System.Drawing.Point(312, 8);
            this.chooseImage.Name = "chooseImage";
            this.chooseImage.Size = new System.Drawing.Size(75, 23);
            this.chooseImage.TabIndex = 3;
            this.chooseImage.Text = "Open...";
            this.chooseImage.Click += new System.EventHandler(this.chooseImage_Click);
            // 
            // properties
            // 
            this.properties.Enabled = false;
            this.properties.Location = new System.Drawing.Point(96, 8);
            this.properties.Name = "properties";
            this.properties.Size = new System.Drawing.Size(75, 23);
            this.properties.TabIndex = 2;
            this.properties.Text = "Properties...";
            this.properties.Click += new System.EventHandler(this.properties_Click);
            // 
            // removeCommand
            // 
            this.removeCommand.Enabled = false;
            this.removeCommand.Location = new System.Drawing.Point(8, 56);
            this.removeCommand.Name = "removeCommand";
            this.removeCommand.Size = new System.Drawing.Size(75, 23);
            this.removeCommand.TabIndex = 1;
            this.removeCommand.Text = "Remove";
            this.removeCommand.Click += new System.EventHandler(this.removeCommand_Click);
            // 
            // addCommand
            // 
            this.addCommand.Location = new System.Drawing.Point(8, 8);
            this.addCommand.Name = "addCommand";
            this.addCommand.Size = new System.Drawing.Size(75, 23);
            this.addCommand.TabIndex = 0;
            this.addCommand.Text = "Add...";
            this.addCommand.Click += new System.EventHandler(this.addCommand_Click);
            // 
            // imageViewer1
            // 
            this.imageViewer1.AntialiasDisplay = Atalasoft.Imaging.WinControls.AntialiasDisplayMode.ScaleToGray;
            this.imageViewer1.AutoZoom = Atalasoft.Imaging.WinControls.AutoZoomMode.BestFit;
            this.imageViewer1.DisplayProfile = null;
            this.imageViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.imageViewer1.Location = new System.Drawing.Point(190, 0);
            this.imageViewer1.Magnifier.BackColor = System.Drawing.Color.White;
            this.imageViewer1.Magnifier.BorderColor = System.Drawing.Color.Black;
            this.imageViewer1.Magnifier.Size = new System.Drawing.Size(100, 100);
            this.imageViewer1.Name = "imageViewer1";
            this.imageViewer1.OutputProfile = null;
            this.imageViewer1.Selection = null;
            this.imageViewer1.Size = new System.Drawing.Size(522, 490);
            this.imageViewer1.TabIndex = 3;
            this.imageViewer1.Text = "imageViewer1";
            // 
            // Form1
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(712, 590);
            this.Controls.Add(this.imageViewer1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.listBox1);
            this.Name = "Form1";
            this.Text = "Composite Command Demo";
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new Form1());
		}

		private void chooseImage_Click(object sender, System.EventArgs e)
		{
			OpenImageFileDialog ofd = new OpenImageFileDialog();

			// Open images in licensed formats
			ofd.Filter = HelperMethods.CreateDialogFilter(true);

			// try to locate images folder
			string imagesFolder = Application.ExecutablePath;
			// we assume we are running under the DotImage install folder
			int pos = imagesFolder.IndexOf("DotImage ");
			if (pos != -1)
			{
				imagesFolder = imagesFolder.Substring(0,imagesFolder.IndexOf(@"\",pos)) + @"\Images";
			}

			//use this folder as starting point			
			ofd.InitialDirectory = imagesFolder;

			if (ofd.ShowDialog() == DialogResult.OK) 
			{
				AtalaImage image = null;
				try 
				{
					image = new AtalaImage(ofd.FileName);
				}
				catch (Exception err) 
				{
					MessageBox.Show(this, "Unable to open file: " + err.Message);
					return;
				}
				imageViewer1.Image = image;
				OnImageChanged(image != null);
			}
		}

		private void listBox1_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			this.removeCommand.Enabled = (listBox1.SelectedIndex != -1);
			this.properties.Enabled = this.removeCommand.Enabled;
			
		}

		private void OnImageChanged(bool hasImage)
		{
			this.doCommand.Enabled = hasImage && compositeCommand.Commands.Count > 0;
		}

		private void addCommand_Click(object sender, System.EventArgs e)
		{
			PickCommand picker = new PickCommand(allImageCommands);
			if (picker.ShowDialog() == DialogResult.OK) 
			{
				Type type = picker.SelectedType;
				if (type != null) 
				{
					AddNewCommand(type);
				}
			}
		
		}

		private Type[] GetAllImageCommands(Assembly[] assemblies)
		{
			ArrayList list = new ArrayList();
			foreach (Assembly a in assemblies) 
			{
				Type[] types = a.GetTypes();
				foreach (Type type in types) 
				{
					if (type.IsSubclassOf(typeof(ImageCommand)) && !type.IsAbstract) 
					{
						ConstructorInfo ctorInfo = type.GetConstructor(new Type[] { });
						if (ctorInfo != null) 
						{
							list.Add(type);
						}
					}
				}
			}
			Type[] finalArray = new Type[list.Count];
			int i=0;
			foreach (object o in list) 
			{
				finalArray[i++] = (Type)o;
			}
			return finalArray;
		}

		private void AddNewCommand(Type type)
		{
			ConstructorInfo ctorInfo = type.GetConstructor(new Type[] { });
			if (ctorInfo == null) 
			{
				MessageBox.Show(this, "Unable to get constructor for image command of type " + type.Name);
				return;
			}
			ImageCommand command = null;
			
			try 
			{
				command = (ImageCommand)ctorInfo.Invoke(null);
			}
			catch
			{
				MessageBox.Show("Unable to construct image command of type " + type.Name);
			}

			if (listBox1.SelectedIndex == -1) 
			{
				compositeCommand.Commands.Add(command);
				listBox1.Items.Add(type.Name);
				listBox1.SelectedIndex = 0;
			}
			else 
			{
				compositeCommand.Commands.Insert(listBox1.SelectedIndex+1, command);
				listBox1.Items.Insert(listBox1.SelectedIndex + 1, type.Name);
				listBox1.SelectedIndex = listBox1.SelectedIndex + 1;
			}
			OnCommandAdded();
		}

		private void OnCommandAdded()
		{
			this.doCommand.Enabled = imageViewer1.Image != null && compositeCommand.Commands.Count > 0;
		}

		private void removeCommand_Click(object sender, System.EventArgs e)
		{
			if (listBox1.SelectedIndex == -1) 
			{
				return; // should never happen
			}
			compositeCommand.Commands.RemoveAt(listBox1.SelectedIndex);
			listBox1.Items.RemoveAt(listBox1.SelectedIndex);
			OnCommandRemoved();
		}

		private void OnCommandRemoved()
		{
			this.doCommand.Enabled = imageViewer1.Image != null && compositeCommand.Commands.Count > 0;
		}

		private void properties_Click(object sender, System.EventArgs e)
		{
			if (listBox1.SelectedIndex == -1) 
			{
				return; // should never happen
			}
			EditCommand picker = new EditCommand(compositeCommand.Commands[listBox1.SelectedIndex]);
			picker.ShowDialog();
		}

		private void doCommand_Click(object sender, System.EventArgs e)
		{
			ImageResults results = null;
			try 
			{
				results = compositeCommand.Apply(imageViewer1.Image);
				AtalaImage oldImage = imageViewer1.Image;
				imageViewer1.Image = results.Image;
				oldImage.Dispose();
			}
			catch (Exception err) 
			{
				MessageBox.Show("Unable to perform command: " + err.Message);
			}
			finally 
			{
				progressBar1.Value = 0;
			}
		}

		private void Form1_Progress(object sender, ProgressEventArgs e)
		{
			this.progressBar1.Value = (e.Current * 100) / e.Total;
		}

		private void listBox1_DoubleClick(object sender, System.EventArgs e)
		{
			properties_Click(this, null);
		}

		private void clearCommands_Click(object sender, System.EventArgs e)
		{
			listBox1.Items.Clear();
			compositeCommand.Commands.Clear();
			OnCommandRemoved();
		}

		private void btnAbout_Click(object sender, System.EventArgs e)
		{
			AtalaDemos.AboutBox.About aboutBox = new AtalaDemos.AboutBox.About("About Atalasoft DotImage Composite Command Demo",
				"DotImage Composite Command Demo");
			aboutBox.Description = @"Shows how to take arbitrary ImageCommands and encapsulate and compose them into one new single ImageCommand.  Uses reflection to display all image commands in all referenced assemblies.";
			aboutBox.ShowDialog();
		}
	}
}
