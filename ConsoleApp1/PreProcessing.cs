﻿using System;
using System.IO;

namespace ConsoleApp1
{
    public class PreProcessing
    {
        static string invalidPathString = "INVALID PATH!";

        public static string Preprocesses()
        {
            //TODO
            string[] files =
                Directory.GetFiles(@"C:\\Users\\mjmah\\OneDrive\\Desktop\\Summer1400-SE-Team14999\\TestProject1\\57110",
                    "*.txt");

            try
            {
                IInvertedIndex index = new InvertedIndex();

                addFilesToIndexFiles(files, index);
                new InputScannerView(index);
                return "end";
            }
            catch (Exception e)
            {
                return "an error has happened!";
            }
        }

        private static void addFilesToIndexFiles(string[] filesList, IInvertedIndex index)
        {
            index.IndexFile(filesList);
        }
    }
}