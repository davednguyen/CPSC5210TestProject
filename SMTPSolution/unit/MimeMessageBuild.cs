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
using System.Drawing.Drawing2D;
using System.IO;

using NUnit;
using NUnit.Framework;
using SmtPop;

namespace SmtPop.Unit
{
	/// <summary>
	/// Test MimeMessage Construction
	/// </summary>
	[TestFixture]
	[Category("FastRunning")]

	public class MimeMessageBuild
	{
		/// <summary>
		/// Constructor
		/// </summary>
		public MimeMessageBuild()
		{
			
		}

		/// <summary>
		/// Test building a simple messsage
		/// </summary>
		[Test (Description="Build a simple Mime Message")]
		public void BuildSimple ()
		{
			MimeMessage msg = new MimeMessage ();
			string body = "This is a simple message for test";
			string subject = "A simple message";

			MailAddressList from = new MailAddressList ();
			from.Add (new MailAddress ("toto@toto.com"));
			msg.AddressFrom = from;
					
			MailAddressList to = new MailAddressList ();
			to.Add (new MailAddress ("tyty@tyty.com"));
			msg.AddressTo = to;

			msg.SaveAdr ();

			msg.SetSubject (subject, MimeTransferEncoding.Ascii7Bit);
			msg.SetBody (body, MimeTransferEncoding.Ascii7Bit, MimeTextContentType.TextPlain);
			
			System.IO.StringWriter wr = new System.IO.StringWriter ();
			msg.Write (wr);

			Assert.IsTrue (wr.ToString ().Length > 0);
			Assert.IsFalse (msg.Multipart);
			Assert.IsTrue (msg.AddressFrom.Count == 1, "From address failed");
			Assert.IsTrue (msg.AddressTo.Count == 1, "To Address failed");
			Assert.IsTrue (msg.Body.Equals(body), "Body test failed");
			Assert.IsTrue (msg.HeaderSubject == subject + "\r\n", "Subject test failed");
			Assert.IsTrue ((string) msg.Headers["Subject"] == subject + "\r\n", "Subject test failed");
			

		}
		/// <summary>
		/// Test building a simple messsage
		/// </summary>
		[Test (Description="Build and read simple Mime Message")]
		public void BuildAndRead()
		{
			MimeMessage msg = new MimeMessage ();
			string body = "This is a simple message for test";
			string subject = "A simple message";

			MailAddressList from = new MailAddressList ();
			from.Add (new MailAddress ("toto@toto.com"));
			msg.AddressFrom = from;
					
			MailAddressList to = new MailAddressList ();
			to.Add (new MailAddress ("tyty@tyty.com"));
			msg.AddressTo = to;
			MailAddressList cc = new MailAddressList ();
			cc.Add (new MailAddress ("tutu <tutu@tyty.com>"));
			cc.Add (new MailAddress ("toto <toto@tyty.com>"));
			msg.AddressCC = cc;

			msg.SaveAdr ();

			msg.SetSubject (subject, MimeTransferEncoding.Ascii7Bit);
			msg.SetBody (body, MimeTransferEncoding.Ascii7Bit, MimeTextContentType.TextPlain);
			
			System.IO.StringWriter wr = new System.IO.StringWriter ();
			msg.Write (wr);

			Assert.IsTrue (wr.ToString ().Length > 0);
			Assert.IsFalse (msg.Multipart);
			Assert.IsTrue (msg.AddressFrom.Count == 1, "From address failed");
			Assert.IsTrue (msg.AddressTo.Count == 1, "To Address failed");
			Assert.IsTrue (msg.AddressCC.Count == 2, "To Address failed");
			Assert.IsTrue (msg.Body.Equals(body), "Body test failed");
			Assert.IsTrue (msg.HeaderSubject == subject + "\r\n", "Subject test failed");
			Assert.IsTrue ((string) msg.Headers["Subject"] == subject + "\r\n", "Subject test failed");
			
			MimeMessage read = new MimeMessage ();
			System.IO.StringReader r = new System.IO.StringReader (wr.ToString ());
			read.Read (r);

			Assert.IsFalse (read.Multipart);
			Assert.IsTrue (read.AddressFrom.Count == 1, "From address failed");
			Assert.IsTrue (read.AddressTo.Count == 1, "To Address failed");
			Assert.IsTrue (read.Body == body +"\r\n", "Body test failed");
			Assert.IsTrue (read.HeaderSubject == subject + "\r\n", "Subject test failed");
			Assert.IsTrue ((string) msg.Headers["Subject"] == subject + "\r\n", "Subject test failed");
			
			string a = read.AddressCC[0].Src;
			string b = cc[0].Src;

			Assert.IsTrue (read.AddressCC[0].Src == cc[0].Src, "First CC Address failed");
			Assert.IsTrue (read.AddressCC[1].Src == cc[1].Src, "Second CC Address failed");

		}
		/// <summary>
		/// Test building a simple messsage with multi from address
		/// </summary>
		[Test (Description="Build and read Mime Message with multi From address")]
		public void BuildAndReadMultiFrom()
		{
			MimeMessage msg = new MimeMessage ();
			string body = "This is a simple message for test";
			string subject = "A simple message";

			MailAddressList from = new MailAddressList ();
			from.Add (new MailAddress ("toto <toto@toto.com>"));
			from.Add (new MailAddress ("gogo@toto.com"));
			msg.AddressFrom = from;
			
			MailAddress sender = new MailAddress ("gogo@toto.com");
			msg.AddressSender = sender;

			MailAddressList to = new MailAddressList ();
			to.Add (new MailAddress ("tyty <tyty@tyty.com>"));
			to.Add (new MailAddress ("tata@tyty.com"));
			msg.AddressTo = to;
			
			MailAddressList cc = new MailAddressList ();
			cc.Add (new MailAddress ("tutu <tutu@tyty.com>"));
			cc.Add (new MailAddress ("toto <toto@tyty.com>"));
			msg.AddressCC = cc;

			msg.SaveAdr ();

			msg.SetSubject (subject, MimeTransferEncoding.Ascii7Bit);
			msg.SetBody (body, MimeTransferEncoding.Ascii7Bit, MimeTextContentType.TextPlain);
			
			System.IO.StringWriter wr = new System.IO.StringWriter ();
			msg.Write (wr);

			Assert.IsTrue (wr.ToString ().Length > 0);
			Assert.IsFalse (msg.Multipart);
			Assert.IsTrue (msg.AddressFrom.Count == 2, "From address failed");
			Assert.IsTrue (msg.AddressTo.Count == 2, "To Address failed");
			Assert.IsTrue (msg.AddressCC.Count == 2, "To Address failed");
			Assert.IsTrue (msg.Body == body, "Body test failed");
			Assert.IsTrue (msg.HeaderSubject == subject + "\r\n", "Subject test failed");
			Assert.IsTrue ((string) msg.Headers["Subject"] == subject + "\r\n", "Subject test failed");
			
			MimeMessage read = new MimeMessage ();
			System.IO.StringReader r = new System.IO.StringReader (wr.ToString ());
			read.Read (r);

			Assert.IsFalse (read.Multipart);
			Assert.IsTrue (read.AddressFrom.Count == 2, "From address failed");
			Assert.IsTrue (read.AddressTo.Count == 2, "To Address failed");
			Assert.IsTrue (read.Body == body + "\r\n", "Body test failed");
			Assert.IsTrue (read.HeaderSubject == subject + "\r\n", "Subject test failed");
			Assert.IsTrue ((string) msg.Headers["Subject"] == subject + "\r\n", "Subject test failed");
			
			Assert.IsTrue (read.AddressSender.Src == sender.Src, "Sender address failed");
			Assert.IsTrue (read.AddressFrom[0].Src == from[0].Src, "First FROM Address failed");
			Assert.IsTrue (read.AddressFrom[1].Src == from[1].Src, "Second FROM Address failed");

			Assert.IsTrue (read.AddressTo[0].Src == to[0].Src, "First TO Address failed");
			Assert.IsTrue (read.AddressTo[1].Src == to[1].Src, "Second TO Address failed");

			Assert.IsTrue (read.AddressCC[0].Src == cc[0].Src, "First CC Address failed");
			Assert.IsTrue (read.AddressCC[1].Src == cc[1].Src, "Second CC Address failed");

		}
		/// <summary>
		/// Test building a simple messsage with multi from address
		/// </summary>
		[Test (Description="Build and read simple Mime Message bad sender")]
		public void BuildAndReadMultiFrombadsender()
		{
			MimeMessage msg = new MimeMessage ();
			string body = "This is a simple message for test";
			string subject = "A simple message";

			MailAddressList from = new MailAddressList ();
			from.Add (new MailAddress ("toto <toto@toto.com>"));
			from.Add (new MailAddress ("gogo@toto.com"));
			msg.AddressFrom = from;
			
			MailAddress sender = new MailAddress ("gigi@toto.com");
			msg.AddressSender = sender;

			MailAddressList to = new MailAddressList ();
			to.Add (new MailAddress ("tyty <tyty@tyty.com>"));
			to.Add (new MailAddress ("tata@tyty.com"));
			msg.AddressTo = to;
			
			MailAddressList cc = new MailAddressList ();
			cc.Add (new MailAddress ("tutu <tutu@tyty.com>"));
			cc.Add (new MailAddress ("toto <toto@tyty.com>"));
			msg.AddressCC = cc;

			msg.SaveAdr ();

			msg.SetSubject (subject, MimeTransferEncoding.Ascii7Bit);
			msg.SetBody (body, MimeTransferEncoding.Ascii7Bit, MimeTextContentType.TextPlain);
			
			System.IO.StringWriter wr = new System.IO.StringWriter ();
			msg.Write (wr);

			Assert.IsTrue (wr.ToString ().Length > 0);
			Assert.IsFalse (msg.Multipart);
			Assert.IsTrue (msg.AddressFrom.Count == 2, "From address failed");
			Assert.IsTrue (msg.AddressTo.Count == 2, "To Address failed");
			Assert.IsTrue (msg.AddressCC.Count == 2, "To Address failed");
			Assert.IsTrue (msg.Body == body, "Body test failed");
			Assert.IsTrue (msg.HeaderSubject == subject + "\r\n", "Subject test failed");
			Assert.IsTrue ((string) msg.Headers["Subject"] == subject + "\r\n", "Subject test failed");
			
			MimeMessage read = new MimeMessage ();
			System.IO.StringReader r = new System.IO.StringReader (wr.ToString ());
			read.Read (r);

			Assert.IsFalse (read.Multipart);
			Assert.IsTrue (read.AddressFrom.Count == 2, "From address failed");
			Assert.IsTrue (read.AddressTo.Count == 2, "To Address failed");
			Assert.IsTrue (read.Body == body +"\r\n", "Body test failed");
			Assert.IsTrue (read.HeaderSubject == subject + "\r\n", "Subject test failed");
			Assert.IsTrue ((string) msg.Headers["Subject"] == subject + "\r\n", "Subject test failed");
			
			Assert.IsTrue (read.AddressSender.Src == sender.Src, "Sender address failed");
			Assert.IsTrue (read.AddressFrom[0].Src == from[0].Src, "First FROM Address failed");
			Assert.IsTrue (read.AddressFrom[1].Src == from[1].Src, "Second FROM Address failed");

			Assert.IsTrue (read.AddressTo[0].Src == to[0].Src, "First TO Address failed");
			Assert.IsTrue (read.AddressTo[1].Src == to[1].Src, "Second TO Address failed");

			Assert.IsTrue (read.AddressCC[0].Src == cc[0].Src, "First CC Address failed");
			Assert.IsTrue (read.AddressCC[1].Src == cc[1].Src, "Second CC Address failed");

		}
		/// <summary>
		/// Test building a simple messsage with  attachment
		/// </summary>
		[Test (Description="Build and read Mime Message with attachment in 7bits")]
		public void BuildAndReadAttachment7Bits()
		{
			MimeMessage msg = new MimeMessage ();
			string body = "This is a simple message for test";
			string subject = "A simple message with attachment";

			MailAddressList from = new MailAddressList ();
			from.Add (new MailAddress ("toto <toto@toto.com>"));
			msg.AddressFrom = from;
			
			MailAddressList to = new MailAddressList ();
			to.Add (new MailAddress ("tyty <tyty@tyty.com>"));
			to.Add (new MailAddress ("tata@tyty.com"));
			msg.AddressTo = to;
			
			MailAddressList cc = new MailAddressList ();
			cc.Add (new MailAddress ("tutu <tutu@tyty.com>"));
			cc.Add (new MailAddress ("toto <toto@tyty.com>"));
			msg.AddressCC = cc;

			msg.SaveAdr ();

			msg.SetSubject (subject, MimeTransferEncoding.Ascii7Bit);
			//msg.SetBody (body, MimeTransferEncoding.Ascii7Bit, MimeTextContentType.TextPlain);
			MimeAttachment[] attachments = new MimeAttachment[2];
			attachments[0] = new MimeAttachment (body, MimeTextContentType.TextPlain);
			attachments[1] = new MimeAttachment ("attachment test", SmtPop.MimeTextContentType.TextPlain);
			msg.SetAttachments (attachments);

			System.IO.StringWriter wr = new System.IO.StringWriter ();
			msg.Write (wr);

			Assert.IsTrue (wr.ToString ().Length > 0);
			Assert.IsTrue (msg.Multipart, "Multipart failed");
			Assert.IsTrue (msg.AddressFrom.Count == 1, "From address failed");
			Assert.IsTrue (msg.AddressTo.Count == 2, "To Address failed");
			Assert.IsTrue (msg.AddressCC.Count == 2, "To Address failed");
			
			Assert.IsTrue (msg.HeaderSubject == subject + "\r\n", "Subject test failed");
			Assert.IsTrue ((string) msg.Headers["Subject"] == subject + "\r\n", "Subject test failed");
			
			MimeMessage read = new MimeMessage ();
			System.IO.StringReader r = new System.IO.StringReader (wr.ToString ());
			read.Read (r);

			
			Assert.IsTrue (read.AddressFrom.Count == 1, "From address failed");
			Assert.IsTrue (read.AddressTo.Count == 2, "To Address failed");
			
			Assert.IsTrue (read.HeaderSubject == subject + "\r\n", "Subject test failed");
			Assert.IsTrue ((string) msg.Headers["Subject"] == subject + "\r\n", "Subject test failed");
			
			
			Assert.IsTrue (read.AddressFrom[0].Src == from[0].Src, "First FROM Address failed");
			

			Assert.IsTrue (read.AddressTo[0].Src == to[0].Src, "First TO Address failed");
			Assert.IsTrue (read.AddressTo[1].Src == to[1].Src, "Second TO Address failed");

			Assert.IsTrue (read.AddressCC[0].Src == cc[0].Src, "First CC Address failed");
			Assert.IsTrue (read.AddressCC[1].Src == cc[1].Src, "Second CC Address failed");
			
			Assert.IsTrue (read.Multipart, "Attachment failed");
			Assert.IsTrue (read.Attachments.Count == 2, "Attachment count failed");
			Assert.IsTrue (read.Attachments[0].Body == attachments[0].Body + "\r\n", "Attachment body failed");
			Assert.IsTrue (read.Attachments[0].ContentTransferEncoding == "7Bit\r\n", "Content-Tranfer-Encoding failed");
			Assert.IsTrue (read.Attachments[1].Body == attachments[1].Body +"\r\n", "Attachment body failed");
			Assert.IsTrue (read.Attachments[1].ContentTransferEncoding == "7Bit\r\n", "Content-Tranfer-Encoding failed");
		}

