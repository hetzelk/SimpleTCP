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
            
            byte[] NS = BitConverter.GetBytes(false); //real life would have to all get these values
            byte[] CWR = BitConverter.GetBytes(false);
            byte[] ECE = BitConverter.GetBytes(false);
            byte[] URG = BitConverter.GetBytes(true);
            byte[] ACK = BitConverter.GetBytes(false);
            byte[] PSH = BitConverter.GetBytes(false);
            byte[] RST = BitConverter.GetBytes(false);
            byte[] SYN = BitConverter.GetBytes(false);
            byte[] FIN = BitConverter.GetBytes(false);

            List<byte[]> ListTheFlags = new List<byte[]>();
            ListTheFlags.Add(NS);
            ListTheFlags.Add(CWR);
            ListTheFlags.Add(ECE);
            ListTheFlags.Add(URG);
            ListTheFlags.Add(ACK);
            ListTheFlags.Add(PSH);
            ListTheFlags.Add(RST);
            ListTheFlags.Add(SYN);
            ListTheFlags.Add(FIN);

            byte[] endbytearray = concatByte(ListTheFlags);

            return endbytearray;
        }

        public byte[] concatByte(List<byte[]> bytelist)
        {
            byte[] endbytelist = new byte[bytelist.Sum(a => a.Length)];
            int offset = 0;
            foreach (byte[] array in bytelist)
            {
                System.Buffer.BlockCopy(array, 0, endbytelist, offset, array.Length);
                offset += array.Length;
            }
            Console.WriteLine(Encoding.Default.GetString(endbytelist));
            return endbytelist;
        }

        public int getWindow()
        {
            Random rnd = new Random();
            int randomspeed = rnd.Next(1, 100);
            Console.WriteLine("This is the 'window speed' (not real, just random) of the reciever " + randomspeed);
            int windowrecievespeed = randomspeed; //32 bit int
            return windowrecievespeed;
        }
    }
}