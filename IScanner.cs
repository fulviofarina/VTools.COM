using System;
using System.IO.Ports;

namespace VTools
{
    public interface IScanner
    {
        int DataBits { get; set; }
        int BaudRate { get; set; }
         bool IsOpen
        {
            get;
        }
            Exception Exception { get; }
        bool OpenPort { set; }
        string Result { get; set; }
        string SendContent { get; set; }
        string ComPort { get; set; }
        int DelayTimeFile { get; set; }
        int MaxLength { get; set; }

        string Status { get; set; }
        int DelayTimeMsg { get; set; }

        void Listen(ref EventHandler cBack, string com, int baudRate, int databits, Parity p = Parity.None, StopBits s = StopBits.One, Handshake h = Handshake.None);
        EventHandler FeedBack
        {
            set;
        }
       void SendFile(ref string filepath, ref string safeFileWithExtension);
        void Flush();
   

    }
}