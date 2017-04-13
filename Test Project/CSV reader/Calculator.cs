using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSV_reader
{
    /// <summary>
    /// calculate some math operations to provided data
    /// </summary>
    public static class Calculator
    {
        /// <summary>
        /// values that are 20% above the average;
        /// </summary>
        /// <param name="data"></param>
        /// <param name="medianValue"></param>
        /// <returns></returns>
        public static List<decimal> GetTwentyPrctAboveAverage(IEnumerable<decimal> data, decimal medianValue)
        {
            var v20prct = medianValue * (decimal)0.2;

            return data.Where(p => p > (medianValue + v20prct)).ToList();
        }

        /// <summary>
        /// values that are 20% below the average;
        /// </summary>
        /// <param name="data"></param>
        /// <param name="medianValue"></param>
        /// <returns></returns>
        public static List<decimal> GetTwentyPrctBelowAverage(IEnumerable<decimal> data, decimal medianValue)
        {
            var v20prct = medianValue * (decimal)0.2;

            return data.Where(p => p < (medianValue - v20prct)).ToList();
        }

        public static decimal GetAverage(IEnumerable<decimal> data)
        {
            return data.Average(p => p);
        }
    }
}
