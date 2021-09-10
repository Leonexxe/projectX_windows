using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Net.Sockets;
using System.IO;
namespace ProjectX_WIN_UI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.background_CPPCSCOM.RunWorkerAsync();
            this.UILoader.RunWorkerAsync();
        }

        private void CPPCSCOM_DoWork(object sender, DoWorkEventArgs e)
        {
            Thread thread = new Thread(this.CPP_CONN);
            thread.Start();
            while(!this.CPP1){}
            this.INIT_NET_CLIENT = true;
            Thread thread2 = new Thread(this.CPP_CONN);
            thread2.Start();
        }

        public string toCPP = "";
        public string CPPAwnser = "";
        public string getCPPAwnser()
        {
            while(this.CPPAwnser == ""){}
            string s = this.CPPAwnser;
            this.CPPAwnser = "";
            return s;
        }
        public bool CPP1 = false;
        public bool CPP_INI_Loaded = false;

        private bool running = true;
        public bool INIT_NET_CLIENT = false;

        public string fromASCII(int I)
        {
            if(I == 32){return " ";}
            else if(I == 33){return "!";}
            else if(I == 34){return "\"";}
            else if(I == 35){return "#";}
            else if(I == 36){return "$";}
            else if(I == 37){return "%";}
            else if(I == 38){return "&";}
            else if(I == 39){return "'";}
            else if(I == 40){return "(";}
            else if(I == 41){return ")";}
            else if(I == 42){return "*";}
            else if(I == 43){return "+";}
            else if(I == 44){return ",";}
            else if(I == 45){return "-";}
            else if(I == 46){return ".";}
            else if(I == 47){return "/";}
            else if(I == 48){return "0";}
            else if(I == 49){return "1";}
            else if(I == 50){return "2";}
            else if(I == 51){return "3";}
            else if(I == 52){return "4";}
            else if(I == 53){return "5";}
            else if(I == 54){return "6";}
            else if(I == 55){return "7";}
            else if(I == 56){return "8";}
            else if(I == 57){return "9";}
            else if(I == 58){return ":";}
            else if(I == 59){return ";";}
            else if(I == 60){return "<";}
            else if(I == 61){return "=";}
            else if(I == 62){return ">";}
            else if(I == 63){return "?";}
            else if(I == 64){return "@";}
            else if(I == 65){return "A";}
            else if(I == 66){return "B";}
            else if(I == 67){return "C";}
            else if(I == 68){return "D";}
            else if(I == 69){return "E";}
            else if(I == 70){return "F";}
            else if(I == 71){return "G";}
            else if(I == 72){return "H";}
            else if(I == 73){return "I";}
            else if(I == 74){return "J";}
            else if(I == 75){return "K";}
            else if(I == 76){return "L";}
            else if(I == 77){return "M";}
            else if(I == 78){return "N";}
            else if(I == 79){return "O";}
            else if(I == 80){return "P";}
            else if(I == 81){return "Q";}
            else if(I == 82){return "R";}
            else if(I == 83){return "S";}
            else if(I == 84){return "T";}
            else if(I == 85){return "U";}
            else if(I == 86){return "V";}
            else if(I == 87){return "W";}
            else if(I == 88){return "X";}
            else if(I == 89){return "Y";}
            else if(I == 90){return "Z";}
            else if(I == 91){return "[";}
            else if(I == 92){return "\\";}
            else if(I == 93){return "]";}
            else if(I == 94){return "^";}
            else if(I == 95){return "_";}
            else if(I == 96){return "`";}
            else if(I == 97){return "a";}
            else if(I == 98){return "b";}
            else if(I == 99){return "c";}
            else if(I == 100){return "d";}
            else if(I == 101){return "e";}
            else if(I == 102){return "f";}
            else if(I == 103){return "g";}
            else if(I == 104){return "h";}
            else if(I == 105){return "i";}
            else if(I == 106){return "j";}
            else if(I == 107){return "k";}
            else if(I == 108){return "l";}
            else if(I == 109){return "m";}
            else if(I == 110){return "n";}
            else if(I == 111){return "o";}
            else if(I == 112){return "p";}
            else if(I == 113){return "q";}
            else if(I == 114){return "r";}
            else if(I == 115){return "s";}
            else if(I == 116){return "t";}
            else if(I == 117){return "u";}
            else if(I == 118){return "v";}
            else if(I == 119){return "w";}
            else if(I == 120){return "x";}
            else if(I == 121){return "y";}
            else if(I == 122){return "z";}
            else if(I == 123){return "{";}
            else if(I == 124){return "|";}
            else if(I == 125){return "}";}
            else if(I == 126){return "~";}
            return "";
        }

        public void CPP_CONN()
        {
            System.Diagnostics.Debug.WriteLine("CPP_CONN function invoked...");
            //! code taken from https://www.youtube.com/watch?v=g5yEWLJxNmI
            string SERVER_IP = "127.0.0.1";
            int PORT = 6001;
            TcpClient client = new TcpClient(SERVER_IP,PORT);
            string msg = "000";
            if(this.INIT_NET_CLIENT == true){msg = "001";}

            int byteCount = Encoding.ASCII.GetByteCount(msg + 1);
            byte[] sendData = new byte[byteCount];
            sendData = Encoding.ASCII.GetBytes(msg);
            NetworkStream stream = client.GetStream();
            stream.Write(sendData,0, sendData.Length);
            System.Diagnostics.Debug.WriteLine(msg +" send to server!");
            String response = "blub";
            byte[] recv = new byte[4096];
            while(!stream.DataAvailable){}if(stream.Read(recv, 0, 4096) == 0){ Application.Exit(); }
            response = Encoding.ASCII.GetString(recv);
            System.Diagnostics.Debug.WriteLine(message: response + " received from server!\n");
            
            if(this.INIT_NET_CLIENT == false)
            {
                System.Diagnostics.Debug.WriteLine("socket 1 opened");
                this.CPP1 = true;
                // C++->C#
                while(this.running)
                {
                    msg = this.processCPPResponse(response);
                    int ByteCount = Encoding.ASCII.GetByteCount(msg) + 1;
                    byte[] SendData = new byte[ByteCount];
                    SendData = Encoding.ASCII.GetBytes(msg);
                    stream.Write(SendData,0, sendData.Length);
                    System.Diagnostics.Debug.WriteLine(msg +" send to server!");
                    while (!stream.DataAvailable) { }
                    if (stream.Read(recv, 0, 4096) == 0) { Application.Exit(); }
                    response = Encoding.ASCII.GetString(recv);
                    System.Diagnostics.Debug.WriteLine(response +" received from server!");
                }
            }
            else
            {
                System.Diagnostics.Debug.WriteLine("socket 2 opened");
                this.CPP_INI_Loaded = true;
                // C#->C++
                while(this.running)
                {
                    msg = this.processCPPResponse2(response);
                    int ByteCount = Encoding.ASCII.GetByteCount(msg) + 1;
                    byte[] SendData = new byte[ByteCount];
                    SendData = Encoding.ASCII.GetBytes(msg);
                    stream.Write(SendData,0, sendData.Length);
                    System.Diagnostics.Debug.WriteLine(msg +" send to server!");
                    while (!stream.DataAvailable) { }
                    if (stream.Read(recv, 0, 4096) == 0) { Application.Exit(); }
                    response = Encoding.ASCII.GetString(recv);
                    System.Diagnostics.Debug.WriteLine(response +" received from server!");
                    this.CPPAwnser = response;
                }
            }
        }

        private string processCPPResponse(string resp)
        {
            //C++->C#
            System.Diagnostics.Debug.WriteLine("server: "+ resp);
            return "000";
        }
        private string processCPPResponse2(string resp)
        {
            //C#->C++
            System.Diagnostics.Debug.WriteLine("server: "+ resp);
            while(this.toCPP == ""){}
            string RETURN = this.toCPP;
            this.toCPP = "";
            return RETURN;
        }

        private void UILoader_DoWork(object sender, DoWorkEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("UILoader waiting...");
            while(this.CPP_INI_Loaded != true){}
            System.Diagnostics.Debug.WriteLine("UILoader loading UI...");

            //set background image
            this.toCPP = "ini,THEME,backgroundImage";
            string IMG = this.getCPPAwnser();
            this.MainPanel.BackgroundImage = Image.FromFile(IMG);
            System.Diagnostics.Debug.WriteLine("Set background Image to " + this.getCPPAwnser() + "");

            //hide console
            this.MainPanel.Show();
            this.Console.Hide();
        }
    }
}
