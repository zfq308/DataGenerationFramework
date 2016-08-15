using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DataGenerationFramework.Core.GeneratorDataByRepository
{
    public interface ILanguageRepository
    {
        List<string> GetAdjectives();
        List<string> GetNouns();
        List<string> GetChineseFourWords();
        List<string> GetChineseTwoWords();

    }

    public class LanguageRepository : ILanguageRepository
    {
        /// <summary>
        /// 形容词清单
        /// </summary>
        /// <returns></returns>
        public List<string> GetAdjectives()
        {
            return LoadList("Adjectives");
        }

        public List<string> GetChineseFourWords()
        {
            return LoadList("ChineseFourWords");
        }

        public List<string> GetChineseTwoWords()
        {
            return LoadList("ChineseTwoWords");
        }

        /// <summary>
        /// 名词清单
        /// </summary>
        /// <returns></returns>
        public List<string> GetNouns()
        {
            return LoadList("Nouns");
        }

        private List<string> LoadList(string listToLoad)
        {
            var executingAssembly = Assembly.GetExecutingAssembly();
            var localNamespace = executingAssembly.GetName().Name;
            var resourceName = string.Format("{0}.Data.Language.{1}.txt", localNamespace, listToLoad);
            var dataList = new List<string>();

            using (var stream = executingAssembly.GetManifestResourceStream(resourceName))
            {
                if (stream != null)
                {
                    using (var reader = new System.IO.StreamReader(stream))
                    {
                        while (!reader.EndOfStream)
                        {
                            dataList.Add(reader.ReadLine());
                        }
                    }
                }
            }

            return dataList;

        }
    }

    public interface ILanguageGenerator
    {
        string GenerateNoun();
        string GenerateAdjective();
        string GenerateChineseTwoWord();
        string GenerateChineseFourWord();
    }

    public class LanguageGenerator : ILanguageGenerator
    {
        private ILanguageRepository _repository;
        private Random r = new Random();

        public LanguageGenerator(ILanguageRepository repository)
        {
            _repository = repository;
        }

        public string GenerateNoun()
        {
            var items = _repository.GetNouns();
            Random r = new Random();
            return items[r.Next(0, items.Count)];
        }

        public string GenerateAdjective()
        {
            var items = _repository.GetAdjectives();
            Random r = new Random();
            return items[r.Next(0, items.Count)];
        }

        public string GenerateChineseTwoWord()
        {
            var items = _repository.GetChineseTwoWords();
            Random r = new Random();
            return items[r.Next(0, items.Count)];
        }

        public string GenerateChineseFourWord()
        {
            var items = _repository.GetChineseFourWords();
            Random r = new Random();
            return items[r.Next(0, items.Count)];
        }
    }
}