		/// <summary>
		/// Test building a simple messsage with  attachment
		/// </summary>
		[Test (Description="Build and read Mime Message with attachment in base64")]
		public void BuildAndReadAttachmentBase64()
		{
			string bodyattachment = "attachment test with accents non ascii char é à €";
			MimeMessage msg = new MimeMessage ();
			string body = "This is a simple message for test";
			string subject = "A simple message with attachment";

			MailAddressList from = new MailAddressList ();
			from.Add (new MailAddress ("toto <toto@toto.com>"));
			msg.AddressFrom = from;
			
			MailAddressList to = new MailAddressList ();
			to.Add (new MailAddress ("tyty <tyty@tyty.com>"));
			to.Add (new MailAddress ("tata@tyty.com"));
			msg.AddressTo = to;
			
			MailAddressList cc = new MailAddressList ();
			cc.Add (new MailAddress ("tutu <tutu@tyty.com>"));
			cc.Add (new MailAddress ("toto <toto@tyty.com>"));
			msg.AddressCC = cc;

			msg.SaveAdr ();

			msg.SetSubject (subject, MimeTransferEncoding.Ascii7Bit);
			msg.SetBody (body, MimeTransferEncoding.Ascii7Bit, MimeTextContentType.TextPlain);
			MimeAttachment[] attachments = new MimeAttachment[2];
			attachments[0] = new MimeAttachment (bodyattachment, SmtPop.MimeTextContentType.TextPlain);
			attachments[1] = new MimeAttachment (bodyattachment, SmtPop.MimeTextContentType.TextPlain);
			msg.SetAttachments (attachments);

			System.IO.StringWriter wr = new System.IO.StringWriter ();
			msg.Write (wr);

			Assert.IsTrue (wr.ToString ().Length > 0);
			Assert.IsTrue (msg.Multipart, "Multipart failed");
			Assert.IsTrue (msg.AddressFrom.Count == 1, "From address failed");
			Assert.IsTrue (msg.AddressTo.Count == 2, "To Address failed");
			Assert.IsTrue (msg.AddressCC.Count == 2, "To Address failed");
			
			Assert.IsTrue (msg.HeaderSubject == subject + "\r\n", "Subject test failed");
			Assert.IsTrue ((string) msg.Headers["Subject"] == subject + "\r\n", "Subject test failed");
			
			MimeMessage read = new MimeMessage ();
			System.IO.StringReader r = new System.IO.StringReader (wr.ToString ());
			read.Read (r);

			
			Assert.IsTrue (read.AddressFrom.Count == 1, "From address failed");
			Assert.IsTrue (read.AddressTo.Count == 2, "To Address failed");
			
			Assert.IsTrue (read.HeaderSubject == subject + "\r\n", "Subject test failed");
			Assert.IsTrue ((string) msg.Headers["Subject"] == subject + "\r\n", "Subject test failed");
			
			
			Assert.IsTrue (read.AddressFrom[0].Src == from[0].Src, "First FROM Address failed");
			

			Assert.IsTrue (read.AddressTo[0].Src == to[0].Src, "First TO Address failed");
			Assert.IsTrue (read.AddressTo[1].Src == to[1].Src, "Second TO Address failed");

			Assert.IsTrue (read.AddressCC[0].Src == cc[0].Src, "First CC Address failed");
			Assert.IsTrue (read.AddressCC[1].Src == cc[1].Src, "Second CC Address failed");
			
			Assert.IsTrue (read.Multipart, "Attachment failed");
			Assert.IsTrue (read.Attachments.Count == 2, "Attachment count failed");
			
			Assert.IsTrue (read.Attachments[0].ContentTransferEncoding == "Base64\r\n", "Content-Tranfer-Encoding failed");
			string code = read.Attachments[0].Body;
			Byte[] utf8 = Convert.FromBase64String (code);
			string s = System.Text.Encoding.UTF8.GetString (utf8);
			Assert.IsTrue (s == bodyattachment, "Body attachment Base64 failed");

			Assert.IsTrue (read.Attachments[1].ContentTransferEncoding == "Base64\r\n", "Content-Tranfer-Encoding failed");
			code = read.Attachments[1].Body;
			utf8 = Convert.FromBase64String (code);
			s = System.Text.Encoding.UTF8.GetString (utf8);
			Assert.IsTrue (s == bodyattachment, "Body attachment Base64 failed");

		}

