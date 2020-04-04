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

        void Listen( string com="", int baudRate=9800, int databits=8, Parity p = Parity.None, StopBits s = StopBits.One, Handshake h = Handshake.None);
        EventHandler FeedBack
        {
            set;
        }
        EventHandler CallBack
        {
            set;
        }
        void SendFile(ref string filepath, ref string safeFileWithExtension);
        void Flush();
   

    }
}