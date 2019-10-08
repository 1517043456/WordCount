using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordCount
{
    /**
     * 用于解析指令,并且调用不同的方法
     * */
    class SplitKeys
    {
        public void getKeys(string[] keys) {
            int i = 0;
            //解析命令
            if (-1 == keys.Length) {
                Console.WriteLine("指令不能为空！！！");
            }
            //判断含有那些指令
            for (; i < keys.Length; i++) {
                if (keys[i].Equals("-i")) {
                    Console.WriteLine(keys[i+1]);
                }
                if (keys[i].Equals("-m"))
                {
                    Console.WriteLine(keys[i + 1]);
                }
                if (keys[i].Equals("-n"))
                {
                    Console.WriteLine(keys[i + 1]);
                }
                if (keys[i].Equals("-o"))
                {
                    Console.WriteLine(keys[i + 1]);
                }
            }
        }
    }
}