		/// <summary>
		/// Test building a simple messsage with  attachments
		/// </summary>
		[Test (Description="Build and read Mime Message with attachments in base64 and 7bit")]
		public void BuildAndReadAttachmentBase647Bit()
		{
			string bodyattachment = "attachment test with accents non ascii char é à €";
			MimeMessage msg = new MimeMessage ();
			string body = "This is a simple message for test";
			string subject = "A simple message with attachment";

			MailAddressList from = new MailAddressList ();
			from.Add (new MailAddress ("toto <toto@toto.com>"));
			msg.AddressFrom = from;
			
			MailAddressList to = new MailAddressList ();
			to.Add (new MailAddress ("tyty <tyty@tyty.com>"));
			to.Add (new MailAddress ("tata@tyty.com"));
			msg.AddressTo = to;
			
			MailAddressList cc = new MailAddressList ();
			cc.Add (new MailAddress ("tutu <tutu@tyty.com>"));
			cc.Add (new MailAddress ("toto <toto@tyty.com>"));
			msg.AddressCC = cc;

			msg.SaveAdr ();

			msg.SetSubject (subject, MimeTransferEncoding.Ascii7Bit);
			msg.SetBody (body, MimeTransferEncoding.Ascii7Bit, MimeTextContentType.TextPlain);
			MimeAttachment[] attachments = new MimeAttachment[2];
			attachments[0] = new MimeAttachment (bodyattachment, SmtPop.MimeTextContentType.TextPlain);
			attachments[1] = new MimeAttachment ("attachment text", SmtPop.MimeTextContentType.TextPlain);
			msg.SetAttachments (attachments);

			System.IO.StringWriter wr = new System.IO.StringWriter ();
			msg.Write (wr);

			Assert.IsTrue (wr.ToString ().Length > 0);
			Assert.IsTrue (msg.Multipart, "Multipart failed");
			Assert.IsTrue (msg.AddressFrom.Count == 1, "From address failed");
			Assert.IsTrue (msg.AddressTo.Count == 2, "To Address failed");
			Assert.IsTrue (msg.AddressCC.Count == 2, "To Address failed");
			
			Assert.IsTrue (msg.HeaderSubject == subject + "\r\n", "Subject test failed");
			Assert.IsTrue ((string) msg.Headers["Subject"] == subject + "\r\n", "Subject test failed");
			
			MimeMessage read = new MimeMessage ();
			System.IO.StringReader r = new System.IO.StringReader (wr.ToString ());
			read.Read (r);

			
			Assert.IsTrue (read.AddressFrom.Count == 1, "From address failed");
			Assert.IsTrue (read.AddressTo.Count == 2, "To Address failed");
			
			Assert.IsTrue (read.HeaderSubject == subject + "\r\n", "Subject test failed");
			Assert.IsTrue ((string) msg.Headers["Subject"] == subject + "\r\n", "Subject test failed");
			
			
			Assert.IsTrue (read.AddressFrom[0].Src == from[0].Src, "First FROM Address failed");
			

			Assert.IsTrue (read.AddressTo[0].Src == to[0].Src, "First TO Address failed");
			Assert.IsTrue (read.AddressTo[1].Src == to[1].Src, "Second TO Address failed");

			Assert.IsTrue (read.AddressCC[0].Src == cc[0].Src, "First CC Address failed");
			Assert.IsTrue (read.AddressCC[1].Src == cc[1].Src, "Second CC Address failed");
			
			Assert.IsTrue (read.Multipart, "Attachment failed");
			Assert.IsTrue (read.Attachments.Count == 2, "Attachment count failed");
			
			Assert.IsTrue (read.Attachments[0].ContentTransferEncoding == "Base64\r\n", "Content-Tranfer-Encoding failed");
			string code = read.Attachments[0].Body;
			Byte[] utf8 = Convert.FromBase64String (code);
			string s = System.Text.Encoding.UTF8.GetString (utf8);
			Assert.IsTrue (s == bodyattachment, "Body attachment Base64 failed");

			Assert.IsTrue (read.Attachments[1].Body == attachments[1].Body + "\r\n", "Attachment body failed");
			Assert.IsTrue (read.Attachments[1].ContentTransferEncoding == "7Bit\r\n", "Content-Tranfer-Encoding failed");

		}

