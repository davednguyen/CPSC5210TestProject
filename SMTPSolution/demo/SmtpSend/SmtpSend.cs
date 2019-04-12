using System;
using System.Reflection;
using SmtPop;

namespace SmtpSend
{
	/// <summary>
	/// Sends an e-mail from command line
	/// </summary>
	class SmtpSend
	{
		static void OnSendCommand (object sender, ClientCommandEventParam e)
		{
			Console.Out.Write ("Client:{0}", e.Command);
		}
		static void OnAnswer (object sender, ServerAnswerEventParam e)
		{
			Console.Out.Write ("Server:{0}", e.Answer);
		}

		static void OnConnect (object sender, ConnectEventParam e)
		{
			Console.Out.WriteLine ("Connected to:{0}", e.Host);
		}

		/// <summary>
		/// Main entry point
		/// </summary>
		/// <param name="args">Command line argument</param>
		[STAThread]
		static void Main(string[] args)
		{
			string exe = System.Reflection.Assembly.GetExecutingAssembly ().GetName ().Name;

			if (args.Length < 6)
			{
				Console.Out.WriteLine ("{0} <host> <port> <from> <to> <subject> <message> [attachment filter]", exe);
				Console.Out.WriteLine (" ex:");
				Console.Out.WriteLine ("{0} mysmtp@mysmtp.com 25 \"Tester <tyty@tata.com>\" test@bidule.com \"test\" \"Hello\"", exe);
				Console.Out.WriteLine ("{0} mysmtp@mysmtp.com 25 tyty@tata.com test@bidule.com \"test\" \"Hello\" *.zip", exe);
				Console.Out.WriteLine ("{0} mysmtp@mysmtp.com 25 tyty@tata.com test@bidule.com \"test\" \"Hello it is me\" attach.zip *.exe", exe);

			}
			try
			{
				string host = args[0];
				int port = Convert.ToInt32 (args[1], 10);
				string from = args[2];
				string to = args[3];
				string subject = args[4];
				string body = args[5];
				
				// build the message
				MimeMessage mes = new MimeMessage ();
				mes.SetAddressFrom (new MailAddress [] {new MailAddress(from)});
				mes.SetAddressTo (new MailAddress [] {new MailAddress(to)});
				mes.SaveAdr ();

				mes.SetSubject (subject, MimeTransferEncoding.Base64);
				if (args.Length <= 6)
				{
					mes.SetBody (body, MimeTransferEncoding.Base64, MimeTextContentType.TextPlain);
				}
				else
				{
					MimeAttachmentList attach = new MimeAttachmentList ();
					
					attach.Add (new MimeAttachment (body, MimeTextContentType.TextPlain));
					
					for (int i = 6; i < args.Length; i++)
					{
						string path = ".";
						string search = args[i];
						int p;

						if ((p = args[0].LastIndexOf ("\\") ) != -1)
						{
							path = args[0].Substring (0, p);
							search = args[0].Substring (p + 1, args[0].Length - p -1);
						}
						
						string[] fnames = System.IO.Directory.GetFiles (path, search);

						
						foreach (string f in fnames)
						{
							string name;
							if ((p = f.LastIndexOf ("\\")) == -1)
								name = f;
							else
								name = f.Substring (p, f.Length - p);
							attach.Add (new MimeAttachment (f, name, "application/binary"));
						}
					}
					
					
					mes.Attachments = attach;
				}
				
				
				SMTPClient smtp = new SMTPClient (host, port);
				smtp.SendedCommand += new ClientCommandEventHandler (OnSendCommand);
				smtp.ServerAnswer += new ServerAnswerEventHandler (OnAnswer);
				smtp.Connected += new ConnectEventHandler (OnConnect);

				smtp.Open ();
				smtp.SendTimeout = 3 * 60000; // 3 minutes
				smtp.SendMail (mes);
				smtp.Close ();

				Console.Out.WriteLine (mes.ToString ());
			}
			catch (Exception e)
			{
				Console.Out.WriteLine ("{0}\r\n{1}\r\n{2}", e.Message, e.Source, e.StackTrace);
			}

		}
	}
}
