using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DataGenerationFramework.Core.GeneratorDataByRepository
{
    public interface IAddressRepository
    {
        List<string> GetStreetTypes();
        List<string> GetSubTypes();
        List<string> GetZipCodeInfo();
        List<string> GetChineseAddress();
        List<string> GetChineseHomeTown();
    }

    public class AddressRepository : IAddressRepository
    {
        /// <summary>
        /// 中文地址
        /// </summary>
        /// <returns></returns>
        public List<string> GetChineseAddress()
        {
            return LoadList("ChineseAddress");
        }

        /// <summary>
        /// 中文城镇名
        /// </summary>
        /// <returns></returns>
        public List<string> GetChineseHomeTown()
        {
            return LoadList("ChineseHomeTown");
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
            var resourceName = string.Format("{0}.Data.GEO.{1}.txt", localNamespace, listToLoad);
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
        string GenerateChineseAddress();
        string GenerateChineseHomeTowns();
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
            Random r = new Random();
            var item = items[r.Next(0, items.Count)].Split(',');
            return item[1].Trim();
        }

        public string GenerateState()
        {
            var items = _repository.GetZipCodeInfo();
            Random r = new Random();

            var item = items[r.Next(0, items.Count)].Split(',');

            return item[2].Trim();
        }

        public string GenerateCounty()
        {
            var items = _repository.GetZipCodeInfo();
            Random r = new Random();
            var item = items[r.Next(0, items.Count)].Split(',');

            return item[3].Trim();
        }

        public string GenerateZipcode()
        {
            var items = _repository.GetZipCodeInfo();
            Random r = new Random();
            var item = items[r.Next(0, items.Count)].Split(',');

            return item[0].Trim();
        }

        public string GenerateCombinedZipInfo()
        {
            var items = _repository.GetZipCodeInfo();
            Random r = new Random();
            var item = items[r.Next(0, items.Count)].Split(',');

            return string.Format("{0}\r\n{1}, {2} {3}", item[3].Trim(), item[1].Trim(), item[2].Trim(), item[0].Trim());
        }

        public string GenerateStreetNumber()
        {
            Random r = new Random();
            return r.Next(0, 10000).ToString();
        }

        public string GenerateStreetName()
        {
            var types = _repository.GetStreetTypes();
            Random r = new Random();
            return string.Format("{0}", types[r.Next(0, types.Count)]);
        }

        public string GenerateSubType()
        {
            var items = _repository.GetSubTypes();
            Random r = new Random();
            return items[r.Next(0, items.Count)];
        }

        public string GenerateSubNumber()
        {
            Random r = new Random();
            return r.Next(0, 100).ToString();
        }

        public string GenerateChineseAddress()
        {
            var items = _repository.GetChineseAddress();
            Random r = new Random();
            return items[r.Next(0, items.Count)];
        }

        public string GenerateChineseHomeTowns()
        {
            var items = _repository.GetChineseHomeTown();
            Random r = new Random();
            return items[r.Next(0, items.Count)];
        }
    }

}
