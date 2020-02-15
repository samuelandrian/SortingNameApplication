using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NameSorter
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                new ProcessingFile(args[0]);
            }
            catch (Exception ex) { }
            Console.ReadKey();
        }     
    }    
}
