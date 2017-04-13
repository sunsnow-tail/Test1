using CSV_reader.Modules;
using CSV_reader.Moduls;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSV_reader
{
    internal class TOUFileResult : BaseFileResult, IFileResult
    {
        List<TOUFile> fileData = new List<TOUFile>();

        internal TOUFileResult(string filePath)
        {
            fileData = FileReader.ReadFile<TOUFile>(filePath).ToList();

            var fileInfo = new FileInfo(filePath);

            base._fileName = fileInfo.Name;
        }

        /// <summary>
        ///  20% above the median
        /// </summary>
        /// <returns></returns>
        public List<decimal> TwentyPrctAboveAverage
        {
            get
            {
                return Calculator.GetTwentyPrctAboveAverage(fileData.Select(p => p.Energy), this.AverageValue);
            }
        }

        /// <summary>
        ///  20% below the median
        /// </summary>
        /// <returns></returns>
        public List<decimal> TwentyPrctBelowAverage
        {
            get
            {
                return Calculator.GetTwentyPrctBelowAverage(fileData.Select(p => p.Energy), this.AverageValue);
            }
        }

        /// <summary>
        /// median value using the "Energy" column for the "TOU" file type
        /// </summary>
        /// <returns></returns>
        public decimal AverageValue
        {
            get
            {
                if (base._avg != null) return base._avg.Value;

                base._avg = Calculator.GetAverage(fileData.Select(p => p.Energy));

                return base._avg.Value;
            }
        }

        public DateTime FileDate
        {
            get
            {
                return fileData.Select(p => p.DateTime).First();
            }
        }
    }
}
