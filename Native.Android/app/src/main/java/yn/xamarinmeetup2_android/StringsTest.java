package yn.xamarinmeetup2_android;

import android.app.Activity;

/**
 * Created by Egorbo on 05.03.14.
 */

public class StringsTest implements Test {
    private Activity activity;

    public StringsTest(Activity activity) {
        this.activity = activity;
    }

    @Override
    public void Run() {
        String result = "";
        StringBuilder builder = new StringBuilder();
        for (int i = 0; i < 100000; i++) {
            //result += String.valueOf(i); -- this performs 3x times slower than in xamarin O_o
            builder.append(i);
        }
        result = builder.toString();
        result = result.substring(1000); //don't know how it works but if it just sets offset to 1000 it will be cheating ;)
        result = result.replaceAll("10", "");
        boolean containsSubstring = result.contains("123");
        String[] parts = result.split("2");
        int length = parts.length;
    }
}