		/// <summary>
		/// Test building a simple messsage with  attachments
		/// </summary>
		[Test (Description="Test attachment line length in base64")]
		public void TestLineLengthBase64()
		{
			Byte[] testbuf = new Byte[4096];

			MimeMessage msg = new MimeMessage ();
			string body = "This is a simple message for test";
			string subject = "A simple message with attachment";

			MailAddressList from = new MailAddressList ();
			from.Add (new MailAddress ("toto <toto@toto.com>"));
			msg.AddressFrom = from;
			
			MailAddressList to = new MailAddressList ();
			to.Add (new MailAddress ("tyty <tyty@tyty.com>"));
			to.Add (new MailAddress ("tata@tyty.com"));
			msg.AddressTo = to;
			
			MailAddressList cc = new MailAddressList ();
			cc.Add (new MailAddress ("tutu <tutu@tyty.com>"));
			cc.Add (new MailAddress ("toto <toto@tyty.com>"));
			msg.AddressCC = cc;

			msg.SaveAdr ();

			msg.SetSubject (subject, MimeTransferEncoding.Ascii7Bit);
			msg.SetBody (body, MimeTransferEncoding.Ascii7Bit, MimeTextContentType.TextPlain);
			MimeAttachment[] attachments = new MimeAttachment[2];
			attachments[0] = new MimeAttachment ("test","test.bin", "application/data", testbuf, MimeAttachment.MimeDisposition.attachment);
			attachments[1] = new MimeAttachment ("attachment text", SmtPop.MimeTextContentType.TextPlain);
			msg.SetAttachments (attachments);

			System.IO.StringWriter wr = new System.IO.StringWriter ();
			msg.Write (wr);

			Assert.IsTrue (wr.ToString ().Length > 0);
			Assert.IsTrue (msg.Multipart, "Multipart failed");
			Assert.IsTrue (msg.AddressFrom.Count == 1, "From address failed");
			Assert.IsTrue (msg.AddressTo.Count == 2, "To Address failed");
			Assert.IsTrue (msg.AddressCC.Count == 2, "To Address failed");
			
			Assert.IsTrue (msg.HeaderSubject == subject + "\r\n", "Subject test failed");
			Assert.IsTrue ((string) msg.Headers["Subject"] == subject + "\r\n", "Subject test failed");
			
			MimeMessage read = new MimeMessage ();
			System.IO.StringReader r = new System.IO.StringReader (wr.ToString ());
			read.Read (r);

			
			Assert.IsTrue (read.AddressFrom.Count == 1, "From address failed");
			Assert.IsTrue (read.AddressTo.Count == 2, "To Address failed");
			
			Assert.IsTrue (read.HeaderSubject == subject + "\r\n", "Subject test failed");
			Assert.IsTrue ((string) msg.Headers["Subject"] == subject + "\r\n", "Subject test failed");
			
			
			Assert.IsTrue (read.AddressFrom[0].Src == from[0].Src, "First FROM Address failed");
			

			Assert.IsTrue (read.AddressTo[0].Src == to[0].Src, "First TO Address failed");
			Assert.IsTrue (read.AddressTo[1].Src == to[1].Src, "Second TO Address failed");

			Assert.IsTrue (read.AddressCC[0].Src == cc[0].Src, "First CC Address failed");
			Assert.IsTrue (read.AddressCC[1].Src == cc[1].Src, "Second CC Address failed");
			
			Assert.IsTrue (read.Multipart, "Attachment failed");
			Assert.IsTrue (read.Attachments.Count == 2, "Attachment count failed");
			
			String st = read.Attachments[0].Body;
			int p = 0;
			int l;
			int max = 0;

			// check max char count on a single line
			while (p < st.Length)
			{
				if ((l = st.IndexOf ("\r\n", p)) == -1)
					l = st.Length;
					
				if (l -p > max)
					max = l-p;
				p = l+1;
			}
				
			Assert.IsTrue (max < 78, "Maximum char in line failed");

		}
		/// <summary>
		/// Sends a simple mail with an attachment
		/// </summary>
		[Test (Description="Send a simple mail with direct attachment")]
		public void TestSimpleDirectAttachment ()
		{
			// build a bmp
			System.Drawing.Bitmap bmp = new System.Drawing.Bitmap (64,64,System.Drawing.Imaging.PixelFormat.Format24bppRgb);
			for (int l = 0; l < bmp.Height; l++)
			{
				for (int c = 0; c < bmp.Width; c++)
					bmp.SetPixel (c, l, System.Drawing.Color.FromArgb (l % 255, c% 255, (l+c) % 255));
			}
		
			// write bmp in a byte buffer
			System.IO.MemoryStream stream = new System.IO.MemoryStream (0);

			bmp.Save (stream,  System.Drawing.Imaging.ImageFormat.Png);
			byte[] buf = stream.GetBuffer ();
			stream.Close ();

			// build the message
			MimeMessage mes = new MimeMessage ();
			
			mes.AddressFrom.Add (new SmtPop.MailAddress ("test@localhost"));
			mes.AddressTo.Add (new SmtPop.MailAddress ("test2@localhost"));
			mes.SetSubject ("test", SmtPop.MimeTransferEncoding.Base64);
			mes.SetBody ("test multipart", SmtPop.MimeTransferEncoding.Ascii7Bit, SmtPop.MimeTextContentType.TextPlain);
			mes.Attachments.Add (new SmtPop.MimeAttachment ("data.bmp", "data.bmp", "application/data", buf, SmtPop.MimeAttachment.MimeDisposition.attachment));

			// store email
			System.IO.StringWriter wr = new System.IO.StringWriter ();
			mes.Write (wr);
			
			MimeMessage read = new MimeMessage ();
			System.IO.StringReader r = new System.IO.StringReader (wr.ToString ());
			read.Read (r);
			Assert.IsTrue (read.Attachments.Count > 0, "Attachment count failed");			
			Assert.IsTrue (read.Attachments[0].Filename == "data.bmp", "Filename value failed");
		}

