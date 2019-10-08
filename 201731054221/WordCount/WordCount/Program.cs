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
        /**
         * 统计文件行数
         * */
        public static int lineFile(string fileName)
        {
            int rows = 0;//文件行数
            StreamReader streamReader = new StreamReader(fileName,Encoding.Default);
            while(streamReader.ReadLine() != null)
            {
                rows++;
            }
            streamReader.Close();
            Console.WriteLine("该文件行数为：" + rows);
            return rows;
        }

        /**
         * 统计字符总数
         * */
        public static int signFile(string fileName)
        {
            int signNumber = 0;
            string allText = File.ReadAllText(fileName);
            signNumber = Regex.Matches(allText, @"\d").Count;//统计数字
            signNumber = signNumber + Regex.Matches(allText, @"\s").Count;//统计空白字符
            signNumber = signNumber + Regex.Matches(allText, @"\w").Count;//统计任何单词字符
            Console.WriteLine("字符数为：" + signNumber);
            return signNumber;
        }

        /**
         * 统计词组
         * */
        public static int sumWord(string fileName,int m)
        {
            int instructionM = m;
            int number = 0;
            int last = 0;
            Dictionary<string, int> keyValuePairs = new Dictionary<string, int>();
            StreamReader reader = new StreamReader(fileName, Encoding.Default);
            String path = null;
            string s = null;
            while ((path = reader.ReadLine()) != null)
            {
                s += (path + "\n");
            }
            string[] words = Regex.Split(s, @"\W+");
            foreach (string word in words)
            {
                if (keyValuePairs.ContainsKey(word))
                {
                    keyValuePairs[word]++;
                    number++;
                }
                else
                {
                    keyValuePairs[word] = 1;
                    number++;
                }
            }
            if (number > instructionM)
            {
                last = number - instructionM;
                Console.WriteLine("词组个数为：" + last);
            }
            else
            {
                Console.WriteLine("不存在这样的词组");
            }

            return last;


        }

        /**
         * 输出n个单词
         * */
        public static int printWord(string fileName,int n)
        {
            int instructionN = n;
            int number = 0;
            Dictionary<string, int> keyValuePairs = new Dictionary<string, int>();
            StreamReader reader = new StreamReader(fileName, Encoding.Default);
            String path = null;
            string s = null;
            while ((path = reader.ReadLine()) != null)
            {
                s += (path + "\n");
            }
            string[] words = Regex.Split(s, @"\W+");
            foreach (string word in words)
            {
                if (keyValuePairs.ContainsKey(word))
                {
                    keyValuePairs[word]++;
                    number++;
                }
                else
                {
                    keyValuePairs[word] = 1;
                    number++;
                }
            }
            Console.WriteLine("单词数为：" + (number-1));


            string[] wordKey = new string[number];
            int[] wordValue = new int[number];
            int i = 0;
            foreach (KeyValuePair<string, int> entry in keyValuePairs)//统计单词总量
            {
                wordKey[i] = entry.Key;
                wordValue[i] = entry.Value;
                i++;
            }
            for (int j = 0; j < i; j++)//排序
            {
                for (int x = j + 1; x < i; x++)
                {
                    if (wordValue[j] < wordValue[x])
                    {
                        int value = 0;
                        value = wordValue[j];
                        wordValue[j] = wordValue[x];
                        wordValue[x] = value;
                        string key = null;
                        key = wordKey[j];
                        wordKey[j] = wordKey[x];
                        wordKey[x] = key;
                    }
                }
            }
            string[] result = new string[instructionN];
            for (int j = 0; j < instructionN; j++)
            {
                result[j] = wordKey[j] + ":" + wordValue[j];
                // Console.WriteLine( ss1[j] );
            }
            var queryResults = from ni in result//字典序排序并输出
                               orderby ni
                               select ni;

            foreach (var item in queryResults)
            {

                Console.WriteLine(item);
            }
            return number;
        }

        /**
         * 输出n个单词到文件
         * */
        public static int printFile(string fileName,int n,string o)
        {
            string o1 = o;
            File.AppendAllText(o, string.Empty);
            int instructionN = n;
            int number = 0;
            Dictionary<string, int> keyValuePairs = new Dictionary<string, int>();
            StreamReader reader = new StreamReader(fileName, Encoding.Default);
            String path = null;
            string s = null;
            while ((path = reader.ReadLine()) != null)
            {
                s += (path + "\n");
            }
            string[] words = Regex.Split(s, @"\W+");
            foreach (string word in words)
            {
                if (keyValuePairs.ContainsKey(word))
                {
                    keyValuePairs[word]++;
                    number++;
                }
                else
                {
                    keyValuePairs[word] = 1;
                    number++;
                }
            }
            string[] wordKey = new string[number];
            int[] wordValue = new int[number];
            int i = 0;
            foreach (KeyValuePair<string, int> entry in keyValuePairs)//统计单词总量
            {
                wordKey[i] = entry.Key;
                wordValue[i] = entry.Value;
                i++;
            }
            for (int j = 0; j < i; j++)//排序
            {
                for (int x = j + 1; x < i; x++)
                {
                    if (wordValue[j] < wordValue[x])
                    {
                        int value = 0;
                        value = wordValue[j];
                        wordValue[j] = wordValue[x];
                        wordValue[x] = value;
                        string key = null;
                        key = wordKey[j];
                        wordKey[j] = wordKey[x];
                        wordKey[x] = key;
                    }
                }
            }
            string[] result = new string[instructionN];
            for (int j = 0; j < instructionN; j++)
            {
                result[j] = wordKey[j] + ":" + wordValue[j];
                // Console.WriteLine( ss1[j] );
            }
            var queryResults = from ni in result//字典序排序并输出
                               orderby ni
                               select ni;

            foreach (var item in queryResults)
            {

                //Console.WriteLine(item);
                File.AppendAllText(o, item + "\r\n");
            }
            return number;
        }

        static void Main(string[] args)
        {
            int m = 0, n = 0;
            string o = null;
            string fileName = null;
            for (int i = 0; i < args.Length; i++)
            {
                if (args[i] == "-i")//输入文件名
                {
                    fileName = args[i + 1];
                }
            }
            signFile(fileName);
            lineFile(fileName);
            for (int i = 0; i < args.Length; i++)
            {
                if (args[i] == "-m")//输入词组长度
                {
                    m = int.Parse(args[i + 1]);
                }
                else if (args[i] == "-n")//输出n个单词
                {
                    n = int.Parse(args[i + 1]);

                }
                else if (args[i] == "-o")//输出文件
                {
                    o = args[i + 1];
                }
            }
            if (n != 0 & o != null)
            {
               
                printFile(fileName, n, o);
                
            }
            if (n != 0)
            {
                printWord(fileName, n);
            
            }
            if (m != 0)
            {
                sumWord(fileName, m);
            }
            
        }
    }
}
