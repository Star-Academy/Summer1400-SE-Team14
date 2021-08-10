import org.junit.jupiter.api.Assertions;
import org.junit.jupiter.api.Test;

public class PreProcessingTest {
    @Test
    public void preProcessingTestValidPath() {
        Assertions.assertNotEquals("INVALID PATH!", PreProcessing.preprocesses("/EnglishData", ""));
    }

    @Test
    public void preProcessingTestInvalidPath() {
        Assertions.assertEquals("INVALID PATH!", PreProcessing.preprocesses("/EnglishDAta/12", ""));
    }
}
