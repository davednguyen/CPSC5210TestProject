using System;
using SmtPop;

namespace PopSrvToEml
{
	/// <summary>
	/// Reads Messages from a pop server and write .eml files
	/// </summary>
	class CPopToEml
	{
		static void OnSendCommand (object sender, ClientCommandEventParam e)
		{
			Console.Out.WriteLine ("Client:{0}", e.Command);
		}
		static void OnAnswer (object sender, ServerAnswerEventParam e)
		{
			Console.Out.WriteLine ("Server:{0}", e.Answer);
		}

		static void OnConnect (object sender, ConnectEventParam e)
		{
			Console.Out.WriteLine ("Connected to:{0}", e.Host);
		}
		static void OnAuth (object sender, AuthentifiedEventParam e)
		{
			Console.Out.WriteLine ("User: {0} logged in", e.User);
		}
		/// <summary>
		/// Main entry point
		/// </summary>
		[STAThread]
		static void Main(string[] args)
		{
			Console.Out.WriteLine ("Pop3 To .Eml files utility");
			if (args.Length != 5)
			{
				Console.Out.WriteLine ("{0} <server> <port> <user> <password> <prefix>",
					AppDomain.CurrentDomain.FriendlyName);
				return;
			}

			Console.Out.WriteLine ("server :" + args[0]);
			Console.Out.WriteLine ("port :" +  args[1]);
			Console.Out.WriteLine ("user :" + args[2]);
			Console.Out.WriteLine ("password :" + args[3]);
			Console.Out.WriteLine ("prefix :" + args[4]);
			try
			{
				POP3Client pop = new POP3Client ();
				pop.SendedCommand += new ClientCommandEventHandler (OnSendCommand);
				pop.ServerAnswer += new ServerAnswerEventHandler (OnAnswer);
				pop.Connected += new ConnectEventHandler (OnConnect);
				pop.Authentified += new AuthentifiedEventHandler (OnAuth);

				// connect to the pop server
				pop.ReceiveTimeout = 3 * 60000;	// 3 minutes
				pop.Open (args[0], Convert.ToInt32(args[1]), args[2], args[3]);

				// retrieve message list
				POPMessageId[] messages = pop.GetMailList ();
				if (messages != null)
				{
					// walk message list
					foreach (POPMessageId mail in messages)
					{
						Console.Out.WriteLine ("Reading mail :" + mail.Id.ToString ());
						
						// get a text reader for the mail
						POPReader r = pop.GetMailReader (mail);
						
						// write mail on disk
						System.IO.StreamWriter tw = new System.IO.StreamWriter (args[4] + mail.Id.ToString() + ".eml", false);
						String s;
						while ((s = r.ReadLine ()) != null)
						{
							tw.WriteLine (s);
						}
						tw.Close ();
						r.Close ();
					}	
				}

				// close connection to server
				pop.Quit ();
			}
			catch (Exception e)
			{
				Console.WriteLine (e.Source + " : " + e.Message + "\r\n" + e.StackTrace);
			}
		}
	}
}
