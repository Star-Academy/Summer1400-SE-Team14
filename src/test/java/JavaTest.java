

import org.junit.jupiter.api.Assertions;
import org.junit.jupiter.api.Test;

import java.io.File;
import java.io.IOException;
import java.util.ArrayList;
import java.util.HashSet;
import java.util.List;
import java.util.Set;

public class JavaTest {
    @Test
    public void test() throws IOException {
        File file = new File(PreProcessing.class.getResource("/EnglishData/57110").getPath());
        InvertedIndex invertedIndex = new InvertedIndex();
        invertedIndex.indexFile(file);
        List<String> filesTest = new ArrayList<>();
        filesTest.add(file.getPath());
        Assertions.assertEquals(filesTest, invertedIndex.getFiles());
    }

    @Test
    public void searchTest() throws IOException {
        File file = new File(PreProcessing.class.getResource("/EnglishData/57110").getPath());
        InvertedIndex invertedIndex = new InvertedIndex();
        invertedIndex.indexFile(file);

        ArrayList<String> wordsToSearch = new ArrayList<>();
        wordsToSearch.add("friend");
        Set<String> pathRoots = new HashSet<>();
        pathRoots.add(file.getPath());
        Assertions.assertEquals(invertedIndex.search(wordsToSearch), pathRoots);
    }
}
