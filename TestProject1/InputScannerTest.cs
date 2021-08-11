using System;
using System.Collections.Generic;
using Xunit;
using ConsoleApp1;
using NSubstitute;

namespace TestProject1
{
    public class UnitTest1
    {
       
        [Fact]
        public void InputScannerTest()
        {
            IInvertedIndex invertedIndex = Substitute.For<IInvertedIndex>();
            List<string> list = new List<string>();
            list.Add("friend");
            HashSet<string> answer = new HashSet<string>();
            answer.Add("C:\\Users\\mjmah\\OneDrive\\Desktop\\Summer1400-SE-Team14999\\TestProject1\\57110");
            invertedIndex.Search(list).Returns(answer);
            List<string> list2 = new List<string>();
            list2.Add("boy");
            invertedIndex.Search(list2).Returns(new HashSet<string>());
            InputScanner inputScanner = new InputScanner(invertedIndex);

            Assert.Null(inputScanner.GetOrder("+friend"));
        }
    }
}