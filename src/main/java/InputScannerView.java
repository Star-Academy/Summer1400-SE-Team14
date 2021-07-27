import java.util.Scanner;
import java.util.Set;

public class InputScannerView {
    public InputScannerView(InvertedIndex index) {
        Scanner scanner = new Scanner(System.in);
        InputScanner inputScanner = new InputScanner(index);
        while (true) {
            String input = scanner.nextLine();
            if (input.equals("--back")) break;
            showResult(inputScanner.getOrder(input));
        }
        scanner.close();

    }

    private void showResult(Set<String> answer) {
        for (String s : answer) System.out.println(s);
    }

}

