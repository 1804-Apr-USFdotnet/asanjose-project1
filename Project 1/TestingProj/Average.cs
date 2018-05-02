using NUnit.Framework;
using System;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;


namespace TestingProj
{
    [TestFixture()]
    public class TestAvg
    {
        [Test()]
        public void TestAverage()
        {
            List<decimal> dlist = new List<decimal> { 4.4M, 4.6M, 2.1M };
           var expected = ((4.4M + 4.6M + 2.1M)/3);
            var actual = (from r in dlist
                         select r).Average();


            Assert.AreEqual(expected, actual);

        }
    }
}