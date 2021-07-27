package main.java;

import java.util.*;
import java.util.regex.Matcher;
import java.util.regex.Pattern;

public class InputScanner {

    public InputScanner(InvertedIndex index) {
        getOrder(index);
    }

    public void getOrder(InvertedIndex index) {
        Scanner scanner = new Scanner(System.in);
        while (true) {
            String input = scanner.nextLine();
            if (input.equals("--back")) break;
            String[] inputSplit = splitInput(input);
            ArrayList<String> plusStrings = new ArrayList<>();
            ArrayList<String> minusStrings = new ArrayList<>();
            ArrayList<String> normalStrings = new ArrayList<>();
            for (String string : inputSplit)
                addItemToOneOfThreeArrayLists(string, plusStrings, minusStrings, normalStrings);
            showResult(processes(index, plusStrings, minusStrings, normalStrings));
        }
        scanner.close();
    }

    private String[] splitInput(String input) {
        return input.split("(\\s+)");
    }

    private void showResult(Set<String> answer) {
        for (String s : answer) System.out.println(s);
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
        Pattern pattern = Pattern.compile("^\\+(.+)$");
        Matcher matcher = pattern.matcher(string);
        Pattern pattern1 = Pattern.compile("^-(.+)$");
        Matcher matcher1 = pattern1.matcher(string);
        if (matcher.find()) {
            String a = matcher.group(1);
            plusStrings.add(a);
        } else if (matcher1.find()) {
            String a = matcher1.group(1);
            minusStrings.add(a);
        } else normalStrings.add(string);
    }

}
