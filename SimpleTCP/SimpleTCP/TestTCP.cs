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

        public static void Main()
        {
            IPAddress sourceaddress = IPAddress.Parse("12.127.92.98");
            IPAddress destinationaddress = IPAddress.Parse("12.127.92.98");

            IPAddress sourceport = sourceaddress;
            IPAddress destinationport = destinationaddress;
            int sequencenumber = 1;
            int acknowledgmentnumber = 1;
            int dataoffset = 1;
            int reserved = 1;
            int ecn = 1;
            int controlbits = 1;
            int window = 1;
            int checksum = 1;
            int urgentpointer = 1;
            int optionsandpadding = 1;
            int data = 1;

            TCPHeader tcpheader = new TCPHeader(sourceport, destinationport, sequencenumber, acknowledgmentnumber, dataoffset, reserved,  ecn, controlbits, window, checksum, urgentpointer, optionsandpadding, data);
            Console.WriteLine(tcpheader);
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
