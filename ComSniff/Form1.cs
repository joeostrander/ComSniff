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

            serialPort1.BaudRate = 57600;
            serialPort1.Parity = Parity.None;
            serialPort1.Handshake = Handshake.RequestToSend; // ??
            serialPort1.DataBits = 8;
            serialPort1.StopBits = StopBits.One;

            serialPort2.BaudRate = 57600;
            serialPort2.Parity = Parity.None;
            serialPort2.Handshake = Handshake.RequestToSend; // ??
            serialPort2.DataBits = 8;
            serialPort2.StopBits = StopBits.One;

            timer1.Enabled = true;
        }


        private void LoadPortsList()
        {
            listPorts1.Clear();
            listPorts2.Clear();
            string strQuery = "Select * from Win32_PnPEntity Where Name LIKE '% (COM%)'";

            listPorts1.Add(new KeyValuePair<string, string>("", ""));
            listPorts2.Add(new KeyValuePair<string, string>("", ""));

            try
            {

                ManagementObjectSearcher searcher = new ManagementObjectSearcher(strQuery);
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
                Console.WriteLine(ex.Message);
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


                ThreadSafeDelegate(delegate { textBoxSniffed.AppendText(String.Format("A => B [ {0} ]", BitConverter.ToString(buffer)) + Environment.NewLine); });


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

     
    }
}
