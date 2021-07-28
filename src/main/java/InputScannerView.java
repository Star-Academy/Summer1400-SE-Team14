import java.util.Scanner;
import java.util.Set;

public class InputScannerView {
    public InputScannerView(InvertedIndex index, String string) {
        Scanner scanner = new Scanner(System.in);
        InputScanner inputScanner = new InputScanner(index);
        if (!string.equals("")) {
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

