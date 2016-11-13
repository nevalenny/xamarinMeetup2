package yn.xamarinmeetup2_android;

/**
 * Created by Egorbo on 05.03.14.
 */

import java.util.ArrayList;

public class CollectionsTest implements Test {
    @Override
    public void Run() {
        ArrayList<FooContainer> list = new ArrayList<FooContainer>(); //let's don't specify initial capacity
        for (int i = 0; i < 1000000; i++) {
            list.add(new FooContainer(i, i));
        }

        ArrayList<FooContainer> filteredList = new ArrayList<FooContainer>();
        for (int i = 0; i < list.size(); i++) {
            if (list.get(i).getSum() % 2 == 0) {
                filteredList.add(list.get(i));
            }
        }
    }
}
