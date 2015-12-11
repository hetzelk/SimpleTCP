using System;
using System.Net;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCPProgram
{
    public class TCPInfo
    {
        public IPAddress getSourceIP()
        {
            return IPAddress.Parse("12.127.92.98");
        }

        public IPAddress getDestinationIP()
        {
            return IPAddress.Parse("12.127.92.98");
        }

        public int getSequenceNumber()
        {
            int seq = 1;
            return seq;
        }

        public int getAcknowledgmentNumber()
        {
            int seq = 1;
            return seq;
        }

        public int getDataOffset()
        {
            int seq = 1;
            return seq;
        }

        public int getReserved()
        {
            int seq = 1;
            return seq;
        }

        public byte[] getFlags()
        {
            
            byte[] NS = BitConverter.GetBytes(false);
            byte[] CWR = BitConverter.GetBytes(false);
            byte[] ECE = BitConverter.GetBytes(false);
            byte[] URG = BitConverter.GetBytes(true);
            byte[] ACK = BitConverter.GetBytes(false);
            byte[] PSH = BitConverter.GetBytes(false);
            byte[] RST = BitConverter.GetBytes(false);
            byte[] SYN = BitConverter.GetBytes(false);
            byte[] FIN = BitConverter.GetBytes(false);

            return seq;
        }

        public int getWindow()
        {
            int seq = 1;
            return seq;
        }
    }
}


NS
CWR
ECE
SYN
URG
ACK
PSH
RST
SYN
FIN