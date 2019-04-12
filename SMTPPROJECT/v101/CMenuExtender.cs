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
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Collections;
using System.Diagnostics;

namespace DotNetControlExtender
{
	/// <summary>
	/// Enumeration for text alignement style in menu
	/// </summary>
	public enum TextAlign
	{
		Right,
		Left,
		Center,
	};

	/// <summary>
	/// Provide parameters for menu extension
	/// </summary>
	public class CMenuExtenderParam
	{
		#region Constructor
		/// <summary>
		/// Default constructor
		/// </summary>
		public CMenuExtenderParam ()
		{
		}
		
		/// <summary>
		/// Construct an image list using an ImagList and A Font
		/// </summary>
		/// <param name="imglist">ImageList for the menu</param>
		/// <param name="font">Font for menu text</param>
		public CMenuExtenderParam (ImageList imglist, Font font)
		{
			m_ImageList		= imglist;
			m_Font			= font;
		}
		#endregion

		/// <summary>
		/// ImageList for the menu
		/// </summary>
		ImageList	m_ImageList = null;
		
		/// <summary>
		/// Font to display the menu text
		/// </summary>
		Font		m_Font = null;	
		
		/// <summary>
		/// Color to display the active item in the menu
		/// </summary>
		Color		m_ActivateColor = Color.Blue;
		
		/// <summary>
		/// BackGround color of the menu
		/// </summary>
		Color		m_BackGroundColor = Color.White;
		
		/// <summary>
		/// Text color of the menu
		/// </summary>
		Color		m_TextColor = Color.Black;
		
		
		
		
		///<summary>
		///Selected menu color
		///</summary>
		///
		Color		m_SelectedColor = Color.LightSkyBlue;
		
		
		
		
		


		/// <summary>
		/// Image index in m_ImageList
		/// </summary>
		int			m_ImageIndex = -1;

		/// <summary>
		/// ImageList for the menu
		/// </summary>
		public ImageList ImageList
		{
			get
			{
				return m_ImageList;
			}
			set
			{
				m_ImageList = value;
			}
		}
		/// <summary>
		/// Font for the menu
		/// </summary>
		public Font Font
		{
			get
			{
				return m_Font;
			}
			set
			{
				m_Font = value;
			}
		}

		/// <summary>
		/// Image index in ImageList
		/// </summary>
		public int ImageIndice
		{
			get
			{
				return m_ImageIndex;
			}
			set
			{
				m_ImageIndex = value;
			}
		}

		/// <summary>
		/// Color for the menu's text
		/// </summary>
		public Color TextColor
		{
			get
			{
				return m_TextColor;
			}
			set
			{
				m_TextColor  = value;
			}
		}

		/// <summary>
		/// Color for selected menu
		/// </summary>
		public Color SelectedColor
		{
			get
			{
				return m_SelectedColor;
			}
			set
			{
				m_SelectedColor = value;
			}
		}
	}
		

	/// <summary>
	/// IExtenderProvider Implementation to extent Menu features
	/// </summary>
	/// 
	[ProvideProperty("Font", typeof(Component)) ]
	[ProvideProperty("ImageIndice", typeof(Component)) ]
	[DefaultProperty("ImageIndice")]
	[ToolboxBitmap(typeof(DotNetControlExtender.CMenuExtender), "DotNetControlExtender.ico")]
	public class CMenuExtender : Component, IExtenderProvider
    {
		#region members
		/// <summary>
		/// Hashtable to stock menus properties
		/// </summary>
		private Hashtable	m_controls = new Hashtable ();
		private ImageList	m_ImgList = new ImageList ();
		private ImageList	m_Marklist = new ImageList ();
		private const int MARGINH = 2;
		private const int MARGINV = 2;
		///<summary>
		///Left color for the margin gradient
		///</summary>
		private Color		m_MarginLeftColor = Color.White;
		
		/// <summary>
		/// Right Color for the margin Gradient
		/// </summary>
		private Color		m_MarginRightColor = Color.Beige;

		/// <summary>
		/// Left color for menu gradient
		/// </summary>
		Color		m_MenuLeftColor = Color.Beige;

		/// <summary>
		/// Right color for menu gradient
		/// </summary>
		Color		m_MenuRightColor = Color.White;
		#endregion

