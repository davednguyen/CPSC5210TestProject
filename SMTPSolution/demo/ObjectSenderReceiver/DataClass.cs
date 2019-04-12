using System;

namespace ObjectSenderReceiver
{
	/// <summary>
	/// Simple data class
	/// </summary>
	/// 
	[Serializable]
	public class DataClass
	{
		protected int m_id;
		protected string m_firstname;
		protected string m_lastname;

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
}
