using System;
using System.Windows.Forms;

namespace VTools
{
    public partial class ucScanner : UserControl
    {
        private System.IO.Ports.SerialPort serial = null;

        public ucScanner()
        {
            InitializeComponent();

            this.open.Enabled = true;
            this.close.Enabled = false;
        }

        private EventHandler callBack = null;

        public void MakeScanner(ref EventHandler cBack)
        {
            string com = "COM" + this.comBox.Text;
            int Baudrate = Convert.ToInt32(this.baudbox.Text);
            int bits = Convert.ToInt32(this.dataBitsBox.Text);
            try
            {
                serial = new System.IO.Ports.SerialPort(com, Baudrate, System.IO.Ports.Parity.None, bits, System.IO.Ports.StopBits.One);
                serial.Handshake = System.IO.Ports.Handshake.None;
                serial.ReceivedBytesThreshold = 1;
                serial.RtsEnable = true;
                serial.DataReceived += serial_DataReceived;
                this.callBack = cBack;
            }
            catch (Exception ex)
            {
                this.status.Text = "Problems: " + ex.Message;
            }
        }

        private string result = string.Empty;

        private string stat = string.Empty;

        public string Status
        {
            get { return stat; }
            set { stat = value; }
        }

        public string Result
        {
            get { return result; }
            set { result = value; }
        }

        private void serial_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            result = string.Empty;
            stat = "algo";

            try
            {
                //  this.status.Text = "Data Received";

                while (!string.IsNullOrEmpty(stat))
                {
                    stat = serial.ReadExisting();
                    result += stat;
                }

                serial.DiscardInBuffer();
                serial.DiscardOutBuffer();

                callBack.Invoke(sender, new EventArgs());
            }
            catch (Exception ex)
            {
                stat = "Problems: " + ex.Message;
                //    this.statuslbl.Text = ex.Message + "\t\t" + ex.StackTrace;
            }
        }

        /* COPIA PORSIAAAAAAA
         *
         *  private void serial_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            result = string.Empty;
            stat = string.Empty;

            try
            {
              //  this.status.Text = "Data Received";

                result = serial.ReadExisting();

                serial.DiscardInBuffer();
                serial.DiscardOutBuffer();

                callBack.Invoke(sender, new EventArgs());
            }
            catch (Exception ex)
            {
                stat = "Problems: " + ex.Message;
                //    this.statuslbl.Text = ex.Message + "\t\t" + ex.StackTrace;
            }
        }
         * */

        //   bool openPort;

        public bool OpenPort
        {
            set
            {
                if (true == value)
                {
                    open_Click(null, EventArgs.Empty);
                }
            }
        }

        //    bool closePort;

        public bool ClosePort
        {
            set
            {
                if (true == value)
                {
                    close_Click(null, EventArgs.Empty);
                }
            }
        }

        private void open_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.serial.IsOpen) serial.Close();
                serial.Open();
                this.open.Enabled = !serial.IsOpen;
                this.close.Enabled = serial.IsOpen;

                if (this.serial.IsOpen) this.status.Text = "Waiting for Scan";
                else this.status.Text = "Could not OPEN the connection";
            }
            catch (Exception ex)
            {
                this.status.Text = "Problems: " + ex.Message;
            }
        }

        private void close_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.serial.IsOpen)
                {
                    serial.Close();
                }
                this.open.Enabled = !this.serial.IsOpen;
                this.close.Enabled = serial.IsOpen;

                if (this.serial.IsOpen) this.status.Text = "Connection still opened";
                else this.status.Text = "Connection CLOSED";
            }
            catch (Exception ex)
            {
                this.status.Text = "Problems: " + ex.Message;
            }
        }

        private void Box_TextChanged(object sender, EventArgs e)
        {
            string com = ((ToolStripTextBox)sender).Text;
            if (string.IsNullOrWhiteSpace(com)) return;
            if (string.IsNullOrEmpty(com)) return;

            close_Click(sender, e);

            try
            {
                if (sender.Equals(this.comBox))
                {
                    com = "COM" + com;
                    this.serial.PortName = com;
                }
                else if (sender.Equals(this.baudbox))
                {
                    int Baudrate = Convert.ToInt32(com);
                    this.serial.BaudRate = Baudrate;
                }
                else if (sender.Equals(this.dataBitsBox))
                {
                    int bits = Convert.ToInt32(com);
                    this.serial.DataBits = bits;
                }
            }
            catch (Exception ex)
            {
                this.status.Text = "Problems: " + ex.Message;
            }

            open_Click(sender, e);
        }
    }
}