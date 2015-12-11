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
        byte[] Checksum;
        byte[] UrgentPointer;
        byte[] OptionsAndPadding;

        public byte[] TCPHeaderConstruct(IPAddress sourceport, IPAddress destinationport, int sequencenumber, int acknowledgmentnumber, int dataoffset, int reserved, int flags, int window)
        {
            SourcePort = getIPByte(sourceport);//16 bits
            DestinationPort = getIPByte(destinationport); ;//16 bits
            SequenceNumber = BitConverter.GetBytes(sequencenumber);//32 bits
            AcknowledgmentNumber = BitConverter.GetBytes(acknowledgmentnumber);//32 bits
            DataOffset = BitConverter.GetBytes(dataoffset);//4 bits
            Reserved = BitConverter.GetBytes(reserved);//3 bits
            Flags = BitConverter.GetBytes(flags);//9 bits
            Window = BitConverter.GetBytes(window);//16 bits
            int checksum = checkSum();//the sum of the tcp header info
            int urgentpointer = checkUrgent();//if the urgent pointer flag is true
            int optionsandpadding = checkOptionsPadding();//if the header needs padding, add padding

            Checksum = BitConverter.GetBytes(checksum);//16 bits
            UrgentPointer = BitConverter.GetBytes(urgentpointer);//16 bits
            OptionsAndPadding = BitConverter.GetBytes(optionsandpadding);//0-40 bit

            checkAll();

            List<byte[]> ListTheBits = new List<byte[]>();
            ListTheBits.Add(SourcePort);
            ListTheBits.Add(DestinationPort);
            ListTheBits.Add(SequenceNumber);
            ListTheBits.Add(AcknowledgmentNumber);
            ListTheBits.Add(Flags);
            ListTheBits.Add(Window);

            ListTheBits.Add(Checksum);
            ListTheBits.Add(UrgentPointer);
            ListTheBits.Add(OptionsAndPadding);
            
            byte[] endbytearray = concatByte(ListTheBits);
            Console.WriteLine("Length of byte list                 " + endbytearray.Length);
            return endbytearray;
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
            int cssize = checkSize(Checksum);
            Console.WriteLine("Length of byte Checksum             " + cssize);
            int upsize = checkSize(UrgentPointer);
            Console.WriteLine("Length of byte UrgentPointer        " + upsize);
            int oapsize = checkSize(OptionsAndPadding);
            Console.WriteLine("Length of byte OptionsAndPadding    " + oapsize);
        }

        public int checkSum()
        {
            return 1;
        }

        public int checkUrgent()
        {
            return 1;
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
            Console.WriteLine(Encoding.Default.GetString(endbytelist));
            return endbytelist;
        }

        byte ConvertToByte(BitArray bits)
        {
            byte[] bytes = new byte[1];
            bits.CopyTo(bytes, 0);
            Console.WriteLine(bytes[0]);
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