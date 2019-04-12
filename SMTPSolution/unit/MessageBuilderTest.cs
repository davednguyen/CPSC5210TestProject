using System;
using NUnit;
using NUnit.Framework;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
using System.Runtime.Serialization.Formatters.Binary;

namespace SmtPop.Unit
{
	/// <summary>
	/// The class tests the class MessageBuilder
	/// </summary>
	[TestFixture]
	[Category("FastRunning")]
	public class MessageBuilderTest
	{
		/// <summary>
		/// Simple data class for test
		/// </summary>
		/// 
		[Serializable]
		private class DataClass
		{
			protected int m_id = 0;
			protected string m_firstname = "";
			protected string m_lastname = "";

			public DataClass()
			{
				m_id = System.DateTime.Now.Millisecond;
				m_firstname = "demo";
				m_lastname = "demo";
			}
			public override String ToString ()
			{
				String s = "ObjectSenderReceiver.DataClass :" + m_id.ToString () + "," + m_firstname + "," + m_lastname;
				return s;
			}

			public String FirstName
			{
				get
				{
					return m_firstname;
				}
				set
				{
					m_firstname = value;
				}
			}

			public String LastName
			{
				get
				{
					return m_lastname;
				}
				set
				{
					m_lastname = value;
				}
			}

			public int Id
			{
				get
				{
					return m_id;
				}
				set
				{
					m_id = value;
				}
			}
		}

		private string FromName = "accentôà€";
		private string FromAdr = "<test@bidule.com>";
		private string ToName = "toaccentôçèé€";
		private string ToAdr = "<tester@bidule.com>";
		private string subject = "this is a test éàç €";
		private string body = "this is a message body\r\nwith some particular char €";


		/// <summary>
		/// Constructor
		/// </summary>
		public MessageBuilderTest()
		{
			
		}

		/// <summary>
		/// Setup the tests
		/// </summary>
		[TestFixtureSetUp]
		public void MessageBuilderSetup ()
		{
		}

		/// <summary>
		/// Clean the test
		/// </summary>
		[TestFixtureTearDown]
		public void MessageBuilderTearDown ()
		{
		}

		/// <summary>
		/// Test building a simple text message
		/// </summary>
		[Test (Description ="Build a Text message")]
		public void MessageBuilderText ()
		{

			MimeMessage m = MessageBuilder.Build (FromName + FromAdr, ToName+ToAdr, subject, body, MimeTextContentType.TextPlain);

			System.IO.StringWriter wr = new System.IO.StringWriter ();
			m.Write (wr);

			MimeMessage read = new MimeMessage ();
			System.IO.StringReader r = new System.IO.StringReader (wr.ToString ());
			read.Read (r);
			
			Assert.IsTrue (read.AddressFrom.Count == 1, "Failed from address count");
			Assert.IsTrue (read.AddressFrom[0].Name == FromName, "Failed From address name");
			Assert.IsTrue (read.AddressFrom[0].Mailbox == FromAdr, "Failed From address mailbox");
			
			Assert.IsTrue (read.AddressTo.Count == 1, "Failed to address count");
			Assert.IsTrue (read.AddressTo[0].Name == ToName, "Failed To address name");
			Assert.IsTrue (read.AddressTo[0].Mailbox == ToAdr, "Failed To address mailbox");

			Assert.IsTrue (read.Subject == subject, "Failed decoding subject");
			Assert.IsTrue (Config.defaultEncoding.GetString (Convert.FromBase64String (read.Body)) == body, "Failed decoding body");


		}

