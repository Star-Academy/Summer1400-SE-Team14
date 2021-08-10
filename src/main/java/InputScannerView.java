import java.util.Scanner;
import java.util.Set;

public class InputScannerView {

    private Scanner scanner;
    private InputScanner inputScanner;

    public InputScannerView(InvertedIndex index) {
        this.scanner = new Scanner(System.in);
        this.inputScanner = new InputScanner(index);
    }

    public void start(String string) {
        if (!string.isEmpty()) {
            while (true) {
                string = scanner.nextLine();
                if (string.equals("--back")) break;
                showResult(inputScanner.getOrder(string));
            }
        }
        scanner.close();
    }

    private void showResult(Set<String> answer) {
        for (String s : answer) System.out.println(s);
    }

}

