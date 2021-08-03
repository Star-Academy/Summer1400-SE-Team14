package main.java;

import java.util.*;
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
        Set<String> answerFoundCommon = index.findCommonFiles(answer, commons);
        Set<String> answerDeletedFiles = index.deleteGivenFiles(answerFoundCommon, toDelete);
        return answerDeletedFiles;
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
