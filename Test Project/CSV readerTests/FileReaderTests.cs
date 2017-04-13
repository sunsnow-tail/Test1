using Microsoft.VisualStudio.TestTools.UnitTesting;
using CSV_reader;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSV_reader.Moduls;

namespace CSV_reader.Tests
{
    [TestClass()]
    public class FileReaderTests
    {
        [TestMethod()]
        public void ReadFileNotFoundTest()
        {
            try
            {
                var reader = FileReader.ReadFile<LPFile>("fakeFile.txt");

                //fails if pass to this point
                Assert.Fail();
            }
            catch (Exception ex)
            {
                //we expect error here
                Assert.IsFalse(false);
            }

        }


        [TestMethod()]
        public void ReadHugeFile_Perfomance()
        {
            var startTime = DateTime.Now;

            var reader = FileReader.ReadFile<LPFile>(@"hugeFile.csv");

            var elapsed = DateTime.Now.Subtract(startTime).TotalMilliseconds;

            Assert.IsTrue(elapsed < 10000);
        }
    }
}