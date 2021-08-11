using System;
using System.Collections.Generic;
using ConsoleApp1;
using Xunit;

namespace TestProject1
{
    public class InvertedIndexTest
    {
       [Fact]
        public void TestDeleteGivenFiles()
        {
            IInvertedIndex invertedIndex = new InvertedIndex();
            HashSet<string> set = new HashSet<string>();
            set.Add("asd");
            set.Add("qwe");
            HashSet<string> set2 = new HashSet<string>();
            set2.Add("asd");
            List<string> set3 = new List<string>();
            set3.Add("qwe");

            Assert.Equal(set3, invertedIndex.DeleteGivenFiles(set, set2));
        }

        [Fact]
        public void TestFindCommonWords_TestingNull()
        {
            IInvertedIndex invertedIndex = new InvertedIndex();
            List<HashSet<String>> arrayList = new List<HashSet<string>>();
            Assert.Equal(invertedIndex.FindCommonWords(arrayList), new HashSet<string>());
            
        } 
        [Fact]
         public void TestFindCommonWords_BasicTest()
         {
             IInvertedIndex invertedIndex = new InvertedIndex();
             HashSet<String> set = new HashSet<string>();
             List<HashSet<String>> arrayList = new List<HashSet<string>>();
             arrayList.Add(set);
             set.Add("asd");
             Assert.Equal(set, invertedIndex.FindCommonWords(arrayList));
           
         }
        
        [Fact]
        public void TestFindCommonWords_HardTest()
        {
            IInvertedIndex invertedIndex = new InvertedIndex();
            HashSet<String> set = new HashSet<string>();
            List<HashSet<String>> arrayList = new List<HashSet<string>>();
            arrayList.Add(set);
            set.Add("asd");
            HashSet<String> set2 = new HashSet<string>();
            set2.Add("ass");
            arrayList.Add(set2);
            Assert.Equal(set, invertedIndex.FindCommonWords(arrayList));
        }
        

        [Fact]
        public void CheckDeleteGivenFiles()
        {
            InvertedIndex invertedIndex = new InvertedIndex();
            HashSet<string> set = new HashSet<string>();
            set.Add("asd");
            set.Add("qwe");
            HashSet<string> set2 = new HashSet<string>();
            set2.Add("asd");
            HashSet<string> set3 = new HashSet<string>();
            set3.Add("qwe");
            Assert.Equal(set3, invertedIndex.DeleteGivenFiles(set, set2));
        }
  
    }
}