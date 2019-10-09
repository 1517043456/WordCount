using Microsoft.VisualStudio.TestTools.UnitTesting;
using WordCount;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordCount.Tests
{
    [TestClass()]
    public class FileUtilTests
    {
        [TestMethod()]
        public void getWordListTest()
        {
            FileUtil fileUtil = new FileUtil();
            fileUtil.Filepath = "input.txt";
            Console.WriteLine(fileUtil.getWordList().ToString());
        }

        [TestMethod()]
        public void printCountToFileTest()
        {
            FileUtil fileUtil = new FileUtil();
            fileUtil.printCountToFile("1213123","output.txt");
        }
    }
}