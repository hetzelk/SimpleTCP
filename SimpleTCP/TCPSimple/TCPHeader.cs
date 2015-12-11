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
        byte[] ECN;
        byte[] ControlBits;
        byte[] Window;
        byte[] Checksum;
        byte[] UrgentPointer;
        byte[] OptionsAndPadding;
        byte[] Data;

        public TCPHeader(IPAddress sourceport, IPAddress destinationport, int sequencenumber, int acknowledgmentnumber, int dataoffset, int reserved, int ecn, int controlbits, int window, int checksum, int urgentpointer, int optionsandpadding, int data)
        {
            //testerlength();
            SourcePort = getIPByte(sourceport);//16 bits
            DestinationPort = getIPByte(destinationport); ;//16 bits
            SequenceNumber = BitConverter.GetBytes(sequencenumber);//32 bits
            AcknowledgmentNumber = BitConverter.GetBytes(acknowledgmentnumber);//32 bits
            DataOffset = BitConverter.GetBytes(dataoffset);//4 bits
            Reserved = BitConverter.GetBytes(reserved);//3 bits
            ECN = BitConverter.GetBytes(ecn);//3 bits
            ControlBits = BitConverter.GetBytes(controlbits);//6 bits
            Window = BitConverter.GetBytes(window);//16 bits
            Checksum = BitConverter.GetBytes(checksum);//16 bits
            UrgentPointer = BitConverter.GetBytes(urgentpointer);//16 bits
            OptionsAndPadding = BitConverter.GetBytes(optionsandpadding);//0-40 bit
            Data = BitConverter.GetBytes(data);//Variable bits

            checkSize(SourcePort);
            checkSize(DestinationPort);
            checkSize(SequenceNumber);
            checkSize(AcknowledgmentNumber);
            checkSize(ECN);
            checkSize(ControlBits);
            checkSize(Window);
            checkSize(Checksum);
            checkSize(UrgentPointer);
            checkSize(OptionsAndPadding);
            checkSize(Data);

            List<byte[]> ListTheBits = new List<byte[]>();
            ListTheBits.Add(SourcePort);
            ListTheBits.Add(DestinationPort);
            ListTheBits.Add(SequenceNumber);
            ListTheBits.Add(AcknowledgmentNumber);
            ListTheBits.Add(ECN);
            ListTheBits.Add(ControlBits);
            ListTheBits.Add(Window);
            ListTheBits.Add(Checksum);
            ListTheBits.Add(UrgentPointer);
            ListTheBits.Add(OptionsAndPadding);
            ListTheBits.Add(Data);
            
            concatByte(ListTheBits);
        }

        public void checkSize(byte[] item)
        {
            Console.WriteLine("Length of byte item " + item.Length);
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