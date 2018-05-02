using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using ClassProj;


namespace TestingProj
{
    [TestFixture()]
    public class TestDescend
    {
        [Test()]
        public void TestDesc()
        {
            int i = 0;
            
            Sorting sorting = new Sorting();
            var expected = new List<string>() { "6", "4" , "3", "1" };
            var actual = new List<string>() { "3", "4", "1", "6" };


            var query = from r in actual
                        orderby r descending
                        select r;

            foreach(var item in query){

                actual[i] = item;
                i++;
            }

            Assert.AreEqual(expected, actual);

        }
    }
}