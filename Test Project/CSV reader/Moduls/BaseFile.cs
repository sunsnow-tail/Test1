using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSV_reader.Moduls
{
    /// <summary>
    /// common file data columns
    /// </summary>
    public class BaseFile
    {
        public long MeterPointCode { get; set; }

        public long SerialNumber { get; set; }

        public string PlantCode { get; set; }

        public DateTime DateTime { get; set; }

        public string DataType { get; set; }

        public string Status { get; set; }

        public string Units { get; set; }
    }
}