		/// <summary>
		/// Tests getting a stream from a base64 mail attachment
		/// </summary>
		[Test (Description="Test getting a stream from a mail attachment")]
		public void TestMimeMessageStream ()
		{
			byte[] samples = new Byte[4096];
			for (int i = 0; i < samples.Length; i++)
			{
					samples [i] = (Byte) ((i + i*i + i*i*i) % 255);
			}

			MimeMessage msg = MessageBuilder.Build ("test@test.test", "toto@test.test", "subject", "body",
				MimeTextContentType.TextPlain, samples, "application/binary", "data");

			MemoryStream s = new MemoryStream (msg.Attachments[1].GetBytes ());
			
			Assert.IsTrue (s.Length == samples.Length, "Invalid data length");
			byte [] test = new byte[samples.Length];
			s.Read (test, 0, samples.Length);
			for (int i = 0; i < test.Length; i++)
				Assert.IsTrue (test[i] == samples[i], "Invalid data indice={0} value={1},{2}", i, test[i], samples[i]);


		}
		
		/// <summary>
		/// Test getting an arry of bytes from a base64 attachment
		/// </summary>
		[Test (Description="Test reading bytes from a mail attachment")]
		public void TestMimeMessageBytes ()
		{
			byte[] samples = new Byte[4096];
			for (int i = 0; i < samples.Length; i++)
			{
				samples [i] = (Byte) ((i + i*i + i*i*i) % 255);
			}

			MimeMessage msg = MessageBuilder.Build ("test@test.test", "toto@test.test", "subject", "body",
				MimeTextContentType.TextPlain, samples, "application/binary", "data");

			Assert.IsTrue (msg.Attachments.Count == 2);

			byte [] test = msg.Attachments[1].GetBytes ();
			
			Assert.IsTrue (test.Length == samples.Length, "Invalid data length");

			for (int i = 0; i < test.Length; i++)
				Assert.IsTrue (test[i] == samples[i], "Invalid data indice={0} value={1},{2}", i, test[i], samples[i]);


		}

