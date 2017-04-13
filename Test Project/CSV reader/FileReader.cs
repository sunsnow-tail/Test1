using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.IO;

namespace CSV_reader
{
    public static class FileReader
    {
        /// <summary>
        /// read the file. LP or TOU
        /// </summary>
        /// <typeparam name="TFile"></typeparam>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public static IEnumerable<TFile> ReadFile<TFile>(string filePath)
        {
            if (!File.Exists(filePath)) throw new FileNotFoundException("File " + filePath + " is not found");

            var lines = File.ReadLines(filePath).Select(a => a.Split(','));
            string[] header = lines.Take(1).First();

            var returnData = lines.Skip(1).Select(p => GetFileLine<TFile>(p, header));

            return returnData;
        }

        /// <summary>
        /// turn file to T type by reading properties and the file header
        /// </summary>
        /// <typeparam name="TFile"></typeparam>
        /// <param name="line"></param>
        /// <returns></returns>
        private static TFile GetFileLine<TFile>(string[] line, string[] header)
        {
            var obj = Activator.CreateInstance<TFile>();

            var objProps = obj.GetType().GetProperties();

            for (var index = 0; index < line.Count(); index++)
            {
                var headerItem = header[index].Replace(" ", "").Replace(@"/", "").ToLower();

                if (objProps.Any(p => (p.Name.ToLower()).Equals(headerItem)))
                {
                    var propInfo =
                        objProps.First(p => (p.Name.ToLower()).Equals(headerItem));

                    Type type = propInfo.PropertyType;

                    propInfo.SetValue(obj, line[index].ToType(type));
                }
            }

            return obj;
        }
    }
}
