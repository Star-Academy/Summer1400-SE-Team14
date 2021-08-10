import org.junit.jupiter.api.Assertions;
import org.junit.jupiter.api.Test;

import java.io.File;
import java.io.IOException;
import java.util.HashSet;
import java.util.Set;

public class InputScannerTest {

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
}
