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
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Collections;

namespace SmtPop 
{


	/// <summary>
	/// This class sends a MimeMessage to an SMTP server
	/// </summary>
	/// <example>
	/// This sample sends an e-mail
	/// <code>
	/// MimeMessage msg = new MimeMessage ();
	/// string body = "This is a simple message for test";
	/// string subject = "A simple message for test";
	/// 
	/// MailAddressList from = new MailAddressList ();
	/// from.Add (new MailAddress ("toto &lt;toto@toto.com&gt;"));
	/// msg.AddressFrom = from;
	/// 			
	/// MailAddressList to = new MailAddressList ();
	/// to.Add (new MailAddress (TestConstant.toadr));
	/// msg.AddressTo = to;
	/// 			
	/// msg.SaveAdr ();
	/// 
	/// msg.SetSubject (subject, MimeTransferEncoding.Ascii7Bit);
	/// msg.SetBody (body, MimeTransferEncoding.Ascii7Bit, MimeTextContentType.TextPlain);
	/// 
	/// SMTPClient smtp = new SMTPClient (TestConstant.host, TestConstant.portsmtp);
	/// smtp.Open ();
	/// smtp.SendMail (msg);
	/// smtp.Close ();
	/// </code>
	/// </example>
	public class SMTPClient
	{
		// TODO : Build an example for doc
		
		/// <summary>
		/// The tcp connection with the server
		/// </summary>
		protected TcpClient 	m_tcpClient;
		
		/// <summary>
		/// A stream for io with server
		/// </summary>
		protected NetworkStream	m_netStream;

		/// <summary>
		/// NetworkStream decoder
		/// </summary>
		protected	StreamReader	m_streamReader;
	
		/// <summary>
		/// NetworkStream encoder
		/// </summary>
		protected	StreamWriter	m_streamWriter;


		/// <summary>
		/// Server m_host address
		/// </summary>
		protected string 	m_host;
		
		/// <summary>
		/// Connection m_port
		/// </summary>
		protected int 		m_port = 25;
		
		/// <summary>
		/// Send timeout on tcp connection
		/// </summary>
		protected int 		m_sendTimeout = 90000;
		
		/// <summary>
		/// Receive timeout on tcp connection
		/// </summary>
		protected int 		m_receiveTimeout = 50000;
		
		/// <summary>
		/// Event fire when connection is established with the server
		/// </summary>
		public event ConnectEventHandler Connected;

		/// <summary>
		/// Event fire when a command is send to the server
		/// </summary>
		public event ClientCommandEventHandler SendedCommand;

		/// <summary>
		/// Event fire when an aswer is receive from the server
		/// </summary>
		public event ServerAnswerEventHandler ServerAnswer;


		/// <summary>
		/// Sends the 'connected' event
		/// </summary>
		private void FireConnected ()
		{
			if (Connected != null)
				Connected (this, new ConnectEventParam (this.m_host, this.m_port));
		}
		
		/// <summary>
		/// Sends the 'SendedCommand' event
		/// </summary>
		/// <param name="command"></param>
		private void FireSendedCommand (string command)
		{
			if (SendedCommand != null)
				SendedCommand (this, new ClientCommandEventParam (command));
		}
		
		/// <summary>
		/// Sends the 'Answer received' event
		/// </summary>
		/// <param name="answer">The answer received from the server</param>
		private void FireReceivedCommand (string answer)
		{
			if (ServerAnswer != null)
				ServerAnswer (this, new ServerAnswerEventParam (answer));
		}

		/// <summary>Default constructor</summary>
		/// <example>
		/// <code>
		/// 	SmtpClient smtp = new SmtpClient();
		/// 	smtp.Host = "smtp.dummy.com";
		/// 	smtp.Port = 25;
		/// 	 	
		/// </code>
		/// </example>
		public SMTPClient()
		{}
		

		
		
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="Host">Server m_host name or ip</param>
		/// <param name="Port">The m_port connection to the server</param>
		/// <example>
		/// <code>
		/// 	SmtpClient smtp = new Smtp("smtp.dummy.com", 25);
		/// </code>
		/// </example>
		public SMTPClient(string Host, int Port) 
		{
			this.m_host = Host;
			this.m_port = Port;
		}

