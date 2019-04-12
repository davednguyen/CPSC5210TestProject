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
using NUnit.Framework;
using SmtPop;


namespace SmtPop.Unit

{
	/// <summary>
	/// Test mime reader with simulation files
	/// </summary>
	[TestFixture]
	[Category("FastRunning")]
	public class EmlFileTest
	{
		/// <summary>
		/// Constructor
		/// </summary>
		public EmlFileTest()
		{
			
		}

		/// <summary>
		/// Setup the tests
		/// </summary>
		[TestFixtureSetUp]
		public void emffiletestSetup ()
		{
		}

		/// <summary>
		/// Tests the reading eml files
		/// </summary>
		[Test (Description = "Test reading .eml files")]
		public void FileTest ()
		{
			try
			{
				string basedir = System.IO.Directory.GetCurrentDirectory ();
				
				basedir += @"\emltest";
				Console.Out.WriteLine ("Test eml files in " + basedir);
				
				string[] fnames = System.IO.Directory.GetFiles (basedir, "*.eml");
				foreach (string f in fnames)
				{
					Console.Out.WriteLine ("testing files "+ f);

					System.IO.StreamReader r = new System.IO.StreamReader (f);
					POPReader pop = new POPReader (r);
					MimeMessage m = new MimeMessage ();
					m.Read (pop);
					Console.Out.Write ("From:");
					foreach (MailAddress a in m.AddressFrom)
					{
						Console.Out.Write (a.Mailbox);
						Console.Out.Write (" ");
					}
					Console.Out.WriteLine ("");
					Console.Out.Write ("Subject:");
					Console.Out.WriteLine (m.Subject);
				}
			}
			catch (Exception ex)
			{
				Console.Error.WriteLine (ex.Message + " " + ex.StackTrace);
				throw (ex);
			}
		}
		
		/// <summary>
		/// Tests reading subject in .eml files
		/// </summary>
		[Test (Description = "Test reading subject in .eml files")]
		public void FileSubjectTest ()
		{
			string basedir = System.IO.Directory.GetCurrentDirectory ();
			
			basedir += @"\emltest";
			Console.Out.WriteLine ("Test subject in .eml files in " + basedir);
			
			string[] fnames = System.IO.Directory.GetFiles (basedir, "*.eml");
			foreach (string f in fnames)
			{
				

				System.IO.StreamReader r = new System.IO.StreamReader (f);
				POPReader pop = new POPReader (r);
				MimeMessage m = new MimeMessage ();
				m.Read (pop);
				string Subject = m.HeaderSubject;
				if (MimeWord.MimeWordDecoder.IsMimeWord (Subject))
				{
					MimeWord.MimeWordDecoder dec= new MimeWord.MimeWordDecoder ();
					Console.Out.WriteLine (f + ":");
					Console.Out.WriteLine ("Subject:" + Subject);
					Console.Out.WriteLine ("Decoded:" + MimeWord.MimeWordDecoder.Decode (Subject));
				}
			}
		}
		
		/// <summary>
		/// Test reading from address in .eml files
		/// </summary>
		[Test (Description = "Test reading from address in .eml files")]
		public void FileFromTest ()
		{
			string basedir = System.IO.Directory.GetCurrentDirectory ();
			
			basedir += @"\emltest";
			Console.Out.WriteLine ("Test From address in .eml files in " + basedir);
			
			string[] fnames = System.IO.Directory.GetFiles (basedir, "*.eml");
			foreach (string f in fnames)
			{
				//Console.Out.WriteLine (f);
				System.IO.StreamReader r = new System.IO.StreamReader (f);
				POPReader pop = new POPReader (r);
				MimeMessage m = new MimeMessage ();
				m.Read (pop);
				if (m.AddressFrom.Count > 0)
				{
					string Str = m.AddressFrom[0].Src;

					if (MimeWord.MimeWordDecoder.IsMimeWord (Str))
					{
						Console.Out.WriteLine (f + ":");
						Console.Out.WriteLine ("From (MimeWord):" + m.AddressFrom[0].Name);
					}
					else
					{
						Console.Out.WriteLine (f + ":");
						Console.Out.WriteLine ("From:" + m.AddressFrom[0].Src);
					}

				}
			}
		}

		/// <summary>
		/// Test reading to address in .eml files
		/// </summary>
		[Test (Description = "Test reading to address in .eml files")]
		public void FileToTest ()
		{
			string basedir = System.IO.Directory.GetCurrentDirectory ();
			
			basedir += @"\emltest";
			Console.Out.WriteLine ("Test To address in .eml files in " + basedir);
			
			string[] fnames = System.IO.Directory.GetFiles (basedir, "*.eml");
			foreach (string f in fnames)
			{
				System.IO.StreamReader r = new System.IO.StreamReader (f);
				POPReader pop = new POPReader (r);
				MimeMessage m = new MimeMessage ();
				m.Read (pop);
				if (m.AddressFrom.Count > 0)
				{
					string Str = m.AddressFrom[0].Src;

					if (MimeWord.MimeWordDecoder.IsMimeWord (Str))
					{
						Console.Out.WriteLine (f + ":");
						Console.Out.WriteLine ("From:" + m.AddressFrom[0].Name);
					}
				}
			}
		}

	}

		
}
