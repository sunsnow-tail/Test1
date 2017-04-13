using CSV_reader.Moduls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using CSV_reader.Modules;

namespace CSV_reader
{
    internal class LPFileResult : BaseFileResult, IFileResult
    {
        List<LPFile> fileData = new List<LPFile>();
        
        internal LPFileResult(string filePath)
        {
            fileData = FileReader.ReadFile<LPFile>(filePath).ToList();

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
                return Calculator.GetTwentyPrctAboveAverage(fileData.Select(p => p.DataValue), this.AverageValue);
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
                return Calculator.GetTwentyPrctBelowAverage(fileData.Select(p => p.DataValue), this.AverageValue);
            }
        }

        /// <summary>
        /// median value using the "Data Value" column for the "LP" file type 
        /// </summary>
        /// <returns></returns>
        public decimal AverageValue
        {
            get
            {
                if (base._avg != null) return _avg.Value;

                base._avg = Calculator.GetAverage(fileData.Select(p => p.DataValue));

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
