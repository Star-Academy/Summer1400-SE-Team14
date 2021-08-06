using System;

namespace ConsoleApp1
{
    public class ViewPreProcessing
    {
        public ViewPreProcessing()
        {
            while (true)
            {
                string result = PreProcessing.Preprocesses();
                if (string.Equals("end", result))
                {
                    return;
                }

                Console.WriteLine(result);
            }
        }
    }
}