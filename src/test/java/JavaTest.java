

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

    @Test
    public void preProcessingTestValidPath() {
        Assertions.assertNotEquals("INVALID PATH!", PreProcessing.preprocesses("/EnglishData", ""));
    }

    @Test
    public void preProcessingTestInvalidPath() {
        Assertions.assertEquals("INVALID PATH!", PreProcessing.preprocesses("/EnglishDAta/12", ""));
    }


    @Test
    public void getOrderTest() throws IOException {
        File file = new File(PreProcessing.class.getResource("/EnglishData/57110").getPath());
        InvertedIndex invertedIndex = new InvertedIndex();
        invertedIndex.indexFile(file);
        InputScanner inputScanner = new InputScanner(invertedIndex);
        Set<String> set = new HashSet<>();
        set.add(file.getPath());
        Assertions.assertEquals(set, inputScanner.getOrder("friend"));
    }

    @Test
    public void fetOrderPlusStrings() throws IOException {
        File file = new File(PreProcessing.class.getResource("/EnglishData/57110").getPath());
        InvertedIndex invertedIndex = new InvertedIndex();
        invertedIndex.indexFile(file);
        InputScanner inputScanner = new InputScanner(invertedIndex);
        Set<String> set = new HashSet<>();
        set.add(file.getPath());
        Assertions.assertEquals(set, inputScanner.getOrder("+friend"));
    }

    @Test
    public void fetOrderMinusStrings() throws IOException {
        File file = new File(PreProcessing.class.getResource("/EnglishData/57110").getPath());
        InvertedIndex invertedIndex = new InvertedIndex();
        invertedIndex.indexFile(file);
        InputScanner inputScanner = new InputScanner(invertedIndex);
        Set<String> set = new HashSet<>();
        Assertions.assertEquals(set, inputScanner.getOrder("+friend -male"));
    }
//    @Test
//    public void giveInput() throws IOException {
//        File file = new File(PreProcessing.class.getResource("/EnglishData/57110").getPath());
//        InvertedIndex invertedIndex = new InvertedIndex();
//        invertedIndex.indexFile(file);
//        new InputScannerView(invertedIndex, "friend");
//        Assertions.assertEquals(file.getPath(), outContent.toString());
//    }

    @Test
    public void checkFindCommonWords() {
        InvertedIndex invertedIndex = new InvertedIndex();
        Set<String> set = new HashSet<>();
        ArrayList<Set<String>> arrayList = new ArrayList<>();
        Assertions.assertEquals(invertedIndex.findCommonWords(arrayList), new HashSet<>());
        arrayList.add(set);
        set.add("asd");
        Assertions.assertEquals(set, invertedIndex.findCommonWords(arrayList));
        Set<String> set2 = new HashSet<>();
        set2.add("ass");
        arrayList.add(set2);
        Assertions.assertEquals(set, invertedIndex.findCommonWords(arrayList));

    }

    @Test
    public void checkDeleteGivenFiles(){
        InvertedIndex invertedIndex = new InvertedIndex();
        Set<String> set = new HashSet<>();
        set.add("asd");
        set.add("qwe");
        Set<String> set2 = new HashSet<>();
        set2.add("asd");
        set.removeAll(set2);
        Assertions.assertEquals(set, invertedIndex.deleteGivenFiles(set , set2));
    }

    @Test
    public void checkFindCommonFiles(){
        InvertedIndex invertedIndex = new InvertedIndex();
        Set<String> answer = new HashSet<>();
        Set<String> set = new HashSet<>();
        set.add("asd");
        set.add("qwe");
        Set<String> set2 = new HashSet<>();
        set2.add("asd");
        ArrayList<Set<String>> arrayList = new ArrayList<>();
        Assertions.assertEquals(new HashSet<>(), invertedIndex.findCommonFiles(answer , arrayList));

        arrayList.add(set);
        arrayList.add(set2);
        Assertions.assertEquals(set2, invertedIndex.findCommonFiles(answer , arrayList));
        answer.add("asd");

        Assertions.assertEquals(answer, invertedIndex.findCommonFiles(answer , arrayList));
        Assertions.assertEquals(answer, invertedIndex.findCommonFiles(answer , new  ArrayList<Set<String>>()));

    }
}
