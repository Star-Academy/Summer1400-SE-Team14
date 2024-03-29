import java.util.ArrayList;
import java.util.Set;
import java.util.regex.Matcher;
import java.util.regex.Pattern;

public class InputScanner {
    private InvertedIndex index;

    public InputScanner(InvertedIndex index) {
        this.index = index;
    }


    public Set<String> getOrder(String input) {
        String[] inputSplit = splitInput(input);
        ArrayList<String> plusStrings = new ArrayList<>();
        ArrayList<String> minusStrings = new ArrayList<>();
        ArrayList<String> normalStrings = new ArrayList<>();
        for (String string : inputSplit)
            addItemToOneOfThreeArrayLists(string, plusStrings, minusStrings, normalStrings);
        return processes(index, plusStrings, minusStrings, normalStrings);
    }

    private String[] splitInput(String input) {
        return input.split("(\\s+)");
    }


    private Set<String> processes(InvertedIndex index, ArrayList<String> plusStrings, ArrayList<String> minusStrings, ArrayList<String> normalStrings) {
        Set<String> answer = index.search(plusStrings);
        Set<String> toDelete = index.search(minusStrings);
        ArrayList<Set<String>> commons = new ArrayList<>();
        for (String normalString : normalStrings) {
            ArrayList<String> arrayList = new ArrayList<>();
            arrayList.add(normalString);
            commons.add(index.search(arrayList));
        }
        answer = index.findCommonFiles(answer, commons);
        answer = index.deleteGivenFiles(answer, toDelete);
        return answer;
    }

    private void addItemToOneOfThreeArrayLists(String string, ArrayList<String> plusStrings, ArrayList<String> minusStrings, ArrayList<String> normalStrings) {
        Pattern patternForPlusWords = Pattern.compile("^\\+(.+)$");
        Matcher matcherForPlusWords = patternForPlusWords.matcher(string);
        Pattern patternForMinusWords = Pattern.compile("^-(.+)$");
        Matcher matcherForMinusWords = patternForMinusWords.matcher(string);
        if (matcherForPlusWords.find()) {
            String a = matcherForPlusWords.group(1);
            plusStrings.add(a);
        } else if (matcherForMinusWords.find()) {
            String a = matcherForMinusWords.group(1);
            minusStrings.add(a);
        } else normalStrings.add(string);
    }

}
