using System;
using System.Net;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.ComponentModel;
using TCPProgram;

namespace TCPConsole
{
    class TestTCP
    {
        
        public object originalObj;
        TCPInfo tcpinfo = new TCPInfo();
        public IPAddress sourceport
        {  get { return tcpinfo.getSourceIP(); } }
        public IPAddress destinationport
        { get { return tcpinfo.getDestinationIP(); } }
        public int sequencenumber
        { get { return tcpinfo.getSequenceNumber(); } }
        public int acknowledgmentnumber
        { get { return tcpinfo.getAcknowledgmentNumber(); } }
        public int dataoffset
        { get { return tcpinfo.getDataOffset(); } }
        public byte[] reserved
        { get { return tcpinfo.getReserved(); } }
        public byte[] flags
        { get { return tcpinfo.getFlags(); } }
        public int window
        { get { return tcpinfo.getWindow(); } }

        public static void Main()
        {         
            TCPHeader tcpheader = new TCPHeader();
            TestTCP test = new TestTCP();
            byte[] tcpbyte = tcpheader.TCPHeaderConstruct(test.sourceport, test.destinationport, test.sequencenumber, test.acknowledgmentnumber, test.dataoffset, test.reserved, test.flags, test.window);
            Console.WriteLine("This is the end byte array length   "+ tcpbyte.Length);
            Console.ReadLine();
                /*
            TCPProgram<int> TestInt = new TCPProgram<int>(23999);
            TCPProgram<ulong> TestBigInt = new TCPProgram<ulong>(234996654546549);
            TCPProgram<string> TestString = new TCPProgram<string>("abcdefghijk");
            Console.WriteLine(TestInt);
            Console.WriteLine(TestBigInt);
            Console.WriteLine(TestString);
            convertToObject(TestString);
            Console.ReadLine();*/
            
        }

        public void convertToObject(byte[] array)
        {
            MemoryStream memStream = new MemoryStream();
            BinaryFormatter formatter = new BinaryFormatter();
            memStream.Write(array, 0, array.Length);
            memStream.Seek(0, SeekOrigin.Begin);
            Object obj = (Object)formatter.Deserialize(memStream);
            originalObj = obj;
            Console.WriteLine(originalObj);
        }
    }
}
