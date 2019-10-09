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
    public class SplitKeys
    {
        public void ActKeys(string[] keys) {
            FileUtil fileUtil = new FileUtil();
            Count count = new Count();
            int m=0, n=0;
            int i = 0;
            string o=null;
            string result = null ;
            //解析命令
            if (-1 == keys.Length)
            {
                Console.WriteLine("指令不能为空！！！");
            }
            //混合指令的使用
            for (; i < keys.Length; i++) {
                if (keys[i].Equals("-i")&&keys[i+1]!=null)
                {
                    fileUtil.Filepath = keys[i+1];
                }
                if (keys[i].Equals("-m"))
                {
                    m = int.Parse(keys[i + 1]);
                }
                if (keys[i].Equals("-n"))
                {
                    n = int.Parse(keys[i + 1]);
                }
                if (keys[i].Equals("-o"))
                {
                    o = keys[i + 1];
                }
            }
           
            //控制台输出的-n指令
            if (n != 0&& o== null) {
                string result_N = count.CountWord(n, fileUtil);
                result_N = "字符数为：" + fileUtil.CountChar + "\n行数为：" + fileUtil.CountLine + "\n" + result_N;
                Console.WriteLine(result_N);
            }
            
            //控制台输出的-m指令
            if (m != 0 && o == null)
            {
                string result_M = count.sumWord(m, fileUtil);
                Console.WriteLine(result_M);
            }
            //写入文件的的方式执行-n指令
            if (n != 0 && o != null&& m!=0)
            { 
                result =
                      count.CountWord(n, fileUtil) + "\n"
                    + count.sumWord(m, fileUtil)+"\n"+
                    "字符数为：" 
                    + fileUtil.CountChar/2+"\n" 
                    + "行数为：" 
                    + fileUtil.CountLine/2 + "\n";
                fileUtil.printCountToFile(result, o);
            }

        }
    }
}
