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
using System.Drawing; // for bitmap test

using NUnit.Framework;

using SmtPop;


namespace SmtPop.Unit
{
	

	/// <summary>
	/// POP3 Client test
	/// </summary>
	[TestFixture]
	[Category("LongRunning")]
	public class POPMailTest
	{
		
		/// <summary>
		/// Constructor
		/// </summary>
		public POPMailTest()
		{
			
		}

		/// <summary>
		/// Setup the tests
		/// </summary>
		[TestFixtureSetUp]
		public void POPMailTestSetup ()
		{
			// empty test mailbox
			EmptyMailBox (TestConstant.host, TestConstant.portpop, TestConstant.popaccount, TestConstant.poppwd);
			
		}
		
		/// <summary>
		/// Cleanup
		/// </summary>
		[TestFixtureTearDown]
		public void POPMailTestTearDown ()
		{
			// empty test mailbox
			EmptyMailBox (TestConstant.host, TestConstant.portpop, TestConstant.popaccount, TestConstant.poppwd);
			
		}

		/// <summary>
		/// Tests the connection to a server
		/// </summary>
		[Test (Description = "Connection test")]
		public void ConnectTest ()
		{
			POP3Client pop = new POP3Client ();
			pop.Open (TestConstant.host, TestConstant.portpop, TestConstant.popaccount, TestConstant.poppwd);
			pop.Quit ();
		}
		/// <summary>
		/// Tests the connection to a server
		/// </summary>
		[Test (Description = "Stat test")]
		public void StatTest ()
		{
			POP3Client pop = new POP3Client ();
			pop.Open (TestConstant.host, TestConstant.portpop, TestConstant.popaccount, TestConstant.poppwd);
			string str = pop.GetStat ();
			pop.Quit ();
		}

		/// <summary>
		/// Tests listing available mail in mailbox
		/// </summary>
		[Test (Description = "ListTest")]
		public void ListTest ()
		{
			// empty test mailbox
			EmptyMailBox (TestConstant.host, TestConstant.portpop, TestConstant.popaccount, TestConstant.poppwd);
			
			// send some messages
			const int nbmail = 2;
			for (int i = 0; i < nbmail; i++)
			{
				SendTestMail (TestConstant.host, TestConstant.portsmtp, "Nunit POP test n" + nbmail.ToString (),
					"this is test " + i.ToString (), "Tyty <toto@test.com>",  TestConstant.toadr);
			}
			// let some time for the server to work
			System.Threading.Thread.Sleep (5000);

			// retrieve mail
			POP3Client pop = new POP3Client ();
			pop.Open (TestConstant.host, TestConstant.portpop, TestConstant.popaccount, TestConstant.poppwd);
			string str = pop.GetStat ();
			POPMessageId[] m = pop.GetMailList();
			Assert.IsTrue (m.Length == nbmail, "List test failed");

			// delete messages
			foreach (POPMessageId p in m)
			{
				pop.Dele (p.Id);
			}
			
			
			pop.Quit ();
		}

		/// <summary>
		/// Tests listing big mail in mailbox
		/// </summary>
		[Test (Description = "ListTestBig")]
		public void ListTestBig ()
		{
			// empty test mailbox
			EmptyMailBox (TestConstant.host, TestConstant.portpop, TestConstant.popaccount, TestConstant.poppwd);
			
			// send some messages
			const int nbmail = 2;
			for (int i = 0; i < nbmail; i++)
			{
				SendTestMailAttachment (TestConstant.host, TestConstant.portsmtp, "Nunit POP test n" + nbmail.ToString (),
					"this is test " + i.ToString (), "Tyty <toto@test.com>",  TestConstant.toadr);
			}
			// let some time to for the server
			System.Threading.Thread.Sleep (10000);

			// retrieve mail
			POP3Client pop = new POP3Client ();
			pop.Open (TestConstant.host, TestConstant.portpop, TestConstant.popaccount, TestConstant.poppwd);
			string str = pop.GetStat ();
			POPMessageId[] m = pop.GetMailList();
			Assert.IsTrue (m.Length == nbmail, "List test failed");

			// delete messages
			foreach (POPMessageId p in m)
			{
				pop.Dele (p.Id);
			}
			
			
			pop.Quit ();
		}