		/// <summary>
		/// The m_host name or IP of the SMTP server
		/// </summary>
		public string Host
		{
			get { 
				return(m_host); 
			}
			set { 
				m_host = value; 
			}
		}		

		/// <summary>
		/// The SMTP server connection m_port
		/// </summary>
		public int Port
		{
			get { 
				return(m_port); 
			}
			set { m_port = value; 
			}
		}
		
		/// <summary>
		/// The timeout to sending data to the server
		/// </summary>
		public int SendTimeout
		{
			get { 
				return m_sendTimeout; 
			}
			set { 
				m_sendTimeout = value; 
			}
		}
		
		/// <summary>
		/// The timeout for receiving data from server
		/// </summary>
		public int ReceiveTimeout
		{
			get { 
				return (m_receiveTimeout); 
			}
			set { 
				m_receiveTimeout = value; 
			}
		}

		
		/// <summary>
		/// Sends a command to smtp server
		/// </summary>
		/// <param name="cmd">A string containing the command to send</param>
		/// <param name="expected_status">A string containing the expected server answer</param>
		/// <returns>A string containing the server answer</returns>
		protected string SendCommand (string cmd, string expected_status)
		{
			string answer;

			m_streamWriter.Write (cmd);
			FireSendedCommand (cmd);
			answer = m_streamReader.ReadLine ();
			FireReceivedCommand (answer);
			if (answer.IndexOf (expected_status) == -1)
			{
				throw (new SmtpException (answer));
			}

			return answer;
		}

		/// <summary>Sends an e-mail message</summary>
		/// <param name="msg">The message to send</param>
		/// <param name="Host">SMTP server hostname or IP address</param>
		/// <param name="Port">Port used for the connection</param>
		public void SendMail(MimeMessage msg, string Host, int Port)
		{
			if (m_tcpClient != null)
				throw (new SmtpException ("Server already connected"));
			
			m_host = Host;
			m_port = Port;
			Open ();
			SendMail(msg);
			Close ();
		}
		
		/// <summary>Sends an e-mail message</summary>
		/// <param name="msg">The message to send</param>
		/// <param name="dst">The destination address</param>
		/// <param name="Host">SMTP server hostname or IP address</param>
		/// <param name="Port">Port used for the connection</param>
		public void SendMail(MimeMessage msg, MailAddress dst, string Host, int Port)
		{
			if (m_tcpClient != null)
				throw (new SmtpException ("Server already connected"));
			
			m_host = Host;
			m_port = Port;
			Open ();
			SendMail(msg, dst);
			Close ();
		}
		/// <summary>Sends an e-mail message to the connected server</summary>
		/// <param name="msg">The mail message to send</param>
		public void SendMail(MimeMessage msg)
		{
			// Send from address
			SendFromAddr (msg);

			// send all recipient list
			
			DeliverTo(msg.AddressTo);
			DeliverTo(msg.AddressCC);
			DeliverTo(msg.AddressBCC);

			// start sending data
			SendCommand ("DATA\r\n", SMTPConstants.START_DATA);
			
			// send the message (header + body + attachment)
			SMTPWriter wr = new SMTPWriter (m_streamWriter);
			msg.Write (wr);
			wr.Close ();

			// end of message data
			SendCommand ("\r\n.\r\n", SMTPConstants.OK);
		}

		/// <summary>
		/// Sends an e-mail message to the connected server
		/// </summary>
		/// <param name="msg">The mail message to send</param>
		/// <param name="dst">The destination address</param>
		public void SendMail (MimeMessage msg, MailAddress dst)
		{
			// Send from address
			SendFromAddr (msg);

			// send recipient list
			DeliverTo(dst);
			
			// start sending data
			SendCommand ("DATA\r\n", SMTPConstants.START_DATA);
			
			// send the message (header + body + attachment)
			SMTPWriter wr = new SMTPWriter (m_streamWriter);
			msg.Write (wr);
			wr.Close ();

			// end of message data
			SendCommand ("\r\n.\r\n", SMTPConstants.OK);
		}