		/// <summary>
		/// Tests building a message with png attachment
		/// </summary>
		[Test (Description="Test building a mail with png attachment")]
		public void MessageBuilderTextPng ()
		{
			Bitmap bmp = new Bitmap (128,128, PixelFormat.Format24bppRgb);

			MimeMessage m = MessageBuilder.Build (FromName + FromAdr, ToName+ToAdr, subject, body, MimeTextContentType.TextPlain, bmp, ImageFormat.Png, "test");

			// write the message in buffer
			System.IO.StringWriter wr = new System.IO.StringWriter ();
			m.Write (wr);

			// read the message
			MimeMessage read = new MimeMessage ();
			System.IO.StringReader r = new System.IO.StringReader (wr.ToString ());
			read.Read (r);
			
			// check
			Assert.IsTrue (read.AddressFrom.Count == 1, "Failed from address count");
			Assert.IsTrue (read.AddressFrom[0].Name == FromName, "Failed From address name");
			Assert.IsTrue (read.AddressFrom[0].Mailbox == FromAdr, "Failed From address mailbox");
			
			Assert.IsTrue (read.AddressTo.Count == 1, "Failed to address count");
			Assert.IsTrue (read.AddressTo[0].Name == ToName, "Failed To address name");
			Assert.IsTrue (read.AddressTo[0].Mailbox == ToAdr, "Failed To address mailbox");
			
			Assert.IsTrue (read.Attachments.Count == 2, "Failed attachment number");
			Assert.IsTrue (read.Subject == subject, "Failed decoding subject");
			Assert.IsTrue (Config.defaultEncoding.GetString (Convert.FromBase64String (read.Attachments[0].Body)) == body, "Failed decoding body");

			// test reading the bitmap
			Byte [] png = Convert.FromBase64String (read.Attachments[1].Body);

			System.IO.MemoryStream stream = new System.IO.MemoryStream (png, false);
			Bitmap load = (Bitmap) Image.FromStream (stream);
			
			Assert.IsTrue (load.Width == bmp.Width, "Failed bitmap width");
			Assert.IsTrue (load.Height== bmp.Height, "Failed bitmap height");


		}

		/// <summary>
		/// Tests building a message with png attachment
		/// </summary>
		[Test (Description="Test building a mail with png attachment")]
		public void MessageBuilderTextBinary ()
		{
			Bitmap bmp = new Bitmap (128,128, PixelFormat.Format24bppRgb);
			System.IO.MemoryStream mem = new System.IO.MemoryStream ();
			bmp.Save (mem, System.Drawing.Imaging.ImageFormat.Png);
			mem.Position = 0;
			System.IO.BinaryReader reader = new System.IO.BinaryReader (mem);
			MimeMessage m = MessageBuilder.Build (FromName + FromAdr, ToName+ToAdr, subject, body, MimeTextContentType.TextPlain, reader, "image/png", "test.png");

			// write the message in buffer
			System.IO.StringWriter wr = new System.IO.StringWriter ();
			m.Write (wr);

			// read the message
			MimeMessage read = new MimeMessage ();
			System.IO.StringReader r = new System.IO.StringReader (wr.ToString ());
			read.Read (r);
			
			// check
			Assert.IsTrue (read.AddressFrom.Count == 1, "Failed from address count");
			Assert.IsTrue (read.AddressFrom[0].Name == FromName, "Failed From address name");
			Assert.IsTrue (read.AddressFrom[0].Mailbox == FromAdr, "Failed From address mailbox");
			
			Assert.IsTrue (read.AddressTo.Count == 1, "Failed to address count");
			Assert.IsTrue (read.AddressTo[0].Name == ToName, "Failed To address name");
			Assert.IsTrue (read.AddressTo[0].Mailbox == ToAdr, "Failed To address mailbox");
			
			Assert.IsTrue (read.Attachments.Count == 2, "Failed attachment number");
			Assert.IsTrue (read.Subject == subject, "Failed decoding subject");
			Assert.IsTrue (Config.defaultEncoding.GetString (Convert.FromBase64String (read.Attachments[0].Body)) == body, "Failed decoding body");

			// test reading the bitmap
			Byte [] png = Convert.FromBase64String (read.Attachments[1].Body);

			System.IO.MemoryStream stream = new System.IO.MemoryStream (png, false);
			Bitmap load = (Bitmap) Image.FromStream (stream);
			
			Assert.IsTrue (load.Width == bmp.Width, "Failed bitmap width");
			Assert.IsTrue (load.Height== bmp.Height, "Failed bitmap height");


		}

