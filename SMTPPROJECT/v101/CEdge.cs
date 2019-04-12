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
using System.Drawing;
using System.Collections;

namespace DotNetControlExtender
{
	/// <summary>
	/// The class CEdge process edge detection.
	/// </summary>
	public class CEdge
	{
		/// <summary>
		/// Spans list of object in image
		/// </summary>
		protected	ArrayList ar = new ArrayList ();

		/// <summary>
		/// Constructor
		/// </summary>
		public CEdge()
		{
			
		}
		
		/// <summary>
		/// The method compute the spans list of object in
		/// image "img"
		/// </summary>
		/// <param name="img">Image</param>
		public void Prepare (Image img)
		{
			if (img == null)
				throw new System.Exception ("Invalid argument");

			Bitmap bmp = new Bitmap (img);
			ar.Clear ();

			if (bmp.Width == 0 || bmp.Height == 0)
				return;
		
			int l,c;

			System.Drawing.Color t = bmp.GetPixel (0,0);

			for (l = 0; l < bmp.Height; l++)
			{
				CSpan s = new CSpan ();	
				s.startx = -1;
				for (c = 0; c < bmp.Width; c++)
				{
					System.Drawing.Color pc = bmp.GetPixel (c, l);

					if (s.startx == -1)
					{
						if (pc != t)
						{
							s.startx = c;
							s.line = l;
						}
					}
					else
					{
						if (pc == t)
						{
							s.endx = c - 1;
							ar.Add (s);
							s = new CSpan ();
					
						}
					}
				}
				if (s.startx != -1)
				{
					s.endx = bmp.Width - 1;
					ar.Add (s);

				}
			}
			
			

		}
				
		/// <summary>
		/// Return spans of detected objects in the image
		/// </summary>
		public ArrayList Spans
		{
			get
			{
				return ar;
			}
		}
	}
}
