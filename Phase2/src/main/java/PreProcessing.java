package main.java;

import java.io.File;
import java.io.IOException;
import java.net.URL;

public class PreProcessing {
    public static String preprocesses() {
        URL url = Main.class.getResource("../resources/EnglishData");
        if (url == null) return "INVALID PATH!";
        else {
            File directoryPath = new File(url.getPath());
            File[] filesList = directoryPath.listFiles();
            try {
                InvertedIndex index = new InvertedIndex();
                if (filesList == null) return "INVALID FILE LIST!";
                else {
                    addFilesToIndexFiles(filesList, index);
                    new InputScannerView(index);
                    return "end";
                }
            } catch (Exception e) {
                return "an error has happened!";
            }
        }
    }

    private static void addFilesToIndexFiles(File[] filesList, InvertedIndex index) throws IOException {
        for (File file : filesList) {
            index.indexFile(file);
        }
    }
}
