using System;
using System.IO.Ports;
using System.Text;
using System.Threading;

namespace VTools
{

    public partial class Scanner : IScanner
    {
        public string Result
        {
            get;
            set;
        }

        public int BaudRate
        {
            get
            {
                return this.serial.BaudRate;
            }
            set
            {
                this.serial.BaudRate = value;
            }
        }

        public string ComPort
        {
            get
            {
                return this.serial.PortName;
            }
            set
            {
                OpenPort = (false);
                this.serial.PortName = Strings.COM + value.Trim();
                OpenPort = (true);
            }
        }

        public int DataBits
        {
            get
            {
                return this.serial.DataBits;
            }
            set
            {
                this.serial.DataBits = value;
            }
        }

        public int DelayTimeFile
        {
            get;
            set;
        }

        public int DelayTimeMsg
        {
            get;
            set;
        }

        public Exception Exception
        {
            get;
            set;

        }
        public EventHandler FeedBack { get; set; }
        public EventHandler CallBack { get; set; }
        public bool IsOpen
        {
            get
            {
                bool opened = false;
                try
                {
                    opened = serial.IsOpen;
                }
                catch (Exception ex)
                {
                    this.Exception = ex;
                }
                return opened;
            }
        }

        public int MaxLength
        {
            get;
            set;
        }

        public string SendContent
        {
            get { return sendContent; }

            set
            {
                sendContent = value;
                if (!string.IsNullOrEmpty(value))
                {
                    send(sendContent, fileSending);
                }
            }
        }

        private void send(string text, bool isFileSending=false)
        {
            Exception = null;

            try
            {
                serial.Write(text);
                if (isFileSending)
                {
                    Thread.Sleep(DelayTimeFile);
                }
                else Thread.Sleep(DelayTimeMsg);
            }
            catch (Exception ex)
            {
                Exception = ex;
            }

            FeedBack?.Invoke(null, EventArgs.Empty);
        }

        public string Status
        {
            get
            {
                if (Exception != null)
                {
                    status = Strings.EXCEPTION + Exception.Message;
                }
                return status;
            }
            set
            {
                status = value;
            }
        }

        public void Flush()
        {
            Exception = null;
            try
            {
                serial.DiscardInBuffer();
                serial.DiscardOutBuffer();
                Status = Strings.FLUSHED;
            }
            catch (Exception ex)
            {
                Exception = ex;
            }

            FeedBack?.Invoke(null, EventArgs.Empty);
        }

        public void Listen(string com , int baudRate = 9800, int databits = 8, Parity p = Parity.None, StopBits s = StopBits.One, Handshake h = Handshake.None)
        {

            try
            {
                Exception = null;
                //    serial.PortName = com;
                serial.BaudRate = baudRate;
                serial.DataBits = databits;

                serial.Parity = p;
                serial.StopBits = s;
                serial.Handshake = h;
                serial.ReceivedBytesThreshold = 1;
                serial.RtsEnable = true;
                serial.DataReceived -= dataReceived;
                serial.DataReceived += dataReceived;
                serial.Encoding = Encoding.UTF8;

          

                this.ComPort = com;

                Status = Strings.WAITING;
            }
            catch (Exception ex)
            {
                Exception = ex;
            }

            FeedBack?.Invoke(null, EventArgs.Empty);
        }

        public bool OpenPort
        {

            set
            {
                Exception = null;
                try
                {
                    // if (this.serial.IsOpen) 
                    {
                        serial.Close();
                    }
                    Status = Strings.CONNECTION_CLOSED;
                    if (value)
                    {
                        serial.Open();
                        Status = Strings.CONNECTION_OPEN;
                    }
                }
                catch (Exception ex)
                {
                    Exception = ex;
                }

                FeedBack?.Invoke(null, EventArgs.Empty);
            }
        }

      

        public void SendFile(ref string filePath, ref string safeFileWithExtension)
        {
            try
            {
                Exception = null;

                if (!System.IO.File.Exists(filePath)) return;


                ///SEND OFILE
                fileSending = true;
                Status = "Preparing file header...";
                FeedBack?.Invoke(null, EventArgs.Empty);

                SendContent = Strings.OFILE + "\n";

              

                ///SEND NAME
                Status = "Sending file: " + safefilename;
                FeedBack?.Invoke(null, EventArgs.Empty);

                SendContent = Strings.ONAME + "\n";
                safefilename = safeFileWithExtension.Split('.')[0];
                SendContent = safefilename + "\n";
                SendContent = Strings.CNAME + "\n";

            

                ///SEND EXTENSION
                SendContent = Strings.OEXT + "\n";
                string extension = safeFileWithExtension.Split('.')[1];
                SendContent = extension + "\n";
                SendContent = Strings.CEXT + "\n";

                // this.status.Text = serial.Status; Application.DoEvents();

                string[] lines = System.IO.File.ReadAllLines(filePath);

                for (int i = 0; i < lines.Length; i++)
                {
                    // Application.DoEvents();
                    sendContentByPieces(MaxLength, lines[i] + "\n", i);
                    // this.status.Text = serial.Status;
                }

                ///SEND CFILE
                Status = "File " + safefilename + " sent";
                SendContent = Strings.CFILE + "\n";
                fileSending = false;

                FeedBack?.Invoke(null, EventArgs.Empty);

                // this.status.Text = serial.Status;
            }
            catch (Exception ex)
            {
                Exception = ex;
            }
        }

    
     

       
        public Scanner()
        {
            MaxLength = 8;
            DelayTimeFile = 500;
            DelayTimeMsg = 50;
            this.serial = new SerialPort();
        }
    }

