using System;
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
            TCPProgram<int> TestInt = new TCPProgram<int>(23999);

            TCPProgram<ulong> TestBigInt = new TCPProgram<ulong>(234996654546549);

            TCPProgram<string> TestString = new TCPProgram<string>("abcdefghijk");
            
            Console.WriteLine(TestInt);
            Console.WriteLine(TestBigInt);
            Console.WriteLine(TestString);

            convertToObject(TestString);

            Console.ReadLine();
            
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