		/// <summary>
		/// Test exception when getting bytes frm a non base64 attachment
		/// </summary>
		[Test (Description="Test exception when reading bytes from a non base64 mail attachment")]
		[ExpectedException(typeof(MimeException))]
		public void TestMimeMessageBytesException ()
		{
			byte[] samples = new Byte[4096];
			
			MimeMessage msg = MessageBuilder.Build ("test@test.test", "toto@test.test", "subject", "body",
				MimeTextContentType.TextPlain, samples, "application/binary", "data");

			Assert.IsTrue (msg.Attachments.Count == 2);

			byte [] test = msg.Attachments[0].GetBytes ();
			
			Assert.IsTrue (test.Length == samples.Length, "Invalid data length");

			
		}
		
		/// <summary>
		/// Test exception when getting stream from a non base64 attachment
		/// </summary>
		[Test (Description="Test exception when getting a stream from a non base64 mail attachment")]
		[ExpectedException(typeof(MimeException))]
		public void TestMimeMessageStreamException ()
		{
			byte[] samples = new Byte[4096];
		
			MimeMessage msg = MessageBuilder.Build ("test@test.test", "toto@test.test", "subject", "body",
				MimeTextContentType.TextPlain, samples, "application/binary", "data");

			MemoryStream s = new MemoryStream (msg.Attachments[0].GetBytes ());
			
			Assert.IsTrue (s.Length == samples.Length, "Invalid data length");
			byte [] test = new byte[samples.Length];
			s.Read (test, 0, samples.Length);
			for (int i = 0; i < test.Length; i++)
				Assert.IsTrue (test[i] == samples[i], "Invalid data indice={0} value={1},{2}", i, test[i], samples[i]);
		}
	}
}


