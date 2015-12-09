using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.ComponentModel;
using TCPSimple2;

namespace TCPSimple1
{
    class TestTCP
    {     
        public static void Main()
        {
            TCPProgram<int> TestInt = new TCPProgram<int>(23999);

            TCPProgram<ulong> TestBigInt = new TCPProgram<ulong>(234996654546549);

            TCPProgram<string> TestString = new TCPProgram<string>("abcdefghijk");

            //TCPProgram<int> TestInt = new TCPProgram<int>(234999);
        }
    }
}
