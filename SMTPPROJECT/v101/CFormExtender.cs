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
using System.ComponentModel;
using System.Collections;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;


namespace DotNetControlExtender
{
	/// <summary>
	/// IExtenderProvider Implementation to extent Form features
	/// </summary>
	/// 
	[ProvideProperty("ProcessMouse", typeof(Component)) ]
	[ProvideProperty("UseBgImage", typeof(Component)) ]
	[DefaultProperty("UseBgImage")]
	[ToolboxBitmap(typeof(DotNetControlExtender.CFormExtender), "DotNetControlExtender.ico")]
	public class CFormExtender : Component, IExtenderProvider
	{
		/// <summary>
		/// Event Handler for MouseMove event
		/// </summary>
		protected MouseEventHandler m_MouseMoveHandler;
		
		/// <summary>
		/// EventHandler for MouseDown event
		/// </summary>
		protected MouseEventHandler m_MouseDownHandler;
		
		/// <summary>
		/// EventHandler for MouseUp event
		/// </summary>
		protected MouseEventHandler m_MouseUpHandler;
		
		/// <summary>
		/// EventHandler for FormLoad event
		/// </summary>
		protected EventHandler		m_LoadHandler;
		
		/// <summary>
		/// EventHandler for BackGroundImageChanged event
		/// </summary>
		protected EventHandler		m_BackgroundImageChangedHandler;

		/// <summary>
		/// Flag to set the form shape with it background image
		/// </summary>
		protected bool	m_UseBgImage = true;

		/// <summary>
		/// Flag to signal that the form should move with the mouse
		/// </summary>
		protected bool	m_ProcessMouse = true;
		
		/// <summary>
		/// A point to save the mouse position
		/// </summary>
		protected Point m_OldPoint = new Point ();

		public CFormExtender()
		{
			Initialize ();			
		}

		/// <summary>
		/// Add the component into a container
		/// </summary>
		/// <param name="container">Container for the component</param>
		public CFormExtender(IContainer container)
		{
			container.Add(this);
			Initialize ();
		}

		protected void Initialize ()
		{
			m_MouseMoveHandler = new MouseEventHandler (OnMouseMove);
			m_LoadHandler = new EventHandler (OnLoad);
			m_BackgroundImageChangedHandler = new EventHandler (OnBackgroundImageChanged);
			m_MouseDownHandler = new MouseEventHandler (OnMouseDown);
			m_MouseUpHandler = new MouseEventHandler (OnMouseUp);
		}
		#region IExtenderProvider members

		///
		///<summary>
		///Check if the component can be extended by this component
		///</summary>
		/// <param name="extendee">component evaluate for extension</param>
		/// <returns>Return true if  "extendee" can be extent. Otherwise return false</returns>
		///
		public bool CanExtend(object extendee)
		{
			System.IO.StreamWriter w = new StreamWriter ("test.txt", true);
			w.WriteLine (extendee.ToString ());
			w.Close ();
			if (extendee is Form)
				return true;	// extend form
			return false;
		}

		#endregion
		
		/// <summary>
		/// Set the UseBgImage flag
		/// </summary>
		/// <param name="component">Form</param>
		/// <param name="UseBgImage">Flag value</param>
		public void SetUseBgImage (Component component, bool UseBgImage)
		{
			Form f = (Form) component;
			if (f == null)
				return;

			m_UseBgImage = UseBgImage;	
			if (m_UseBgImage)
				RegisterShapeEvent (f);
			else
				UnregisterShaveEvent (f);
		}
		
		/// <summary>
		/// Return the value of UseBgImage flag
		/// </summary>
		/// <param name="component">Form</param>
		/// <returns>UseBgImage flag</returns>
		public bool GetUseBgImage (Component component)
		{
			return (m_UseBgImage);
		}
		
