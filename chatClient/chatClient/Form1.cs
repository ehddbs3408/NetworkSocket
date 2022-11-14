using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace chatClient
{
    public partial class Form1 : Form
    {
        TcpClient clientsocket = new TcpClient();
        NetworkStream serverStream = default(NetworkStream);
        string readData = null;
        bool stopRunning = false;

        private void msg()
        {
            if (InvokeRequired)
            {
                Invoke(new MethodInvoker(msg));
            }
            else textBox2.Text = textBox2.Text + Environment.NewLine
                    + " >> " + readData;
        }

        private void getMessage()
        {
            byte[] inStream = new byte[1024];
            string returnData = "";

            try
            {
                while (!stopRunning)
                {
                    serverStream = clientsocket.GetStream();
                    int buffsize = 0;
                    buffsize = clientsocket.ReceiveBufferSize;
                    int numBytesRead;

                    if (serverStream.DataAvailable)
                    {
                        returnData = "";
                        while (serverStream.DataAvailable)
                        {
                            numBytesRead = serverStream.Read(inStream, 0, inStream.Length);
                            returnData += Encoding.UTF8.GetString(inStream, 0, numBytesRead);
                        }
                        readData = returnData;
                        msg();
                    }
                }
            }
            catch (Exception ex)
            {
                stopRunning = true;
            }
        }
        public Form1()
        {
            InitializeComponent();
        }

        private void btn_connect_Click(object sender, EventArgs e)
        {
            readData = "Connected to Chat Server...";
            msg();
                clientsocket.Connect("localhost", 8888);
            serverStream = clientsocket.GetStream();

            byte[] outStream = Encoding.UTF8.GetBytes(textBox1.Text + '$');
            serverStream.Write(outStream, 0, outStream.Length); //send
            serverStream.Flush();

            Thread ctThread = new Thread(getMessage);
            ctThread.Start();

        }

        private void btn_send_Click(object sender, EventArgs e)
        {
            byte[] outStream = Encoding.UTF8.GetBytes(textBox3.Text + '$');
            serverStream.Write(outStream, 0, outStream.Length);
            serverStream.Flush();
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            stopRunning = true;
            if(clientsocket.Connected==true)
            {
                serverStream.Close();
                clientsocket.Close();
            }
            
        }

        private void button1_Click(object sender, EventArgs e) //새로운기능 꼐산기!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
        {

            //입력 예 ) 1+1 , 2*2 , 10/2
            string a = textBox3.Text;
            for(int j = 0;j<4;j++)
            {
                if(a.IndexOf('+') > -1)
                {
                    string[] s = a.Split('+');
                    int result = 0;
                    for (int i = 0; i < s.Length; i++)
                    {
                        result += int.Parse(s[i]);
                    }
                    a = a + "=" + result;
                    break;
                }
                if (a.IndexOf('-') > -1)
                {
                    string[] s = a.Split('-');
                    int result = 0;
                    for (int i = 0; i < s.Length; i++)
                    {
                        result -= int.Parse(s[i]);
                    }
                    a = a + "=" + result;
                    break;
                }
                if (a.IndexOf('/') > -1)
                {
                    string[] s = a.Split('/');
                    int result = int.Parse(s[0]); ;
                    for (int i = 1; i < s.Length; i++)
                    {
                        result /= int.Parse(s[i]);
                    }
                    a = a + "=" + result;
                    break;
                }
                if (a.IndexOf('*') > -1)
                {
                    string[] s = a.Split('*');
                    int result = 1;
                    for (int i = 0; i < s.Length; i++)
                    {
                        result *= int.Parse(s[i]);
                    }
                    a = a + "=" + result;
                    break;
                }
            }
            
            byte[] outStream = Encoding.UTF8.GetBytes(a + '$');
            serverStream.Write(outStream, 0, outStream.Length);
            serverStream.Flush();
        }

        private void Btn_earInHorse_Click(object sender, EventArgs e)//귀속말=======================================
        {
            int id = int.Parse(textBox4.Text);
            byte[] outStream = Encoding.UTF8.GetBytes(textBox3.Text + '$');
            serverStream.Write(outStream, id, outStream.Length);
        }

        private void CLS_Click(object sender, EventArgs e) //지우기 기능=============================================
        {
            textBox2.Text = "";
        }

        private void Out_Click(object sender, EventArgs e)//나가기=============================================
        {
            if(clientsocket.Connected == true)
            {
                stopRunning = true;
                serverStream.Close();
                clientsocket.Close();
                readData = "서버에서 나갔습니다.";
                msg();
            }
            else
            {
                readData = "님이미 나감";
                msg();
            }
            
        }

        private void Red_Click(object sender, EventArgs e)
        {
            textBox2.ForeColor = Color.Red;
            this.BackColor = Color.Red;
        }

        private void O_Click(object sender, EventArgs e)
        {
            textBox2.ForeColor = Color.Orange;
            this.BackColor = Color.Orange;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox2.ForeColor = Color.Yellow;
            this.BackColor = Color.Yellow;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox2.ForeColor = Color.Green;
            this.BackColor = Color.Green;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox2.ForeColor = Color.SkyBlue;
            this.BackColor = Color.SkyBlue;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox2.ForeColor = Color.Blue;
            this.BackColor = Color.Blue;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }
    }
}
