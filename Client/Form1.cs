
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AsyncSocketClient
{
    
    public partial class Form1 : Form
    {
        SocketClient client;
        public Form1(SocketClient _client)
        {
            client = _client;
            InitializeComponent();
        }
        public void appendText(string _message)
        {
            dbgTextBox.AppendText(_message + '\n');
        }

        private void txtIPAddress_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtPort_TextChanged(object sender, EventArgs e)
        {

        }

        private void dbgTextBox_TextChanged(object sender, EventArgs e)
        {
            dbgTextBox.ScrollToCaret();
        }

        private async void btnConnect_Click(object sender, EventArgs e)
        {
            try
            {

                if (!client.SetServerIPAddress(txtIPAddress.Text) || !client.SetPortNumber(txtPort.Text) || !client.setUsername(username_textbox.Text))
                {
                    throw new InvalidOperationException("SERVER: An error occured with connection parameters. Please check your ip address, port, or username. \n");
                }

                txtIPAddress.Enabled = false;
                txtPort.Enabled = false;

                dbgTextBox.AppendText(string.Format("SERVER: Trying to connect to server on IP/Port: {0} / {1}\n",
                    txtIPAddress.Text, txtPort.Text));

                btnConnect.Enabled = false;

                await client.ConnectToServer();


                dbgTextBox.AppendText(string.Format("SERVER: Connected to server IP/Port: {0} / {1}\n",
                    txtIPAddress.Text, txtPort.Text));

                btnDisconnect.Enabled = true;
                username_textbox.Enabled = false;
                btnGetSweets.Enabled = true ;
                btn_getAllSweets.Enabled = true;
                btnFollow.Enabled = true;
                btnListUser.Enabled = true;
                btnBlockUser.Enabled = true;
                btnGetFollowers.Enabled = true;
                btnGetFollowSweetFeed.Enabled = true;
                btnFollowers.Enabled = true;
                btnDeleteSweet.Enabled = true;

            }
            catch(Exception excp)
            {
                txtIPAddress.Enabled = true;
                txtPort.Enabled = true;
                btnConnect.Enabled = true;
                username_textbox.Enabled = true;
                btnGetSweets.Enabled = false;
                btn_getAllSweets.Enabled = false;
                btnFollow.Enabled = false;
                btnListUser.Enabled = false;
                btnBlockUser.Enabled = false;
                btnGetFollowSweetFeed.Enabled = false;
                btnFollowers.Enabled = false;
                btnDeleteSweet.Enabled = false;
                btnGetFollowers.Enabled = false;
                Console.WriteLine(excp.Message);
                dbgTextBox.AppendText(excp.Message);
            }
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(msgBox.Text))
            {
                client.SendToServer("POST " + msgBox.Text);
                msgBox.Clear();
            }
        }

        private void msgBox_TextChanged(object sender, EventArgs e)
        {

        }

        public void disconnectOperations()
        {
            txtIPAddress.Enabled = true;
            txtPort.Enabled = true;
            btnConnect.Enabled = true;
            btnDisconnect.Enabled = false;
            username_textbox.Enabled = true;
            btnGetSweets.Enabled = false;
            btn_getAllSweets.Enabled = false;
            btnFollow.Enabled = false;
            btnListUser.Enabled = false;
            btnGetFollowSweetFeed.Enabled = false;
            btnBlockUser.Enabled = false;
            btnGetFollowers.Enabled = false;
            btnFollowers.Enabled = false;
            btnDeleteSweet.Enabled = false;
        }

        private void btnDisconnect_Click(object sender, EventArgs e)
        {
            client.CloseAndDisconnect();
            disconnectOperations();


        }

        private void msgBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSend_Click(this, new EventArgs());
            }
        }

        private void username_textbox_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnGetSweets_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(userSearchTextBox.Text))
            {
                client.SendToServer("LIST " + userSearchTextBox.Text);
                dbgTextBox.AppendText("Requested sweets of " + userSearchTextBox.Text + "\n");
            }
            else
            {
                dbgTextBox.AppendText("Username field cannot be empty\n");
            }
        }

        private void userSearchTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void Form1_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            // Determine if text has changed in the textbox by comparing to original text.
            if (btnDisconnect.Enabled)
            {
                client.CloseAndDisconnect();
            }
        }

        private void btn_getAllSweets_Click(object sender, EventArgs e)
        {
            client.SendToServer("LSWT");
            dbgTextBox.AppendText("Requested sweets\n");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            client.SendToServer("LUSR");
            dbgTextBox.AppendText("Requested user list\n");
        }

        private void btnFollow_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(followUserTextBox.Text))
            {
                if (followUserTextBox.Text == username_textbox.Text)
                {
                    dbgTextBox.AppendText("ERROR: You can not follow yourself\n");
                }
                else
                {
                    client.SendToServer("FLLW " + followUserTextBox.Text);
                }
            }

            else
            {
                dbgTextBox.AppendText("Username field cannot be empty\n");
            }
        }

        private void btnGetFollowSweetFeed_Click(object sender, EventArgs e)
        {
            client.SendToServer("LFLS");
            dbgTextBox.AppendText("Requested followed user sweets\n");
        }

        private void usrBlockTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnBlockUser_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(usrBlockTextBox.Text))
            {
                if (usrBlockTextBox.Text == username_textbox.Text)
                {
                    dbgTextBox.AppendText("ERROR: You can not block yourself\n");
                }
                else
                {
                    client.SendToServer("BLCK " + usrBlockTextBox.Text);
                }
            }

            else
            {
                dbgTextBox.AppendText("Username field cannot be empty\n");
            }
        }

        private void btnGetFollowers_Click(object sender, EventArgs e)
        {
            client.SendToServer("FLWD");
            dbgTextBox.AppendText("Requested followed list\n");
        }

        private void btnFollowers_Click(object sender, EventArgs e)
        {
            client.SendToServer("FLWR");
            dbgTextBox.AppendText("Requested followers list\n");
        }

        private void btnDeleteSweet_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(deleteSweetTextBox.Text))
            {
                if (!deleteSweetTextBox.Text.All(char.IsNumber))
                {
                    dbgTextBox.AppendText("ERROR: Sweet ID can only consist digits\n");
                }
                else
                {
                    client.SendToServer("DSWT " + deleteSweetTextBox.Text);
                }
            }

            else
            {
                dbgTextBox.AppendText("ERROR: Sweet ID field cannot be empty\n");
            }
        }
    }
    public class SocketClient
    {

        IPAddress mServerIPAddress;
        int mServerPort;
        TcpClient mClient;
        Form1 form;
        String username;

        public SocketClient()
        {
            form = null;
            mClient = null;
            mServerPort = -1;
            mServerIPAddress = null;
            username = null;
        }

        public void connectForm(Form1 _form)
        {
            form = _form;
        }

        public IPAddress ServerIPAddress
        {
            get
            {
                return mServerIPAddress;
            }
        }

        public int ServerPort
        {
            get
            {
                return mServerPort;
            }
        }

        public bool setUsername(string _username)
        {
            if (_username.Length == 0)
            {
                return false;
            }
            else
            {
                username = _username;
                Debug.WriteLine(username);
                return true;
            }
        }
        public bool SetServerIPAddress(string _IPAddressServer)
        {
            IPAddress ipaddr = null;

            if (!IPAddress.TryParse(_IPAddressServer, out ipaddr))
            {

                Console.WriteLine("Invalid IP Address provided.");
                throw new InvalidOperationException("SERVER: Invalid IP Address provided.\n");
            }

            mServerIPAddress = ipaddr;
            Debug.WriteLine(mServerIPAddress.ToString());
            return true;
        }

        public bool SetPortNumber(string _ServerPort)
        {
            int portNumber = 0;

            if (!int.TryParse(_ServerPort.Trim(), out portNumber))
            {
                Console.WriteLine("Invalid port number supplied, return.");
                throw new InvalidOperationException("SERVER: Invalid port number provided. Not an integer.\n");
            }

            if (portNumber <= 0 || portNumber > 65535)
            {
                Console.WriteLine("Port number must be between 0 and 65535.");
                throw new InvalidOperationException("SERVER: Invalid port number provided. Port number must be between 0 and 65535.\n");
            }

            mServerPort = portNumber;

            return true;
        }

        public async Task ConnectToServer()
        {
            if (mClient == null)
            {
                mClient = new TcpClient();
            }

            try
            {
                await mClient.ConnectAsync(mServerIPAddress, mServerPort);

                StreamWriter clientStreamWriter = new StreamWriter(mClient.GetStream());
                clientStreamWriter.AutoFlush = true;
                clientStreamWriter.Write(username);

                StreamReader clientStreamReader = new StreamReader(mClient.GetStream());
                char[] buff = new char[64];
                int readByteCount = 0;
                readByteCount = clientStreamReader.Read(buff, 0, buff.Length);

                String message = new string(buff);

                form.appendText("SERVER: " + message);

                if (message.Substring(0,3) == "404")
                {
                    mClient = null;
                    throw new InvalidOperationException("SERVER: An error occured when trying to connect to server. \n");
                }


                ReadDataAsync(mClient);

                



            }
            catch (Exception excp)
            {
                throw new InvalidOperationException("SERVER: An error occured when trying to connect to server. \n");
            }
        }

        private async Task ReadDataAsync(TcpClient mClient)
        {
            try
            {
                StreamReader clientStreamReader = new StreamReader(mClient.GetStream());
                char[] buff = new char[64];
                int readByteCount = 0;

                while (true)
                {

                    readByteCount = await clientStreamReader.ReadAsync(buff, 0, buff.Length);

                    if (readByteCount <= 0)
                    {

                        form.appendText("SERVER: Disconnected");
                        form.disconnectOperations();
                        CloseAndDisconnect();
                        break;
                    }

                    String message = new string(buff);
                    message = message.Replace("\0", string.Empty);
                    //Console.WriteLine(string.Format("Received bytes: {0} - Message: {1}",readByteCount, new string(buff)));
                    if (message != "")
                    {
                        form.appendText(message);
                    }

                    Array.Clear(buff, 0, buff.Length);
                }
            }
            catch (Exception excp)
            {
                //form.appendText(excp.ToString());
                throw;
            }
        }

        public void CloseAndDisconnect()
        {
            if (mClient != null)
            {
                if (mClient.Connected)
                {
                    mClient.Close();
                    mClient.Dispose();
                    
                }
                mClient = null;
            }
        }

        public async Task SendToServer(string strInputUser)
        {
            if (string.IsNullOrEmpty(strInputUser))
            {
                Console.WriteLine("Empty string supplied to send.");
                return;
            }

            if (mClient != null)
            {
                if (mClient.Connected)
                {
                    StreamWriter clientStreamWriter = new StreamWriter(mClient.GetStream());
                    clientStreamWriter.AutoFlush = true;

                    await clientStreamWriter.WriteAsync(strInputUser);
                    form.appendText(username + ": " + strInputUser.Substring(5));
                }
            }

        }

    }



}
