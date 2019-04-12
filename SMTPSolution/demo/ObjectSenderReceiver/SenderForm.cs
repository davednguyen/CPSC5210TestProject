using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Runtime.Serialization.Formatters.Binary;

namespace ObjectSenderReceiver
{
	/// <summary>
	/// Description résumée de SenderForm.
	/// </summary>
	public class SenderForm : System.Windows.Forms.Form
	{
		private System.Windows.Forms.TextBox textBoxSMTPHost;
		private System.Windows.Forms.TextBox textBoxSMTPPort;
		private System.Windows.Forms.Label labelSMTPHost;
		private System.Windows.Forms.Label labelSMTPPort;
		private System.Windows.Forms.Label labelSender;
		private System.Windows.Forms.Label labelDestination;
		private System.Windows.Forms.TextBox textBoxSender;
		private System.Windows.Forms.TextBox textBoxDestination;
		private System.Windows.Forms.GroupBox groupBoxData;
		private System.Windows.Forms.Label labelFirstName;
		private System.Windows.Forms.Label labelLastName;
		private System.Windows.Forms.TextBox textBoxFirstName;
		private System.Windows.Forms.TextBox textBoxLastName;
		private System.Windows.Forms.Button buttonSend;
		/// <summary>
		/// Variable nécessaire au concepteur.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public SenderForm()
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
				if(components != null)
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
			this.labelSMTPHost = new System.Windows.Forms.Label();
			this.textBoxSMTPHost = new System.Windows.Forms.TextBox();
			this.textBoxSMTPPort = new System.Windows.Forms.TextBox();
			this.labelSMTPPort = new System.Windows.Forms.Label();
			this.labelSender = new System.Windows.Forms.Label();
			this.labelDestination = new System.Windows.Forms.Label();
			this.textBoxSender = new System.Windows.Forms.TextBox();
			this.textBoxDestination = new System.Windows.Forms.TextBox();
			this.groupBoxData = new System.Windows.Forms.GroupBox();
			this.labelFirstName = new System.Windows.Forms.Label();
			this.labelLastName = new System.Windows.Forms.Label();
			this.textBoxFirstName = new System.Windows.Forms.TextBox();
			this.textBoxLastName = new System.Windows.Forms.TextBox();
			this.buttonSend = new System.Windows.Forms.Button();
			this.groupBoxData.SuspendLayout();
			this.SuspendLayout();
			// 
			// labelSMTPHost
			// 
			this.labelSMTPHost.Location = new System.Drawing.Point(8, 16);
			this.labelSMTPHost.Name = "labelSMTPHost";
			this.labelSMTPHost.Size = new System.Drawing.Size(64, 23);
			this.labelSMTPHost.TabIndex = 0;
			this.labelSMTPHost.Text = "SMTP host";
			// 
			// textBoxSMTPHost
			// 
			this.textBoxSMTPHost.Location = new System.Drawing.Point(96, 16);
			this.textBoxSMTPHost.Name = "textBoxSMTPHost";
			this.textBoxSMTPHost.Size = new System.Drawing.Size(216, 20);
			this.textBoxSMTPHost.TabIndex = 1;
			this.textBoxSMTPHost.Text = "localhost";
			// 
			// textBoxSMTPPort
			// 
			this.textBoxSMTPPort.Location = new System.Drawing.Point(96, 56);
			this.textBoxSMTPPort.Name = "textBoxSMTPPort";
			this.textBoxSMTPPort.Size = new System.Drawing.Size(40, 20);
			this.textBoxSMTPPort.TabIndex = 2;
			this.textBoxSMTPPort.Text = "25";
			// 
			// labelSMTPPort
			// 
			this.labelSMTPPort.Location = new System.Drawing.Point(8, 56);
			this.labelSMTPPort.Name = "labelSMTPPort";
			this.labelSMTPPort.Size = new System.Drawing.Size(64, 23);
			this.labelSMTPPort.TabIndex = 0;
			this.labelSMTPPort.Text = "SMTP port";
			// 
			// labelSender
			// 
			this.labelSender.Location = new System.Drawing.Point(8, 88);
			this.labelSender.Name = "labelSender";
			this.labelSender.TabIndex = 2;
			this.labelSender.Text = "Sender e-mail";
			// 
			// labelDestination
			// 
			this.labelDestination.Location = new System.Drawing.Point(8, 112);
			this.labelDestination.Name = "labelDestination";
			this.labelDestination.TabIndex = 2;
			this.labelDestination.Text = "Destination e-mail";
			// 
			// textBoxSender
			// 
			this.textBoxSender.Location = new System.Drawing.Point(136, 88);
			this.textBoxSender.Name = "textBoxSender";
			this.textBoxSender.Size = new System.Drawing.Size(216, 20);
			this.textBoxSender.TabIndex = 3;
			this.textBoxSender.Text = "test@localhost";
			// 
			// textBoxDestination
			// 
			this.textBoxDestination.Location = new System.Drawing.Point(136, 112);
			this.textBoxDestination.Name = "textBoxDestination";
			this.textBoxDestination.Size = new System.Drawing.Size(216, 20);
			this.textBoxDestination.TabIndex = 4;
			this.textBoxDestination.Text = "test@localhost";
			// 
			// groupBoxData
			// 
			this.groupBoxData.Controls.Add(this.labelFirstName);
			this.groupBoxData.Controls.Add(this.labelLastName);
			this.groupBoxData.Controls.Add(this.textBoxFirstName);
			this.groupBoxData.Controls.Add(this.textBoxLastName);
			this.groupBoxData.Location = new System.Drawing.Point(16, 144);
			this.groupBoxData.Name = "groupBoxData";
			this.groupBoxData.Size = new System.Drawing.Size(368, 96);
			this.groupBoxData.TabIndex = 3;
			this.groupBoxData.TabStop = false;
			this.groupBoxData.Text = "Data";
			// 
			// labelFirstName
			// 
			this.labelFirstName.Location = new System.Drawing.Point(16, 24);
			this.labelFirstName.Name = "labelFirstName";
			this.labelFirstName.Size = new System.Drawing.Size(64, 23);
			this.labelFirstName.TabIndex = 0;
			this.labelFirstName.Text = "First Name";
			// 
			// labelLastName
			// 
			this.labelLastName.Location = new System.Drawing.Point(16, 64);
			this.labelLastName.Name = "labelLastName";
			this.labelLastName.Size = new System.Drawing.Size(64, 23);
			this.labelLastName.TabIndex = 0;
			this.labelLastName.Text = "Last Name";
			// 
			// textBoxFirstName
			// 
			this.textBoxFirstName.Location = new System.Drawing.Point(104, 24);
			this.textBoxFirstName.Name = "textBoxFirstName";
			this.textBoxFirstName.Size = new System.Drawing.Size(216, 20);
			this.textBoxFirstName.TabIndex = 5;
			this.textBoxFirstName.Text = "Toto";
			// 
			// textBoxLastName
			// 
			this.textBoxLastName.Location = new System.Drawing.Point(104, 64);
			this.textBoxLastName.Name = "textBoxLastName";
			this.textBoxLastName.Size = new System.Drawing.Size(216, 20);
			this.textBoxLastName.TabIndex = 6;
			this.textBoxLastName.Text = "Tata";
			// 
			// buttonSend
			// 
			this.buttonSend.Location = new System.Drawing.Point(264, 272);
			this.buttonSend.Name = "buttonSend";
			this.buttonSend.TabIndex = 7;
			this.buttonSend.Text = "Send Data";
			this.buttonSend.Click += new System.EventHandler(this.buttonSend_Click);
			// 
			// SenderForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(416, 318);
			this.Controls.Add(this.buttonSend);
			this.Controls.Add(this.groupBoxData);
			this.Controls.Add(this.labelSender);
			this.Controls.Add(this.textBoxSMTPHost);
			this.Controls.Add(this.labelSMTPHost);
			this.Controls.Add(this.textBoxSMTPPort);
			this.Controls.Add(this.labelSMTPPort);
			this.Controls.Add(this.labelDestination);
			this.Controls.Add(this.textBoxSender);
			this.Controls.Add(this.textBoxDestination);
			this.Name = "SenderForm";
			this.Text = "SenderForm";
			this.groupBoxData.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		
		private void buttonSend_Click(object sender, System.EventArgs e)
		{
			
			try
			{

				DataClass data = new DataClass ();
				
				// initialize data
				data.FirstName = textBoxFirstName.Text;
				data.LastName = textBoxLastName.Text;
				
				// serialize data
				System.IO.MemoryStream mem = new System.IO.MemoryStream ();
				BinaryFormatter f = new BinaryFormatter ();
				f.Serialize (mem, data);
				Byte[] buf = mem.GetBuffer ();
				mem.Close ();
				
				// build email
				SmtPop.MimeMessage mes = new SmtPop.MimeMessage ();
				mes.AddressFrom.Add (new SmtPop.MailAddress (textBoxSender.Text));
				mes.AddressTo.Add (new SmtPop.MailAddress (textBoxDestination.Text));
				mes.SetSubject ("test", SmtPop.MimeTransferEncoding.Ascii7Bit);
				mes.SetBody ("this demo of application data transfert", SmtPop.MimeTransferEncoding.Ascii7Bit, SmtPop.MimeTextContentType.TextPlain);
				mes.AddAttachment (new SmtPop.MimeAttachment ("data", "data", "application/data", buf, SmtPop.MimeAttachment.MimeDisposition.attachment));

				// send email
				SmtPop.SMTPClient smtp = new SmtPop.SMTPClient (textBoxSMTPHost.Text, Convert.ToInt32 (textBoxSMTPPort.Text));
				smtp.Open ();
				smtp.SendMail (mes);
				smtp.Close ();
			}
			catch (Exception ex)
			{
				MessageBox.Show (ex.Source + " : " + ex.Message);
			}



		}
	}
}
