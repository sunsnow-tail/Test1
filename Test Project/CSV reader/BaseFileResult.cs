using CSV_reader.Moduls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSV_reader
{
    internal class BaseFileResult
    {
        protected string _fileName;

        //keep average here in case if data is big
        protected decimal? _avg;

        public string FileName
        {
            get
            {
                return _fileName;
            }
        }
    }
}