		/// <summary>
		/// Sends the "from:" SMTP command
		/// </summary>
		/// <param name="msg">Mime message</param>
		private void SendFromAddr (MimeMessage msg)
		{
			// get a FROM: address
			if (msg.AddressSender.Mailbox.Length > 0)
				SendCommand ("MAIL FROM: " + msg.AddressSender.Mailbox + "\r\n", SMTPConstants.OK);
			else
			{
				if (msg.AddressFrom.Count == 0)
					throw (new SmtpException ("No sender address in 'from' address list"));
				else if (msg.AddressFrom.Count > 1)
					throw (new SmtpException ("Multiple 'from' address and 'sender' address empty"));

				SendCommand ("MAIL FROM: " + msg.AddressFrom[0].Mailbox + "\r\n", SMTPConstants.OK);
			}
		}
		
		/// <summary>
		/// Close the connection with the server
		/// </summary>
		public void Close ()
		{
			string answer;

			m_streamWriter.Write ("QUIT\r\n");
			if ((answer = m_streamReader.ReadLine ()).IndexOf (SMTPConstants.QUIT) == -1)
				throw (new SmtpException (answer));

			// close tcp connection 
			if (m_streamWriter != null)
				m_streamWriter.Close ();
			if (m_streamReader != null)
				m_streamReader.Close ();
			if (m_netStream != null)
				m_netStream.Close ();
			if (m_tcpClient != null)			
				m_tcpClient.Close(); 
			
			m_netStream = null;
			m_streamWriter = null;
			m_streamReader = null;
			m_tcpClient = null;
		}
		
		
		/// <summary>
		/// Opens the connection with the server
		/// </summary>
		public void Open ()
		{
			string answer;

			if (m_host == null || m_port == 0)
				throw new SmtpException("Invalid argument :" + m_host + "," + m_port.ToString());

			// initialize TCP connection
			m_tcpClient = new TcpClient(m_host, m_port);
				
			m_tcpClient.ReceiveTimeout	= m_receiveTimeout;
			m_tcpClient.SendTimeout		= m_sendTimeout;
			
			// build stream over TCP connection
			m_netStream = m_tcpClient.GetStream ();	
			m_streamReader = new StreamReader(m_tcpClient.GetStream(), System.Text.Encoding.ASCII);
			m_streamWriter = new StreamWriter(m_tcpClient.GetStream(), System.Text.Encoding.ASCII);
			m_streamWriter.AutoFlush = true;

			// check server answer
			if ((answer = m_streamReader.ReadLine ()).IndexOf (SMTPConstants.SYSTEM_READY) == -1)
				throw (new SmtpException (answer));

			m_streamWriter.Write ("HELO " + Dns.GetHostName() + "\r\n"); // standard SMTP
				
			// check server answer
			if ((answer = m_streamReader.ReadLine ()).IndexOf (SMTPConstants.OK) == -1)
				throw (new SmtpException (answer));
		}

		
		/// <summary>
		/// Send recipients addresses to the server
		/// </summary>
		/// <param name="recipients">Recipient address list</param>
		private void DeliverTo(MailAddressList recipients)
		{
			foreach (MailAddress addr in recipients)
			{
				DeliverTo (addr);
			}
		}
		
		/// <summary>
		/// Send a recipient address to the server
		/// </summary>
		/// <param name="recipient">Recipient address </param>
		private void DeliverTo(MailAddress recipient)
		{
			StringBuilder cmd = new StringBuilder ();
			cmd.AppendFormat ("RCPT TO:{0}\r\n", recipient.Mailbox);
			SendCommand (cmd.ToString (), SMTPConstants.OK);
		}
	}

}