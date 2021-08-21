public class ViewPreProcessing {

    public static void start() {
        while (true){
            String result = PreProcessing.preprocesses("/EnglishData" ,"1");
            if (result.equals("end"))
                break;
            else System.out.println(result);
        }
    }
}
