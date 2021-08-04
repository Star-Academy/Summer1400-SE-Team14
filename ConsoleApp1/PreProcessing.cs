using System.IO;

namespace ConsoleApp1
{

    public class PreProcessing
    {
        static string invalidPathString = "INVALID PATH!";

        public static string preprocesses()
        {
            //TODO?
            URL url = PreProcessing.class.getResource("../resources/EnglishData");
            if (url == null) return invalidPathString;
            else
            {
                File directoryPath = new File(url.getPath());
                File[] filesList = directoryPath.listFiles();
                try
                {
                    InvertedIndex index = new InvertedIndex();
                    if (filesList == null) return "INVALID FILE LIST!";
                    else
                    {
                        addFilesToIndexFiles(filesList, index);
                        new InputScannerView(index);
                        return "end";
                    }
                }
                catch (Exception e)
                {
                    return "an error has happened!";
                }
            }
        }

        private static void addFilesToIndexFiles(File[] filesList, InvertedIndex index) throws IOException
        {
            // for (File file : filesList) {
            //     index.indexFile(file);
            // }
            get { throw new System.NotImplementedException(); }
            set { throw new System.NotImplementedException(); }
        }
    }

}

