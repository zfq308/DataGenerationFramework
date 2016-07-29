using System;
using System.Collections.Generic;
using Microsoft.Practices.Unity;
using DataGenerationFramework.Core;
using DataGenerationFramework.Core.GeneratorDataByRepository;

namespace DataGenerationFramework.Core
{
    public class RepositoryGenerators
    {
        private IUnityContainer container;
        private Random r = new Random();

        public RepositoryGenerators()
        {
            container = new UnityContainer()
                .RegisterType<IHumanDataGenerator, HumanDataGenerator>()
                .RegisterType<IHumanDataRepository, HumanDataRepository>()
                .RegisterType<IAddressGenerator, AddressGenerator>()
                .RegisterType<IAddressRepository, AddressRepository>()
                .RegisterType<ILanguageGenerator, LanguageGenerator>()
                .RegisterType<ILanguageRepository, LanguageRepository>()
                .RegisterType<IBusinessRepository, BusinessRepository>()
                .RegisterType<IBusinessGenerator, BusinessGenerator>();
        }

        #region Human Data

        public string GetHumanData_Name(Gender gender)
        {
            var nameGenerator = container.Resolve<IHumanDataGenerator>();
            List<string> fullName = new List<string>();


            switch (gender)
            {
                case Gender.Male:
                    if (r.Next(0, 3) == 0)
                    {
                        fullName.Add(nameGenerator.GenerateMaleTitle());
                    }
                    fullName.Add(nameGenerator.GenerateMaleName());
                    fullName.Add(nameGenerator.GenerateMaleName());
                    fullName.Add(nameGenerator.GenerateSurname());
                    if (r.Next(0, 5) == 0)
                    {
                        fullName.Add(nameGenerator.GenerateSuffix());
                    }
                    break;
                case Gender.Female:
                    if (r.Next(0, 2) == 0)
                    {
                        fullName.Add(nameGenerator.GenerateFemaleTitle());
                    }
                    fullName.Add(nameGenerator.GenerateFemaleName());
                    fullName.Add(nameGenerator.GenerateFemaleName());
                    fullName.Add(nameGenerator.GenerateSurname());
                    break;
            }

            return string.Join(" ", fullName.ToArray());
        }

        public string GetHumanData_ChineseName()
        {
            var generator2 = container.Resolve<IHumanDataGenerator>();
            return generator2.GenerateChineseName();
        }

        public string GetHumanData_ChineseLastName()
        {
            var generator2 = container.Resolve<IHumanDataGenerator>();
            return generator2.GenerateChineseLastName();
        }

        public string GetHumanData_EmailAddress()
        {
            var generator2 = container.Resolve<IHumanDataGenerator>();
            string EmailProvide = generator2.GenerateEmail();
            string name = generator2.GenerateFemaleName();
            return name + "@" + EmailProvide;
        }

        public string GetHumanData_ChineseNation()
        {
            var generator2 = container.Resolve<IHumanDataGenerator>();
            return generator2.GenerateChineseNationName();
        }

        public string GetHumanData_ChineseSchoolName()
        {
            var generator2 = container.Resolve<IHumanDataGenerator>();
            return generator2.GenerateChineseSchoolName();
        }

        public string GetHumanData_ChineseMobileNumber()
        {
            var generator2 = container.Resolve<IHumanDataGenerator>();
            return generator2.GenerateChineseMobileNumber();
        }

        public string GetHumanData_ChineseRandomMobileNumber()
        {
            var generator2 = container.Resolve<IHumanDataGenerator>();
            return generator2.GenerateChineseMobilePrefix() + RandomHelper.GetString(8, 8, "0123456789");
        }

        public string GetHumanData_ChinesePersonalSigner()
        {
            var generator2 = container.Resolve<IHumanDataGenerator>();
            return generator2.GenerateChinesePersonalSigner();
        }

        #endregion

        #region GEO Address

        public string GetGEOData_ChineseAddress()
        {
            var generator = container.Resolve<IAddressGenerator>();
            return generator.GenerateChineseAddress();
        }

        public string GetGEOData_ChineseHomeTown()
        {
            var generator = container.Resolve<IAddressGenerator>();
            return generator.GenerateChineseHomeTowns();
        }

        public string GetGEOData_Address()
        {
            var generator = container.Resolve<IAddressGenerator>();
            List<string> fullAddress = new List<string>();

            fullAddress.Add(generator.GenerateStreetNumber());
            fullAddress.Add(" ");
            fullAddress.Add(generator.GenerateStreetName());
            fullAddress.Add("\r\n");
            if (r.Next(0, 5) == 0)
            {
                fullAddress.Add(generator.GenerateSubType());
                fullAddress.Add(" ");
                fullAddress.Add(generator.GenerateSubNumber());
                fullAddress.Add("\r\n");
            }
            fullAddress.Add(generator.GenerateCombinedZipInfo());

            return string.Join("", fullAddress.ToArray());
        }

        #endregion

        #region Business
        public string GetBusiness_ChineseCommodity()
        {
            var generator = container.Resolve<IBusinessGenerator>();
            return generator.GenerateChineseCommodity();
        }

        public string GetBusiness_ChineseCompanyName()
        {
            var generator = container.Resolve<IBusinessGenerator>();
            return generator.GenerateChineseCompanyName();
        }

        #endregion

        #region Language
        public string GetLanguage_ChineseTwoWord()
        {
            var generator = container.Resolve<ILanguageGenerator>();
            return generator.GenerateChineseTwoWord();
        }

        public string GetLanguage_ChineseFourWord()
        {
            var generator = container.Resolve<ILanguageGenerator>();
            return generator.GenerateChineseFourWord();
        }

        #endregion

    }
}
