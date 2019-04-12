//
// SmtPop	SMTP and POP library
//
// Copyright (C) 2004-2005 sillycoder	sillycoder@users.sourceforge.net 
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

using NUnit;
using NUnit.Framework;

namespace SmtPop.Unit
{
	/// <summary>
	/// Test sending mail
	/// </summary>
	[TestFixture]
	[Category("LongRunning")]

	public class SendMailTest
	{
		/// <summary>
		/// Constructor
		/// </summary>
		public SendMailTest()
		{
			
		}

		/// <summary>
		/// Tests setup
		/// </summary>
		[TestFixtureSetUp]
		public void SendMailSetup ()
		{
		}

		/// <summary>
		/// Tests teardown
		/// </summary>
		[TestFixtureTearDown]
		public void SendMailTearDown ()
		{ 
		}

		/// <summary>
		/// Test sending a simple mail
		/// </summary>
		[Test (Description="Send a simple mail")]
		public void SendSimpleMailTest()
		{
			// build the message
			MimeMessage msg = new MimeMessage ();
			string body = "This is a simple message for test";
			string subject = "A simple message for test";

			MailAddressList from = new MailAddressList ();
			from.Add (new MailAddress ("toto <toto@toto.com>"));
			msg.AddressFrom = from;
			
			MailAddressList to = new MailAddressList ();
			to.Add (new MailAddress (TestConstant.toadr));
			msg.AddressTo = to;
			
			msg.SaveAdr ();

			msg.SetSubject (subject, MimeTransferEncoding.Ascii7Bit);
			msg.SetBody (body, MimeTransferEncoding.Ascii7Bit, MimeTextContentType.TextPlain);

			SMTPClient smtp = new SMTPClient (TestConstant.host, TestConstant.portsmtp);
			smtp.Open ();
			smtp.SendMail (msg);
			smtp.Close ();
			
		}

		/// <summary>
		/// Test sending a simple mail with special cr/lf sequence
		/// </summary>
		[Test (Description="Send a simple mail with cr/lf.cr/lf")]
		public void SendSimpleMailCRLFTest()
		{
			string body = "This is a simple message for test\r\n.\r\n";
			string subject = "A simple message for test";

			
			MimeMessage msg = new MimeMessage ();
			
			// build the address source and destination
			MailAddressList from = new MailAddressList ();
			from.Add (new MailAddress ("toto <toto@toto.com>"));
			msg.AddressFrom = from;
			
			MailAddressList to = new MailAddressList ();
			to.Add (new MailAddress (TestConstant.toadr));
			msg.AddressTo = to;
			
			msg.SaveAdr ();
			
			// build message
			msg.SetSubject (subject, MimeTransferEncoding.Ascii7Bit);
			msg.SetBody (body, MimeTransferEncoding.Ascii7Bit, MimeTextContentType.TextPlain);

			// send message
			SMTPClient smtp = new SMTPClient (TestConstant.host, TestConstant.portsmtp);
			smtp.Open ();
			smtp.SendMail (msg);
			smtp.Close ();
			
		}
		/// <summary>
		/// Test sending a mail with html body
		/// </summary>
		[Test (Description="Send a simple mail with html")]
		public void SendSimpleMailTestHtml()
		{
			// build the message
			MimeMessage msg = new MimeMessage ();
			string body = "<html><body><B>Hello it is me</B><BR/><font size=\"+4\" color=\"red\">It Works</font><body></html>";
			string subject = "A simple message for test";

			MailAddressList from = new MailAddressList ();
			from.Add (new MailAddress ("toto <toto@toto.com>"));
			msg.AddressFrom = from;
			
			MailAddressList to = new MailAddressList ();
			to.Add (new MailAddress (TestConstant.toadr));
			msg.AddressTo = to;
			
			msg.SaveAdr ();

			msg.SetSubject (subject, MimeTransferEncoding.Ascii7Bit);
			msg.SetBody (body, MimeTransferEncoding.Base64, MimeTextContentType.TextHtml);

			SMTPClient smtp = new SMTPClient ("localhost", 25);
			smtp.Open ();
			smtp.SendMail (msg);
			smtp.Close ();
			
		}
		/// <summary>
		/// Send a mail with html body and bmp attachment
		/// </summary>
		[Test (Description="Send a simple mail with html and bmp")]
		public void SendSimpleMailTestHtmlBmp()
		{
			// build a small bmp
			System.Drawing.Bitmap bmp = new Bitmap (128,128,System.Drawing.Imaging.PixelFormat.Format24bppRgb);
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
			
			string body = "<html><body><B>Hello it is me</B><BR/><font size=\"+4\" color=\"red\">It Works</font><body></html>";
			string subject = "A simple message for test";

			MailAddressList from = new MailAddressList ();
			from.Add (new MailAddress ("toto <toto@toto.com>"));
			msg.AddressFrom = from;
			
			MailAddressList to = new MailAddressList ();
			to.Add (new MailAddress (TestConstant.toadr));
			msg.AddressTo = to;
			
			msg.SaveAdr ();

			msg.SetSubject (subject, MimeTransferEncoding.Ascii7Bit);
			
			MimeAttachment text = new MimeAttachment (body, MimeTextContentType.TextHtml, MimeTransferEncoding.Base64, System.Text.Encoding.UTF8);
			MimeAttachment attach = new MimeAttachment ("test.png", "test.png", "image/png", buf, MimeAttachment.MimeDisposition.inline);
			MimeAttachment[] attachments = { text,
											attach
										   };
			msg.SetAttachments (attachments);

			SMTPClient smtp = new SMTPClient (TestConstant.host, TestConstant.portsmtp);
			smtp.Open ();
			smtp.SendMail (msg);
			
		}

		
	}
}
