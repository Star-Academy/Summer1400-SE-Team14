package main.java;

import java.io.File;
import java.io.IOException;
import java.net.URL;

public class PreProcessing {
    public static void preprocesses() {
        URL url = Main.class.getResource("../resources/EnglishData");
        if (url == null) System.out.println("INVALID PATH!");
        else {
            File directoryPath = new File(url.getPath());
            File[] filesList = directoryPath.listFiles();
            try {
                InvertedIndex idx = new InvertedIndex();
                if (filesList == null) System.out.println("INVALID FILE LIST!");
                else {
                    addFilesToIndexFiles(filesList, idx);
                    new TakeInput(idx);
                }
            } catch (Exception e) {
                e.printStackTrace();
            }
        }
    }

    private static void addFilesToIndexFiles(File[] filesList, InvertedIndex idx) throws IOException {
        for (File file : filesList) {
            idx.indexFile(file);
        }
    }
}
