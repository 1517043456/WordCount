using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace WordCount
{
    /**
     * 处理文件的读入
    **/
    public class FileUtil
    {
        //统计字符数
        int countChar = 0;
        //统计行数
        int countLine = 0;
        string filepath = null;

        public int CountChar { get => countChar; set => countChar = value; }
        public int CountLine { get => countLine; set => countLine = value; }
        public string Filepath { get => filepath; set => filepath = value; }

        public List<string> getWordList() {
            /**
            * 用于获取文件中的单词并将其返回
            **/
            try
            {
                StreamReader sr = new StreamReader(this.Filepath, Encoding.Default);
                //用于存储读取后的单词
                List<string> wordList = new List<string>();
                //用于分割筛选出每行的字母数字
                string argex1 = "\\s*[^0-9a-zA-Z]+";
                //用于分割单词
                string argex2 = "[a-zA-Z]{4,}[a-zA-Z0-9]*";
                //读取一行
                string readLine;
                while ((readLine = sr.ReadLine()) != null) {
                    CountChar += readLine.Length;
                    CountLine++;
                    string[] wordArray = Regex.Split(readLine, argex1);
                    foreach (string word in wordArray) {
                        if(Regex.IsMatch(word,argex2))
                        wordList.Add(word);
                    }
                }
                sr.Close();
                return wordList;
            }
            catch (Exception e) {
                Console.WriteLine(e.Message.ToString());
            }
            return null;
        }

        /**
        *用于文件写入最终结果
        * */
        public void printCountToFile(string result,string output) {
            try
            {
                string txtfile = output;
                StreamWriter sw = new StreamWriter(txtfile);
                sw.Write(result);
                sw.Flush();
                sw.Close();
                Console.WriteLine(output+"文件写入完毕！");
            }
            catch (Exception e)
            {
                Console.WriteLine("文件写入失败！");
            }
        }
    }
}
