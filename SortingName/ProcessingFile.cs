using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NameSorter
{
    public class ProcessingFile
    {
        public ProcessingFile() { }
        public ProcessingFile(string fileName)
        {            
            this.ProcessSequentially(fileName);
        }
        private static string filePath;
        private static string newFilePath;
        public string[] Content;
        private static string[] SortedContent = null;
        private bool isFileExist()
        {            
            return File.Exists(filePath);
        }
        private void SetFilePath(string fileName)
        {
            filePath = Path.Combine(Directory.GetCurrentDirectory(), Path.GetFileName(fileName));            
        }
        public string[] GetNewContent()
        {
            SetNewFilePath();
            if(isFileExist())
            {
                FileStream readerStream = new FileStream(newFilePath, FileMode.Open);
                using (StreamReader reader = new StreamReader(readerStream))
                {
                    Content = reader.ReadToEnd().Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);                    
                }
            }
            return Content;
        }
        private string[] GetContent()
        {
            FileStream readerStream = new FileStream(filePath, FileMode.Open);
            using (StreamReader reader = new StreamReader(readerStream))
            {
                Content = reader.ReadToEnd().Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
            }
            return Content;
        }
        public void SetContent()
        {
            GetContent();
        }
        private void SetSortedContent()
        {
            SetContent();   
            if (Content != null && Content.Length != 0)
            {
                var sorted = Content.Cast<string>()
                            .OrderBy(str => str.Length)
                            .ThenBy(str => str);
                SortedContent = sorted.ToArray();
            }
            else
            {
                throw new IndexOutOfRangeException("File Is Empty");
            }            
        }
        private void WriteToConsole()
        {
            foreach (var item in SortedContent)
                Console.WriteLine(item);
        }
        private void SetNewFilePath()
        {
            newFilePath = Path.Combine(Directory.GetCurrentDirectory(), "sorted-names-list.txt");
        }
        private void WriteFileWithSortedContent()
        {
            SetNewFilePath();
            FileStream writerStream = new FileStream(newFilePath, FileMode.OpenOrCreate);
            if (SortedContent != null && SortedContent.Length != 0)
            {
                using (StreamWriter writer = new StreamWriter(writerStream))
                {
                    writer.Write(string.Join(Environment.NewLine, SortedContent));
                }
            }            
        }
        public void ProcessSequentially(string fileName)
        {
            SetFilePath(fileName);
            if (isFileExist())
            {                
                SetSortedContent();
                WriteToConsole();
                WriteFileWithSortedContent();
            }
            else
            {
                throw new FileNotFoundException("File is Not Exist");
            }
        }        
    }
}
