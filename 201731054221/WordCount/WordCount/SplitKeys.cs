using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordCount
{
    /**
     * 用于解析指令
     * */
    class SplitKeys
    {
        public string getKeys(string[] keys) {
            //指令的字符串
            string stringKeys = null;
            //装指令的list
            Dictionary<int, string> keysDir = new Dictionary<int, string>();
            //指令的计数，即如果第一个输入-i 则对应0 接着的input.txt为1
            int count = 0;
            int i = 0;
            //解析命令
            if (-1 == keys.Length) {
                Console.WriteLine("指令不能为空！！！");
            }
            //将命令拼接起来
            foreach (string str in keys) {
                stringKeys += str;
                keysDir.Add(count,str);
                count++;
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
            return null;
        }
    }
}
