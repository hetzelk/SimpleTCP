using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.ComponentModel;

namespace TCPSimple2
{
    public class TCPProgram<T>
    {
        public TCPProgram(T input)
        {
            runConversion(input);

        }
        
        public void runConversion(T input)
        {
            byte[] answer = Switcher(input);
            Console.WriteLine(answer);
        }

        private byte[] Switcher(T tcpitem)
        {
            if (tcpitem == null)
                return null;
            BinaryFormatter bf = new BinaryFormatter();
            MemoryStream ms = new MemoryStream();
            bf.Serialize(ms, tcpitem);
            return ms.ToArray();
        }

    }
}
