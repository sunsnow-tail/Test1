using Microsoft.VisualStudio.TestTools.UnitTesting;
using CSV_reader;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSV_reader.Tests
{
    [TestClass()]
    public class CalculatorTests
    {
        [TestMethod()]
        public void GetTwentyPrctAboveAverageTest()
        {
            var values = new decimal[] { 10, 100, 50, 40 };

            var result = Calculator.GetTwentyPrctAboveAverage(values, (decimal)50);

            CollectionAssert.AreEqual(new List<decimal>() { 100 }, result);
        }

        [TestMethod()]
        public void GetTwentyPrctAboveAverageTest2()
        {
            var values = new decimal[] { 10, 10, 50, 130 };

            var result = Calculator.GetTwentyPrctAboveAverage(values, (decimal)50);

            CollectionAssert.AreNotEqual(new List<decimal>() { 100 }, result);
        }

        [TestMethod()]
        public void GetTwentyPrctBelowAverageTest()
        {
            var values = new decimal[] { 10, 110, 50, 30 };

            var result = Calculator.GetTwentyPrctBelowAverage(values, (decimal)50);

            CollectionAssert.AreEqual(new List<decimal>() { 10, 30 }, result);
        }

        [TestMethod()]
        public void GetTwentyPrctBelowAverageTest2()
        {
            var values = new decimal[] { 10, 110, 50, 30 };

            var result = Calculator.GetTwentyPrctBelowAverage(values, (decimal)50);

            CollectionAssert.AreNotEqual(new List<decimal>() { 10, 40 }, result);
        }

        [TestMethod()]
        public void GetAverageTest()
        {
            var values = new decimal[] { 10, 100, 50, 40 };

            var result = Calculator.GetAverage(values);

            Assert.AreEqual((decimal)50, result);
        }

        [TestMethod()]
        public void GetAverageTest2()
        {
            var values = new decimal[] { 1, 1, 2, 2 };

            var result = Calculator.GetAverage(values);

            Assert.AreEqual((decimal)1.5, result);
        }
    }
}