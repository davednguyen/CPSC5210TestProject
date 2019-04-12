using System;
using SmtPop;

namespace SamplePopEvent
{
	/// <summary>
	/// Description résumée de Class1.
	/// </summary>
	class Program
	{
		static void OnConnect (object sender, ConnectEventParam e)
		{
			Console.Out.WriteLine ("Connected");
		}

		static void OnAuth (object sender, AuthentifiedEventParam e)
		{
			Console.Out.WriteLine (e.User + " logged in");
		}

		static void OnReceive (object sender, ReceivedEventParam e)
		{
			int percent = 0;
			if (e.ByteExpected > 0)
				percent = (e.ByteReceived * 100) / e.ByteExpected;
			Console.Out.WriteLine ("{0}%  {1} bytes", percent, e.ByteReceived);
		}

		/// <summary>
		/// Point d'entrée principal de l'application.
		/// </summary>
		[STAThread]
		static void Main(string[] args)
		{
			if (args.Length != 4)
			{
				Console.Out.WriteLine ("{0} <server> <port> <user> <password>",
					AppDomain.CurrentDomain.FriendlyName);
				return;
			}

			

			Console.Out.WriteLine ("server :" + args[0]);
			Console.Out.WriteLine ("port :" +  args[1]);
			Console.Out.WriteLine ("user :" + args[2]);
			Console.Out.WriteLine ("password :" + args[3]);
			try
			{
				POP3Client pop = new POP3Client ();
				
				pop.Connected += new ConnectEventHandler (OnConnect);
				pop.Authentified += new AuthentifiedEventHandler (OnAuth);
				pop.Received += new ReceivedEventHandler (OnReceive);



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
						
						// read mail 
						
						String s;
						int t = 0;
						while ((s = r.ReadLine ()) != null)
						{
							t += s.Length;
						}
						Console.Out.WriteLine ("Mail size = " + mail.Size.ToString ());
						Console.Out.WriteLine ("");
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