		/// <summary>
		/// Tests building a message with various image format
		/// </summary>
		[Test (Description="Test building a mail with png attachment")]
		public void MessageBuilderImageType ()
		{
			Bitmap bmp = new Bitmap (128,128, PixelFormat.Format24bppRgb);

			ImageFormat[] format = { ImageFormat.Jpeg,
									ImageFormat.Bmp,
									ImageFormat.Png,
									ImageFormat.Gif,
									ImageFormat.Tiff, 
									//ImageFormat.Exif  // don't work with exif
								   };
			for (int i = 0; i < format.Length; i++)
			{
				MimeMessage m = MessageBuilder.Build (FromName + FromAdr, ToName+ToAdr, subject, body, MimeTextContentType.TextPlain, bmp, format[i], "test");

				// write the message in buffer
				System.IO.StringWriter wr = new System.IO.StringWriter ();
				m.Write (wr);

				// read the message
				MimeMessage read = new MimeMessage ();
				System.IO.StringReader r = new System.IO.StringReader (wr.ToString ());
				read.Read (r);
				
				// check
				Assert.IsTrue (read.Attachments.Count == 2, "Incorrect attachment number");
				string ext = format[i].ToString ().ToLower ();

				
				Assert.IsTrue (((string) read.Attachments[1].Headers["Content-Type"]).IndexOf (ext) != -1, "incorrect file extension");
			}	
		}

		/// <summary>
		/// Tests building a message with a serialized object
		/// </summary>
		[Test (Description="Test building a mail with serialized object")]
		public void MessageBuilderSerialized ()
		{
			DataClass data = new DataClass ();
			data.FirstName = "test";
			data.LastName = "tester";
			data.Id = 1;

			MimeMessage m = MessageBuilder.Build (FromName + FromAdr, ToName+ToAdr, subject, body, MimeTextContentType.TextPlain, data, "application/binary", "test");

			// write the message in buffer
			System.IO.StringWriter wr = new System.IO.StringWriter ();
			m.Write (wr);

			// read the message
			MimeMessage read = new MimeMessage ();
			System.IO.StringReader r = new System.IO.StringReader (wr.ToString ());
			read.Read (r);
			
			// check
			Assert.IsTrue (read.Attachments.Count == 2, "Incorrect attachment number");
			
			// test data deserialization
			Byte[] b = Convert.FromBase64String (read.Attachments[1].Body);
							 
			System.IO.MemoryStream mem = new System.IO.MemoryStream (b, false);
			BinaryFormatter f = new BinaryFormatter ();
			object robj = f.Deserialize (mem);
			Assert.IsTrue (robj.GetType() == data.GetType(), "Failed deserialization");
			DataClass rdata = (DataClass) robj;		
			
			Assert.IsTrue (rdata.FirstName == data.FirstName, "Failed FirstName");
			Assert.IsTrue (rdata.LastName == data.LastName, "Failed LastName");
			Assert.IsTrue (rdata.Id == data.Id, "Failed Id");

			mem.Close();
			
			
			
		}

		/// <summary>
		/// Tests building a message with serialized objects
		/// </summary>
		[Test (Description="Test building a mail with serialized objects")]
		public void MessageBuilderSerializedArray ()
		{
			DataClass [] data = new DataClass [10];
			for (int i = 0; i < data.Length; i++)
			{
				data[i] = new DataClass ();
				data[i].FirstName = "test";
				data[i].LastName = "tester";
				data[i].Id = i;
			}
			

			MimeMessage m = MessageBuilder.Build (FromName + FromAdr, ToName+ToAdr, subject, body, MimeTextContentType.TextPlain, data, "application/binary", "test");

			// write the message in buffer
			System.IO.StringWriter wr = new System.IO.StringWriter ();
			m.Write (wr);

			// read the message
			MimeMessage read = new MimeMessage ();
			System.IO.StringReader r = new System.IO.StringReader (wr.ToString ());
			read.Read (r);
			
			// check
			Assert.IsTrue (read.Attachments.Count == 2, "Incorrect attachment number");
			
			// test data deserialization
			Byte[] b = Convert.FromBase64String (read.Attachments[1].Body);
							 
			System.IO.MemoryStream mem = new System.IO.MemoryStream (b, false);
			BinaryFormatter f = new BinaryFormatter ();
			object robj = f.Deserialize (mem);
			Assert.IsTrue (robj.GetType() == data.GetType(), "Failed deserialization");
			DataClass[] rdata = (DataClass[]) robj;		
			
			Assert.IsTrue (rdata.Length == data.Length, "Incorect array length");
			for (int i = 0; i < rdata.Length; i++)
			{
				Assert.IsTrue (rdata[i].FirstName == data[i].FirstName, "Failed FirstName");
				Assert.IsTrue (rdata[i].LastName == data[i].LastName, "Failed LastName");
				Assert.IsTrue (rdata[i].Id == data[i].Id, "Failed Id");
			}

			mem.Close();
			
			
			
		}
	}
}
