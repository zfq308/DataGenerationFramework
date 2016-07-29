using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DataGenerationFramework.Core.GeneratorDataByRepository
{
    public interface IBusinessRepository
    {
        List<string> ChineseCommodities();
        List<string> ChineseCompanyName();
    }

    public class BusinessRepository : IBusinessRepository
    {
        public List<string> ChineseCommodities()
        {
            return LoadList("ChineseCommodities");
        }

        public List<string> ChineseCompanyName()
        {
            return LoadList("ChineseCompanyName");
        }

        private List<string> LoadList(string listToLoad)
        {
            var executingAssembly = Assembly.GetExecutingAssembly();
            var localNamespace = executingAssembly.GetName().Name;
            var resourceName = string.Format("{0}.Data.Business.{1}.txt", localNamespace, listToLoad);
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

    public interface IBusinessGenerator
    {
        string GenerateChineseCommodity();
        string GenerateChineseCompanyName();
    }

    public class BusinessGenerator : IBusinessGenerator
    {
        private IBusinessRepository _repository;
        private Random r = new Random();

        public BusinessGenerator(IBusinessRepository repository)
        {
            _repository = repository;
        }

        public string GenerateChineseCommodity()
        {
            var items = _repository.ChineseCommodities();
            return items[r.Next(0, items.Count)];
        }

        public string GenerateChineseCompanyName()
        {
            var items = _repository.ChineseCompanyName();
            return items[r.Next(0, items.Count)];
        }
    }
}
