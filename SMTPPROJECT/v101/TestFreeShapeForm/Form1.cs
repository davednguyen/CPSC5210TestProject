using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace TestFreeShapeForm
{
	/// <summary>
	/// Description résumée de Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Button buttonQuit;
		private DotNetControlExtender.CFormExtender cFormExtender1;
		private System.Windows.Forms.ImageList imageList1;
		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.Button buttonChange;
		private System.ComponentModel.IContainer components;

		public Form1()
		{
			//
			// Requis pour la prise en charge du Concepteur Windows Forms
			//
			InitializeComponent();

			//
			// TODO : ajoutez le code du constructeur après l'appel à InitializeComponent
			//
		}

		/// <summary>
		/// Nettoyage des ressources utilisées.
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

		#region Code généré par le Concepteur Windows Form
		/// <summary>
		/// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
		/// le contenu de cette méthode avec l'éditeur de code.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(Form1));
			this.buttonQuit = new System.Windows.Forms.Button();
			this.imageList1 = new System.Windows.Forms.ImageList(this.components);
			this.cFormExtender1 = new DotNetControlExtender.CFormExtender(this.components);
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.buttonChange = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// buttonQuit
			// 
			this.buttonQuit.Cursor = System.Windows.Forms.Cursors.Hand;
			this.buttonQuit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.buttonQuit.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.buttonQuit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.buttonQuit.Location = new System.Drawing.Point(152, 232);
			this.buttonQuit.Name = "buttonQuit";
			this.buttonQuit.Size = new System.Drawing.Size(56, 32);
			this.buttonQuit.TabIndex = 0;
			this.buttonQuit.Text = "Quit";
			this.buttonQuit.Click += new System.EventHandler(this.buttonQuit_Click);
			// 
			// imageList1
			// 
			this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
			this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
			this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
			// 
			// pictureBox1
			// 
			this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
			this.pictureBox1.Location = new System.Drawing.Point(24, 176);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(16, 16);
			this.pictureBox1.TabIndex = 1;
			this.pictureBox1.TabStop = false;
			this.pictureBox1.Visible = false;
			// 
			// buttonChange
			// 
			this.buttonChange.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.buttonChange.Location = new System.Drawing.Point(104, 192);
			this.buttonChange.Name = "buttonChange";
			this.buttonChange.TabIndex = 2;
			this.buttonChange.Text = "Change";
			this.buttonChange.Click += new System.EventHandler(this.buttonChange_Click);
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
			this.CancelButton = this.buttonQuit;
			this.ClientSize = new System.Drawing.Size(472, 328);
			this.ControlBox = false;
			this.Controls.Add(this.buttonChange);
			this.Controls.Add(this.pictureBox1);
			this.Controls.Add(this.buttonQuit);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "Form1";
			this.cFormExtender1.SetProcessMouse(this, true);
			this.Text = "Form1";
			this.TransparencyKey = System.Drawing.Color.Fuchsia;
			this.cFormExtender1.SetUseBgImage(this, true);
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// Point d'entrée principal de l'application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new Form1());
		}

		private void buttonQuit_Click(object sender, System.EventArgs e)
		{
			Close ();
		}

		private void buttonChange_Click(object sender, System.EventArgs e)
		{
			BackgroundImage = pictureBox1.Image;
			buttonChange.Visible = false;
		}

		
	}
}