		/// <summary>
		/// Tests listing available mail in mailbox
		/// </summary>
		[Test (Description = "ReadTest")]
		public void ReadTest ()
		{
			// empty test mailbox
			EmptyMailBox (TestConstant.host, TestConstant.portpop, TestConstant.popaccount, TestConstant.poppwd);
			
			// send some messages
			const int nbmail = 2;
			for (int i = 0; i < nbmail; i++)
			{
				SendTestMail (TestConstant.host, TestConstant.portsmtp, "Nunit POP test n" + nbmail.ToString (),
					"this is test " + i.ToString (), "Tyty <toto@test.com>",  TestConstant.toadr);
			}
			// let some time to for the server
			System.Threading.Thread.Sleep (5000);

			// retrieve mail
			POP3Client pop = new POP3Client ();
			pop.Open (TestConstant.host, TestConstant.portpop, TestConstant.popaccount, TestConstant.poppwd);
			string str = pop.GetStat ();
			POPMessageId[] m = pop.GetMailList();
			Assert.IsTrue (m.Length == nbmail, "List test failed");

			// delete messages
			foreach (POPMessageId p in m)
			{
				POPReader r = pop.GetMailReader (p);

				MimeMessage mes = new MimeMessage ();
				mes.Read (r);

				pop.Dele (p.Id);
			}
			
			
			pop.Quit ();
		}
		/// <summary>
		/// Tests reading big mail from mailbox
		/// </summary>
		[Test (Description = "ReadTestBig")]
		public void ReadTestBig ()
		{
			// empty test mailbox
			EmptyMailBox (TestConstant.host, TestConstant.portpop, TestConstant.popaccount, TestConstant.poppwd);
			
			// send some messages
			const int nbmail = 2;
			for (int i = 0; i < nbmail; i++)
			{
				SendTestMailAttachment (TestConstant.host, TestConstant.portsmtp, "Nunit POP test n" + nbmail.ToString (),
					"this is test " + i.ToString (), "Tyty <toto@test.com>",  TestConstant.toadr);
			}
			// let some time to for the server
			System.Threading.Thread.Sleep (15000);

			// retrieve mail
			POP3Client pop = new POP3Client ();
			pop.Open (TestConstant.host, TestConstant.portpop, TestConstant.popaccount, TestConstant.poppwd);
			string str = pop.GetStat ();
			POPMessageId[] m = pop.GetMailList();
			Assert.IsTrue (m.Length == nbmail, "List test failed");

			// delete messages
			foreach (POPMessageId p in m)
			{
				POPReader r = pop.GetMailReader (p);

				MimeMessage mes = new MimeMessage ();
				mes.Read (r);

				pop.Dele (p.Id);
			}
			
			
			pop.Quit ();
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

		/// <summary>
		/// Sends a mail in test mailbox
		/// </summary>
		/// <param name="host">The smtp host</param>
		/// <param name="port">The smtp service port</param>
		/// <param name="body">The mail body</param>
		/// <param name="subject">The mail subject</param>
		/// <param name="fromstr">The source address</param>
		/// <param name="tostr">The destination address</param>
		private void SendTestMail (string host, int port, string body, string subject, string fromstr, string tostr)
		{
			// build the message
			MimeMessage msg = new MimeMessage ();
			
			MailAddressList from = new MailAddressList ();
			from.Add (new MailAddress (fromstr));
			msg.AddressFrom = from;
			
			MailAddressList to = new MailAddressList ();
			to.Add (new MailAddress (tostr));
			msg.AddressTo = to;
			
			msg.SaveAdr ();

			msg.SetSubject (subject, MimeTransferEncoding.Base64);
			msg.SetBody (body, MimeTransferEncoding.Base64, MimeTextContentType.TextPlain);
			
			SMTPClient smtp = new SMTPClient (host, port);
			smtp.Open ();
			smtp.SendMail (msg);
			smtp.Close ();
			
		}
		
		/// <summary>
		/// Send a mail with attachment in test mailbox
		/// </summary>
		/// <param name="host">The smtp host</param>
		/// <param name="port">The smtp service port</param>
		/// <param name="body">The mail body</param>
		/// <param name="subject">The mail subject</param>
		/// <param name="fromstr">The source address</param>
		/// <param name="tostr">The destination address</param>
		private void SendTestMailAttachment (string host, int port, string body, string subject, string fromstr, string tostr)
		{
			// build a bmp
			System.Drawing.Bitmap bmp = new Bitmap (64,64,System.Drawing.Imaging.PixelFormat.Format24bppRgb);
			for (int l = 0; l < bmp.Height; l++)
			{
				for (int c = 0; c < bmp.Width; c++)
					bmp.SetPixel (c, l, Color.FromArgb (l % 255, c% 255, (l+c) % 255));
			}
		
			// write bmp in a byte buffer
			System.IO.MemoryStream stream = new System.IO.MemoryStream (0);

			bmp.Save (stream,  System.Drawing.Imaging.ImageFormat.Png);
			byte[] buf = stream.GetBuffer ();

			// build the message
			MimeMessage msg = new MimeMessage ();
			
			MailAddressList from = new MailAddressList ();
			from.Add (new MailAddress (fromstr));
			msg.AddressFrom = from;
			
			MailAddressList to = new MailAddressList ();
			to.Add (new MailAddress (tostr));
			msg.AddressTo = to;
			
			msg.SaveAdr ();

			msg.SetSubject (subject, MimeTransferEncoding.Base64);
			MimeAttachment text = new MimeAttachment (body, MimeTextContentType.TextHtml, MimeTransferEncoding.Base64, System.Text.Encoding.UTF8);
			MimeAttachment attach = new MimeAttachment ("test.bmp", "test.bmp", "image/bmp", buf, MimeAttachment.MimeDisposition.inline);
			MimeAttachment attach2 = new MimeAttachment ("test2.bmp", "test2.bmp", "image/bmp", buf, MimeAttachment.MimeDisposition.inline);
			MimeAttachment[] attachments = { text,
											attach,
											attach2
										   };
			msg.SetAttachments (attachments);
			
			SMTPClient smtp = new SMTPClient (host, port);
			smtp.Open ();
			smtp.SendMail (msg);
			smtp.Close ();
			
		}

		
	}
}
