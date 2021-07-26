package main.java;

import java.io.File;
import java.net.URL;

public class Main {
    public static void main(String[] args) {
        preprocesses();
    }

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
                    for (File file : filesList) {
                        idx.indexFile(file);
                    }
                    new TakeInput(idx);
                }
            } catch (Exception e) {
                e.printStackTrace();
            }
        }
    }
}
