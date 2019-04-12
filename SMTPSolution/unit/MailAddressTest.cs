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
using SmtPop;
using NUnit.Framework;

namespace SmtPop.Unit
{
	/// <summary>
	/// Unit tests for MailAddress
	/// </summary>
	/// 
	[TestFixture]
	[Category("FastRunning")]
	public class MailAddressTest
	{
		/// <summary>
		/// Constructor
		/// </summary>
		public MailAddressTest()
		{
			
		}
		
		/// <summary>
		/// Test the Mail Adress constructor
		/// </summary>
		[Test (Description = "Simple test")]
		public void SimpleTest ()
		{
			MailAddress a = new MailAddress ("toto", "toto@tyty.com");
			string str = a.Src;

			Assert.IsTrue (a.Name == "toto", "Name test failed");
			Assert.IsTrue (a.Domain == "tyty.com",  "Domain test failed");
			Assert.IsTrue (a.Mailbox == "<toto@tyty.com>", "Mailbox test failed");
			Assert.IsTrue (str == "toto <toto@tyty.com>", "Src test failed");
			
		}

		/// <summary>
		/// Test the Mail Address constructor
		/// </summary>
		[Test (Description = "Check building full address")]
		public void FullAddressTest ()
		{
			MailAddress a = new MailAddress ("toto", "toto@tyty.com");
			string str = a.Src;

			Assert.IsTrue (str == "toto <toto@tyty.com>");
			
		}
		
		/// <summary>
		/// Test MimeWord encoding of name
		/// </summary>
		[Test (Description = "Test MimeWord encoding in address")]
		public void TestMimeWord ()
		{
			string from = "Accent‡È";
			string mbox = "<toto@tyty.com>";
			
			MailAddress a = new MailAddress (from, mbox);
			Assert.IsTrue (MimeWord.MimeWordDecoder.IsMimeWord (a.Src),
				"MimeWord encoding failed in MailAddress (name, mailbox)");
			Assert.IsTrue (a.Name == from,
				"Name MimeWord encoding failed in MailAddress (name, mailbox)");
			Assert.IsTrue (a.Mailbox == mbox,
				"Mailbox encoding failed in MailAddress (name, mailbox)");

			MailAddress at = new MailAddress (a.Src);
			Assert.IsTrue (at.Name == from, "MimeWord decoding failed");

			MailAddress b = new MailAddress (from + " " + mbox);
			Assert.IsTrue (MimeWord.MimeWordDecoder.IsMimeWord (b.Src),
				"MimeWord encoding failed in MailAddress (src)");
			Assert.IsTrue (b.Name == from,
				"Name MimeWord encoding failed in MailAddress (src)");
			Assert.IsTrue (b.Mailbox == mbox,
				"Mailbox encoding failed in MailAddress (src)");

			MailAddress bt = new MailAddress (b.Src);
			Assert.IsTrue (bt.Name == from, "MimeWord decoding failed");

			
		}

		/// <summary>
		/// Tests a malformed mail address
		/// </summary>
		[Test (Description = "Test malformed mailbox")]
		[ExpectedException (typeof (MailAddressException))]
		public void TestBadSource ()
		{
			MailAddress a = new MailAddress ("a");

		}
		
		/// <summary>
		/// Test malformed mailbox
		/// </summary>
		[Test (Description = "Test malformed mailbox")]
		[ExpectedException (typeof (MailAddressException))]
		public void TestBadDomain ()
		{
			MailAddress a = new MailAddress ("Test.bidule.com");

		}

		/// <summary>
		/// Tests a malformed mailbox
		/// </summary>
		[Test (Description = "Test malformed mailbox")]
		[ExpectedException (typeof (MailAddressException))]
		public void TestBadMailbox ()
		{
			MailAddress a = new MailAddress ("<Test@bidule.com");

		}
	}
}