		#region Constructor
		/// <summary>
		/// Default constructor
		/// </summary>
		public CMenuExtender()
		{
			Initialize ();
		}
		/// <summary>
		/// Add the component into a container
		/// </summary>
		/// <param name="container">Container for the component</param>
		public CMenuExtender(IContainer container)
		{
			container.Add(this);
			Initialize ();
		}
		/// <summary>
		/// Initialize some useful data for the component
		/// </summary>
		protected void Initialize ()
		{
			Icon tmp;
			String[] st = {"DotNetControlExtender.Check.ico", "DotNetControlExtender.Radio.ico"};
			foreach (String s in st)
			{
				tmp = new Icon(typeof (CMenuExtender).Assembly.GetManifestResourceStream(s));
				m_Marklist.Images.Add (tmp);
			}
			
		}
		#endregion

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
			if (extendee is MenuItem)
			{
				MenuItem menuItem = (MenuItem) extendee ;
				return ! (  menuItem.Parent is MainMenu ) ;
			}

			

			return false;
			
		}

		#endregion
		
		#region MenuItem Properties
	
#if false
		/// <summary>
		/// Initialize the ImageList for a MenuItem
		/// </summary>
		/// <param name="component">MenuItem to initialize</param>
		/// <param name="imglist">ImageList for the menu</param>
		public void SetImageList (Component component, ImageList imglist)
		{
			if (! m_controls.ContainsKey (component))
				RegisterMenu (component);
			
			((CMenuExtenderParam) m_controls[component]).ImageList = imglist;
			
		}
		/// <summary>
		/// Return the ImageList for a MenuItem
		/// </summary>
		/// <param name="component">MenuItem</param>
		/// <returns>ImageList of the MenuItem</returns>
		public ImageList GetImageList (Component component)
		{
			if (m_controls.ContainsKey (component))
				return (((CMenuExtenderParam) m_controls[component]).ImageList);
			else
				return (m_ImgList);

		}
#endif		
		/// <summary>
		/// Initialize the Font for the MenuItem
		/// </summary>
		/// <param name="component">MenuItem to initialize</param>
		/// <param name="font">Font to draw the MenuItem text</param>
		public void SetFont (Component component, Font font)
		{
			if (! m_controls.ContainsKey (component))
				RegisterMenu (component);
			
			((CMenuExtenderParam) m_controls[component]).Font = font;
			
		}
		/// <summary>
		/// Return the font for a MenuItem
		/// </summary>
		/// <param name="component">MenuItem</param>
		/// <returns>Return the Font used to draw MenuItem text</returns>
		public Font GetFont (Component component)
		{
			if (m_controls.ContainsKey (component))
				return (((CMenuExtenderParam) m_controls[component]).Font);
			else
				return null;

		}
		
		public void SetImageIndice (Component component, Int32 ImageIndex)
		{
			if (! m_controls.ContainsKey (component))
				RegisterMenu (component);
			
			((CMenuExtenderParam) m_controls[component]).ImageIndice = ImageIndex;
						
		}
		public Int32 GetImageIndice (Component component)
		{
			if (m_controls.ContainsKey(component))
				return ((((CMenuExtenderParam) m_controls[component]).ImageIndice));
			else
				return (-1);
		}
		

		#endregion
		
		#region Event processing
		/// <summary>
		/// Event triggered to measure the size of a owner drawn <c>MenuItem</c>.
		/// <param name="sender">the menu item client object</param>
		/// <param name="e">the event arguments</param>
		private void OnMeasureItem( Object sender, MeasureItemEventArgs e )
		{
			MenuItem menuItem = (MenuItem) sender ;
			Font f = GetMenuFont (menuItem);
			if (f == null)
				f = new Font ("Arial", 12);
			
			String str = menuItem.Text;
			if (menuItem.ShowShortcut == true && menuItem.Shortcut != Shortcut.None)
				str += " " + menuItem.Shortcut.ToString ();
			SizeF size = e.Graphics.MeasureString (str, f);
			
			int height = (int) size.Height;
			if (m_ImgList.ImageSize.Height > height)
				height = m_ImgList.ImageSize.Height;
			
			// compute size
			
			Rectangle Total = new Rectangle (0,0, 
				(MARGINH + m_Marklist.ImageSize.Width + MARGINH) +		// mark zone (chek or radio)
					(MARGINH + m_ImgList.ImageSize.Width + MARGINH) +	// icon zone
					(MARGINH + (int) size.Width + MARGINH) +			// text zone
					(MARGINH + m_Marklist.ImageSize.Width + MARGINH),	// sub menu zone
				MARGINV + height + MARGINV);
		
			
			if (! m_controls.ContainsKey (sender))
			{
				RegisterMenu ((Component) sender);											
			}
			

			e.ItemWidth = Total.Width;
			e.ItemHeight = Total.Height;
		}
		
