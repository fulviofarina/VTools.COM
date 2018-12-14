using System;
using System.IO.Ports;
using System.Windows.Forms;

namespace VTools
{
    public partial class ucScanner : UserControl, IScanner
    {
        private static string PROBLEMS = "Problems: ";

        private IScanner serial;

        public int BaudRate
        {
            get
            {
                return Convert.ToInt32(this.baudbox.Text);
            }

            set
            {
                this.baudbox.Text = value.ToString();
                this.serial.BaudRate = value;
            }
        }

        public string ComPort
        {
            get
            {
                return (this.comBox.Text.Trim());
            }

            set
            {
                this.comBox.Text = value.Trim();
                this.serial.ComPort = value.Trim();
            }
        }

        public int DataBits
        {
            get
            {
                return Convert.ToInt32(this.dataBitsBox.Text);
            }

            set
            {
                this.dataBitsBox.Text = value.ToString();
                this.serial.DataBits = value;
            }
        }

        public int DelayTimeFile
        {
            get { return Convert.ToInt32(delayTimeFileBox.Text); }
            set
            {
                delayTimeFileBox.Text = value.ToString();
                serial.DelayTimeFile = value;
            }
        }

        public int DelayTimeMsg
        {
            get { return Convert.ToInt32(delayTimeMsgBox.Text); }
            set
            {
                delayTimeMsgBox.Text = value.ToString();
                serial.DelayTimeMsg = value;
            }
        }

        public int MaxLength
        {
            get { return Convert.ToInt32(maxlengthBox.Text); }
            set
            {
                maxlengthBox.Text = value.ToString();
                serial.MaxLength = value;
            }
        }

        public bool OpenPort
        {
            set
            {
                serial.OpenPort=(value);

                this.open.Enabled = !this.serial.IsOpen;
                this.close.Enabled = serial.IsOpen;
            }
        }

        public string Result
        {
            get { return serial.Result; }
            set { serial.Result = value; }
        }

        public string SendContent
        {
            get { return serial.SendContent; }

            set
            {
                serial.SendContent = value;
            }
        }

        public string Status
        {
            get { return this.status.Text; }
            set { this.status.Text = value; }
        }

        public Exception Exception
        {
            get
            {
               return serial.Exception;
            }
        }

        public void Flush()
        {
            serial.Flush();

            // checkStatus(PROBLEMS, exception?.Message);
        }

        public void Listen(ref EventHandler cBack, string com = "", int baud = 9800, int databits =8,  Parity p = Parity.None, StopBits s = StopBits.One, Handshake h = Handshake.None)
        {
            serial.Listen(ref cBack, ComPort, BaudRate, DataBits);
        }

        public void SendFile(ref string filePath, ref string safeFileWithExtension)
        {
            serial.SendFile(ref filePath, ref safeFileWithExtension);
        }

        private void checkStatus(object sender, EventArgs e)
        {
            this.status.Text = serial.Status;
            if (serial.Exception != null)
            {
                this.status.Text = PROBLEMS + serial.Exception.Message;
            }
            Application.DoEvents();
        }

        private void close_Click(object sender, EventArgs e)
        {
            if (sender.Equals(this.close))
            {
                this.OpenPort = false;
            }
            else
            {
                this.OpenPort = true;
            }
        }

        private void flushBtn_Click(object sender, EventArgs e)
        {
            Flush();
        }

        private void openFileDialog_FileOk()
        {
            Application.DoEvents();

            string[] safefilenames = openFileDialog1.SafeFileNames;
            string[] filenames = openFileDialog1.FileNames;

            for (int i = 0; i < filenames.Length; i++)
            {
                Application.DoEvents();
                string safefilenamewithExtension = safefilenames[i];
                string filepath = filenames[i];

                SendFile(ref filepath, ref safefilenamewithExtension);
            }
        }

        private void parameterBoxTextChanged(object sender, EventArgs e)
        {
            string text = ((ToolStripTextBox)sender).Text;

            if (string.IsNullOrEmpty(text)) return;

            if (sender.Equals(this.comBox))
            {
                this.serial.ComPort = ComPort;
            }
            else if (sender.Equals(this.baudbox))
            {
                this.serial.BaudRate = BaudRate;
            }
            else if (sender.Equals(this.dataBitsBox))
            {
                this.serial.DataBits = DataBits;
            }
        }

        private void sendFiles_Click(object sender, EventArgs e)
        {
            DialogResult rs = openFileDialog1.ShowDialog();
            if (rs != DialogResult.OK)
            {
                this.status.Text = "Nothing selected";
                return;
            }
            openFileDialog_FileOk();
        }

        public ucScanner()
        {
            InitializeComponent();

            this.open.Enabled = true;
            this.close.Enabled = false;
            serial = new Scanner();

            serial.FeedBack = checkStatus;
        }

        public bool IsOpen
        {
            get
            {
                return this.serial.IsOpen;
            }
        }

        public EventHandler FeedBack
        {
            set
            {
                this.serial.FeedBack = value;
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
     // this.status.Text = "Data Received";

       result = serial.ReadExisting();

       serial.DiscardInBuffer();
       serial.DiscardOutBuffer();

       callBack.Invoke(sender, new EventArgs());
   }
   catch (Exception ex)
   {
       stat = "Problems: " + ex.Message;
       // this.statuslbl.Text = ex.Message + "\t\t" + ex.StackTrace;
   }
}
* */
    }
}