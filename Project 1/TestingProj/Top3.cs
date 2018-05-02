using NUnit.Framework;
using System.Collections.Generic;
using System.Collections;
using Newtonsoft.Json;
using System.Linq;
using System;
using ClassProj;



namespace TestingProj
{
    [TestFixture()]
    public class TestTop3
    {
        [Test()]
        public void Top3()
        {
            List<decimal> test = new List<decimal>() { 4.4M, 4.2M, 4.4M, 1.2M, 22.0M, 10.0M };
            List<decimal> actual = new List<decimal>();
            List<decimal> expected = new List<decimal>() { 22.0M, 10.0M, 4.4M };

            var query = (from r in test
                         orderby r descending
                         select r).Take(3);

            foreach (var item in query)
            {
                actual.Add(item);
              

            }


            Assert.AreEqual(expected, actual);

        }
    }
}