		/// <summary>
		/// Set the ProcessMouse flag
		/// </summary>
		/// <param name="component">Form</param>
		/// <param name="ProcessMouse">Flag value</param>
		public void SetProcessMouse (Component component, bool ProcessMouse)
		{
			Form f = (Form) component;
			if (f == null)
				return;

			m_ProcessMouse = ProcessMouse;
			if (m_ProcessMouse)
				RegisterMouseEvent (f);
			else
				UnregisterMouseEvent (f);
		}

		/// <summary>
		/// Return the ProcessMouse flag
		/// </summary>
		/// <param name="component">Form</param>
		/// <returns>ProcessMouse flag</returns>
		public bool GetProcessMouse (Component component)
		{
			return (m_ProcessMouse);
		}

		/// <summary>
		/// Register events concerned by the shape of the form
		/// </summary>
		/// <param name="comp">Form</param>
		protected void RegisterShapeEvent (Form f)
		{
			f.ControlBox = false;						// disable system menu
			f.FormBorderStyle = FormBorderStyle.None;	// disable border

			f.Load += m_LoadHandler;
			f.BackgroundImageChanged += m_BackgroundImageChangedHandler;
			if (f.Created)
				SetRegion (f);

		}
		
		/// <summary>
		/// Register mouse events 
		/// </summary>
		/// <param name="comp">Form</param>
		protected void RegisterMouseEvent (Form f)
		{
			f.MouseUp +=  m_MouseUpHandler;
			f.MouseDown +=  m_MouseDownHandler;
			
		}

		/// <summary>
		/// Unregister mouse events 
		/// </summary>
		/// <param name="comp">Form</param>
		protected void UnregisterMouseEvent (Form f)
		{
			f.MouseUp -=  m_MouseUpHandler;
			f.MouseDown -=  m_MouseDownHandler;
			f.MouseMove -=  m_MouseMoveHandler;
					
		}

		/// <summary>
		/// Unregister events concerned by the shape of the form
		/// </summary>
		/// <param name="comp">Form</param>
		protected void UnregisterShaveEvent (Form f)
		{
			f.Load -=  m_LoadHandler;
			f.BackgroundImageChanged -= m_BackgroundImageChangedHandler;
			if (f.Created)
				f.Region = new Region ();
		}
		protected void SetRegion (Form f)
		{
			CEdge edge = new CEdge ();
			edge.Prepare (f.BackgroundImage);
			
			Region r = new Region (new Rectangle (0,0,1,1));
			
			foreach (CSpan s in edge.Spans)
			{
				
				r.Union (new Rectangle (s.startx, s.line, (s.endx - s.startx) + 1, 1));
			}
			
			f.Region = r;
		
		}
		protected void OnLoad (object sender, EventArgs e)
		{
			Form f = (Form) sender;
			if (f == null)
				return;

			SetRegion (f);	
		}
		
		protected void OnBackgroundImageChanged (object sender, EventArgs e)
		{
			Form f = (Form) sender;

			if (f == null)
				return;

			SetRegion (f);
		}

		protected void OnMouseDown(object sender, MouseEventArgs e)
		{
			Form f = (Form) sender;
			if (f == null)
				return;

			if(e.Button == MouseButtons.Left && e.Clicks == 1)
			{
				m_OldPoint.X = e.X;
				m_OldPoint.Y = e.Y;
				f.MouseMove += m_MouseMoveHandler;	// register the mouse move event
								
			}
		}

		/// <summary>
		/// Process mouse button up
		/// </summary>
		/// <param name="sender">Form</param>
		/// <param name="e">Mouse event arguments</param>
		protected void OnMouseUp(object sender, MouseEventArgs e)
		{
			Form f = (Form) sender;
			if (f == null)
				return;

			if(e.Button == MouseButtons.Left)
			{
				f.MouseMove -= m_MouseMoveHandler;
			}
		}
		protected void OnMouseMove(object sender, MouseEventArgs e)
		{
			Form f = (Form) sender;
			if (f == null)
				return;

			Point p = new Point (f.Location.X + (e.X - m_OldPoint.X),
				f.Location.Y + (e.Y - m_OldPoint.Y));
			f.Location = p;
				
		}
	}
}
