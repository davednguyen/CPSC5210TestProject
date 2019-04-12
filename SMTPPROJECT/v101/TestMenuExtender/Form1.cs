using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace TestMenuExtender
{
	/// <summary>
	/// Description résumée de Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private System.Windows.Forms.MainMenu mainMenu1;
		private System.Windows.Forms.MenuItem menuItem1;
		private System.Windows.Forms.MenuItem menuItem2;
		private System.Windows.Forms.MenuItem menuItem3;
		private System.Windows.Forms.MenuItem menuItem4;
		private System.Windows.Forms.MenuItem menuItem5;
		private System.Windows.Forms.MenuItem menuItem6;
		private System.Windows.Forms.MenuItem menuItem7;
		private System.Windows.Forms.MenuItem menuItem8;
		private System.Windows.Forms.MenuItem menuItem9;
		private System.Windows.Forms.MenuItem menuItem10;
		private System.Windows.Forms.ImageList imageList1;
		
		private System.Windows.Forms.MenuItem menuItem11;
		private System.Windows.Forms.MenuItem menuItem12;
		private System.Windows.Forms.MenuItem menuItem13;
		private System.Windows.Forms.MenuItem menuItem14;
		private System.Windows.Forms.MenuItem menuItem15;
		private System.Windows.Forms.MenuItem menuItem16;
		private System.Windows.Forms.MenuItem menuItem17;
		private System.Windows.Forms.MenuItem menuItem18;
		private System.Windows.Forms.MenuItem menuItem19;
		private System.Windows.Forms.MenuItem menuItem20;
		private System.Windows.Forms.MenuItem menuItem21;
		private System.Windows.Forms.MenuItem menuItem22;
		private System.Windows.Forms.MenuItem menuItem23;
		private System.Windows.Forms.MenuItem menuItem24;
		private System.Windows.Forms.MenuItem menuItem25;
		private System.Windows.Forms.MenuItem menuItem26;
		private System.Windows.Forms.MenuItem menuItem27;
		private System.Windows.Forms.MenuItem menuItem28;
		private System.Windows.Forms.MenuItem menuItem29;
		private System.Windows.Forms.MenuItem menuItem30;
		private System.Windows.Forms.MenuItem menuItem31;
		private System.Windows.Forms.MenuItem menuItem32;
		private System.Windows.Forms.MenuItem menuItem33;
		private System.Windows.Forms.MenuItem menuItem34;
		private System.Windows.Forms.MenuItem menuItem35;
		private System.Windows.Forms.MenuItem menuItem36;
		private System.Windows.Forms.MenuItem menuItem37;
		private System.Windows.Forms.MenuItem menuItem38;
		private DotNetControlExtender.CMenuExtender cMenuExtender;
		private System.Windows.Forms.ImageList imageList2;
		private System.ComponentModel.IContainer components;

		public Form1()
		{
			//
			// Requis pour la prise en charge du Concepteur Windows Forms
			//
			InitializeComponent();

			//
			// TODO : ajoutez le code du constructeur après l'appel à InitializeComponent
			//
		}

		/// <summary>
		/// Nettoyage des ressources utilisées.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Code généré par le Concepteur Windows Form
		/// <summary>
		/// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
		/// le contenu de cette méthode avec l'éditeur de code.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(Form1));
			this.mainMenu1 = new System.Windows.Forms.MainMenu();
			this.menuItem1 = new System.Windows.Forms.MenuItem();
			this.menuItem2 = new System.Windows.Forms.MenuItem();
			this.menuItem33 = new System.Windows.Forms.MenuItem();
			this.menuItem3 = new System.Windows.Forms.MenuItem();
			this.menuItem34 = new System.Windows.Forms.MenuItem();
			this.menuItem4 = new System.Windows.Forms.MenuItem();
			this.menuItem5 = new System.Windows.Forms.MenuItem();
			this.menuItem6 = new System.Windows.Forms.MenuItem();
			this.menuItem7 = new System.Windows.Forms.MenuItem();
			this.menuItem8 = new System.Windows.Forms.MenuItem();
			this.menuItem37 = new System.Windows.Forms.MenuItem();
			this.menuItem38 = new System.Windows.Forms.MenuItem();
			this.menuItem9 = new System.Windows.Forms.MenuItem();
			this.menuItem10 = new System.Windows.Forms.MenuItem();
			this.menuItem31 = new System.Windows.Forms.MenuItem();
			this.menuItem32 = new System.Windows.Forms.MenuItem();
			this.menuItem11 = new System.Windows.Forms.MenuItem();
			this.menuItem12 = new System.Windows.Forms.MenuItem();
			this.menuItem13 = new System.Windows.Forms.MenuItem();
			this.menuItem14 = new System.Windows.Forms.MenuItem();
			this.menuItem15 = new System.Windows.Forms.MenuItem();
			this.menuItem16 = new System.Windows.Forms.MenuItem();
			this.menuItem17 = new System.Windows.Forms.MenuItem();
			this.menuItem19 = new System.Windows.Forms.MenuItem();
			this.menuItem20 = new System.Windows.Forms.MenuItem();
			this.menuItem21 = new System.Windows.Forms.MenuItem();
			this.menuItem22 = new System.Windows.Forms.MenuItem();
			this.menuItem23 = new System.Windows.Forms.MenuItem();
			this.menuItem24 = new System.Windows.Forms.MenuItem();
			this.menuItem18 = new System.Windows.Forms.MenuItem();
			this.menuItem25 = new System.Windows.Forms.MenuItem();
			this.menuItem26 = new System.Windows.Forms.MenuItem();
			this.menuItem27 = new System.Windows.Forms.MenuItem();
			this.menuItem28 = new System.Windows.Forms.MenuItem();
			this.menuItem29 = new System.Windows.Forms.MenuItem();
			this.menuItem30 = new System.Windows.Forms.MenuItem();
			this.menuItem35 = new System.Windows.Forms.MenuItem();
			this.menuItem36 = new System.Windows.Forms.MenuItem();
			this.imageList1 = new System.Windows.Forms.ImageList(this.components);
			this.cMenuExtender = new DotNetControlExtender.CMenuExtender(this.components);
			this.imageList2 = new System.Windows.Forms.ImageList(this.components);
			// 
			// mainMenu1
			// 
			this.mainMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					  this.menuItem1,
																					  this.menuItem9,
																					  this.menuItem11,
																					  this.menuItem25});
			// 
			// menuItem1
			// 
			this.menuItem1.Index = 0;
			this.menuItem1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					  this.menuItem2,
																					  this.menuItem33,
																					  this.menuItem3,
																					  this.menuItem34,
																					  this.menuItem4,
																					  this.menuItem37,
																					  this.menuItem38});
			this.menuItem1.Text = "Main";
			// 
			// menuItem2
			// 
			this.cMenuExtender.SetFont(this.menuItem2, null);
			this.cMenuExtender.SetImageIndice(this.menuItem2, 1);
			
			this.menuItem2.Index = 0;
			this.menuItem2.OwnerDraw = true;
			this.menuItem2.Text = "Separator samples";
			// 
			// menuItem33
			// 
			this.cMenuExtender.SetFont(this.menuItem33, null);
			this.cMenuExtender.SetImageIndice(this.menuItem33, 7);
			this.menuItem33.Index = 1;
			this.menuItem33.OwnerDraw = true;
			this.menuItem33.Text = "-";
			// 
			// menuItem3
			// 
			this.cMenuExtender.SetFont(this.menuItem3, null);
			this.cMenuExtender.SetImageIndice(this.menuItem3, 1);
			this.menuItem3.Index = 2;
			this.menuItem3.OwnerDraw = true;
			this.menuItem3.Text = "sub12";
			// 
			// menuItem34
			// 
			this.cMenuExtender.SetFont(this.menuItem34, null);
			this.cMenuExtender.SetImageIndice(this.menuItem34, 3);
			this.menuItem34.Index = 3;
			this.menuItem34.OwnerDraw = true;
			this.menuItem34.Text = "-";
			// 
			// menuItem4
			// 
			this.cMenuExtender.SetFont(this.menuItem4, null);
			this.cMenuExtender.SetImageIndice(this.menuItem4, 1);
			this.menuItem4.Index = 4;
			this.menuItem4.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					  this.menuItem5,
																					  this.menuItem7,
																					  this.menuItem8});
			this.menuItem4.OwnerDraw = true;
			this.menuItem4.Text = "sub13";
			// 
			// menuItem5
			// 
			this.cMenuExtender.SetFont(this.menuItem5, null);
			this.cMenuExtender.SetImageIndice(this.menuItem5, -1);
			this.menuItem5.Index = 0;
			this.menuItem5.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					  this.menuItem6});
			this.menuItem5.OwnerDraw = true;
			this.menuItem5.Text = "sub23";
			// 
			// menuItem6
			// 
			this.cMenuExtender.SetFont(this.menuItem6, null);
			this.cMenuExtender.SetImageIndice(this.menuItem6, -1);
			this.menuItem6.Index = 0;
			this.menuItem6.OwnerDraw = true;
			this.menuItem6.Text = "sub33";
			// 
			// menuItem7
			// 
			this.cMenuExtender.SetFont(this.menuItem7, null);
			this.cMenuExtender.SetImageIndice(this.menuItem7, -1);
			this.menuItem7.Index = 1;
			this.menuItem7.OwnerDraw = true;
			this.menuItem7.Text = "sub24";
			// 
			// menuItem8
			// 
			this.cMenuExtender.SetFont(this.menuItem8, null);
			this.cMenuExtender.SetImageIndice(this.menuItem8, -1);
			this.menuItem8.Index = 2;
			this.menuItem8.OwnerDraw = true;
			this.menuItem8.Text = "sub25";
			// 
			// menuItem37
			// 
			this.cMenuExtender.SetFont(this.menuItem37, null);
			this.cMenuExtender.SetImageIndice(this.menuItem37, 9);
			this.menuItem37.Index = 5;
			this.menuItem37.OwnerDraw = true;
			this.menuItem37.Text = "-";
			// 
			// menuItem38
			// 
			this.cMenuExtender.SetFont(this.menuItem38, null);
			this.cMenuExtender.SetImageIndice(this.menuItem38, 5);
			this.menuItem38.Index = 6;
			this.menuItem38.OwnerDraw = true;
			this.menuItem38.Text = "sub14";
			// 
			// menuItem9
			// 
			this.menuItem9.Index = 1;
			this.menuItem9.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					  this.menuItem10,
																					  this.menuItem31,
																					  this.menuItem32});
			this.menuItem9.Text = "Font";
			// 
			// menuItem10
			// 
			this.cMenuExtender.SetFont(this.menuItem10, new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0))));
			this.cMenuExtender.SetImageIndice(this.menuItem10, 8);
			this.menuItem10.Index = 0;
			this.menuItem10.OwnerDraw = true;
			this.menuItem10.Text = "Arial bold 12";
			// 
			// menuItem31
			// 
			this.cMenuExtender.SetFont(this.menuItem31, new System.Drawing.Font("Wingdings 2", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(2))));
			this.cMenuExtender.SetImageIndice(this.menuItem31, 6);
			this.menuItem31.Index = 1;
			this.menuItem31.OwnerDraw = true;
			this.menuItem31.Text = "Wingdings 2 12";
			// 
			// menuItem32
			// 
			this.cMenuExtender.SetFont(this.menuItem32, new System.Drawing.Font("Script MT Bold", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0))));
			this.cMenuExtender.SetImageIndice(this.menuItem32, 5);
			this.menuItem32.Index = 2;
			this.menuItem32.OwnerDraw = true;
			this.menuItem32.Text = "Script MT Bold 20";
			// 
			// menuItem11
			// 
			this.menuItem11.Index = 2;
			this.menuItem11.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					   this.menuItem12,
																					   this.menuItem13,
																					   this.menuItem14,
																					   this.menuItem15,
																					   this.menuItem16,
																					   this.menuItem17,
																					   this.menuItem18});
			this.menuItem11.Text = "Icons";
			// 
			// menuItem12
			// 
			this.cMenuExtender.SetFont(this.menuItem12, null);
			this.cMenuExtender.SetImageIndice(this.menuItem12, 1);
			this.menuItem12.Index = 0;
			this.menuItem12.OwnerDraw = true;
			this.menuItem12.Text = "rr";
			// 
			// menuItem13
			// 
			this.menuItem13.Enabled = false;
			this.cMenuExtender.SetFont(this.menuItem13, null);
			this.cMenuExtender.SetImageIndice(this.menuItem13, 8);
			this.menuItem13.Index = 1;
			this.menuItem13.OwnerDraw = true;
			this.menuItem13.Text = "rr";
			// 
			// menuItem14
			// 
			this.menuItem14.Enabled = false;
			this.cMenuExtender.SetFont(this.menuItem14, null);
			this.cMenuExtender.SetImageIndice(this.menuItem14, 7);
			this.menuItem14.Index = 2;
			this.menuItem14.OwnerDraw = true;
			this.menuItem14.Text = "rr";
			// 
			// menuItem15
			// 
			this.cMenuExtender.SetFont(this.menuItem15, null);
			this.cMenuExtender.SetImageIndice(this.menuItem15, 6);
			this.menuItem15.Index = 3;
			this.menuItem15.OwnerDraw = true;
			this.menuItem15.Text = "tt";
			// 
			// menuItem16
			// 
			this.cMenuExtender.SetFont(this.menuItem16, null);
			this.cMenuExtender.SetImageIndice(this.menuItem16, -1);
			this.menuItem16.Index = 4;
			this.menuItem16.OwnerDraw = true;
			this.menuItem16.Text = "yy";
			// 
			// menuItem17
			// 
			this.cMenuExtender.SetFont(this.menuItem17, null);
			this.cMenuExtender.SetImageIndice(this.menuItem17, 5);
			this.menuItem17.Index = 5;
			this.menuItem17.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					   this.menuItem19,
																					   this.menuItem20,
																					   this.menuItem21,
																					   this.menuItem22,
																					   this.menuItem23,
																					   this.menuItem24});
			this.menuItem17.OwnerDraw = true;
			this.menuItem17.Text = "yy";
			// 
			// menuItem19
			// 
			this.cMenuExtender.SetFont(this.menuItem19, null);
			this.cMenuExtender.SetImageIndice(this.menuItem19, 1);
			this.menuItem19.Index = 0;
			this.menuItem19.OwnerDraw = true;
			this.menuItem19.Text = "rr";
			// 
			// menuItem20
			// 
			this.cMenuExtender.SetFont(this.menuItem20, null);
			this.cMenuExtender.SetImageIndice(this.menuItem20, 2);
			this.menuItem20.Index = 1;
			this.menuItem20.OwnerDraw = true;
			this.menuItem20.Text = "rr";
			// 
			// menuItem21
			// 
			this.cMenuExtender.SetFont(this.menuItem21, null);
			this.cMenuExtender.SetImageIndice(this.menuItem21, 3);
			this.menuItem21.Index = 2;
			this.menuItem21.OwnerDraw = true;
			this.menuItem21.Text = "rr";
			// 
			// menuItem22
			// 
			this.cMenuExtender.SetFont(this.menuItem22, null);
			this.cMenuExtender.SetImageIndice(this.menuItem22, 4);
			this.menuItem22.Index = 3;
			this.menuItem22.OwnerDraw = true;
			this.menuItem22.Text = "rr";
			// 
			// menuItem23
			// 
			this.cMenuExtender.SetFont(this.menuItem23, null);
			this.cMenuExtender.SetImageIndice(this.menuItem23, 5);
			this.menuItem23.Index = 4;
			this.menuItem23.OwnerDraw = true;
			this.menuItem23.Text = "rr";
			// 
			// menuItem24
			// 
			this.cMenuExtender.SetFont(this.menuItem24, null);
			this.cMenuExtender.SetImageIndice(this.menuItem24, 6);
			this.menuItem24.Index = 5;
			this.menuItem24.OwnerDraw = true;
			this.menuItem24.Text = "rr";
			// 
			// menuItem18
			// 
			this.cMenuExtender.SetFont(this.menuItem18, null);
			this.cMenuExtender.SetImageIndice(this.menuItem18, -1);
			this.menuItem18.Index = 6;
			this.menuItem18.OwnerDraw = true;
			this.menuItem18.Text = "tt";
			// 
			// menuItem25
			// 
			this.menuItem25.Index = 3;
			this.menuItem25.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					   this.menuItem26,
																					   this.menuItem27,
																					   this.menuItem28,
																					   this.menuItem29,
																					   this.menuItem30,
																					   this.menuItem35,
																					   this.menuItem36});
			this.menuItem25.Text = "Check";
			// 
			// menuItem26
			// 
			this.cMenuExtender.SetFont(this.menuItem26, null);
			this.cMenuExtender.SetImageIndice(this.menuItem26, 6);
			this.menuItem26.Index = 0;
			this.menuItem26.OwnerDraw = true;
			this.menuItem26.Shortcut = System.Windows.Forms.Shortcut.F5;
			this.menuItem26.Text = "Shortcut";
			// 
			// menuItem27
			// 
			this.cMenuExtender.SetFont(this.menuItem27, null);
			this.cMenuExtender.SetImageIndice(this.menuItem27, -1);
			this.menuItem27.Index = 1;
			this.menuItem27.OwnerDraw = true;
			this.menuItem27.Shortcut = System.Windows.Forms.Shortcut.F8;
			this.menuItem27.Text = "ShortCut";
			// 
			// menuItem28
			// 
			this.cMenuExtender.SetFont(this.menuItem28, null);
			this.cMenuExtender.SetImageIndice(this.menuItem28, -1);
			this.menuItem28.Index = 2;
			this.menuItem28.OwnerDraw = true;
			this.menuItem28.Shortcut = System.Windows.Forms.Shortcut.CtrlF11;
			this.menuItem28.Text = "ShortCut";
			// 
			// menuItem29
			// 
			this.menuItem29.Checked = true;
			this.cMenuExtender.SetFont(this.menuItem29, null);
			this.cMenuExtender.SetImageIndice(this.menuItem29, 8);
			this.menuItem29.Index = 3;
			this.menuItem29.OwnerDraw = true;
			this.menuItem29.Text = "Check";
			// 
			// menuItem30
			// 
			this.menuItem30.Checked = true;
			this.cMenuExtender.SetFont(this.menuItem30, null);
			this.cMenuExtender.SetImageIndice(this.menuItem30, 7);
			this.menuItem30.Index = 4;
			this.menuItem30.OwnerDraw = true;
			this.menuItem30.RadioCheck = true;
			this.menuItem30.Text = "Radio";
			// 
			// menuItem35
			// 
			this.menuItem35.Checked = true;
			this.menuItem35.Enabled = false;
			this.cMenuExtender.SetFont(this.menuItem35, null);
			this.cMenuExtender.SetImageIndice(this.menuItem35, -1);
			this.menuItem35.Index = 5;
			this.menuItem35.OwnerDraw = true;
			this.menuItem35.Text = "chekdisable";
			// 
			// menuItem36
			// 
			this.menuItem36.Checked = true;
			this.menuItem36.Enabled = false;
			this.cMenuExtender.SetFont(this.menuItem36, null);
			this.cMenuExtender.SetImageIndice(this.menuItem36, -1);
			this.menuItem36.Index = 6;
			this.menuItem36.OwnerDraw = true;
			this.menuItem36.RadioCheck = true;
			this.menuItem36.Text = "radiodisable";
			// 
			// imageList1
			// 
			this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
			this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
			this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
			// 
			// cMenuExtender
			// 
			this.cMenuExtender.ImgList = this.imageList1;
			this.cMenuExtender.MarginLeftColor = System.Drawing.Color.Chocolate;
			this.cMenuExtender.MarginRightColor = System.Drawing.Color.Beige;
			this.cMenuExtender.MenuLeftColor = System.Drawing.Color.Beige;
			this.cMenuExtender.MenuRightColor = System.Drawing.Color.White;
			// 
			// imageList2
			// 
			this.imageList2.ImageSize = new System.Drawing.Size(16, 16);
			this.imageList2.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList2.ImageStream")));
			this.imageList2.TransparentColor = System.Drawing.Color.Transparent;
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(292, 266);
			this.Menu = this.mainMenu1;
			this.Name = "Form1";
			this.Text = "Form1";
			this.Load += new System.EventHandler(this.Form1_Load);

		}
		#endregion

		/// <summary>
		/// Point d'entrée principal de l'application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new Form1());
		}

		private void Form1_Load(object sender, System.EventArgs e)
		{
		
		}

		private void button1_Click(object sender, System.EventArgs e)
		{
			//Form2 form = new Form2 ();
			//form.ShowDialog (this);
		}

		private void menuItem40_Click(object sender, System.EventArgs e)
		{
			Form2 form = new Form2 ();
			form.MdiParent = this;
			form.Show ();
		}

		
	}
}
