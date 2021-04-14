using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;
using System.Management;
using System.Text.RegularExpressions;

namespace ComSniff
{
    public partial class Form1 : Form
    {

        private static List<KeyValuePair<string, string>> listPorts1 = new List<KeyValuePair<string, string>>();
        private static List<KeyValuePair<string, string>> listPorts2 = new List<KeyValuePair<string, string>>();
        private static bool boolConnected;

        private static SerialPort serialPort1 = new SerialPort();
        private static SerialPort serialPort2 = new SerialPort();


        public Form1()
        {
            InitializeComponent();
        }


        public void ThreadSafeDelegate(MethodInvoker method)
        {
            if (InvokeRequired)
                BeginInvoke(method);
            else
                method.Invoke();
        }

        private void buttonConnect_Click(object sender, EventArgs e)
        {
            if (boolConnected)
            {
                disconnect();
            }
            else
            {
                connect();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadPortsList();

            comboBoxComPort1.DataSource = listPorts1;
            comboBoxComPort1.ValueMember = "Key";
            comboBoxComPort1.DisplayMember = "Value";

            comboBoxComPort2.DataSource = listPorts2;
            comboBoxComPort2.ValueMember = "Key";
            comboBoxComPort2.DisplayMember = "Value";

            this.Text = Application.ProductName;

            // TODO:  remember last setting
            comboBoxBitsPerSecond.SelectedItem = "115200";
            comboBoxDataBits.SelectedItem = "8";
            comboBoxFlowControl.SelectedIndex = 0;
            comboBoxStopBits.SelectedIndex = 0;
            comboBoxParity.SelectedIndex = 0;

            timer1.Enabled = true;
        }


        private void LoadPortsList()
        {
            listPorts1.Clear();
            listPorts2.Clear();
            string str_query_pnp = "Select * from Win32_PnPEntity Where Name LIKE '% (COM%)'";

            listPorts1.Add(new KeyValuePair<string, string>("", ""));
            listPorts2.Add(new KeyValuePair<string, string>("", ""));

            try
            {

                ManagementObjectSearcher searcher = new ManagementObjectSearcher(str_query_pnp);
                ManagementObjectCollection collection = searcher.Get();

                foreach (ManagementObject item in collection)
                {
                    string fn = item.Properties["Name"].Value.ToString();
                    string strPattern = @"^(?<porttext>.*?)\((?<portname>COM[\d]+)\)$";
                    Match m = Regex.Match(fn, strPattern);

                    if (m.Success)
                    {
                        string portname = m.Groups["portname"].Value.ToString();
                        string porttext = m.Groups["porttext"].Value.ToString();
                        listPorts1.Add(new KeyValuePair<string, string>(portname, portname.PadRight(6, ' ') + porttext));
                        listPorts2.Add(new KeyValuePair<string, string>(portname, portname.PadRight(6, ' ') + porttext));
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Could not get serial port list!", "Serial Ports", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            // Also search Win32_SerialPort for any not found
            string str_query_serialport = "Select * from Win32_SerialPort";

            try
            {

                ManagementObjectSearcher searcher = new ManagementObjectSearcher(str_query_serialport);
                ManagementObjectCollection collection = searcher.Get();

                foreach (ManagementObject item in collection)
                {
                    string portname = item.Properties["DeviceID"].Value.ToString();
                    string porttext = item.Properties["Name"].Value.ToString();

                    KeyValuePair<string, string> kvp = new KeyValuePair<string, string>(portname, portname.PadRight(6, ' ') + porttext);

                    var pair = listPorts1.FirstOrDefault(x => x.Key == portname);
                    
                    if (pair.Key == null)
                    {
                        Console.WriteLine("Missing:  {0}", portname);
                        listPorts1.Add(kvp);
                        listPorts2.Add(kvp);
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Could not get serial port list!", "Serial Ports", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
        }


        private void disconnect()
        {
            boolConnected = false;
            if (serialPort1.IsOpen)
            {
                serialPort1.Close();
            }

            if (serialPort2.IsOpen)
            {
                serialPort2.Close();
            }


        }

        private void connect()
        {
            string strPortName1 = comboBoxComPort1.SelectedValue.ToString();
            string strPortName2 = comboBoxComPort2.SelectedValue.ToString();
            if (string.IsNullOrEmpty(strPortName1) || string.IsNullOrEmpty(strPortName2))
            {
                return;
            }
            //serialPort1 = new SerialPort(strPortName, 9600, Parity.None, 8, StopBits.One);
            serialPort1.PortName = strPortName1;
            serialPort2.PortName = strPortName2;

            serialPort1.BaudRate = Int32.Parse(comboBoxBitsPerSecond.SelectedItem.ToString());

            switch (comboBoxParity.SelectedItem.ToString())
            {
                case "Even":
                    serialPort1.Parity = Parity.Even;
                    break;
                case "Odd":
                    serialPort1.Parity = Parity.Odd;
                    break;
                case "None":
                    serialPort1.Parity = Parity.None;
                    break;
                case "Mark":
                    serialPort1.Parity = Parity.Mark;
                    break;
                case "Space":
                    serialPort1.Parity = Parity.Space;
                    break;
            }


            serialPort1.DataBits = Int32.Parse(comboBoxDataBits.SelectedItem.ToString());
            serialPort1.StopBits = (StopBits)Int32.Parse(comboBoxStopBits.SelectedItem.ToString());

            switch (comboBoxFlowControl.SelectedItem.ToString())
            {
                case "Xon / Xoff":
                    serialPort1.Handshake = Handshake.XOnXOff;
                    break;
                case "Hardware":
                    serialPort1.Handshake = Handshake.RequestToSend;
                    break;
                case "Both":
                    serialPort1.Handshake = Handshake.RequestToSendXOnXOff;
                    break;
                case "None":
                    serialPort1.Handshake = Handshake.None;
                    break;
            }


            serialPort2.BaudRate = serialPort1.BaudRate;
            serialPort2.Parity = serialPort1.Parity;
            serialPort2.DataBits = serialPort1.DataBits;
            serialPort2.StopBits = serialPort1.StopBits;
            serialPort2.Handshake = serialPort1.Handshake;

            try
            {
                serialPort1.Open();
                serialPort2.Open();
                boolConnected = true;

                serialPort1.DataReceived += new SerialDataReceivedEventHandler(serialPort1_DataReceived);
                serialPort2.DataReceived += new SerialDataReceivedEventHandler(serialPort2_DataReceived);

            }
            catch (Exception ex)
            {
                //Console.WriteLine(ex.Message);
                boolConnected = false;

                if (serialPort1.IsOpen)
                {
                    serialPort1.Close();
                }

                if (serialPort2.IsOpen)
                {
                    serialPort2.Close();
                }
                MessageBox.Show(ex.Message, "Connect Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

        }


        private void timer1_Tick(object sender, EventArgs e)
        {

            
            try
            {
                if (!string.IsNullOrEmpty(serialPort1.PortName) && !string.IsNullOrEmpty(serialPort2.PortName))
                {
                    if (serialPort1.IsOpen && serialPort2.IsOpen)
                    {
                        boolConnected = true;
                        comboBoxComPort1.Enabled = false;
                        comboBoxComPort2.Enabled = false;
                    }
                    else
                    {
                        boolConnected = false;
                        comboBoxComPort1.Enabled = true;
                        comboBoxComPort2.Enabled = true;
                    }
                }
            }
            catch (Exception ex)
            {
                boolConnected = false;
                comboBoxComPort1.Enabled = true;
                comboBoxComPort2.Enabled = true;
            }




            if (boolConnected)
            {
                buttonConnect.Text = "&Disconnect";
                toolStripStatusLabel1.Text = "Connected to ports:  " + serialPort1.PortName + "," + serialPort2.PortName;
            
            }
            else
            {
                buttonConnect.Text = "&Connect";
                toolStripStatusLabel1.Text = "Disconnected";
            }

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            boolConnected = false;

        }



        private void serialPort1_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            
            try
            {

                SerialPort sp = (SerialPort)sender;
                int byteLength = sp.BytesToRead;
                byte[] buffer = new byte[byteLength];
                sp.Read(buffer, 0, byteLength);

                string recvHex = BitConverter.ToString(buffer);
                Console.WriteLine("{0}\tCOM A SENT:  {1}", DateTime.Now, recvHex + " ");


                StringBuilder sb = new StringBuilder(byteLength * 3);
                foreach (byte b in buffer)
                {
                    if (b == 0x00)
                    {
                        sb.Append("00 ");
                    }
                    else
                    {
                        sb.Append(b.ToString("X2"));
                        sb.Append(" ");
                    }
                    
                }
                if (byteLength == 0)
                {
                    sb.Append("???");
                }
                    
                //ThreadSafeDelegate(delegate { textBoxSniffed.AppendText(String.Format("A => B [ {0} ]", BitConverter.ToString(buffer)) + Environment.NewLine); });
                ThreadSafeDelegate(delegate { textBoxSniffed.AppendText(String.Format("A => B [ {0} ]", sb.ToString()) + Environment.NewLine); });


                //redirect to COM B
                serialPort2.Write(buffer, 0, byteLength);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            

        }

        private void serialPort2_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {

                SerialPort sp = (SerialPort)sender;
                int byteLength = sp.BytesToRead;
                byte[] buffer = new byte[byteLength];

                sp.Read(buffer, 0, byteLength);

                string recvHex = BitConverter.ToString(buffer);
                Console.WriteLine("{0}\tCOM B SENT:  {1}", DateTime.Now, recvHex + " ");

                ThreadSafeDelegate(delegate { textBoxSniffed.AppendText(String.Format("B => A [ {0} ]", BitConverter.ToString(buffer)) + Environment.NewLine); });

                //redirect to port 1
                serialPort1.Write(buffer, 0, byteLength);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }


        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox1 about = new AboutBox1();
            about.ShowDialog();

        }
    }
}
