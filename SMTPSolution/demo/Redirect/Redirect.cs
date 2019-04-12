using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using SmtPop;

namespace Redirect
{
	/// <summary>
	/// Description résumée de Form1.
	/// </summary>
	public class FormRedirect : System.Windows.Forms.Form
	{
		private System.Windows.Forms.GroupBox groupBoxSrc;
		private System.Windows.Forms.GroupBox groupBoxDst;
		private System.Windows.Forms.TextBox textBoxPOPHost;
		private System.Windows.Forms.TextBox textBoxPOPPort;
		private System.Windows.Forms.TextBox textBoxUser;
		private System.Windows.Forms.TextBox textBoxPassword;
		private System.Windows.Forms.Label labelPOPHost;
		private System.Windows.Forms.Label labelPOPPort;
		private System.Windows.Forms.Label labelUser;
		private System.Windows.Forms.Label labelPassword;
		private System.Windows.Forms.TextBox textBoxSMTPHost;
		private System.Windows.Forms.Label labelSMTPHost;
		private System.Windows.Forms.TextBox textBoxSMTPPort;
		private System.Windows.Forms.Label labelSMTPPort;
		private System.Windows.Forms.Label labelDestination;
		private System.Windows.Forms.TextBox textBoxDestination;
		private System.Windows.Forms.Button buttonStart;
		private System.Windows.Forms.ProgressBar progressBarMail;
		/// <summary>
		/// Variable nécessaire au concepteur.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public FormRedirect()
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
			this.groupBoxSrc = new System.Windows.Forms.GroupBox();
			this.textBoxPOPHost = new System.Windows.Forms.TextBox();
			this.textBoxPOPPort = new System.Windows.Forms.TextBox();
			this.textBoxUser = new System.Windows.Forms.TextBox();
			this.textBoxPassword = new System.Windows.Forms.TextBox();
			this.labelPOPHost = new System.Windows.Forms.Label();
			this.labelPOPPort = new System.Windows.Forms.Label();
			this.labelUser = new System.Windows.Forms.Label();
			this.labelPassword = new System.Windows.Forms.Label();
			this.groupBoxDst = new System.Windows.Forms.GroupBox();
			this.textBoxSMTPHost = new System.Windows.Forms.TextBox();
			this.labelSMTPHost = new System.Windows.Forms.Label();
			this.textBoxSMTPPort = new System.Windows.Forms.TextBox();
			this.labelSMTPPort = new System.Windows.Forms.Label();
			this.labelDestination = new System.Windows.Forms.Label();
			this.textBoxDestination = new System.Windows.Forms.TextBox();
			this.buttonStart = new System.Windows.Forms.Button();
			this.progressBarMail = new System.Windows.Forms.ProgressBar();
			this.groupBoxSrc.SuspendLayout();
			this.groupBoxDst.SuspendLayout();
			this.SuspendLayout();
			// 
			// groupBoxSrc
			// 
			this.groupBoxSrc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.groupBoxSrc.Controls.Add(this.textBoxPOPHost);
			this.groupBoxSrc.Controls.Add(this.textBoxPOPPort);
			this.groupBoxSrc.Controls.Add(this.textBoxUser);
			this.groupBoxSrc.Controls.Add(this.textBoxPassword);
			this.groupBoxSrc.Controls.Add(this.labelPOPHost);
			this.groupBoxSrc.Controls.Add(this.labelPOPPort);
			this.groupBoxSrc.Controls.Add(this.labelUser);
			this.groupBoxSrc.Controls.Add(this.labelPassword);
			this.groupBoxSrc.Location = new System.Drawing.Point(16, 16);
			this.groupBoxSrc.Name = "groupBoxSrc";
			this.groupBoxSrc.Size = new System.Drawing.Size(384, 168);
			this.groupBoxSrc.TabIndex = 0;
			this.groupBoxSrc.TabStop = false;
			this.groupBoxSrc.Text = "Source";
			// 
			// textBoxPOPHost
			// 
			this.textBoxPOPHost.Location = new System.Drawing.Point(128, 32);
			this.textBoxPOPHost.Name = "textBoxPOPHost";
			this.textBoxPOPHost.Size = new System.Drawing.Size(224, 20);
			this.textBoxPOPHost.TabIndex = 1;
			this.textBoxPOPHost.Text = "localhost";
			// 
			// textBoxPOPPort
			// 
			this.textBoxPOPPort.Location = new System.Drawing.Point(128, 56);
			this.textBoxPOPPort.Name = "textBoxPOPPort";
			this.textBoxPOPPort.Size = new System.Drawing.Size(32, 20);
			this.textBoxPOPPort.TabIndex = 2;
			this.textBoxPOPPort.Text = "110";
			// 
			// textBoxUser
			// 
			this.textBoxUser.Location = new System.Drawing.Point(128, 96);
			this.textBoxUser.Name = "textBoxUser";
			this.textBoxUser.Size = new System.Drawing.Size(224, 20);
			this.textBoxUser.TabIndex = 3;
			this.textBoxUser.Text = "localhost";
			// 
			// textBoxPassword
			// 
			this.textBoxPassword.Location = new System.Drawing.Point(128, 128);
			this.textBoxPassword.Name = "textBoxPassword";
			this.textBoxPassword.Size = new System.Drawing.Size(224, 20);
			this.textBoxPassword.TabIndex = 4;
			this.textBoxPassword.Text = "localhost";
			// 
			// labelPOPHost
			// 
			this.labelPOPHost.Location = new System.Drawing.Point(32, 32);
			this.labelPOPHost.Name = "labelPOPHost";
			this.labelPOPHost.Size = new System.Drawing.Size(88, 16);
			this.labelPOPHost.TabIndex = 29;
			this.labelPOPHost.Text = "POP Host";
			// 
			// labelPOPPort
			// 
			this.labelPOPPort.Location = new System.Drawing.Point(32, 56);
			this.labelPOPPort.Name = "labelPOPPort";
			this.labelPOPPort.Size = new System.Drawing.Size(88, 16);
			this.labelPOPPort.TabIndex = 28;
			this.labelPOPPort.Text = "POP Host";
			// 
			// labelUser
			// 
			this.labelUser.Location = new System.Drawing.Point(32, 96);
			this.labelUser.Name = "labelUser";
			this.labelUser.Size = new System.Drawing.Size(56, 16);
			this.labelUser.TabIndex = 27;
			this.labelUser.Text = "User";
			// 
			// labelPassword
			// 
			this.labelPassword.Location = new System.Drawing.Point(32, 128);
			this.labelPassword.Name = "labelPassword";
			this.labelPassword.Size = new System.Drawing.Size(56, 16);
			this.labelPassword.TabIndex = 26;
			this.labelPassword.Text = "Password";
			// 
			// groupBoxDst
			// 
			this.groupBoxDst.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.groupBoxDst.Controls.Add(this.textBoxSMTPHost);
			this.groupBoxDst.Controls.Add(this.labelSMTPHost);
			this.groupBoxDst.Controls.Add(this.textBoxSMTPPort);
			this.groupBoxDst.Controls.Add(this.labelSMTPPort);
			this.groupBoxDst.Controls.Add(this.labelDestination);
			this.groupBoxDst.Controls.Add(this.textBoxDestination);
			this.groupBoxDst.Location = new System.Drawing.Point(16, 200);
			this.groupBoxDst.Name = "groupBoxDst";
			this.groupBoxDst.Size = new System.Drawing.Size(384, 176);
			this.groupBoxDst.TabIndex = 0;
			this.groupBoxDst.TabStop = false;
			this.groupBoxDst.Text = "Destination";
			// 
			// textBoxSMTPHost
			// 
			this.textBoxSMTPHost.Location = new System.Drawing.Point(108, 29);
			this.textBoxSMTPHost.Name = "textBoxSMTPHost";
			this.textBoxSMTPHost.Size = new System.Drawing.Size(216, 20);
			this.textBoxSMTPHost.TabIndex = 5;
			this.textBoxSMTPHost.Text = "localhost";
			// 
			// labelSMTPHost
			// 
			this.labelSMTPHost.Location = new System.Drawing.Point(20, 29);
			this.labelSMTPHost.Name = "labelSMTPHost";
			this.labelSMTPHost.Size = new System.Drawing.Size(64, 23);
			this.labelSMTPHost.TabIndex = 4;
			this.labelSMTPHost.Text = "SMTP host";
			// 
			// textBoxSMTPPort
			// 
			this.textBoxSMTPPort.Location = new System.Drawing.Point(108, 69);
			this.textBoxSMTPPort.Name = "textBoxSMTPPort";
			this.textBoxSMTPPort.Size = new System.Drawing.Size(40, 20);
			this.textBoxSMTPPort.TabIndex = 6;
			this.textBoxSMTPPort.Text = "25";
			// 
			// labelSMTPPort
			// 
			this.labelSMTPPort.Location = new System.Drawing.Point(20, 69);
			this.labelSMTPPort.Name = "labelSMTPPort";
			this.labelSMTPPort.Size = new System.Drawing.Size(64, 23);
			this.labelSMTPPort.TabIndex = 3;
			this.labelSMTPPort.Text = "SMTP port";
			// 
			// labelDestination
			// 
			this.labelDestination.Location = new System.Drawing.Point(20, 125);
			this.labelDestination.Name = "labelDestination";
			this.labelDestination.TabIndex = 8;
			this.labelDestination.Text = "Destination e-mail";
			// 
			// textBoxDestination
			// 
			this.textBoxDestination.Location = new System.Drawing.Point(148, 125);
			this.textBoxDestination.Name = "textBoxDestination";
			this.textBoxDestination.Size = new System.Drawing.Size(216, 20);
			this.textBoxDestination.TabIndex = 7;
			this.textBoxDestination.Text = "test@localhost";
			// 
			// buttonStart
			// 
			this.buttonStart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonStart.Location = new System.Drawing.Point(424, 24);
			this.buttonStart.Name = "buttonStart";
			this.buttonStart.TabIndex = 1;
			this.buttonStart.Text = "Start";
			this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
			// 
			// progressBarMail
			// 
			this.progressBarMail.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.progressBarMail.Location = new System.Drawing.Point(424, 56);
			this.progressBarMail.Name = "progressBarMail";
			this.progressBarMail.Size = new System.Drawing.Size(168, 16);
			this.progressBarMail.TabIndex = 2;
			this.progressBarMail.Value = 25;
			// 
			// FormRedirect
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(608, 390);
			this.Controls.Add(this.progressBarMail);
			this.Controls.Add(this.buttonStart);
			this.Controls.Add(this.groupBoxSrc);
			this.Controls.Add(this.groupBoxDst);
			this.Name = "FormRedirect";
			this.Text = "Redirect";
			this.Load += new System.EventHandler(this.Form1_Load);
			this.groupBoxSrc.ResumeLayout(false);
			this.groupBoxDst.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// Point d'entrée principal de l'application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new FormRedirect());
		}

		private void Form1_Load(object sender, System.EventArgs e)
		{
		
		}

		private void buttonStart_Click(object sender, System.EventArgs e)
		{
			try
			{
				progressBarMail.Minimum = 0;
				progressBarMail.Maximum = 100;

				// read mail from pop server
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
						
						progressBarMail.Value = (id.Id * 100) / messages.Length;
						progressBarMail.Update ();

						// send message
						SmtPop.SMTPClient smtp = new SmtPop.SMTPClient (textBoxSMTPHost.Text, Convert.ToInt32 (textBoxSMTPPort.Text));
						smtp.Open ();
						smtp.SendMail (msg, new MailAddress(textBoxDestination.Text));
						smtp.Close ();

						pop.Dele (id.Id);

					}
				}
				pop.Quit ();
			}
			catch (SmtpException smtp)
			{
				MessageBox.Show (smtp.Message, "SMTP Exception",MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}
			catch (POP3Exception pop)
			{
				MessageBox.Show (pop.Message, "POP Exception",MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}
			catch (Exception ex)
			{
				MessageBox.Show (ex.Message, "Exception",MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}
		}
	}
}
