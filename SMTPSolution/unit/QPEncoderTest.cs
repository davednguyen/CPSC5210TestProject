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
using NUnit;
using NUnit.Framework;
using SmtPop;

namespace SmtPop.Unit
{
	/// <summary>
	/// Test for quoted printable encoder / decoder
	/// </summary>
	/// 
	[TestFixture]
	[Category("FastRunning")]

	public class QPEncoderTest
	{
		/// <summary>
		/// Constructor
		/// </summary>
		public QPEncoderTest()
		{
			
		}
		
		/// <summary>
		/// Test setup
		/// </summary>
		[TestFixtureSetUp]
		public void QPEncoderTestSetup ()
		{
		}

		/// <summary>
		/// Test Teardown
		/// </summary>
		[TestFixtureTearDown]
		public void QPEncoderTestTearDown ()
		{ 
		}

		/// <summary>
		/// Tests the IsAscii () method
		/// </summary>
		[Test (Description="Test IsAscii () (expected true)")]
		public void QPEncoderTestIsAscii_1 ()
		{
			string s = "SmtPop is wonderful";

			string r = QPEncoder.Encode (s, "utf-8");
			Assert.IsTrue (QPEncoder.IsAscii (s));
			
		}
		
		/// <summary>
		/// Tests the IsAscii () method
		/// </summary>
		[Test (Description="Test IsAscii () (expected false)")]
		public void QPEncoderTestIsAscii_2 ()
		{
			string s = "SmtPop is wonderful with accent יאחט";

			string r = QPEncoder.Encode (s, "utf-8");
			Assert.IsTrue (QPEncoder.IsAscii (r));
			Assert.IsFalse (QPEncoder.IsAscii (s));
			
		}
		/// <summary>
		/// Tests encoding and decoding
		/// </summary>
		[Test (Description="Test Encode + Decode")]
		public void QPEncoderTestEncodeDecode ()
		{
			string s = "SmtPop is wonderful with accents יאחטפצ isn't it";

			string r = QPEncoder.Encode (s, "utf-8");
			Assert.IsTrue (QPEncoder.IsAscii (r), "Encoded string is not ascii");
			Assert.IsTrue (r != s);
			string d = QPEncoder.Decode (r, "utf-8");
						
			Assert.IsTrue (d == s, "Encoded decoded string failed");
			Assert.IsTrue (d.Length > 0, "Decoded string failed");
			
		}
		
		/// <summary>
		/// Test encoder with accentuate characters
		/// </summary>
		[Test (Description="Test accents")]
		public void QPEncoderTestEncode ()
		{
			string s = "SmtPop is wonderful with accent יא&איצ€";

			string r = QPEncoder.Encode (s, "utf-8");
			Assert.IsTrue (r != s);
			Assert.IsTrue (QPEncoder.IsAscii (r));
		}
		
		/// <summary>
		/// Test encoder with accentuate characters
		/// </summary>
		[Test (Description="accent test1")]
		public void QPEncoderTestAccent1 ()
		{
			string s = "SmtPop wonderful י";

			string r = QPEncoder.Encode (s, "utf-8");
			Assert.IsTrue (CountChar (r, '=') >= 3);
		}
		
		/// <summary>
		/// Test encoder with accentuate characters
		/// </summary>
		[Test (Description="accent test2")]
		public void QPEncoderTestAccent2 ()
		{
			string s = "SmtPop wonderful פ";

			string r = QPEncoder.Encode (s, "utf-8");
			Assert.IsTrue (CountChar (r, '=') >= 3);
		}
		/// <summary>
		/// Test encoding space
		/// </summary>
		[Test (Description="Space test")]
		public void QPEncoderTestSpace ()
		{
			string s = "SmtPop wonderful";

			string r = QPEncoder.Encode (s, "utf-8");
			Assert.IsTrue (r == "SmtPop=20wonderful");
		}

		
		/// <summary>
		/// Test encoder with euro symbol
		/// </summary>
		[Test (Description="euro test")]
		public void QPEncoderTestEuro ()
		{
			string s = "SmtPop wonderful €";

			string r = QPEncoder.Encode (s, "utf-8");
			Assert.IsTrue (CountChar (r, '=') >= 3);

			string t = QPEncoder.Decode (r, "utf-8");
			Assert.IsTrue (t == s, "Failed encoding / decoding");
		}
		
		/// <summary>
		/// The method counts occurance of "t" in "s".
		/// </summary>
		/// <param name="s">A string</param>
		/// <param name="t">A char</param>
		/// <returns></returns>
		private int CountChar (string s, char t)
		{
			int count = 0;
			for (int i = 0; i < s.Length; i++)
			{
				if (s[i] == t)
					count ++;
			}

			return count;
		}
	}
}