		/// <summary>
		/// Event triggered to owner draw the provide <c>MenuItem</c>.
		/// </summary>
		/// <param name="sender">the menu item client object</param>
		/// <param name="e">the event arguments</param>
		private void OnDrawItem( Object sender, DrawItemEventArgs e )
		{
			// derive the MenuItem object, and create the MenuHelper
			if ( ! m_controls.ContainsKey(sender))
				return;
			
			MenuItem menuItem = (MenuItem) sender ;
			CMenuExtenderParam param = ((CMenuExtenderParam) m_controls[sender]);
			Font f = param.Font;
/* afac */
			//Trace.WriteLine (menuItem.Text);
			//Trace.WriteLine (menuItem.ToString ());
/* cafa */
			
			// compute element position
			Rectangle RectMargin = new Rectangle (e.Bounds.X, e.Bounds.Y, (MARGINH + m_Marklist.ImageSize.Width + MARGINH), e.Bounds.Height);
			Rectangle RectIcon = new Rectangle (RectMargin.X + RectMargin.Width, e.Bounds.Y,(MARGINH + m_ImgList.ImageSize.Width + MARGINH), e.Bounds.Height);
			Rectangle RectSub = new Rectangle (e.Bounds.X + e.Bounds.Width - 1 - (MARGINH + m_Marklist.ImageSize.Width + MARGINH), e.Bounds.Y, 
				(MARGINH + m_Marklist.ImageSize.Width + MARGINH), e.Bounds.Height);
			Rectangle RectText  = new Rectangle (RectIcon.X + RectIcon.Width,
				e.Bounds.Y, RectSub.X - (RectIcon.X + RectIcon.Width), e.Bounds.Height);
			
			Rectangle RTotal = Rectangle.Union (Rectangle.Union (RectMargin, RectIcon), 
				Rectangle.Union (RectText, RectSub));
			Rectangle RMenu = Rectangle.Union (Rectangle.Union (RectIcon, RectText), RectSub);

			if (f == null)
				f = e.Font;
			String str = menuItem.Text;
			if (menuItem.ShowShortcut == true && menuItem.Shortcut != Shortcut.None)
				str += " " + menuItem.Shortcut.ToString ();
			SizeF size = e.Graphics.MeasureString (str, f);

			Rectangle rgMenu = RMenu;
			Rectangle rgMargin = RectMargin;
			rgMargin.X -= 1;
			rgMargin.Width += 1;
			rgMenu.X -= 1;
			rgMenu.Width += 1;

			// create brushes for drawing
			LinearGradientBrush br = new LinearGradientBrush (rgMenu, m_MenuLeftColor, m_MenuRightColor, 0, false);
			LinearGradientBrush brm = new LinearGradientBrush (rgMargin, m_MarginLeftColor, m_MarginRightColor, 0, false);
			

			SolidBrush brf = new SolidBrush (menuItem.Enabled == true ? param.TextColor : SystemColors.GrayText);
			SolidBrush brs = new SolidBrush (param.SelectedColor);
			

			// draw the background
			e.DrawBackground ();
			if ((e.State & DrawItemState.Selected) != DrawItemState.Selected)
			{
				// normal menu
				e.Graphics.FillRectangle (br, RMenu);
			}
			else
			{
				// selected menu
				e.Graphics.FillRectangle (brs, RMenu);
				e.Graphics.DrawRectangle (new Pen (brf), RMenu.X, RMenu.Y, RMenu.Width, RMenu.Height - 1);
			}
			e.Graphics.FillRectangle (brm, RectMargin);
			
			
			// draw separator
			if (menuItem.Text == "_" || menuItem.Text == "-")
			{
				if (param.ImageIndice >= 0 && param.ImageIndice < m_ImgList.Images.Count)
				{
					e.Graphics.DrawImage (m_ImgList.Images[param.ImageIndice], RMenu);
				}
				else
				{
					e.Graphics.DrawLine (new Pen (brf, 1), RMenu.X, RMenu.Y + RMenu.Height / 2, RMenu.X + RMenu.Width, RMenu.Y + RMenu.Height / 2);
					
				}
			}
			else// draw menu 
			{
				// menu icon
				if (param.ImageIndice >= 0 && param.ImageIndice < m_ImgList.Images.Count)
					if (menuItem.Enabled)
						e.Graphics.DrawImage (m_ImgList.Images[param.ImageIndice], RectIcon.X + MARGINH, RectIcon.Y + ((RectIcon.Height - m_ImgList.ImageSize.Height) / 2));
					else
						ControlPaint.DrawImageDisabled (e.Graphics, m_ImgList.Images[param.ImageIndice], RectIcon.X + MARGINH, RectIcon.Y + ((RectIcon.Height - m_ImgList.ImageSize.Height) / 2), SystemColors.GrayText);
				
				// menu text
				StringFormat format = new StringFormat ();
								
				format.Alignment = StringAlignment.Near;
				format.HotkeyPrefix = System.Drawing.Text.HotkeyPrefix.Show ;
				format.LineAlignment = StringAlignment.Center;
				e.Graphics.DrawString (menuItem.Text, f, brf, RectText, format);
				
				// menu shortcut
				if (menuItem.ShowShortcut == true && menuItem.Shortcut != Shortcut.None)
				{
					format.Alignment = StringAlignment.Far;
					Keys keys = (Keys) menuItem.Shortcut ;
					String strs = TypeDescriptor.GetConverter(keys).ConvertToString(keys) ;

					
					e.Graphics.DrawString (strs/*menuItem.Shortcut.ToString()*/, f, brf, RectText, format);
					
				}

				// draw check / radio ...
				if (menuItem.Checked == true )
				{
					Rectangle rmark = new Rectangle (RectMargin.X + (RectMargin.Height - m_Marklist.ImageSize.Width) / 2,
						RectMargin.Y + (RectMargin.Height - m_Marklist.ImageSize.Height) / 2, m_Marklist.ImageSize.Width, m_Marklist.ImageSize.Height);

					// draw the checkbox
					e.Graphics.DrawImage ( m_Marklist.Images[menuItem.RadioCheck == true ? 1 : 0], rmark);

				}

			}

			
		
		}
		#endregion

