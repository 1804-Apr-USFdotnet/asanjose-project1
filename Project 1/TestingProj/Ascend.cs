using NUnit.Framework;
using System;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using ClassProj;


namespace TestingProj
{
    [TestFixture()]
    public class TestAscend
    {
        [Test()]
        public void TestAsc()
        {   int i = 0;
            Sorting sorting = new Sorting();
            var expected = new List<string>() { "1", "3", "4", "6" };
            var actual = new List<string>() { "3", "4", "1", "6" };



            var query = from r in actual
                        orderby r ascending
                        select r;

            foreach (var item in query)
            {

                actual[i] = item;
                i++;
            }

            Assert.AreEqual(expected, actual);

        }
    }
}