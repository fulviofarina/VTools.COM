using System;
using System.IO.Ports;
using System.Text;
using System.Threading;

namespace VTools
{
    public class Scanner: IScanner
    {
        public string Result
        {
            get;
            set;
        }
        private static string BAR = "\\";
        private static string CEXT = "</Ext>";
        private static string CFILE = "</File>";
        private static string CNAME = "</Name>";
        private static string COM = "COM";
        private static string CONNECTION_CLOSED = "Connection CLOSED";
        // private static string CONNECTION_FAILED = "Could not OPEN the connection";
        private static string CONNECTION_OPEN = "Connection OPENED";

        private static string DOT = ".";
        private static string EXPLORER = "explorer.exe ";
        private static string FLUSHED = "Flushed";
        private static string OEXT = "<Ext>";
        private static string OFILE = "<File>";
        private static string ONAME = "<Name>";
        private static string WAITING = "Waiting for Data";
        private string buffer = string.Empty;

        private EventHandler callBack = null;

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
                OpenPort =(false);
                this.serial.PortName = COM + value.Trim();
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

        public bool IsOpen
        {
            get
            {
                return serial.IsOpen;
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
                sendTxt(sendContent, fileSending);
            }
        }

        public string Status { get; set; }

        public void Flush()
        {
            Exception = null;
            try
            {
                serial.DiscardInBuffer();
                serial.DiscardOutBuffer();
                Status = FLUSHED;
            }
            catch (Exception ex)
            {
                Exception = ex;
            }

            FeedBack?.Invoke(null, EventArgs.Empty);
        }

        public void Listen(ref EventHandler cBack, string com, int baudRate, int databits, Parity p = Parity.None, StopBits s = StopBits.One, Handshake h = Handshake.None)
        {
            try
            {
                Exception = null;
                serial.PortName = com;
                serial.BaudRate = baudRate;
                serial.DataBits = databits;

                serial.Parity = p;
                serial.StopBits = s;
                serial.Handshake = h;
                serial.ReceivedBytesThreshold = 1;
                serial.RtsEnable = true;
                serial.DataReceived += serial_DataReceived;
                serial.Encoding = Encoding.UTF8;

                this.callBack = cBack;

                this.ComPort = com;

                Status = WAITING;
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
                    if (this.serial.IsOpen) serial.Close();
                    Status = CONNECTION_CLOSED;
                    if (value)
                    {
                        serial.Open();
                        Status = CONNECTION_OPEN;
                    }
                }
                catch (Exception ex)
                {
                    Exception = ex;
                }

                FeedBack?.Invoke(null, EventArgs.Empty);
            }
        }

        public void SendContentByPieces(int maxLenght, string content, int index)
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

        public void SendFile(ref string filePath, ref string safeFileWithExtension)
        {
            try
            {
                Exception = null;

                if (!System.IO.File.Exists(filePath)) return;

                sendOFILE();

                // this.status.Text = serial.Status; Application.DoEvents();

                string safefilename = sendNAME(ref safeFileWithExtension);
                // Application.DoEvents();

                sendEXT(ref safeFileWithExtension);

                // this.status.Text = serial.Status; Application.DoEvents();

                string[] lines = System.IO.File.ReadAllLines(filePath);

                for (int i = 0; i < lines.Length; i++)
                {
                    // Application.DoEvents();
                    SendContentByPieces(MaxLength, lines[i] + "\n", i);
                    // this.status.Text = serial.Status;
                }

                sendCFILE();

                // this.status.Text = serial.Status;
            }
            catch (Exception ex)
            {
                Exception = ex;
            }
        }

        private void sendTxt(string text, bool isFileSending)
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
        private void checkForFile(string text)
        {
            if (text.Contains(OFILE))
            {
                fileMode = true;
                fileContent = string.Empty;
                filepath = string.Empty;
            }
            else if (fileMode)
            {
                if (text.Contains(CFILE))
                {
                    writeFile();
                    fileMode = false;
                    buffer = string.Empty;
                    fileContent = string.Empty;
                    fileExtension = string.Empty;
                    filepath = string.Empty;
                }
                else
                {
                    if (text.Contains(ONAME))
                    {
                        nameMode = true;
                        filepath = string.Empty;
                    }
                    else if (text.Contains(CNAME))
                    {
                        nameMode = false;
                    }
                    else if (nameMode)
                    {
                        filepath = text;
                    }
                    else if (text.Contains(OEXT))
                    {
                        extensionMode = true;
                        fileExtension = string.Empty;
                    }
                    else if (text.Contains(CEXT))
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

        private void sendCFILE()
        {
            Status = "File " + safefilename + " sent";
            SendContent = CFILE + "\n";
            fileSending = false;
        }

        private string sendEXT(ref string safeFileWithExtension)
        {
            SendContent = OEXT + "\n";
            string extension = safeFileWithExtension.Split('.')[1];
            SendContent = extension + "\n";
            SendContent = CEXT + "\n";
            return extension;
        }

        private string sendNAME(ref string safeFileWithExtension)
        {
            Status = "Sending file: " + safefilename;

            SendContent = ONAME + "\n";
            safefilename = safeFileWithExtension.Split('.')[0];
            SendContent = safefilename + "\n";
            SendContent = CNAME + "\n";

            return safefilename;
        }

        private void sendOFILE()
        {
            fileSending = true;
            Status = "Preparing file header...";

            SendContent = OFILE + "\n";
        }

        private void sendToBuffer(string texto)
        {
            if (texto.Contains(CFILE))
            {
                buffer += texto;
                string[] lines = buffer.Split('\n');

                foreach (var item in lines)
                {
                    checkForFile(item);
                }
            }
            else if (texto.Contains(OFILE))
            {
                buffer = string.Empty;
                buffer += texto;
            }
            else buffer += texto;
        }

        private void serial_DataReceived(object sender, SerialDataReceivedEventArgs e)
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

                    sendToBuffer(texto);
                }
            }
            catch (Exception ex)
            {
                Exception = ex;
            }

            FeedBack?.Invoke(sender, EventArgs.Empty);

            callBack?.Invoke(sender, EventArgs.Empty);
        }

        private void writeFile()
        {
            filepath = Environment.GetFolderPath(Environment.SpecialFolder.InternetCache);
            filepath += BAR + filepath + DOT;
            filepath += Guid.NewGuid().ToString().Substring(0, 5);
            filepath += DOT + fileExtension;
            System.IO.File.WriteAllText(filepath, fileContent, Encoding.ASCII);
            System.Diagnostics.Process p = new System.Diagnostics.Process();
            p.StartInfo = new System.Diagnostics.ProcessStartInfo(EXPLORER, filepath);
            p.Start();
        }

        public Scanner()
        {
            MaxLength = 8;
            DelayTimeFile = 500;
            DelayTimeMsg = 50;
            this.serial = new SerialPort();
        }
    }
}