using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace ObjectSenderReceiver
{
	/// <summary>
	/// Main form class
	/// </summary>
	public class MainForm : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Button buttonSender;
		private System.Windows.Forms.Button buttonReceiver;
		/// <summary>
		/// Useful for conceptor
		/// </summary>
		private System.ComponentModel.Container components = null;

		public MainForm()
		{
			//
			// Useful for conceptor
			//
			InitializeComponent();

			
		}

		/// <summary>
		/// Freeing resources
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

		#region Generated by Windows form conceptor
		/// <summary>
		/// Form initialisation
		/// </summary>
		private void InitializeComponent()
		{
			this.buttonSender = new System.Windows.Forms.Button();
			this.buttonReceiver = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// buttonSender
			// 
			this.buttonSender.Location = new System.Drawing.Point(8, 16);
			this.buttonSender.Name = "buttonSender";
			this.buttonSender.TabIndex = 0;
			this.buttonSender.Text = "Sender";
			this.buttonSender.Click += new System.EventHandler(this.buttonSender_Click);
			// 
			// buttonReceiver
			// 
			this.buttonReceiver.Location = new System.Drawing.Point(120, 16);
			this.buttonReceiver.Name = "buttonReceiver";
			this.buttonReceiver.TabIndex = 0;
			this.buttonReceiver.Text = "Receiver";
			this.buttonReceiver.Click += new System.EventHandler(this.buttonReceiver_Click);
			// 
			// MainForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(448, 70);
			this.Controls.Add(this.buttonSender);
			this.Controls.Add(this.buttonReceiver);
			this.Name = "MainForm";
			this.Text = "Form1";
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// Main function
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new MainForm());
		}

		private void buttonSender_Click(object sender, System.EventArgs e)
		{
			SenderForm form = new SenderForm ();
			form.ShowDialog ();

		}

		private void buttonReceiver_Click(object sender, System.EventArgs e)
		{
			ReceiverForm form = new ReceiverForm ();
			form.ShowDialog ();
		}
	}
}
