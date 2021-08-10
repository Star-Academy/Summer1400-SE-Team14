import java.io.BufferedReader;
import java.io.File;
import java.io.FileReader;
import java.io.IOException;
import java.util.*;
import java.util.regex.Matcher;
import java.util.regex.Pattern;

public class InvertedIndex {
    List<String> stopWords = Arrays.asList("a", "able", "about",
            "across", "after", "all", "almost", "also", "am", "among", "an",
            "and", "any", "are", "as", "at", "be", "because", "been", "but",
            "by", "can", "cannot", "could", "dear", "did", "do", "does",
            "either", "else", "ever", "every", "for", "from", "get", "got",
            "had", "has", "have", "he", "her", "hers", "him", "his", "how",
            "however", "i", "if", "in", "into", "is", "it", "its", "just",
            "least", "let", "like", "likely", "may", "me", "might", "most",
            "must", "my", "neither", "no", "nor", "not", "of", "off", "often",
            "on", "only", "or", "other", "our", "own", "rather", "said", "say",
            "says", "she", "should", "since", "so", "some", "than", "that",
            "the", "their", "them", "then", "there", "these", "they", "this",
            "tis", "to", "too", "twas", "us", "wants", "was", "we", "were",
            "what", "when", "where", "which", "while", "who", "whom", "why",
            "will", "with", "would", "yet", "you", "your");

    Map<String, List<FileInfo>> indexedWords = new HashMap<>();
    List<String> files = new ArrayList<>();

    public void indexFile(File file) throws IOException {
        int fileNumber = files.indexOf(file.getPath());
        if (fileNumber == -1) {
            files.add(file.getPath());
            fileNumber = files.size() - 1;
        }
        BufferedReader reader = new BufferedReader(new FileReader(file));
        convertFileToTokens(reader, fileNumber);
    }

    private void convertFileToTokens(BufferedReader reader, int fileNumber) throws IOException {
        for (String line = reader.readLine(); line != null; line = reader.readLine()) {
            importWordsInList(line, fileNumber);
        }
    }

    private void importWordsInList(String line, int fileNumber) {
        for (String wordsInFiles : line.split("\\W+")) {
            wordsInFiles = normalize(wordsInFiles);
            if (stopWords.contains(wordsInFiles))
                continue;
            List<FileInfo> idx = indexedWords.computeIfAbsent(wordsInFiles, k -> new LinkedList<>());
            idx.add(new FileInfo(fileNumber));
        }
    }

    private String normalize(String wordsInFiles) {
        return wordsInFiles.toLowerCase();
    }

    public Set<String> search(ArrayList<String> wordsToFind) {
        Set<String> answer = new HashSet<>();
        wordsToFind = normalizeInputWords(wordsToFind);
        for (String word : wordsToFind) findWordInFiles(word, answer);
        return answer;
    }

    private void findWordInFiles(String word, Set<String> answer) {
        for (String key : indexedWords.keySet()) checkCommandMatcher(word, key, answer);
    }

    private void checkCommandMatcher(String word, String key, Set<String> answer) {
        Matcher matcher = Pattern.compile(word).matcher(key);
        if (matcher.find()) {
            List<FileInfo> fileInfoList = indexedWords.get(key);
            if (fileInfoList != null) addFileNumbers(fileInfoList, answer);
        }
    }

    private void addFileNumbers(List<FileInfo> fileInfoList, Set<String> answer) {
        for (FileInfo t : fileInfoList) answer.add(files.get(t.getFileNumber()));
    }

    private ArrayList<String> normalizeInputWords(ArrayList<String> wordsToFind) {
        ArrayList<String> returnArrayList = new ArrayList<>();
        for (String string : wordsToFind) {
            returnArrayList.add(normalize(string));
        }
        return returnArrayList;
    }

    public Set<String> findCommonFiles(Set<String> answer, ArrayList<Set<String>> wordsToFindCommon) {
        Set<String> commonWords = findCommonWords(wordsToFindCommon);
        if (answer.size() > 0 && commonWords.size() > 0) {
            answer.retainAll(commonWords);
            return answer;
        }
        if (answer.size() == 0 && commonWords.size() > 0) {
            return commonWords;
        }
        if (answer.size() == 0) {
            return new HashSet<>();
        }
        return answer;
    }

    public Set<String> deleteGivenFiles(Set<String> answer, Set<String> deleteFiles) {
        answer.removeAll(deleteFiles);
        return answer;
    }

    public Set<String> findCommonWords(ArrayList<Set<String>> wordsToFindCommon) {
        if (wordsToFindCommon.size() <= 0){
            return new HashSet<>();
        }
        Set<String> commonWords = wordsToFindCommon.get(0);
        if (wordsToFindCommon.size() == 1) {
            return commonWords;
        }
        for (int i = 1; i < wordsToFindCommon.size(); i++) {
            commonWords.retainAll(wordsToFindCommon.get(i));
        }
        return commonWords;
    }

    public List<String> getFiles() {
        return files;
    }
}
 