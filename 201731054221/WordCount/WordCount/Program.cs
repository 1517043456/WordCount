using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace WordCount
{
    class Program
    {
        static void Main(string[] args) {
            try
            {
                //将获取的的指令送去解析
                    SplitKeys splitKeys = new SplitKeys();
                    splitKeys.ActKeys(args);
            }
            catch (Exception e) {
                Console.WriteLine(e.Message);

            }
        }

    }
}
