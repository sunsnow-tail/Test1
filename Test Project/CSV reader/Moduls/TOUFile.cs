using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSV_reader.Moduls
{
    public class TOUFile : BaseFile
    {
        public decimal Energy { get; set; }

        public decimal MaximumDemand { get; set; }

        public DateTime TimeOfMaxDemand { get; set; }

        public string Period { get; set; }

        public bool DLSActive { get; set; }

        public int BillingResetCount { get; set; }

        public DateTime BillingResetDateTime { get; set; }

        public string Rate { get; set; }

    }
}
