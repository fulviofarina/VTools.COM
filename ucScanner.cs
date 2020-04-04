using System;
using System.IO.Ports;
using System.Windows.Forms;

namespace VTools
{
    public partial class ucScanner : UserControl, IScanner
    {
     

        private IScanner scanner;

        public int BaudRate
        {
            get
            {
                return Convert.ToInt32(this.baudbox.Text.Trim());
            }

            set
            {
                this.baudbox.Text = value.ToString();
                this.scanner.BaudRate = value;
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
                this.scanner.ComPort = value.Trim();
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
                this.scanner.DataBits = value;
            }
        }

        public int DelayTimeFile
        {
            get { return Convert.ToInt32(delayTimeFileBox.Text); }
            set
            {
                delayTimeFileBox.Text = value.ToString();
                scanner.DelayTimeFile = value;
            }
        }

        public int DelayTimeMsg
        {
            get { return Convert.ToInt32(delayTimeMsgBox.Text); }
            set
            {
                delayTimeMsgBox.Text = value.ToString();
                scanner.DelayTimeMsg = value;
            }
        }

        public int MaxLength
        {
            get { return Convert.ToInt32(maxlengthBox.Text); }
            set
            {
                maxlengthBox.Text = value.ToString();
                scanner.MaxLength = value;
            }
        }

        public bool OpenPort
        {
            set
            {
                scanner.OpenPort = (value);
                setOpenCloseEnable();
            }
        }

        private void setOpenCloseEnable()
        {
            bool ok = IsOpen;

            this.open.Enabled = !ok;
            this.close.Enabled = ok;
        }

        public string Result
        {
            get { return scanner.Result; }
            set { scanner.Result = value; }
        }

        public string SendContent
        {
            get { return scanner.SendContent; }

            set
            {
                scanner.SendContent = value;
            }
        }

        public string Status
        {
            get {
               
                return this.status.Text; 
            }
            set { this.status.Text = value; }
        }

        public Exception Exception
        {
            get
            {
               return scanner.Exception;
            }
        }

        public void Flush()
        {
            scanner.Flush();

            // checkStatus(PROBLEMS, exception?.Message);
        }

        public void Listen(string com="" , int baud = 9600, int databits =8,  Parity p = Parity.None, StopBits s = StopBits.One, Handshake h = Handshake.None)
        {
            if (baud!=BaudRate)
            {
                BaudRate = baud;
            }
            if (databits!=DataBits)
            {
                DataBits = databits;
            }
            if (!string.IsNullOrEmpty(com))
            {
                ComPort = com;
            }
            scanner.Listen(ComPort, BaudRate, DataBits,p,s,h);
        }

        public void SendFile(ref string filePath, ref string safeFileWithExtension)
        {
            scanner.SendFile(ref filePath, ref safeFileWithExtension);
        }

        private void checkStatus(object sender, EventArgs e)
        {
            this.status.Text = scanner.Status;
         
            Application.DoEvents();
        }

        private void close_Click(object sender, EventArgs e)
        {
           
                this.OpenPort = !(sender.Equals(this.close));
          
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
                this.scanner.ComPort = ComPort;
                setOpenCloseEnable();
            }
            else if (sender.Equals(this.baudbox))
            {
                this.scanner.BaudRate = BaudRate;
            }
            else if (sender.Equals(this.dataBitsBox))
            {
                this.scanner.DataBits = DataBits;
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
            scanner = new Scanner();

            scanner.FeedBack = checkStatus;

            InitializeComponent();

          
           

            setOpenCloseEnable();
        }

        public bool IsOpen
        {
            get
            {
                return this.scanner.IsOpen;
            }
        }

        public EventHandler FeedBack
        {
            set
            {
                this.scanner.FeedBack = value;
            }
        }
        public EventHandler CallBack
        {
            set
            {
                this.scanner.CallBack = value;
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