using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DataGenerationFramework.Core;
using System.Reflection;

namespace DataGenerationFramework.Core.GeneratorDataByRepository
{
    public interface IHumanDataRepository
    {
        List<string> GetMaleNames();
        List<string> GetFemaleNames();
        List<string> GetSurnames();
        List<string> GetMaleTitles();
        List<string> GetFemaleTitles();
        List<string> GetTitles();
        List<string> GetSuffixes();
        List<string> GetChineseNames();
        List<string> GetChineseLastNames();
        List<string> GetEmailProvides();
        List<string> GetChineseNations();
        List<string> GetChineseSchools();
        List<string> GetChineseMobiles();
        List<string> GetChineseMobilePreFix();
        List<string> GetChinesePersonalSigner();
    }

    public class HumanDataRepository : IHumanDataRepository
    {
        private List<string> LoadList(string listToLoad)
        {
            var executingAssembly = Assembly.GetExecutingAssembly();
            var localNamespace = executingAssembly.GetName().Name;
            var resourceName = string.Format("{0}.Data.HumanData.{1}.txt", localNamespace, listToLoad);
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

        public List<string> GetChineseNames()
        {
            return LoadList("ChineseName");
        }

        public List<string> GetChineseLastNames()
        {
            return LoadList("ChineseLastName");
        }

        public List<string> GetEmailProvides()
        {
            return LoadList("Email");
        }

        public List<string> GetChineseNations()
        {
            return LoadList("ChineseNation");
        }

        public List<string> GetChineseSchools()
        {
            return LoadList("ChineseSchoolName");
        }

        public List<string> GetChineseMobiles()
        {
            return LoadList("MobileFullNumber");
        }

        public List<string> GetChineseMobilePreFix()
        {
            return LoadList("MobilePreFix");
        }

        public List<string> GetChinesePersonalSigner()
        {
            return LoadList("PersonalSigner");
        }
    }

    public interface IHumanDataGenerator
    {
        string GenerateFemaleName();
        string GenerateFemaleTitle();
        string GenerateMaleName();
        string GenerateMaleTitle();
        string GenerateSurname();
        string GenerateSuffix();
        string GenerateFullName(Gender gender);
        string GenerateChineseName();
        string GenerateChineseLastName();
        string GenerateChineseNationName();
        string GenerateChineseSchoolName();
        string GenerateChineseMobileNumber();
        string GenerateChineseMobilePrefix();
        string GenerateChinesePersonalSigner();
        string GenerateEmail();
    }

    public class HumanDataGenerator : IHumanDataGenerator
    {
        private IHumanDataRepository _nameRepository;
        private Random r = new Random();

        public HumanDataGenerator(IHumanDataRepository nameRepository)
        {
            _nameRepository = nameRepository;
        }

        #region English-Name

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
        
        #endregion

        public string GenerateChineseName()
        {
            var names = _nameRepository.GetChineseNames();
            return names[r.Next(0, names.Count)];
        }

        public string GenerateChineseLastName()
        {
            var names = _nameRepository.GetChineseLastNames();
            return names[r.Next(0, names.Count)];
        }

        public string GenerateEmail()
        {
            var EmailProvides = _nameRepository.GetEmailProvides();
            return EmailProvides[r.Next(0, EmailProvides.Count)];
        }

        public string GenerateChineseNationName()
        {
            var ChineseNations = _nameRepository.GetChineseNations();
            return ChineseNations[r.Next(0, ChineseNations.Count)];
        }

        public string GenerateChineseSchoolName()
        {
            var list = _nameRepository.GetChineseSchools();
            return list[r.Next(0, list.Count)];
        }

        public string GenerateChineseMobileNumber()
        {
            var list = _nameRepository.GetChineseMobiles();
            return list[r.Next(0, list.Count)];
        }

        public string GenerateChineseMobilePrefix()
        {
            var list = _nameRepository.GetChineseMobilePreFix();
            return list[r.Next(0, list.Count)];
        }

        public string GenerateChinesePersonalSigner()
        {
            var list = _nameRepository.GetChinesePersonalSigner();
            return list[r.Next(0, list.Count)];
        }
    }

}