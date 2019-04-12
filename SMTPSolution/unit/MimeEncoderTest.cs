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
using System.Text;
using System.Text.RegularExpressions;
using NUnit.Framework;
using SmtPop;
using SmtPop.MimeWord;

namespace SmtPop.Unit
{
	/// <summary>
	/// Test MimeEncoder 
	/// </summary>
	/// 
	[TestFixture]
	[Category("FastRunning")]
	public class MimeEncoderTest
	{
		/// <summary>
		/// Constructor
		/// </summary>
		public MimeEncoderTest()
		{
			
		}

		/// <summary>
		/// Test word encoding
		/// </summary>
		[Test (Description = "Test word encoding crlf in base64")]
		public void WordEncodingBase64CrLf ()
		{
			string test = "non ascii é~€ôö$0RqäàåçêëèïîìÄ";
			string res = MimeWordEncoder.Encode (test, Config.defaultEncoding, EncodingIdentifier.Base64, 78);
			
			Assert.IsTrue (res != test, "Failed encoding");
			Assert.IsTrue (res.Length != 0, "Failed encoding");
			Assert.IsTrue (res.IndexOf ("\r") == -1,"Failed LF encoding");
			Assert.IsTrue (res.IndexOf ("\n") == -1,"Failed CR encoding");

			string rtest = MimeWordDecoder.Decode (res);
			Assert.IsTrue (rtest == test, "Failed encode / decode");
		}

		/// <summary>
		/// Test word encoding
		/// </summary>
		[Test (Description = "Test word encoding ")]
		public void WordEncodingUtf8TestBase64 ()
		{
			string [] tests = {
								"hello it is me",
								"ceci est un test éà n° €~²@çêëùµ",
								"^$ëöï @ ^ ç #",
								"smtpop is wonderful"
							  };
			for (int t = 0; t < tests.Length; t++)
			{
				string encode = MimeWordEncoder.Encode (tests[t], Config.defaultEncoding, EncodingIdentifier.Base64);
				string decode ="";

				Regex r = new Regex (@"=\?.*\?[bqBQ]\?(.*)\?=", RegexOptions.Singleline);
				Match m = r.Match (encode);
				if (m.Success)
				{
					string tmp = m.Result ("$1");
					Byte [] code = Convert.FromBase64String (tmp);
					decode = System.Text.Encoding.UTF8.GetString (code);
						
				}

				Assert.IsTrue (decode == tests[t], "Failed encoding / decoding");
			}
			
		}

		/// <summary>
		/// Test max line length in base64 encoding
		/// </summary>
		[Test (Description = "Test encoding base 64 with line length")]
		public void Base64MaxLengthTest ()
		{
			Byte [] src = new Byte[64];
			for (int i = 0; i < src.Length; i++)
			{
				src[i] = (Byte) ((i + i*i + i*i*i) % 255);
			}

			for (int maxlength = 10 ; maxlength < 120; maxlength += 3)
			{
				String b64 = MimeEncoder.ByteBase64 (src, maxlength);
				
				int p = 0;
				int l;
				int max = 0;

				// check max char count on a single line
				while (p < b64.Length)
				{
					if ((l = b64.IndexOf ("\r\n", p)) == -1)
						l = b64.Length;
					
						if (l -p > max)
							max = l-p;
						p = l+1;
				}
				
				Assert.IsTrue (max < maxlength, "Maximum char in line failed");

				// check if b64 is valid
				Byte [] tb = Convert.FromBase64String (b64);
				Assert.IsTrue (tb.Length == src.Length, "Base64 decoding failed src length=" + src.Length.ToString () + 
						" decoded length=" + tb.Length.ToString ());
				for (int i = 0; i < tb.Length; i++)
				{
					Assert.IsTrue (tb[i] == src[i] , 
						"Base64 decoding failed at indice " + 
						i.ToString () + "tb=" + tb[i].ToString () + 
						" src[i]=" + src.ToString () + 
						" maxlength=" + maxlength.ToString());
				}

			}

			
		}

		/// <summary>
		/// Test max line length in base64 encoding
		/// </summary>
		[Test (Description = "Test encoding base 64 with line length")]
		public void MimeWordMaxLengthTest ()
		{
			const int len = 64;
			string src = "";
			for (int i = 0; i < len; i++)
			{
				src += (char) ('0' + i);
			}
			src += " " + src;

			for (int maxlength = 32 ; maxlength < 256; maxlength += 3)
			{
				string word = MimeWordEncoder.Encode (src, Config.defaultEncoding, EncodingIdentifier.QuotedPrintable, maxlength);
				

				int p = 0;
				int l;
				int max = 0;

				// check max char count on a single line
				while (p < word.Length)
				{
					if ((l = word.IndexOf ("\r\n", p)) == -1)
						l = word.Length;
					
					if (l -p > max)
						max = l-p;
					p = l+1;
				}
				
				Assert.IsTrue (max <= maxlength, "Maximum char in line failed");

				// check if word is valid
				string tb = MimeWordDecoder.Decode (word);
				Assert.IsTrue (tb.Length == src.Length, "MimeWord decoding failed src length=" + src.Length.ToString () + 
					" decoded length=" + tb.Length.ToString () + "maxlength=" + maxlength.ToString () );
				for (int i = 0; i < tb.Length && i < src.Length; i++)
				{
					Assert.IsTrue (tb[i] == src[i] , 
						"Quoted printable decoding failed at indice " + 
						i.ToString () + " tb=" + tb[i].ToString () + 
						" src[i]=" + src[i].ToString () + 
						" maxlength=" + maxlength.ToString());
				}

			}

			
		}
	}
}
