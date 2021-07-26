package main.java;

import java.io.File;
import java.net.URL;
import java.util.Objects;

public class Main {
    public static void main(String[] args) {
        preprocesses();
    }

    public static void preprocesses() {
        URL url = Main.class.getResource("../resources/EnglishData");
        assert url != null;
        File directoryPath = new File(url.getPath());
        File[] filesList = directoryPath.listFiles();
        try {
            InvertedIndex idx = new InvertedIndex();
            for (File file : Objects.requireNonNull(filesList)) {
                idx.indexFile(file);
            }
            new TakeInput(idx);
        } catch (Exception e) {
            e.printStackTrace();
        }
    }
}
