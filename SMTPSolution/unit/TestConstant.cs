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

namespace SmtPop.Unit
{
	/// <summary>
	/// Some constants definition for tests
	/// </summary>
	public class TestConstant
	{
		/// <summary>
		/// Server host
		/// </summary>
		public static string host = "localhost";
		/// <summary>
		/// SMTP port
		/// </summary>
		public static int portsmtp = 25;
		/// <summary>
		/// POP3 port
		/// </summary>
		public static int portpop = 110;
		
		/// <summary>
		/// destination address
		/// </summary>
		public static string toadr = "Tester <test@bidule.com>";
		
		/// <summary>
		/// destination address for long test
		/// </summary>
		public static string tolongadr = "Long Tester <longtest@bidule.com>";

		/// <summary>
		/// pop user login
		/// </summary>
		public static string popaccount = "test@bidule.com";
		
		/// <summary>
		/// pop user password
		/// </summary>
		public static string poppwd = "test";
		
		/// <summary>
		/// Number of loop for long test
		/// </summary>
		public static int longtest_loop = 100;

		/// <summary>
		/// Number of messages per loop for long test
		/// </summary>
		public static int longtest_mailloop = 5;

		/// <summary>
		/// long test mailbox login
		/// </summary>
		public static string longtestaccount = "longtest@bidule.com";
		
		/// <summary>
		/// long test mailbox password
		/// </summary>
		public static string longtestpasswd = "test";

		/// <summary>
		/// Constructor
		/// </summary>
		public TestConstant()
		{
			
		}
	}
}
