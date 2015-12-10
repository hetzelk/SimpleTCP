using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace TCPSimple
{
    public class TCPHeader
    {
        public object TCPHeaderFunction(int sourceport, int destinationport, int sequencenumber, int acknowledgmentnumber, int dataoffset, int ecn, int controlbits, int window, int checksum, int urgentpointer, int optionsandpadding, int data)
        {
            BitArray SourcePort = new BitArray(BitConverter.GetBytes(sourceport));//16 bits
            BitArray DestinationPort = new BitArray(BitConverter.GetBytes(destinationport));//16 bits

            BitArray SequenceNumber = new BitArray(BitConverter.GetBytes(sequencenumber));//32 bits

            BitArray AcknowledgmentNumber = new BitArray(BitConverter.GetBytes(acknowledgmentnumber));//32 bits

            BitArray DataOffset = new BitArray(BitConverter.GetBytes(dataoffset));//4 bits
            //reserved 3 bits
            BitArray ECN = new BitArray(BitConverter.GetBytes(ecn));//3 bits
            BitArray ControlBits = new BitArray(BitConverter.GetBytes(controlbits));//6 bits
            BitArray Window = new BitArray(BitConverter.GetBytes(window));//16 bits

            BitArray Checksum = new BitArray(BitConverter.GetBytes(checksum));//16 bits
            BitArray UrgentPointer = new BitArray(BitConverter.GetBytes(urgentpointer));//16 bits

            BitArray OptionsAndPadding = new BitArray(BitConverter.GetBytes(optionsandpadding));//0-40 bit

            BitArray Data = new BitArray(BitConverter.GetBytes(data));//Variable bits

            List<BitArray> ListTheBits = new List<BitArray>();
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

            object returnlist = ListTheBits;

            return returnlist;
        }
        
    }
}
