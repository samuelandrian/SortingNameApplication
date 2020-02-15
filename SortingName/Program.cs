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
                //ProcessingFile temp1 =  new ProcessingFile("unsorted-names-list.txt");
                ProcessingFile temp1 = new ProcessingFile();
                temp1.ProcessSequentially("unsorted-names-list.txt");
                var a = temp1.GetNewContent();
            }
            catch (Exception ex) { }
            Console.ReadKey();
        }     
    }    
}
