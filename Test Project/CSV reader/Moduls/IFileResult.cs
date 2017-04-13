using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSV_reader.Modules
{
    public interface IFileResult
    {
        /// <summary>
        /// average value using a) the "Data Value" column for the "LP" file type or b) or the "Energy" column for the "TOU" file type
        /// </summary>
        /// <returns></returns>
        decimal AverageValue { get; }

        /// <summary>
        ///  20% above the median
        /// </summary>
        /// <returns></returns>
        List<decimal> TwentyPrctAboveAverage { get; }

        /// <summary>
        ///  20% below the median
        /// </summary>
        /// <returns></returns>
        List<decimal> TwentyPrctBelowAverage { get; }

        /// <summary>
        /// file date with starting time as a file is generated per day.
        /// </summary>
        /// <returns></returns>
        DateTime FileDate { get; }

        string FileName { get; }
    }
}
