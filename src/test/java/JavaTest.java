

import org.junit.After;
import org.junit.Before;
import org.junit.jupiter.api.Assertions;
import org.junit.jupiter.api.Test;

import java.io.ByteArrayOutputStream;
import java.io.File;
import java.io.IOException;
import java.io.PrintStream;
import java.util.ArrayList;
import java.util.HashSet;
import java.util.List;
import java.util.Set;

public class JavaTest {

    private final ByteArrayOutputStream outContent = new ByteArrayOutputStream();
    private final PrintStream originalOut = System.out;


    @Before
    public void setUpStreams() {
        System.setOut(new PrintStream(outContent));
    }

    @After
    public void restoreStreams() {
        System.setOut(originalOut);
    }

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

//    @Test
//    public void preProcessingTest() {
//        Assertions.assertEquals(PreProcessing.preprocesses("/EnglishDaTA"), "INVALID PATH!");
//    }

    @Test
    public void giveInput() throws IOException {
        File file = new File(PreProcessing.class.getResource("/EnglishData/57110").getPath());
        InvertedIndex invertedIndex = new InvertedIndex();
        invertedIndex.indexFile(file);

        InputScannerView inputScannerView = new InputScannerView(invertedIndex, "friend");
        Assertions.assertEquals(file.getPath(), outContent.toString());
    }
}
