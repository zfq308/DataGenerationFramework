using System.Xml.Serialization;
using System.IO;

namespace DataGenerationFramework.Core
{
    static public class Storage
    {
        public static T LoadXml<T>(string fileName) where T : class, new()
        {
            T loadedObject = null;
            XmlSerializer serializer = new XmlSerializer(typeof(T));
            if (File.Exists(fileName))
                using (var stream = new FileStream(fileName, FileMode.Open))

                {
                    if (stream != null)
                    {
                        if (stream.Length > 0)
                        {
                            loadedObject = (T)serializer.Deserialize(stream);
                        }
                        stream.Close();
                    }
                }
            return loadedObject;
        }

        public static void SaveXml<T>(string fileName, T objectToSave)
        {
            using (var stream = new FileStream(fileName, FileMode.Create))
            {
                if (stream != null)
                {
                    XmlSerializer xs = new XmlSerializer(typeof(T));
                    xs.Serialize(stream, objectToSave);
                    stream.Flush();
                }
            }
        }
    }
}
