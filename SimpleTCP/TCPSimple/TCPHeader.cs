using System;
using System.Net;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.ComponentModel;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace TCPProgram
{
    public class TCPHeader
    {
        byte[] SourcePort;
        byte[] DestinationPort;
        byte[] SequenceNumber;
        byte[] AcknowledgmentNumber;
        byte[] DataOffset;
        byte[] Reserved;
        byte[] Flags;
        byte[] Window;
        byte[] CheckSum;
        byte[] UrgentPointer;
        byte[] OptionsAndPadding;

        public byte[] TCPHeaderConstruct(IPAddress sourceport, IPAddress destinationport, int sequencenumber, int acknowledgmentnumber, int dataoffset, byte[] reserved, byte[] flags, int window)
        {
            SourcePort = getIPByte(sourceport);//16 bits
            Array.Resize(ref SourcePort, 16);
            DestinationPort = getIPByte(destinationport); ;//16 bits
            Array.Resize(ref DestinationPort, 16);
            SequenceNumber = BitConverter.GetBytes(sequencenumber);//32 bits
            Array.Resize(ref SequenceNumber, 32);
            AcknowledgmentNumber = BitConverter.GetBytes(acknowledgmentnumber);//32 bits
            Array.Resize(ref AcknowledgmentNumber, 32);
            DataOffset = BitConverter.GetBytes(dataoffset);//4 bits
            Reserved = reserved;//3 bits
            Flags = flags;//9 bits
            Window = BitConverter.GetBytes(window);//16 bits
            Array.Resize(ref Window, 16);

            checkAll();

            List<byte[]> ListTheBits = new List<byte[]>();
            ListTheBits.Add(SourcePort);
            ListTheBits.Add(DestinationPort);
            ListTheBits.Add(SequenceNumber);
            ListTheBits.Add(AcknowledgmentNumber);
            ListTheBits.Add(DataOffset);
            ListTheBits.Add(Reserved);
            ListTheBits.Add(Flags);
            ListTheBits.Add(Window);
            
            byte[] endbytearray = concatByte(ListTheBits);
            Console.WriteLine("Length of header byte list          " + endbytearray.Length);
            

            int checksum = checkSum(endbytearray, 0, getLength(ListTheBits));//the sum of the tcp header info
            bool urgentpointer = checkUrgent(flags);//if the urgent pointer flag is true
            int optionsandpadding = checkOptionsPadding();//if the header needs padding, add padding

            CheckSum = BitConverter.GetBytes(checksum);//16 bits
            Array.Resize(ref CheckSum, 16);
            UrgentPointer = BitConverter.GetBytes(urgentpointer);//16 bits
            Array.Resize(ref UrgentPointer, 16);
            OptionsAndPadding = BitConverter.GetBytes(optionsandpadding);//0-40 bit
            Array.Resize(ref OptionsAndPadding, 32);

            ListTheBits.Add(CheckSum);
            ListTheBits.Add(UrgentPointer);
            ListTheBits.Add(OptionsAndPadding);

            byte[] newendbytearray = concatByte(ListTheBits);

            //Console.WriteLine("Length of end byte list             " + newendbytearray.Length);
            return newendbytearray;
        }
        
        public int getLength(List<byte[]> bytelist)
        {
            int length = 0;
            foreach (byte[] array in bytelist)
            {
                length++;   
            }
            return length;
        }

        public void checkAll()
        {
            int spsize = checkSize(SourcePort);
            Console.WriteLine("Length of byte SourcePort           " + spsize);
            int dpsize = checkSize(DestinationPort);
            Console.WriteLine("Length of byte DestinationPort      " + dpsize);
            int snsize = checkSize(SequenceNumber);
            Console.WriteLine("Length of byte SequenceNumber       " + snsize);
            int ansize = checkSize(AcknowledgmentNumber);
            Console.WriteLine("Length of byte AcknowledgmentNumber " + ansize);
            int dosize = checkSize(DataOffset);
            Console.WriteLine("Length of byte DataOffset           " + dosize);
            int rsize = checkSize(Reserved);
            Console.WriteLine("Length of byte Reserved             " + rsize);
            int fsize = checkSize(Flags);
            Console.WriteLine("Length of byte Flags                " + fsize);
            int wsize = checkSize(Window);
            Console.WriteLine("Length of byte Window               " + wsize);
        }

        public ushort checkSum(byte[] header, int start, int length)
        {
            ushort word16;
            long sum = 0;
            for (int i = start; i < (length + start); i += 2)
            {
                word16 = (ushort)(((header[i] << 8) & 0xFF00) + (header[i + 1] & 0xFF));
                sum += (long)word16;
            }

            while ((sum >> 16) != 0)
            {
                sum = (sum & 0xFFFF) + (sum >> 16);
            }

            sum = ~sum;
            Console.WriteLine("Checksum = " + (ushort)sum);
            return (ushort)sum;
        }

        public bool checkUrgent(byte[] allflags)
        {
            bool urgent =  BitConverter.ToBoolean(allflags, 3);
            Console.WriteLine("Boolean if this is urgent or not " + urgent);
            return urgent;
        }

        public int checkOptionsPadding()
        {
            return 1;
        }

        public int checkSize(byte[] item)
        {
            if (item == null)
            {
                Console.WriteLine("This is null");
                return 0;
            }
            else
            {
                return item.Length;
            }
            
        }

        public byte[] getIPByte(IPAddress ipaddress)
        {
            Byte[] addressbytes = ipaddress.GetAddressBytes();
            return addressbytes;
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
            //Console.WriteLine("Binary Console.WriteLine " + Encoding.Default.GetString(endbytelist));
            return endbytelist;
        }

        byte ConvertToByte(BitArray bits)
        {
            byte[] bytes = new byte[1];
            bits.CopyTo(bytes, 0);
            Console.WriteLine("Bytes " + bytes[0]);
            return bytes[0];
        }
        
        public int nullConverter(int? nullitem)
        {
            if (nullitem == null)
            {
                return 0;
            }
            else
            {
                object nullobject = nullitem;
                int notnullitem = (int)nullobject;
                return notnullitem;
            }
        }
    }
}


//http://ssfnet.org/Exchange/tcp/tcpTutorialNotes.html#TH tcp tuturial
//http://www.networksorcery.com/enp/protocol/tcp.htm#URG more tcp tuturial

#region lol, not used, but might use
/*public object bitLength(BitArray bitlist)
{
    long size = 0;
    using (Stream stream = new MemoryStream())
    {
        BinaryFormatter formatter = new BinaryFormatter();
        formatter.Serialize(stream, bitlist);
        size = stream.Length;
        Console.WriteLine(size);
    }
    return bitlist;
}

public object returnList(object bitlist)
{
    long size = 0;
    using (Stream stream = new MemoryStream())
    {
        BinaryFormatter formatter = new BinaryFormatter();
        formatter.Serialize(stream, bitlist);
        size = stream.Length;
        Console.WriteLine(size);
    }
    return bitlist;
}

public void testerlength()
{
    long size = 0;
    int bitlist = 1;
    using (Stream stream = new MemoryStream())
    {
        BinaryFormatter formatter = new BinaryFormatter();
        formatter.Serialize(stream, bitlist);
        size = stream.Length;
        Console.WriteLine(size);
    }
}*/
#endregion