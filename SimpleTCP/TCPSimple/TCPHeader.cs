using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace TCPSimple
{
    class TCPHeader
    {
        public TCPHeader(int sourcePort)
        {
            BitArray SourcePort = new BitArray(BitConverter.GetBytes(sourcePort));//16 bits
            BitArray DestinationPort = new BitArray(BitConverter.GetBytes(sourcePort));//16 bits

            BitArray SequenceNumber = new BitArray(BitConverter.GetBytes(sourcePort));//32 bits

            BitArray AcknowledgmentNumber = new BitArray(BitConverter.GetBytes(sourcePort));//32 bits

            BitArray DataOffset = new BitArray(BitConverter.GetBytes(sourcePort));//4 bits
            //reserved 3 bits
            BitArray ECN = new BitArray(BitConverter.GetBytes(sourcePort));//3 bits
            BitArray ControlBits = new BitArray(BitConverter.GetBytes(sourcePort));//6 bits
            BitArray Window = new BitArray(BitConverter.GetBytes(sourcePort));//16 bits

            BitArray Checksum = new BitArray(BitConverter.GetBytes(sourcePort));//16 bits
            BitArray UrgentPointer = new BitArray(BitConverter.GetBytes(sourcePort));//16 bits

            BitArray OptionsAndPadding = new BitArray(BitConverter.GetBytes(sourcePort));//0-40 bits

            BitArray Data = new BitArray(BitConverter.GetBytes(sourcePort));//Variable bits
        }
        
    }
}
