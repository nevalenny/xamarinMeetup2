package yn.xamarinmeetup2_android;

import java.util.ArrayList;

/**
 * Created by Egorbo on 05.03.14.
 */
public class TestExecutor {
    private final int TestsCount = 5;
    private long startTime = 0;

    public String Run(Test test) {
        ArrayList<Long> durationsList = new ArrayList<>(TestsCount);
        for (int i = 0; i < TestsCount; i++) {
            StartTimer();
            test.Run();
            durationsList.add(GetElapsedTime());
        }
        long first = durationsList.get(0);
        long fastest = first;
        long slowest = first;
        long sum = 0;

        for (int i = 0; i < durationsList.size(); i++) {
            long current = durationsList.get(i);
            if (current < fastest) {
                fastest = current;
            }
            if (current > slowest) {
                slowest = current;
            }
            sum += current;
        }

        double average = (double) (sum - fastest - slowest) / (durationsList.size() - 2.0);

        return String.format("%d ms", (long) average);
    }

    private void StartTimer() {
        startTime = System.currentTimeMillis();
    }

    private long GetElapsedTime() {
        long stopTime = System.currentTimeMillis();
        long elapsedTime = stopTime - startTime;
        return elapsedTime;
    }
}
