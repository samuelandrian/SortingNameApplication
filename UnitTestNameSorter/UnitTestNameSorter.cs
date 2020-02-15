using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NameSorter;
using System.IO;

namespace UnitTestNameSorter
{
    [TestClass]
    public class UnitTestNameSorter
    {
        [TestMethod]
        [ExpectedException(typeof(FileNotFoundException))]
        public void TestFileNotFound()
        {
            ProcessingFile processingFile = new ProcessingFile("weqwrqewreqwr");
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]        
        public void TestEmptyFile()
        {
            ProcessingFile processingFile = new ProcessingFile("test1.txt");            
        } 
        [TestMethod]
        public void TestInputingFileUnsortedNamesList()
        {
            string[] expectedResult = {

                "Avie Annakin",
                "Debra Micheli",
                "Hailey Annakin",
                "Selle Bellison",
                "Roy Ketti Kopfen",
                "Odetta Sue Kaspar",
                "Orson Milka Iddins",
                "Erna Dorey Battelle",
                "Flori Chaunce Franzel",
                "Madel Bordie Mapplebeck",
                "Leonerd Adda Micheli Monaghan",
                "Leonerd Adda Mitchell Monaghan"

            };
            ProcessingFile processingFile = new ProcessingFile("unsorted-names-list.txt");
            var actual = processingFile.GetNewContent();
            CollectionAssert.AreEqual(actual, expectedResult);
        }
        
    }
}
