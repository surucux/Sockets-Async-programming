

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



namespace SocketServerGUI
{

    public partial class Form1 : Form
    {
        SocketServer mServer;
        public Form1(SocketServer _server)
        {
            Control.CheckForIllegalCrossThreadCalls = false;
            InitializeComponent();
            mServer = _server;
        }

        public void appendText(string _message)
        {
            serverDebugTextField.AppendText(_message);
            serverDebugTextField.AppendText("\n");
            serverDebugTextField.ScrollToCaret();
        }


        private void btnAcceptIncomingConnection_Click(object sender, EventArgs e) // button listen click
        {
            if(portNumber.Text.Trim() == "")
            {
                portNumber.Text = "23000";
            }
            portNumber.Enabled = false;
            portNumber.ReadOnly = true;
            btnAcceptIncomingConnection.Enabled = false;
            stopListening.Enabled = true;

            mServer.StartListeningForIncomingConnection(port: Int32.Parse(portNumber.Text.Trim()));
            

            serverDebugTextField.AppendText("SERVER: Started listening on port " + mServer.mPort + "\n");
        }




        private void txtMessage_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnSendAll_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txtMessage.Text))
            {
                mServer.SendToAll(txtMessage.Text.Trim());
                String dbgText = "SERVER: Sent a global message to clients: " + txtMessage.Text.Trim() + '\n';
                serverDebugTextField.AppendText(dbgText);
                txtMessage.Clear();
            }
        }

        private void serverDebugTextField_TextChanged(object sender, EventArgs e)
        {

        }

        private void portNumber_TextChanged(object sender, EventArgs e)
        {

        }

        private void stopListening_Click(object sender, EventArgs e)
        {
            mServer.KeepRunning = false;
            stopListening.Enabled = false;
            btnAcceptIncomingConnection.Enabled = true;
            portNumber.Enabled = true;
            portNumber.ReadOnly = false;

            mServer.StopServer();

            serverDebugTextField.AppendText("SERVER: Stopped listening on port " + mServer.mPort + "\n");

        }
        private void Form1_FormClosing_1(object sender, FormClosingEventArgs e)
        {
            mServer.StopServer();
        }
    }

    public class SocketServer
    {

        IPAddress mIP;
        public int mPort;
        TcpListener mTCPListener;
        Form1 form;
        Dictionary<String, TcpClient> users;
        List<TcpClient> mClients;

        string userFile = @"C:\server\user-db.txt";
        string messagesFile = @"C:\server\messages.txt";
        string followFile = @"C:\server\follow.txt";
        string blockFile = @"C:\server\block.txt";


        public void connectForm(Form1 _form)
        {
            form = _form;
        }

        public bool KeepRunning { get; set; } = true;

        public SocketServer()
        {
            mClients = new List<TcpClient>();
            users = new Dictionary<String, TcpClient>();


            //Read the user database and store them inside a dictionary (dictionary type => username,int. int represents online status.)
            using (StreamReader file = new StreamReader(userFile))  //D:\\Users\suuser\Desktop\SocketServerGUI\user-db.txt
            {
                int counter = 0;
                string ln;

                while ((ln = file.ReadLine()) != null)
                {
                    Debug.WriteLine($"User {ln} has been added to database.");
                    users.Add(ln, null);
                    counter++;
                }
                file.Close();
                Debug.WriteLine($"File has {counter} lines.");
            }

        }
        public async void StartListeningForIncomingConnection(IPAddress ipaddr = null, int port = 23000)
        {
            if (ipaddr == null)
            {
                ipaddr = IPAddress.Any;
            }

            if (port <= 0)
            {
                port = 23000;
            }

            mIP = ipaddr;
            mPort = port;

            form.appendText(string.Format("SERVER: Started listening. IP Address: {0} - Port: {1}", mIP.ToString(), mPort));

            mTCPListener = new TcpListener(mIP, mPort);

            try
            {
                mTCPListener.Start();

                KeepRunning = true;
                while (KeepRunning)
                {
                    var returnedByAccept = await mTCPListener.AcceptTcpClientAsync();
                    String username = getUsername(returnedByAccept);

                    if (username != null)
                    {
                        mClients.Add(returnedByAccept);
                        form.appendText(String.Format("SERVER: Client connected, count: {0} - username: {1}", mClients.Count, username));

                        ClientService(returnedByAccept, username);
                    }
                    else
                    {
                        RemoveClient(returnedByAccept);
                    }

                }


            }
            catch (Exception excp)
            {
                Debug.WriteLine(excp.ToString());
            }

        }

        private string getUsername(TcpClient clientParam)
        {
            NetworkStream stream = null;
            StreamReader reader = null;

            try
            {
                String message;
                stream = clientParam.GetStream();
                reader = new StreamReader(stream);

                char[] buff = new char[64];

                int nRet = reader.Read(buff, 0, buff.Length);
                string username = new string(buff);
                username = username.Replace("\0", string.Empty);

                TcpClient tempClient = null;

                if (users.ContainsKey(username)) // && !
                {
                    users.TryGetValue(username, out tempClient);
                    if (tempClient == null)
                    {
                        message = $"200 - Succesfully logged in as {username}.\n";
                        byte[] buffMessage = Encoding.ASCII.GetBytes(message);
                        clientParam.GetStream().WriteAsync(buffMessage, 0, buffMessage.Length);

                        users[username] = clientParam;
                        return username;
                    }
                    else
                    {
                        message = $"404 - User {username} is already logged in!\n";
                        byte[] buffMessage = Encoding.ASCII.GetBytes(message);
                        clientParam.GetStream().WriteAsync(buffMessage, 0, buffMessage.Length);
                        return null;
                    }

                }
                else
                {
                    message = $"404 - User {username} does not exist!\n";
                    byte[] buffMessage = Encoding.ASCII.GetBytes(message);
                    clientParam.GetStream().WriteAsync(buffMessage, 0, buffMessage.Length);
                    return null;
                }


            }
            catch (Exception excp)
            {
                Debug.WriteLine(excp.ToString());
                return null;
            }
        }

        public void StopServer()
        {
            try
            {
                if (mTCPListener != null)
                {
                    mTCPListener.Stop();
                }

                foreach (TcpClient c in mClients)
                {
                    c.Close();
                }

                mClients.Clear();
            }
            catch (Exception excp)
            {

                Debug.WriteLine(excp.ToString());
            }
        }

        private async void ClientService(TcpClient clientParam, String username)
        {
            NetworkStream stream = null;
            StreamReader reader = null;

            try
            {
                stream = clientParam.GetStream();
                reader = new StreamReader(stream);

                char[] buff = new char[64];

                while (KeepRunning)
                {
                    Debug.WriteLine("\n\n*** Ready to read ***");

                    int nRet = await reader.ReadAsync(buff, 0, buff.Length);

                    Debug.WriteLine("Communications returned: " + nRet);

                    if (nRet == 0)
                    {
                        RemoveClient(clientParam);
                        users[username] = null;
                        form.appendText($"SERVER: Client disconnected, count: {mClients.Count} - username: {username}");
                        Debug.WriteLine("Socket Disconnected");
                        break;
                    }

                    string receivedText = new string(buff);
                    receivedText = receivedText.Replace("\n", string.Empty);
                    receivedText = receivedText.Replace("\0", string.Empty);

                    // PROCESS CHECK
                    if (receivedText.Substring(0, 4) == "LIST")
                    {
                        string searchUsername = receivedText.Substring(5);
                        ListThePosts(searchUsername, clientParam, username);
                        form.appendText("[" + clientParam.Client.RemoteEndPoint + "] " + username + " requested the sweets of " + searchUsername);
                    }
                    else if (receivedText.Substring(0, 4) == "LSWT")
                    {
                        //list all 
                        ListThePosts(null, clientParam, username);
                        form.appendText("[" + clientParam.Client.RemoteEndPoint + "] " + username + " requested all the sweets");
                    }
                    else if (receivedText.Substring(0, 4) == "POST")
                    {
                        //post operation
                        receivedText = receivedText.Substring(5);
                        addToDatabase(username, receivedText);
                        //SendToAllExcept(username + ": " + receivedText, clientParam);
                        form.appendText("[" + clientParam.Client.RemoteEndPoint + "] " + username + " Sweeted: " + receivedText);
                    }
                    else if (receivedText.Substring(0, 4) == "LUSR")
                    {
                        //list all 
                        sendUserList(clientParam);
                        form.appendText("[" + clientParam.Client.RemoteEndPoint + "] " + username + " requested user list");
                    }
                    else if (receivedText.Substring(0, 4) == "FLLW")
                    {
                        //follow user
                        string followedUser = receivedText.Substring(5);
                        follow(username, followedUser, clientParam);
                    }
                    else if (receivedText.Substring(0, 4) == "LFLS")
                    {
                        //list sweets of followed users
                        form.appendText("[" + clientParam.Client.RemoteEndPoint + "] " + username + " requested followed user feed");
                        List<string> fList = followerList(username);

                        foreach (string usr in fList)
                        {
                            ListThePosts(usr, clientParam, username);
                        }
                    }
                    else if (receivedText.Substring(0, 4) == "BLCK")
                    {
                        // block user
                        string blockedUser = receivedText.Substring(5);
                        blockUser(username, blockedUser, clientParam);
                    }
                    else if (receivedText.Substring(0, 4) == "FLWD")
                    {
                        form.appendText("[" + clientParam.Client.RemoteEndPoint + "] " + username + " requested followed users");

                        // send back users logged in user follows
                        foreach (string user in followerList(username))
                        {
                            sendToUser(clientParam, "You follow: " + user);
                            System.Threading.Thread.Sleep(1);
                        }
                    }
                    else if (receivedText.Substring(0, 4) == "FLWR")
                    {
                        form.appendText("[" + clientParam.Client.RemoteEndPoint + "] " + username + " requested followers");
                        // send back users who follow logged user
                        foreach (string user in reverseFollowerList(username))
                        {
                            sendToUser(clientParam, "You are followed by: " + user);
                            System.Threading.Thread.Sleep(1);
                        }
                    }
                    else if (receivedText.Substring(0, 4) == "DSWT")
                    {
                        // delete sweet
                        string sweetID = receivedText.Substring(5);
                        
                        if (sweetExist(sweetID))
                        {
                            deleteSweet(sweetID, username, clientParam);
                        }
                        else
                        {
                            sendToUser(clientParam, "[SERVER] Such sweet does not exist!");
                        }
                    }
                    else
                    {
                        form.appendText("[" + clientParam.Client.RemoteEndPoint + "] " + username + " - Unknown Request: " + receivedText);
                    }
                    Array.Clear(buff, 0, buff.Length);

                }
            }
            catch (Exception excp)
            {
                RemoveClient(clientParam);
                users[username] = null;
                form.appendText($"SERVER: Client disconnected, count: {mClients.Count} - username: {username}");
                Debug.WriteLine(excp.ToString());
            }

        }

        private void blockUser(string userName,string blocked, TcpClient client)
        {
            if (!users.ContainsKey(blocked))
            {
                sendToUser(client, "SERVER: The user you are trying to block does not exist:  " + blocked);
            }

            if (followerList(blocked).Contains(userName))
            {
                //unfollow user operation
                sendToUser(client, "SERVER: The user you are trying to block was following you. User has been removed from your followers list.");
                unfollowUser(blocked,userName);
            }

            addToBlockedFile(userName, blocked);
            sendToUser(client, "SERVER: You have now blocked: " + blocked);
            form.appendText("[" + client.Client.RemoteEndPoint + "] " + userName + " blocked " + blocked);

        }

        private void addToBlockedFile(string userName, string blocked)
        {
            string line = userName + '-' + blocked;
            if (!File.Exists(blockFile))
            {
                using (StreamWriter writer = new StreamWriter(blockFile))
                {

                    writer.WriteLine(line);

                }
            }
            else
            {
                using (StreamWriter sw = File.AppendText(blockFile))
                {
                    sw.WriteLine(line);
                }
            }
        }

        private void unfollowUser(string userName,string follower)
        {

            var tempFile = Path.GetTempFileName();
            var linesToKeep = File.ReadLines(followFile).Where(l => l != $"{userName}-{follower}");

            File.WriteAllLines(tempFile, linesToKeep);

            File.Delete(followFile);
            File.Move(tempFile, followFile);
        }
        private bool sweetExist(string id)
        {
            var lines = File.ReadLines(messagesFile);
            foreach (string line in lines)
            {
                string swID = line.Substring(line.IndexOf("//") + 3, 6);
                if (id == swID)
                {
                    return true;
                }
            }
            return false;

        }
        private bool keepSweet(string line,string removeID,string username, TcpClient client)
        {
            string swID = line.Substring(line.IndexOf("//") + 3, 6);
            
            if (swID != removeID)
            {
                return true;
            }
            else
            {
                string author = line.Substring(0, line.IndexOf("//") - 1);
                if (author == username)
                {
                    form.appendText("[" + client.Client.RemoteEndPoint + "] Succesfully deleted sweetID: " + swID);
                    sendToUser(client, "[SERVER] You have deleted sweet " + swID);

                    return false;
                }
                form.appendText("[" + client.Client.RemoteEndPoint + "] "+username+" is not authorized to delete sweet " + swID);
                sendToUser(client, "[SERVER] You don't own this sweet. Not authorized! ");
                return true;
            }

        }
        private void deleteSweet(string sweetID,string username,TcpClient client)
        {

            var tempFile = Path.GetTempFileName();
            var linesToKeep = File.ReadLines(messagesFile).Where(l => keepSweet(l,sweetID,username, client) );

            File.WriteAllLines(tempFile, linesToKeep);

            File.Delete(messagesFile);
            File.Move(tempFile, messagesFile);
        }

        public List<string> reverseFollowerList(string username)
        {

            List<string> userList = new List<string>();


            using (StreamReader file = new StreamReader(followFile))
            {
                string ln, user;

                while ((ln = file.ReadLine()) != null)
                {
                    user = ln.Substring(ln.IndexOf('-')+1);

                    if (user == username)
                    {
                        userList.Add(ln.Substring(0,ln.IndexOf('-')));
                    }

                }
                file.Close();
            }

            return userList;
        }
        //
        public List<string> followerList(string username)
        {

            List<string> userList = new List<string>();


            using (StreamReader file = new StreamReader(followFile))
            {
                string ln,user;

                while ((ln = file.ReadLine()) != null)
                {
                    user = ln.Substring(0, ln.IndexOf('-'));

                    if (user == username)
                    {
                        userList.Add(ln.Substring(ln.IndexOf('-') + 1));
                    }

                }
                file.Close();
            }

            return userList;
        }

        public void follow(string follower, string followed,TcpClient client)
        {

            followed = followed.Trim();
            followed = followed.Replace("\0", string.Empty);
            string line = follower + '-' + followed;

            if (users.ContainsKey(followed))
            {
                if (!isBlocked(followed,follower))
                {
                    if (!File.Exists(followFile))
                    {
                        using (StreamWriter writer = new StreamWriter(followFile))
                        {

                            writer.WriteLine(line);

                        }
                    }
                    else
                    {
                        using (StreamWriter sw = File.AppendText(followFile))
                        {
                            sw.WriteLine(line);
                        }
                    }
                    sendToUser(client, "You are now following " + followed);
                    form.appendText("SERVER: " + follower + " followed " + followed);
                }
                else
                {
                    form.appendText("SERVER: " + follower + " is blocked by " + followed + ", unable to follow.");
                    sendToUser(client, "[SERVER] You are blocked by "+followed+"!");
                }
                


            }
            else
            {
                form.appendText("SERVER: "+ follower + " tried to follow but user does not exist: " + followed);
                sendToUser(client, "[SERVER] Such user does not exist!");
            }

        }

        private void RemoveClient(TcpClient clientParam)
        {
            if (mClients.Contains(clientParam))
            {
                if (clientParam.Connected)
                {
                    clientParam.GetStream().Close();
                }
                clientParam.Close();
                mClients.Remove(clientParam);

            }
        }
        public static String GetTimestamp(DateTime value)
        {
            return value.ToString("yyyy-MM-dd HH:mm:ss");
        }

        private void addToDatabase(string username, string message)
        {

            String timeStamp = GetTimestamp(DateTime.Now);
            Random rnd = new Random();

            DateTime foo = DateTime.Now;
            long unixTime = ((DateTimeOffset)foo).ToUnixTimeSeconds();
            String sweetID = unixTime.ToString().Substring(7) + rnd.Next(100,999).ToString();

            message = message.Trim();
            message = message.Replace("\0", string.Empty);
            message = username + " // " + sweetID + " // " + timeStamp +" // "+message;
            


            if (!File.Exists(messagesFile))
            {
                using (StreamWriter writer = new StreamWriter(messagesFile))
                {
                    
                    writer.WriteLine(message);

                }
            }
            else
            {
                using (StreamWriter sw = File.AppendText(messagesFile))
                {
                    sw.WriteLine(message);
                }
            }

        }
    
        
        public async void sendUserList(TcpClient client)
        {
            foreach (string username in users.Keys)
            {
                sendToUser(client, "USER: " + username);
                System.Threading.Thread.Sleep(1);
            }
        }
        
        public async void SendToAllExcept(string message, TcpClient exc)
        {
            
            if (string.IsNullOrEmpty(message))
                return;

            try
            {
                byte[] buffMessage = Encoding.ASCII.GetBytes(message);

                foreach (TcpClient client in mClients)
                {
                    if (client != exc)
                    {
                        client.GetStream().WriteAsync(buffMessage, 0, buffMessage.Length);
                        
                    }
                    
                }

            }
            catch (Exception excp)
            {
                Debug.WriteLine(excp.ToString());
            }
        }

        public async void sendToUser(TcpClient client, string message)
        {
            byte[] buffMessage = Encoding.ASCII.GetBytes(message);
            client.GetStream().WriteAsync(buffMessage, 0, buffMessage.Length);
        }

        public async void SendToAll(string message)
        {
            if (string.IsNullOrEmpty(message))
                return;

            try
            {
                message ="ADMIN: " + message + '\n';
                byte[] buffMessage = Encoding.ASCII.GetBytes(message);

                foreach (TcpClient client in mClients)
                {
                    client.GetStream().WriteAsync(buffMessage, 0, buffMessage.Length);
                }
                
            }
            catch (Exception excp)
            {
                Debug.WriteLine(excp.ToString());
            }
        }

        private bool isBlocked(String user,String possibleBlocked)
        {
            string key = user + '-' + possibleBlocked;
            using (StreamReader file = new StreamReader(blockFile))
            {
                string ln;

                while ((ln = file.ReadLine()) != null)
                {

                    if (ln == key)
                    {
                        return true;
                    }

                }
                file.Close();
            }
            return false;
        }

        public async void ListThePosts(string searchedUser , TcpClient user,string loggedUser)
        {
            bool allSweets = searchedUser == null ? true : false;

            string[] lines = File.ReadAllLines(messagesFile);

            foreach (string line in lines)
            {
                string sweetAuthor = line.Substring(0, line.IndexOf("//") - 1);
                string sweetData = line.Substring(0, line.LastIndexOf("//"));
                string sweet = line.Substring(line.LastIndexOf("//") + 3);


                if (allSweets)
                {
                    if (sweetAuthor != loggedUser && !isBlocked(sweetAuthor,loggedUser))
                    {
                        byte[] buffMessage = Encoding.ASCII.GetBytes("INFO: " + sweetData);
                        user.GetStream().WriteAsync(buffMessage, 0, buffMessage.Length);
                        System.Threading.Thread.Sleep(10);
                        buffMessage = Encoding.ASCII.GetBytes("Sweet: " + sweet);
                        user.GetStream().WriteAsync(buffMessage, 0, buffMessage.Length);

                        System.Threading.Thread.Sleep(30);
                    }
                }

                else if (sweetAuthor == searchedUser && !isBlocked(sweetAuthor, loggedUser))
                {
                    
                    byte[] buffMessage = Encoding.ASCII.GetBytes("INFO: " + sweetData);
                    user.GetStream().WriteAsync(buffMessage, 0, buffMessage.Length);
                    System.Threading.Thread.Sleep(10);
                    buffMessage = Encoding.ASCII.GetBytes("Sweet: " + sweet);
                    user.GetStream().WriteAsync(buffMessage, 0, buffMessage.Length);

                    System.Threading.Thread.Sleep(30);
                }
            }

            if (searchedUser != null && isBlocked(searchedUser, loggedUser))
            {
                sendToUser(user,"SERVER: You are blocked by " + searchedUser + ". You can not retrieve user's sweets.");
                form.appendText("SERVER: " + searchedUser + " is blocked by " + loggedUser + ", can not retrieve sweets.");
            }

            return;
        }
    }
}