    public partial class Scanner
    {

        protected static class Strings
        {
            public static string EXCEPTION = "Exception: ";
            public static string BAR = "\\";
            public static string CEXT = "</Ext>";
            public static string CFILE = "</File>";
            public static string CNAME = "</Name>";
            public static string COM = "COM";
            public static string CONNECTION_CLOSED = "Connection CLOSED";
            // private static string CONNECTION_FAILED = "Could not OPEN the connection";
            public static string CONNECTION_OPEN = "Connection OPENED";

            public static string DOT = ".";
            public static string EXPLORER = "explorer.exe ";
            public static string FLUSHED = "Flushed";
            public static string OEXT = "<Ext>";
            public static string OFILE = "<File>";
            public static string ONAME = "<Name>";
            public static string WAITING = "Waiting for Data";

        }


        private string status;

        private string buffer = string.Empty;

  
        private bool extensionMode = false;

        private string fileContent = string.Empty;

        private string fileExtension = string.Empty;

        private bool fileMode = false;

        private string filepath = string.Empty;

        private bool fileSending = false;

        private bool nameMode = false;

        private string safefilename = string.Empty;

        private string sendContent;


        private SerialPort serial = null;


        private void sendContentByPieces(int maxLenght, string content, int index)
        {
            while (content.Length > 0)
            {
                if (content.Length > maxLenght)
                {
                    SendContent = content.Substring(0, maxLenght);
                    content = content.Remove(0, maxLenght);
                }
                else
                {
                    SendContent = content;
                    content = string.Empty;
                }
            }

            Status = "Sending " + safefilename + " / Line " + index.ToString();
        }

   
    
        private void _checkForFile(string text)
        {
            if (text.Contains(Strings.OFILE))
            {
                fileMode = true;
                fileContent = string.Empty;
                filepath = string.Empty;
            }
            else if (fileMode)
            {
                if (text.Contains(Strings.CFILE))
                {
                    _writeFile();
                    fileMode = false;
                    buffer = string.Empty;
                    fileContent = string.Empty;
                    fileExtension = string.Empty;
                    filepath = string.Empty;
                }
                else
                {
                    if (text.Contains(Strings.ONAME))
                    {
                        nameMode = true;
                        filepath = string.Empty;
                    }
                    else if (text.Contains(Strings.CNAME))
                    {
                        nameMode = false;
                    }
                    else if (nameMode)
                    {
                        filepath = text;
                    }
                    else if (text.Contains(Strings.OEXT))
                    {
                        extensionMode = true;
                        fileExtension = string.Empty;
                    }
                    else if (text.Contains(Strings.CEXT))
                    {
                        extensionMode = false;
                    }
                    else if (extensionMode)
                    {
                        fileExtension = text;
                    }
                    else fileContent += text;
                }
            }
        }


        private void storeIntoBuffer(string texto)
        {
            //closing
            if (texto.Contains(Strings.CFILE))
            {
                buffer += texto;
                string[] lines = buffer.Split('\n');

                foreach (var item in lines)
                {
                    _checkForFile(item);
                }
            }
            //opening
            else if (texto.Contains(Strings.OFILE))
            {
                buffer = string.Empty;
                buffer += texto;
            }
            else buffer += texto;
        }

        private void dataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            Result = string.Empty;
            string texto = "something";

            Exception = null;

            try
            {
                while (!string.IsNullOrEmpty(texto))
                {
                    texto = serial.ReadExisting();
                    Result += texto;

                    storeIntoBuffer(texto);
                }
            }
            catch (Exception ex)
            {
                Exception = ex;
            }

            FeedBack?.Invoke(sender, EventArgs.Empty);

            CallBack?.Invoke(sender, EventArgs.Empty);
        }

        private void _writeFile()
        {
            filepath = Environment.GetFolderPath(Environment.SpecialFolder.InternetCache);
            filepath += Strings.BAR + filepath + Strings.DOT;
            filepath += Guid.NewGuid().ToString().Substring(0, 5);
            filepath += Strings.DOT + fileExtension;
            System.IO.File.WriteAllText(filepath, fileContent, Encoding.ASCII);
            System.Diagnostics.Process p = new System.Diagnostics.Process();
            p.StartInfo = new System.Diagnostics.ProcessStartInfo(Strings.EXPLORER, filepath);
            p.Start();
        }

        
    }
}