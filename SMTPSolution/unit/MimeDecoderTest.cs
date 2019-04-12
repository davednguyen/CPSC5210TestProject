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
using SmtPop.MimeWord;

	
namespace SmtPop.Unit
{
	/// <summary>
	/// Test MimeDecoder
	/// </summary>
	///
	[TestFixture]
	[Category("FastRunning")]
	public class MimeDecoderTest
	{
		/// <summary>
		/// Constructor
		/// </summary>
		public MimeDecoderTest()
		{
			
		}
	
		/// <summary>
		/// Test word decoding quoted printable iso8859-1
		/// </summary>	
		[Test (Description = "Test word decoding quoted printable iso8859-1")]
		public void WordDecodingTestQPIso88591()
		{
			string[] src = {
							   @"=?iso-8859-1?q?Devis_r=E9f=E9rencement_=7C=7C=20A=20l=27attention=20du=20service=20commercial?=",
							   @"=?iso-8859-1?q?Devis_r=E9f=E9rencement_=7C=7C=20A=20l=27attention=20du=20service=20commercial?= =?iso-8859-1?q?Devis_r=E9f=E9rencement_=7C=7C=20A=20l=27attention=20du=20service=20commercial?=",
							   @"Start String =?iso-8859-1?q?Devis_r=E9f=E9rencement_=7C=7C=20A=20l=27attention=20du=20service=20commercial?= End String"
			};
						
			foreach (string s in src)
			{
				string dst = MimeWordDecoder.Decode (s);
				Assert.IsTrue (dst.IndexOf ("=?") == -1, "Decoding failed");
				Assert.IsTrue (dst.IndexOf ("?=") == -1, "Decoding failed");
				Assert.IsTrue (dst.IndexOf ("=") == -1, "Decoding failed");
			}
		}


		/// <summary>
		/// Test word decoding quoted printable utf-8
		/// </summary>	
		[Test (Description = "Test word decoding quoted printable utf8")]
		public void WordDecodingTestQPUTF8()
		{
			string[] src = {
								@"=?utf-8?Q?Proposition_:_Recherche_de_comp=C3=A9?=	=?utf-8?Q?tences?=",
								@"=?utf-8?Q?Proposition_:_Recherche_de_comp=C3=A9tences?=",
								@"StartString =?utf-8?Q?Proposition_:_Recherche_de_comp=C3=A9tences?= End String",
						   };
						
			foreach (string s in src)
			{
				string dst = MimeWordDecoder.Decode (s);
				Assert.IsTrue (dst.IndexOf ("=?") == -1, "Decoding failed");
				Assert.IsTrue (dst.IndexOf ("?=") == -1, "Decoding failed");
				Assert.IsTrue (dst.IndexOf ("=") == -1, "Decoding failed");
			}
		}

	}
}
