using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Unity;
using DataGenerationFramework.Core;

namespace DataGenerationFramework.Demo
{
    public class Generators
    {
        private IUnityContainer container;
        private Random r = new Random();

        public Generators()
        {
            container = new UnityContainer()
                .RegisterType<INameGenerator, NameGenerator>()
                .RegisterType<INameRepository, NameRepository>()
                .RegisterType<IAddressGenerator, AddressGenerator>()
                .RegisterType<IAddressRepository, AddressRepository>();
        }

        public string GetName(Gender gender)
        {
            var nameGenerator = container.Resolve<INameGenerator>();
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
        public string GetAddress()
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
    }
}
