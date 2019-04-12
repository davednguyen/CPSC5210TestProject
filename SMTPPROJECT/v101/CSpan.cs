//
// DotNetControlExtender	Extend standard .Net controls
//
// Copyright (C) 2003 sillycoder	sillycoder@users.sourceforge.net 
//
//
// This library is free software; you can redistribute it and/or
// modify it under the terms of the GNU Lesser General Public
// License as published by the Free Software Foundation; either
// version 2.1 of the License, or (at your option) any later version.
//
// This library is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU
// Lesser General Public License for more details.

using System;

namespace DotNetControlExtender
{
	/// <summary>
	/// The class CSpan handle an horizontal segment in image
	/// </summary>
	public class CSpan
	{
		public CSpan ()
		{
		}
		
		/// <summary>
		/// Span line in pixel
		/// </summary>
		int m_line = -1;

		/// <summary>
		/// Span start column in pixel
		/// </summary>
		int m_startx = -1;
		
		/// <summary>
		/// Span end column in pixel
		/// </summary>
		int m_endx = -1;

		/// <summary>
		/// Span line in pixel
		/// </summary>
		public int line
		{
			get
			{
				return m_line;
			}
			set
			{
				m_line = value;
			}
		}
		
		/// <summary>
		/// Span start column in pixel
		/// </summary>
		public int startx
		{
			get
			{
				return m_startx;
			}
			set
			{
				m_startx = value;
			}
		}
		
		/// <summary>
		/// Span end column in pixel
		/// </summary>
		public int endx
		{
			get
			{
				return m_endx;
			}
			set
			{
				m_endx = value;
			}
		}

	};
}
