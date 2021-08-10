import org.junit.jupiter.api.Assertions;
import org.junit.jupiter.api.Test;

import java.io.File;
import java.io.IOException;
import java.util.ArrayList;
import java.util.HashSet;
import java.util.List;
import java.util.Set;

public class InvertedIndexTests {

    @Test
    public void getFilesTest() throws IOException {
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
        Assertions.assertEquals(pathRoots, invertedIndex.search(wordsToSearch));
    }

    @Test
    public void checkFindCommonWordsForEmptySituation() {
        InvertedIndex invertedIndex = new InvertedIndex();
        ArrayList<Set<String>> arrayList = new ArrayList<>();
        Assertions.assertEquals(invertedIndex.findCommonWords(arrayList), new HashSet<>());
    }

    @Test
    public void checkFirstFindCommonWordsForUnEmptySituation() {
        InvertedIndex invertedIndex = new InvertedIndex();
        Set<String> set = new HashSet<>();
        ArrayList<Set<String>> arrayList = new ArrayList<>();
        arrayList.add(set);
        set.add("asd");
        Assertions.assertEquals(set, invertedIndex.findCommonWords(arrayList));
    }

    @Test
    public void checkSecondFindCommonWordsForUnEmptySituation() {
        InvertedIndex invertedIndex = new InvertedIndex();
        Set<String> set = new HashSet<>();
        ArrayList<Set<String>> arrayList = new ArrayList<>();
        arrayList.add(set);
        set.add("asd");
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
    public void checkFindCommonFiles1(){
        InvertedIndex invertedIndex = new InvertedIndex();
        Set<String> answer = new HashSet<>();
        ArrayList<Set<String>> arrayList = new ArrayList<>();
        Assertions.assertEquals(new HashSet<>(), invertedIndex.findCommonFiles(answer , arrayList));
    }

    @Test
    public void checkFindCommonFiles2(){
        InvertedIndex invertedIndex = new InvertedIndex();
        Set<String> answer = new HashSet<>();
        Set<String> set = new HashSet<>();
        set.add("asd");
        set.add("qwe");
        Set<String> set2 = new HashSet<>();
        set2.add("asd");
        ArrayList<Set<String>> arrayList = new ArrayList<>();
        arrayList.add(set);
        arrayList.add(set2);
        Assertions.assertEquals(set2, invertedIndex.findCommonFiles(answer , arrayList));

    }

    @Test
    public void checkFindCommonFiles3(){
        InvertedIndex invertedIndex = new InvertedIndex();
        Set<String> answer = new HashSet<>();
        Set<String> set = new HashSet<>();
        set.add("asd");
        set.add("qwe");
        Set<String> set2 = new HashSet<>();
        set2.add("asd");
        ArrayList<Set<String>> arrayList = new ArrayList<>();
        arrayList.add(set);
        arrayList.add(set2);
        answer.add("asd");
        Assertions.assertEquals(answer, invertedIndex.findCommonFiles(answer , arrayList));
    }

    @Test
    public void checkFindCommonFiles4(){
        InvertedIndex invertedIndex = new InvertedIndex();
        Set<String> answer = new HashSet<>();
        answer.add("asd");
        Assertions.assertEquals(answer, invertedIndex.findCommonFiles(answer , new  ArrayList<Set<String>>()));
    }

}
