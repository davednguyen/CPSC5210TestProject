using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Runtime.Serialization.Formatters.Binary;

namespace ObjectSenderReceiver
{
	/// <summary>
	/// Reader form
	/// </summary>
	public class ReceiverForm : System.Windows.Forms.Form
	{
		private System.Windows.Forms.TextBox textBoxPOPHost;
		private System.Windows.Forms.Label labelPOPHost;
		private System.Windows.Forms.Label labelPOPPort;
		private System.Windows.Forms.TextBox textBoxPOPPort;
		private System.Windows.Forms.Label labelUser;
		private System.Windows.Forms.TextBox textBoxUser;
		private System.Windows.Forms.Label labelPassword;
		private System.Windows.Forms.TextBox textBoxPassword;
		private System.Windows.Forms.Button buttonReadData;
		private System.Windows.Forms.ListBox listBoxData;
		/// <summary>
		/// Need for design
		/// </summary>
		private System.ComponentModel.Container components = null;

		public ReceiverForm()
		{
			//
			// Need for Windows Forms designer
			//
			InitializeComponent();

			
		}

		/// <summary>
		/// Cleanup
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

		#region Designer Generated code
		/// <summary>
		/// Dont modify
		/// </summary>
		private void InitializeComponent()
		{
			this.textBoxPOPHost = new System.Windows.Forms.TextBox();
			this.labelPOPHost = new System.Windows.Forms.Label();
			this.labelPOPPort = new System.Windows.Forms.Label();
			this.textBoxPOPPort = new System.Windows.Forms.TextBox();
			this.labelUser = new System.Windows.Forms.Label();
			this.textBoxUser = new System.Windows.Forms.TextBox();
			this.labelPassword = new System.Windows.Forms.Label();
			this.textBoxPassword = new System.Windows.Forms.TextBox();
			this.buttonReadData = new System.Windows.Forms.Button();
			this.listBoxData = new System.Windows.Forms.ListBox();
			this.SuspendLayout();
			// 
			// textBoxPOPHost
			// 
			this.textBoxPOPHost.Location = new System.Drawing.Point(104, 16);
			this.textBoxPOPHost.Name = "textBoxPOPHost";
			this.textBoxPOPHost.Size = new System.Drawing.Size(224, 20);
			this.textBoxPOPHost.TabIndex = 1;
			this.textBoxPOPHost.Text = "localhost";
			// 
			// labelPOPHost
			// 
			this.labelPOPHost.Location = new System.Drawing.Point(8, 16);
			this.labelPOPHost.Name = "labelPOPHost";
			this.labelPOPHost.Size = new System.Drawing.Size(88, 16);
			this.labelPOPHost.TabIndex = 21;
			this.labelPOPHost.Text = "POP Host";
			// 
			// labelPOPPort
			// 
			this.labelPOPPort.Location = new System.Drawing.Point(8, 40);
			this.labelPOPPort.Name = "labelPOPPort";
			this.labelPOPPort.Size = new System.Drawing.Size(88, 16);
			this.labelPOPPort.TabIndex = 20;
			this.labelPOPPort.Text = "POP Host";
			// 
			// textBoxPOPPort
			// 
			this.textBoxPOPPort.Location = new System.Drawing.Point(104, 40);
			this.textBoxPOPPort.Name = "textBoxPOPPort";
			this.textBoxPOPPort.Size = new System.Drawing.Size(32, 20);
			this.textBoxPOPPort.TabIndex = 2;
			this.textBoxPOPPort.Text = "110";
			// 
			// labelUser
			// 
			this.labelUser.Location = new System.Drawing.Point(8, 80);
			this.labelUser.Name = "labelUser";
			this.labelUser.Size = new System.Drawing.Size(56, 16);
			this.labelUser.TabIndex = 19;
			this.labelUser.Text = "User";
			// 
			// textBoxUser
			// 
			this.textBoxUser.Location = new System.Drawing.Point(104, 80);
			this.textBoxUser.Name = "textBoxUser";
			this.textBoxUser.Size = new System.Drawing.Size(224, 20);
			this.textBoxUser.TabIndex = 3;
			this.textBoxUser.Text = "localhost";
			// 
			// labelPassword
			// 
			this.labelPassword.Location = new System.Drawing.Point(8, 112);
			this.labelPassword.Name = "labelPassword";
			this.labelPassword.Size = new System.Drawing.Size(56, 16);
			this.labelPassword.TabIndex = 18;
			this.labelPassword.Text = "Password";
			// 
			// textBoxPassword
			// 
			this.textBoxPassword.Location = new System.Drawing.Point(104, 112);
			this.textBoxPassword.Name = "textBoxPassword";
			this.textBoxPassword.Size = new System.Drawing.Size(224, 20);
			this.textBoxPassword.TabIndex = 4;
			this.textBoxPassword.Text = "localhost";
			// 
			// buttonReadData
			// 
			this.buttonReadData.Location = new System.Drawing.Point(256, 144);
			this.buttonReadData.Name = "buttonReadData";
			this.buttonReadData.TabIndex = 5;
			this.buttonReadData.Text = "Read Data";
			this.buttonReadData.Click += new System.EventHandler(this.buttonReadData_Click);
			// 
			// listBoxData
			// 
			this.listBoxData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.listBoxData.Location = new System.Drawing.Point(32, 192);
			this.listBoxData.Name = "listBoxData";
			this.listBoxData.Size = new System.Drawing.Size(312, 108);
			this.listBoxData.TabIndex = 27;
			// 
			// ReceiverForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(400, 326);
			this.Controls.Add(this.listBoxData);
			this.Controls.Add(this.buttonReadData);
			this.Controls.Add(this.textBoxPOPHost);
			this.Controls.Add(this.textBoxPOPPort);
			this.Controls.Add(this.textBoxUser);
			this.Controls.Add(this.textBoxPassword);
			this.Controls.Add(this.labelPOPHost);
			this.Controls.Add(this.labelPOPPort);
			this.Controls.Add(this.labelUser);
			this.Controls.Add(this.labelPassword);
			this.Name = "ReceiverForm";
			this.Text = "ReceiverForm";
			this.ResumeLayout(false);

		}
		#endregion

		private void buttonReadData_Click(object sender, System.EventArgs e)
		{
			listBoxData.Items.Clear ();

			SmtPop.POP3Client pop = new SmtPop.POP3Client ();
			pop.Open (textBoxPOPHost.Text, Convert.ToInt32 (textBoxPOPPort.Text), textBoxUser.Text, textBoxPassword.Text);
			
			// get messages list from pop server
			SmtPop.POPMessageId[] messages = pop.GetMailList ();

			if (messages != null)
			{
				// Walk attachment list
				foreach (SmtPop.POPMessageId id in messages)
				{
					SmtPop.POPReader reader = pop.GetMailReader (id);
					SmtPop.MimeMessage msg = new SmtPop.MimeMessage ();
					
					// read message
					msg.Read (reader);
					if (msg.Attachments != null)
					{
						SmtPop.MimeAttachment attach = msg.Attachments[0];
						if (attach.Filename == "data")
						{
							// read data from attachment
							Byte[] b = Convert.FromBase64String (attach.Body);
							 
							System.IO.MemoryStream mem = new System.IO.MemoryStream (b, false);
							BinaryFormatter f = new BinaryFormatter ();
							DataClass data = (DataClass) f.Deserialize (mem);		
							listBoxData.Items.Add (data);
							mem.Close();

							//delete message
							pop.Dele (id.Id);
						}
					}
				}
			}
			pop.Quit ();
		}
	}
}
