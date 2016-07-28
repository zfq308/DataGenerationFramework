using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DataGenerationFramework.Core;
using System.Reflection;

namespace DataGenerationFramework.Core
{

    public interface IAddressRepository
    {
        List<string> GetAdjectives();
        List<string> GetNouns();
        List<string> GetStreetTypes();
        List<string> GetSubTypes();
        List<string> GetZipCodeInfo();
    }

    public class AddressRepository : IAddressRepository
    {
        /// <summary>
        /// 形容词清单
        /// </summary>
        /// <returns></returns>
        public List<string> GetAdjectives()
        {
            return LoadList("Adjectives");
        }

        /// <summary>
        /// 名词清单
        /// </summary>
        /// <returns></returns>
        public List<string> GetNouns()
        {
            return LoadList("Nouns");
        }

        /// <summary>
        /// 街道类型
        /// </summary>
        /// <returns></returns>
        public List<string> GetStreetTypes()
        {
            return LoadList("StreetTypes");
        }

        /// <summary>
        /// 次级地址
        /// </summary>
        /// <returns></returns>
        public List<string> GetSubTypes()
        {
            return LoadList("SubAddress");
        }

        /// <summary>
        /// 美国邮区编号
        /// </summary>
        /// <returns></returns>
        public List<string> GetZipCodeInfo()
        {
            return LoadList("ZipCodes");
        }

        private List<string> LoadList(string listToLoad)
        {
            var executingAssembly = Assembly.GetExecutingAssembly();
            var localNamespace = executingAssembly.GetName().Name;
            var resourceName = string.Format("{0}.Data.{1}.txt", localNamespace, listToLoad);
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

    public interface IAddressGenerator
    {
        string GenerateCity();
        string GenerateState();
        string GenerateCounty();
        string GenerateZipcode();
        string GenerateCombinedZipInfo();
        string GenerateStreetNumber();
        string GenerateStreetName();
        string GenerateSubType();
        string GenerateSubNumber();
    }

    public class AddressGenerator : IAddressGenerator
    {
        private IAddressRepository _repository;
        private Random r = new Random();

        public AddressGenerator(IAddressRepository repository)
        {
            _repository = repository;
        }

        public string GenerateCity()
        {
            var items = _repository.GetZipCodeInfo();
            var item = items[r.Next(0, items.Count)].Split(',');

            return item[1].Trim();

        }

        public string GenerateState()
        {
            var items = _repository.GetZipCodeInfo();
            var item = items[r.Next(0, items.Count)].Split(',');

            return item[2].Trim();
        }

        public string GenerateCounty()
        {
            var items = _repository.GetZipCodeInfo();
            var item = items[r.Next(0, items.Count)].Split(',');

            return item[3].Trim();
        }

        public string GenerateZipcode()
        {
            var items = _repository.GetZipCodeInfo();
            var item = items[r.Next(0, items.Count)].Split(',');

            return item[0].Trim();
        }

        public string GenerateCombinedZipInfo()
        {
            var items = _repository.GetZipCodeInfo();
            var item = items[r.Next(0, items.Count)].Split(',');

            return string.Format("{0}\r\n{1}, {2} {3}", item[3].Trim(), item[1].Trim(), item[2].Trim(), item[0].Trim());
        }

        public string GenerateStreetNumber()
        {
            return r.Next(0, 10000).ToString();
        }

        public string GenerateStreetName()
        {
            var adjectives = _repository.GetAdjectives();
            var nouns = _repository.GetNouns();
            var types = _repository.GetStreetTypes();

            return string.Format("{0} {1} {2}"
                , adjectives[r.Next(0, adjectives.Count)]
                , nouns[r.Next(0, nouns.Count)]
                , types[r.Next(0, types.Count)]
                );
        }

        public string GenerateSubType()
        {
            var items = _repository.GetSubTypes();
            return items[r.Next(0, items.Count)];
        }

        public string GenerateSubNumber()
        {
            return r.Next(0, 100).ToString();
        }

    }



    public interface INameGenerator
    {
        string GenerateFemaleName();
        string GenerateFemaleTitle();
        string GenerateMaleName();
        string GenerateMaleTitle();
        string GenerateSurname();
        string GenerateSuffix();
        string GenerateFullName(Gender gender);
    }

    public interface INameRepository
    {
        List<string> GetMaleNames();
        List<string> GetFemaleNames();
        List<string> GetSurnames();
        List<string> GetMaleTitles();
        List<string> GetFemaleTitles();
        List<string> GetTitles();
        List<string> GetSuffixes();
    }

    public class NameGenerator : INameGenerator
    {
        private INameRepository _nameRepository;
        private Random r = new Random();

        public NameGenerator(INameRepository nameRepository)
        {
            _nameRepository = nameRepository;
        }

        public string GenerateFemaleName()
        {
            var names = _nameRepository.GetFemaleNames();
            return names[r.Next(0, names.Count)];
        }

        public string GenerateFemaleTitle()
        {
            var names = _nameRepository.GetFemaleTitles();
            names.AddRange(_nameRepository.GetTitles());
            return names[r.Next(0, names.Count)];
        }

        public string GenerateMaleName()
        {
            var names = _nameRepository.GetMaleNames();
            return names[r.Next(0, names.Count)];
        }

        public string GenerateMaleTitle()
        {
            var names = _nameRepository.GetMaleTitles();
            names.AddRange(_nameRepository.GetTitles());
            return names[r.Next(0, names.Count)];
        }

        public string GenerateSurname()
        {
            var names = _nameRepository.GetSurnames();
            return names[r.Next(0, names.Count)];
        }

        public string GenerateSuffix()
        {
            var names = _nameRepository.GetSuffixes();
            return names[r.Next(0, names.Count)];
        }

        public string GenerateFullName(Gender gender)
        {
            var title = string.Empty;
            var firstName = string.Empty;
            var middleName = string.Empty;

            switch (gender)
            {
                case Gender.Female:
                    title = GenerateFemaleTitle();
                    firstName = GenerateFemaleName();
                    middleName = GenerateFemaleName();
                    break;
                case Gender.Male:
                    title = GenerateMaleTitle();
                    firstName = GenerateMaleName();
                    middleName = GenerateMaleName();
                    break;
            }
            var lastName = GenerateSurname();
            var suffix = GenerateSuffix();

            return string.Format("{0} {1} {2} {3} {4}", title, firstName, middleName, lastName, suffix);
        }
    }

    public class NameRepository : INameRepository
    {
        public List<string> GetMaleNames()
        {
            return LoadList("MaleNames");
        }

        public List<string> GetFemaleNames()
        {
            return LoadList("FemaleNames");
        }

        public List<string> GetSurnames()
        {
            return LoadList("Surnames");
        }

        public List<string> GetMaleTitles()
        {
            return LoadList("MaleTitles");
        }

        public List<string> GetFemaleTitles()
        {
            return LoadList("FemaleTitles");
        }

        public List<string> GetTitles()
        {
            return LoadList("GenericTitles");
        }

        public List<string> GetSuffixes()
        {
            return LoadList("Suffixes");
        }

        private List<string> LoadList(string listToLoad)
        {
            var executingAssembly = Assembly.GetExecutingAssembly();
            var localNamespace = executingAssembly.GetName().Name;
            var resourceName = string.Format("{0}.Data.{1}.txt", localNamespace, listToLoad);
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


}
