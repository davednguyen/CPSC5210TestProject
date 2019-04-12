using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using SmtPop;

namespace ShowAttachmentList
{
	/// <summary>
	/// Description résumée de Form1.
	/// </summary>
	public class FormShowAttachment : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Button buttonOpen;
		private System.Windows.Forms.OpenFileDialog openFileDialog;
		private System.Windows.Forms.TreeView treeView;
		private System.Windows.Forms.LinkLabel linkLabelFile;
		
		/// <summary>
		/// Needed for design
		/// </summary>
		private System.ComponentModel.Container components = null;

		public FormShowAttachment()
		{
			//
			// Needed for Windows form
			//
			InitializeComponent();
			
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

		#region Windows form generated code
		/// <summary>
		/// Dont modify
		/// </summary>
		private void InitializeComponent()
		{
			this.buttonOpen = new System.Windows.Forms.Button();
			this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
			this.treeView = new System.Windows.Forms.TreeView();
			this.linkLabelFile = new System.Windows.Forms.LinkLabel();
			this.SuspendLayout();
			// 
			// buttonOpen
			// 
			this.buttonOpen.Location = new System.Drawing.Point(16, 16);
			this.buttonOpen.Name = "buttonOpen";
			this.buttonOpen.TabIndex = 0;
			this.buttonOpen.Text = "Open";
			this.buttonOpen.Click += new System.EventHandler(this.buttonOpen_Click);
			// 
			// treeView
			// 
			this.treeView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.treeView.ImageIndex = -1;
			this.treeView.Location = new System.Drawing.Point(8, 48);
			this.treeView.Name = "treeView";
			this.treeView.SelectedImageIndex = -1;
			this.treeView.Size = new System.Drawing.Size(408, 272);
			this.treeView.TabIndex = 1;
			// 
			// linkLabelFile
			// 
			this.linkLabelFile.Location = new System.Drawing.Point(128, 16);
			this.linkLabelFile.Name = "linkLabelFile";
			this.linkLabelFile.Size = new System.Drawing.Size(288, 23);
			this.linkLabelFile.TabIndex = 2;
			// 
			// FormShowAttachment
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(424, 334);
			this.Controls.Add(this.linkLabelFile);
			this.Controls.Add(this.treeView);
			this.Controls.Add(this.buttonOpen);
			this.Name = "FormShowAttachment";
			this.Text = "ShowAttachmentList";
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// Main entry point
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new FormShowAttachment());
		}
		
		/// <summary>
		/// Button "Open" callback. Displays openfile dialog box and display the file in treeview.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void buttonOpen_Click(object sender, System.EventArgs e)
		{
			// get a file name
			openFileDialog.Title = "Open .eml file";
			openFileDialog.Filter = "eml (*.eml)|*.eml|all (*.*)|*.*||";
			openFileDialog.FilterIndex = 0;
			if (openFileDialog.ShowDialog () != DialogResult.OK)
				return;

			// decode eml file
			System.IO.StreamReader r = new System.IO.StreamReader (openFileDialog.FileName);
			POPReader reader = new POPReader (r);
			MimeMessage m = new MimeMessage ();
			m.Read (reader);
			reader.Close ();
			r.Close ();

			// display all attachment
			treeView.Nodes.Clear ();
			TreeNode body = treeView.Nodes.Add ("body");
			/*
			 * body.Nodes.Add  ("Content-transfer-encoding:" + m.ContentTransferEncoding);
			 * body.Nodes.Add  ("Content-Type:" + m.HeaderContentType);
			 */
#if false
			foreach (string k in m.Headers.Keys)
			{
				if (m.Headers[k].GetType () == typeof (ArrayList))
				{
					foreach (string st in (ArrayList) m.Headers[k])
					{
						body.Nodes.Add (k + " : " + st);
					}
				}
				else
					body.Nodes.Add (k + " : " + m.Headers[k]);
			}
#else
			foreach (MimeField k in m.Headers)
			{
				body.Nodes.Add (k.Name + " : " + k.Value);
			}
#endif
			TreeNode attachment = treeView.Nodes.Add ("attachments");
			
			
			BuildNode (attachment, m.Attachments);	

			
			linkLabelFile.Text = openFileDialog.FileName;

		}

		/// <summary>
		/// Displays an attachment in treeview
		/// </summary>
		/// <param name="node">The node where to display the attachments</param>
		/// <param name="attachments">Attachments list</param>
		private void BuildNode (TreeNode node, MimeAttachmentList attachments)
		{
			
		
			foreach (MimeAttachment attach in attachments)
			{
				TreeNode child;
				if (attach.Filename.Length != 0)
				{
					child = node.Nodes.Add (attach.Filename);
					
					
				}						
				else
				{
					child = node.Nodes.Add ("inline");

				}
#if false
				foreach (string k in attach.Headers.Keys)
				{
					child.Nodes.Add (k + " : " + attach.Headers[k]);
				}
#else
				foreach (MimeField k in attach.Headers)
				{
					child.Nodes.Add (k.Name + " : " + k.Value);
				}
#endif
				BuildNode (child, attach.Attachments);
			}
		
		}
		
	}
}
