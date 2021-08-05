using System;
using System.Collections.Generic;
using Xunit;
using ConsoleApp1;

namespace TestProject1
{
    public class UnitTest1
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
        public void TestFindCommonWords()
        {
            IInvertedIndex invertedIndex = new InvertedIndex();
            HashSet<String> set = new HashSet<string>();
            List<HashSet<String>> arrayList = new List<HashSet<string>>();
            Assert.Equal(invertedIndex.FindCommonWords(arrayList), new HashSet<string>());
            arrayList.Add(set);
            set.Add("asd");
            Assert.Equal(set, invertedIndex.FindCommonWords(arrayList));
            HashSet<String> set2 = new HashSet<string>();
            set2.Add("ass");
            arrayList.Add(set2);
            Assert.Equal(set, invertedIndex.FindCommonWords(arrayList));
        }

        [Fact]
        public void TestCheckFindCommonFiles()
        {
            IInvertedIndex invertedIndex = new InvertedIndex();
            HashSet<string> answer = new HashSet<string>();
            HashSet<string> set = new HashSet<string>();
            set.Add("asd");
            set.Add("qwe");
            HashSet<string> set2 = new HashSet<string>();
            set2.Add("asd");
            List<HashSet<string>> arrayList = new List<HashSet<string>>();
            Assert.Equal(new HashSet<string>(), invertedIndex.FindCommonFiles(answer, arrayList));

            arrayList.Add(set);
            arrayList.Add(set2);
            Assert.Equal(set2, invertedIndex.FindCommonFiles(answer, arrayList));
            answer.Add("asd");

            Assert.Equal(answer, invertedIndex.FindCommonFiles(answer, arrayList));
            Assert.Equal(answer, invertedIndex.FindCommonFiles(answer, new List<HashSet<string>>()));
        }


        [Fact]
        public void test()
        {
            IInvertedIndex invertedIndex = new InvertedIndex();
            invertedIndex.IndexFile("C:\\Users\\ASUS\\RiderProjects\\Phase-5\\EnglishData\\");
            List<string> filesTest = new List<string>();
            filesTest.Add(@"C:\Users\ASUS\RiderProjects\Phase-5\EnglishData\57110");
            Assert.Equal(filesTest, invertedIndex.GetFiles());
        }

        [Fact]
        public void searchTest()
        {
            InvertedIndex invertedIndex = new InvertedIndex();
            invertedIndex.IndexFile("C:\\Users\\ASUS\\RiderProjects\\Phase-5\\EnglishData\\");

            List<string> wordsToSearch = new List<string>();
            wordsToSearch.Add("friend");
            HashSet<string> pathRoots = new HashSet<string>();
            pathRoots.Add(@"C:\Users\ASUS\RiderProjects\Phase-5\EnglishData\57110");
            Assert.Equal(invertedIndex.Search(wordsToSearch), pathRoots);
        }

        [Fact]
        public void checkDeleteGivenFiles() {
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