		#region Extender Properties
		/// <summary>
		/// Image List for the menu
		/// </summary>
		public ImageList ImgList
		{
			get
			{
				return m_ImgList;
			}
			set
			{
				m_ImgList = value;
			}
		}
		/// <summary>
		/// Right Color for margin gradient
		/// </summary>
		public Color MarginRightColor
		{
			get
			{
				return m_MarginRightColor;
			}
			set
			{
				m_MarginRightColor = value;
			}
		}

		/// <summary>
		/// Left Color for margin gradient
		/// </summary>
		public Color MarginLeftColor
		{
			get
			{
				return m_MarginLeftColor;
			}
			set
			{
				m_MarginLeftColor = value;
			}
		}

		

		/// <summary>
		/// Left Color for  menu gradient
		/// </summary>
		public Color MenuLeftColor
		{
			get
			{
				return m_MenuLeftColor;
			}
			set
			{
				m_MenuLeftColor = value;
			}
		}

		/// <summary>
		/// Right Color for  menu gradient
		/// </summary>
		public Color MenuRightColor
		{
			get
			{
				return m_MenuRightColor;
			}
			set
			{
				m_MenuRightColor = value;
			}
		}
	
		#endregion

		/// <summary>
		/// The method return the current font for "item"
		/// </summary>
		/// <param name="item">Item for which you search font</param>
		/// <returns>Font for item "item"</returns>
		protected Font GetMenuFont (MenuItem item)
		{
			Font f = null;
			if (m_controls.ContainsKey (item))
				f = ((CMenuExtenderParam)m_controls[item]).Font;
			if (f == null)
				f = GetDefaultFont (item);
			return (f);
		}

		/// <summary>
		/// Register menu for drawing
		/// </summary>
		/// <param name="component">menu to register for drawing</param>
		protected void RegisterMenu (Component component)
		{
			Font f = GetDefaultFont (component);
								
			CMenuExtenderParam param = new CMenuExtenderParam (m_ImgList, f); 
			m_controls[component] = param;
				
			// register event
			RegisterMenuEvent (component);
			
		}

		/// <summary>
		/// Register menu event for drawing
		/// </summary>
		/// <param name="component">menu to register for drawing</param>
		protected void RegisterMenuEvent (Component component)
		{
			MenuItem menu = (MenuItem) component;
			menu.OwnerDraw = true;
			menu.MeasureItem += new MeasureItemEventHandler (OnMeasureItem ) ;
			menu.DrawItem  += new DrawItemEventHandler (OnDrawItem ) ;
		}

		/// <summary>
		/// Return the default font for the component
		/// </summary>
		/// <param name="component">Component to find the default font</param>
		/// <returns>Default font for the component</returns>
		protected Font GetDefaultFont (Component component)
		{
			Font f = null;
			MenuItem menu = (MenuItem) component;

			if (menu.Parent != null)
			{
				if (menu.Parent is MainMenu)
					f = ((MainMenu) (menu.Parent)).GetForm ().Font;
											
			}
			return (f);	
		}
	}
}
