

import org.junit.jupiter.api.Assertions;
import org.junit.jupiter.api.Test;

import java.io.File;
import java.io.IOException;
import java.util.ArrayList;
import java.util.List;

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
}
