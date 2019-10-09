using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordCount
{
    /**
    *用于统计单词个数以及-m,-n指令的统计
    **/
    public class Count
    {
        int wordCount = 0;

        public int WordCount { get => wordCount; set => wordCount = value; }

        /**
        * 参数n代表输出的排序前多少的单词数量
        * */
        public string CountWord(int n,FileUtil fileUtil) {
            String resultWord = null;
            //需要输出单词数
            int instructionN = n;
            //获取已经分割了的单词列表
            List<string> wordList = fileUtil.getWordList();
                    //用于将单词进行排序和存储
        Dictionary<string, int> keyValuePairs = new Dictionary<string, int>();
            foreach (string word in wordList) {
                if (keyValuePairs.ContainsKey(word))
                {
                    keyValuePairs[word]++;
                    WordCount++;
                }
                else {
                    keyValuePairs[word] = 1;
                    WordCount++;
                }
            }
            string[] wordKey = new string[WordCount];
            int[] wordValue = new int[WordCount];
            int i = 0;
            foreach (KeyValuePair<string,int> entry in keyValuePairs) {
                wordKey[i] = entry.Key;
                wordValue[i] = entry.Value;
                i++;
            }
            //词频排序
            for (int j = 0; j < i; j++)
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
            string ss = null;
            string[] result = new string[instructionN];
            for (int j = 0; j < instructionN; j++)
            {
                result[j] = wordKey[j] + ":" + wordValue[j];
                ss+= wordKey[j] + ":" + wordValue[j] +"\n";                
            }
            var queryResults = from ni in result//字典序排序
                               orderby ni
                               select ni;
            foreach (var item in queryResults)
            {
               resultWord += item.ToString()+"\n";
            }
            return ss;
        }

        /**
         * 统计词组 -m指令
         * */
        public string sumWord(int m,FileUtil fileUtil) {
            int instructionM = m;
            int last = 0;
                        //获取已经分割了的单词列表
            List<string> wordList = fileUtil.getWordList();
            Dictionary<string, int> keyValuePairs = new Dictionary<string, int>();
            foreach (string word in wordList) {
                if (keyValuePairs.ContainsKey(word))
                {
                    keyValuePairs[word]++;
                    WordCount++;
                }
                else {
                    keyValuePairs[word] = 1;
                    WordCount++;
                }
            }
            if (WordCount > instructionM)
            {
                last = WordCount - instructionM;
                return m+"个长度的词组有："+last.ToString()+"个";
            }
            else {
                return "不存在长度为："+m/2+"的词组!\n";
            }
        }
    }
}
