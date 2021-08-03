using System;
using System.Collections.Generic;
using Xunit;
using ConsoleApp1;

namespace TestProject1
{
    public class UnitTest1
    {
        [Fact]
        public void TestOne()
        {
            IInvertedIndex invertedIndex = new InvertedIndex();
            List<string> set = new List<string>();
            set.Add("asd");
            set.Add("qwe");
            List<string> set2 = new List<string>();
            set2.Add("asd");
            List<string> set3 = new List<string>();
            set3.Add("qwe");

            Assert.Equal(set3, invertedIndex.deleteGivenFiles(set, set2));
        }
    }
}