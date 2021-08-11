using System;
using System.Collections.Generic;
using ConsoleApp1;
using Xunit;

namespace TestProject1
{
    public class InvertedIndexTest
    {
        [Fact]
        public void DeleteGivenFiles_ShouldDeleteFiles_WhenIsGivenTwoLists()
        {
            IInvertedIndex invertedIndex = new InvertedIndex();
            HashSet<string> set = new HashSet<string>() {"asd", "qwe"};

            HashSet<string> set2 = new HashSet<string>() {"asd"};
            List<string> set3 = new List<string>() {"qwe"};

            Assert.Equal(set3, invertedIndex.DeleteGivenFiles(set, set2));
        }

        [Fact]
        public void FindCommonWords_ShoulReturnNull_WhenGivenListIsNull()
        {
            IInvertedIndex invertedIndex = new InvertedIndex();
            List<HashSet<String>> arrayList = new List<HashSet<string>>();
            Assert.Equal(invertedIndex.FindCommonWords(arrayList), new HashSet<string>());
        }

        [Fact]
        public void FindCommonWords_ShouldReturnList_WhenHasOneImput()
        {
            IInvertedIndex invertedIndex = new InvertedIndex();
            HashSet<String> set = new HashSet<string>() {"asd"};

            List<HashSet<String>> arrayList = new List<HashSet<string>>();
            arrayList.Add(set);
            Assert.Equal(set, invertedIndex.FindCommonWords(arrayList));
        }

        [Fact]
        public void FindCommonWords_ShouldGiveCommonsBetween_WhenIsGivenTwoLists()
        {
            IInvertedIndex invertedIndex = new InvertedIndex();
            HashSet<String> set = new HashSet<string>() {"asd"};
            List<HashSet<String>> arrayList = new List<HashSet<string>>();
            arrayList.Add(set);
            HashSet<String> set2 = new HashSet<string>() {"ass"};

            arrayList.Add(set2);
            Assert.Equal(set, invertedIndex.FindCommonWords(arrayList));
        }


        [Fact]
        public void DeleteGivenFiles_ShouldDeleteDifferentFiles_WhenIsGivenLists()
        {
            InvertedIndex invertedIndex = new InvertedIndex();
            HashSet<string> set = new HashSet<string>() {"asd", "qwe"};
           
            HashSet<string> set2 = new HashSet<string>(){"asd"};
            HashSet<string> set3 = new HashSet<string>(){"qwe"};
            Assert.Equal(set3, invertedIndex.DeleteGivenFiles(set, set2));
        }
    }
}