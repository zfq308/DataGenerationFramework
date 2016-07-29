using System;
using System.Linq;
using System.Text;

namespace DataGenerationFramework.Core
{
    /// <summary>
    /// 随机段落生成帮助类
    /// <example>
    ///         string[] words = { "anemone", "wagstaff", "man", "the", "for", "and", "a", "with", "bird", "fox" };
    //          RandomParagraphGeneratorHelper text = new RandomParagraphGeneratorHelper(words);
    //          text.AddContentParagraphs(2, 2, 4, 5, 12);
    //          Consile.Write(text.Content);
    /// </example>
    /// </summary>
    public class RandomParagraphGeneratorHelper
    {
        #region 成员变量
        private const string defaultString = "At vero eos et accusamus et iusto odio dignissimos ducimus qui blanditiis praesentium voluptatum deleniti atque corrupti quos dolores et quas molestias excepturi sint occaecati cupiditate non provident similique sunt in culpa qui officia deserunt mollitia animi id est laborum et dolorum fuga Et harum quidem rerum facilis est et expedita distinctio Nam libero tempore cum soluta nobis est eligendi optio cumque nihil impedit quo minus id quod maxime placeat facere possimus omnis voluptas assumenda est omnis dolor repellendus Temporibus autem quibusdam et aut officiis debitis aut rerum necessitatibus saepe eveniet ut et voluptates repudiandae sint et molestiae non recusandae Itaque earum rerum hic tenetur a sapiente delectus ut aut reiciendis voluptatibus maiores alias consequatur aut perferendis doloribus asperiores repellat";
        private const char defaultSplitChar = ' ';

        private StringBuilder _builder;
        readonly Random _random = new Random();

        #endregion

        #region 属性
        /// <summary>
        /// 构成句子的词组集合
        /// </summary>
        public string[] WordList { get; set; }

        private int _maxCharacters = -1;
        /// <summary>
        /// 返回的最长字符数
        /// </summary>
        public int MaxCharacters
        {
            get { return _maxCharacters; }
            set { _maxCharacters = value; }
        }

        /// <summary>
        /// 随机生成的文本
        /// </summary>
        public string Content
        {
            get
            {
                // if no wordlist
                if (!WordList.Any())
                {
                    InitaliseInLatin();
                }
                // If no randomized but max characters set
                if (_builder.ToString().Trim().Length < 1)
                {
                    AddSentence(_maxCharacters > 0 ? _maxCharacters : 1234);
                }

                string retVal = _builder.ToString().Trim();
                //handle maximum characters
                if (_maxCharacters > 0 && retVal.Length > 1)
                    retVal = retVal.Substring(0, _random.Next(1, _maxCharacters));

                return retVal;
            }
        }

        public override string ToString()
        {
            return Content;
        }

        #endregion

        #region 建构式

        /// <summary>
        /// Initalise a random word generator, but specify a string list of random text
        /// </summary>
        /// <param name="words"></param>
        public RandomParagraphGeneratorHelper(string[] words = null)
        {
            _builder = new StringBuilder();
            WordList = words;
        }

        /// <summary>
        /// Generate a random word array.
        /// Test used is latin
        /// Look in property Wordlist for string array
        /// </summary>
        public RandomParagraphGeneratorHelper()
        {
            InitaliseInLatin();
        }


        /// <summary>
        /// Generate a random word array.
        /// Test used is latin
        /// Look in property Wordlist for string array
        /// </summary>
        public RandomParagraphGeneratorHelper(int maxCharacters)
        {
            _maxCharacters = maxCharacters;
            InitaliseInLatin();
        }

        #endregion

        #region 公共方法

        /// <summary>
        /// Clear the output
        /// </summary>
        public void Clear()
        {
            _builder.Clear();

        }

        /// <summary>
        /// Specify the world list to use
        /// </summary>
        /// <param name="wordlist"></param>
        /// <param name="delimiter"></param>
        public void SetWordList(string wordlist, char delimiter)
        {
            WordList = wordlist.Split(delimiter);
        }

        /// <summary>
        /// 添加内容段落
        /// </summary>
        /// <param name="numberParagraphs">需要生成的段落数</param>
        /// <param name="minSentences"></param>
        /// <param name="maxSentences"></param>
        /// <param name="minWords"></param>
        /// <param name="maxWords"></param>
        public void AddContentParagraphs(int numberParagraphs, int minSentences, int maxSentences, int minWords, int maxWords)
        {
            for (int i = 0; i < numberParagraphs; i++)
            {
                AddParagraph(_random.Next(minSentences, maxSentences + 1), minWords, maxWords);
                _builder.Append("\n\n");  // 添加段落换行符
            }
        }

        #endregion

        #region 私有方法

        /// <summary>
        /// Add a paragraph to the output.
        /// </summary>
        /// <param name="numberSentences">生成段落中包含的句子个数</param>
        /// <param name="minWords">每个句子的最少单词个数</param>
        /// <param name="maxWords">每个句子的最多单词个数</param>
        private void AddParagraph(int numberSentences, int minWords, int maxWords)
        {
            for (int i = 0; i < numberSentences; i++)
            {
                int count = _random.Next(minWords, maxWords + 1);
                AddSentence(count);
            }
        }

        /// <summary>
        /// 生成一个指定单词个数的随机句子
        /// </summary>
        /// <param name="numberWords">生成句子的单词个数</param>
        private void AddSentence(int numberWords)
        {
            StringBuilder b = new StringBuilder();
            for (int i = 0; i < numberWords; i++)
            {
                b.Append(WordList[_random.Next(WordList.Length)]).Append(" ");
            }
            string sentence = b.ToString().Trim() + ". ";
            // 句子首字符大写
            sentence = char.ToUpper(sentence[0]) + sentence.Substring(1);
            _builder.Append(sentence);
        }

        private void InitaliseInLatin()
        {
            _builder = new StringBuilder();
            SetWordList(defaultString, defaultSplitChar);
        }

        #endregion
    }
}
