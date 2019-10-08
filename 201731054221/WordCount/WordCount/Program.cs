using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordCount
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                //将控制台传入的命令送去解析
                SplitKeys splitKeys = new SplitKeys();
                splitKeys.getKeys(args);
                
            }
            catch (Exception e) {
                Console.WriteLine(e.Message);
            }
        }

           
    }
}