//
// SmtPop	SMTP and POP library
//
// Copyright (C) 2004-2006 sillycoder	sillycoder@users.sourceforge.net 
//
//
// This program is free software; you can redistribute it and/or
// modify it under the terms of the GNU General Public License
// as published by the Free Software Foundation; either version 2
// of the License, or (at your option) any later version.
// 
// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
// 
// You should have received a copy of the GNU General Public License
// along with this program; if not, write to the Free Software
// Foundation, Inc., 51 Franklin Street, Fifth Floor, Boston, MA  02110-1301, USA.
// 


using System;
using NUnit.Framework;
using SmtPop;

namespace SmtPop.Unit
{
	/// <summary>
	/// Test sending and reading lots of messages
	/// </summary>
	/// 
	[TestFixture]
	[Category("LongRunning")]
	public class LongTest
	{
		/// <summary>
		/// Constructor
		/// </summary>
		public LongTest()
		{
			
		}

		/// <summary>
		/// Setup the tests
		/// </summary>
		[TestFixtureSetUp]
		public void LongTestSetup ()
		{
			EmptyMailBox (TestConstant.host, TestConstant.portpop, TestConstant.longtestaccount, TestConstant.longtestpasswd);
		}

		/// <summary>
		/// Cleanup
		/// </summary>
		[TestFixtureTearDown]
		public void LongTestTearDown ()
		{
			EmptyMailBox (TestConstant.host, TestConstant.portpop, TestConstant.longtestaccount, TestConstant.longtestpasswd);
		}
		/// <summary>
		/// Tests sending and reading messages
		/// </summary>
		[Test (Description = "Test sending and reading messages")]
		public void SendReceiveTest ()
		{
			
			for (int l = 0; l < TestConstant.longtest_loop; l++)
			{
				Console.Out.WriteLine ("Long test loop " + l.ToString ());

				SMTPClient smtp = new SMTPClient (TestConstant.host, TestConstant.portsmtp);
				string body = "This is a simple message for test";
				string subject = "A simple message for test";

				smtp.Open ();
				for (int i = 0; i < TestConstant.longtest_mailloop; i++)
				{
					// build the message
					MimeMessage msg = new MimeMessage ();
					
					MailAddressList from = new MailAddressList ();
					from.Add (new MailAddress ("toto <toto@toto.com>"));
					msg.AddressFrom = from;
				
					MailAddressList to = new MailAddressList ();
					to.Add (new MailAddress (TestConstant.tolongadr));
					msg.AddressTo = to;
				
					msg.SaveAdr ();

					msg.SetSubject (subject, MimeTransferEncoding.Ascii7Bit);
					msg.SetBody (body, MimeTransferEncoding.Ascii7Bit, MimeTextContentType.TextPlain);
					
					smtp.SendMail (msg);
					
				}
				smtp.Close ();
				
				// let some time for the server to work
				System.Threading.Thread.Sleep (100);

				// retrieve mail
				POP3Client pop = new POP3Client ();
				POPMessageId[] m;

				System.DateTime start = System.DateTime.Now;
				System.DateTime end = System.DateTime.Now;
				do
				{
					pop.Open (TestConstant.host, TestConstant.portpop, TestConstant.longtestaccount, TestConstant.longtestpasswd);
					string str = pop.GetStat ();
					m = pop.GetMailList();
					end = System.DateTime.Now;

					if (m.Length >= TestConstant.longtest_mailloop)
						break;
					pop.Quit ();
					
				} while (end.Ticks - start.Ticks < TimeSpan.TicksPerMinute);

				Assert.IsTrue (end.Ticks - start.Ticks < TimeSpan.TicksPerMinute, "Timeout waiting messages in loop " + l.ToString ());
				Assert.IsTrue (m.Length == TestConstant.longtest_mailloop, "List test failed in loop " + l.ToString ());
				

				// delete messages
				foreach (POPMessageId p in m)
				{
					POPReader r = pop.GetMailReader (p);

					MimeMessage mes = new MimeMessage ();
					mes.Read (r);

					Assert.IsTrue (mes.Body == body + "\r\n", "Body test failed in loop "  + l.ToString ());
					Assert.IsTrue (mes.Subject == subject +"\r\n", "Subject test failed in loop " + l.ToString ());
					pop.Dele (p.Id);
				}
			
			
				pop.Quit ();
			}
			
		}
		
		/// <summary>
		/// Resets the test mailbox contents
		/// </summary>
		/// <param name="host">pop server</param>
		/// <param name="port">pop port</param>
		/// <param name="user">user login</param>
		/// <param name="password">user password</param>
		private void EmptyMailBox (string host, int port, string user, string password)
		{
			// empty test mailbox
			POP3Client pop = new POP3Client ();
			pop.Open (host, port, user, password);
			
			POPMessageId[] m = pop.GetMailList();
			if (m != null)
			{
				foreach (POPMessageId p in m)
				{
					pop.Dele (p.Id);
				}
			}
			
			pop.Quit ();
		
		}
	}
}
