package yn.xamarinmeetup2_android;

import android.graphics.BitmapFactory;
import android.os.AsyncTask;
import android.os.Bundle;
import android.os.Handler;
import android.os.Looper;
import android.support.design.widget.TabLayout;
import android.support.v4.app.Fragment;
import android.support.v4.app.FragmentManager;
import android.support.v4.app.FragmentPagerAdapter;
import android.support.v4.view.ViewPager;
import android.support.v7.app.AppCompatActivity;
import android.support.v7.widget.LinearLayoutManager;
import android.support.v7.widget.RecyclerView;
import android.util.Base64;
import android.view.LayoutInflater;
import android.view.Menu;
import android.view.MenuItem;
import android.view.View;
import android.view.ViewGroup;
import android.widget.Button;
import android.widget.ImageView;
import android.widget.TextView;

import org.json.JSONArray;
import org.json.JSONException;
import org.json.JSONObject;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStream;
import java.io.InputStreamReader;
import java.io.Reader;
import java.io.StringWriter;
import java.io.Writer;

public class MainActivity extends AppCompatActivity {

    /**
     * The {@link android.support.v4.view.PagerAdapter} that will provide
     * fragments for each of the sections. We use a
     * {@link FragmentPagerAdapter} derivative, which will keep every
     * loaded fragment in memory. If this becomes too memory intensive, it
     * may be best to switch to a
     * {@link android.support.v4.app.FragmentStatePagerAdapter}.
     */
    private SectionsPagerAdapter mSectionsPagerAdapter;

    /**
     * The {@link ViewPager} that will host the section contents.
     */
    private ViewPager mViewPager;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);

        mSectionsPagerAdapter = new SectionsPagerAdapter(getSupportFragmentManager());

        mViewPager = (ViewPager) findViewById(R.id.container);
        mViewPager.setAdapter(mSectionsPagerAdapter);

        TabLayout tabLayout = (TabLayout) findViewById(R.id.tabs);
        tabLayout.setupWithViewPager(mViewPager);

    }


    @Override
    public boolean onCreateOptionsMenu(Menu menu) {
        // Inflate the menu; this adds items to the action bar if it is present.
        getMenuInflater().inflate(R.menu.menu_main, menu);
        return true;
    }

    @Override
    public boolean onOptionsItemSelected(MenuItem item) {
        // Handle action bar item clicks here. The action bar will
        // automatically handle clicks on the Home/Up button, so long
        // as you specify a parent activity in AndroidManifest.xml.
        int id = item.getItemId();

        //noinspection SimplifiableIfStatement
        if (id == R.id.action_settings) {
            return true;
        }

        return super.onOptionsItemSelected(item);
    }

    public static class ListFragment extends Fragment {
        private JSONArray array;

        public ListFragment() {
        }

        public static ListFragment newInstance() {
            return new ListFragment();
        }

        @Override
        public View onCreateView(final LayoutInflater inflater, ViewGroup container,
                                 Bundle savedInstanceState) {
            View rootView = inflater.inflate(R.layout.fragment_list, container, false);

            InputStream is = getResources().openRawResource(R.raw.mock_data);
            Writer writer = new StringWriter();
            char[] buffer = new char[1024];

            Reader reader = null;
            try {
                reader = new BufferedReader(new InputStreamReader(is, "UTF-8"));
                int n;
                while ((n = reader.read(buffer)) != -1) {
                    writer.write(buffer, 0, n);
                }
            } catch (IOException e) {
                e.printStackTrace();
            } finally {
                try {
                    is.close();
                } catch (IOException e) {
                    e.printStackTrace();
                }
            }

            String jsonString = writer.toString();

            try {
                array = new JSONArray(jsonString);
            } catch (JSONException e) {
                e.printStackTrace();
            }

            RecyclerView recyclerView = (RecyclerView) rootView.findViewById(R.id.recyclerView1);
            recyclerView.setHasFixedSize(true);
            recyclerView.setVerticalScrollBarEnabled(true);
            recyclerView.setLayoutManager(new LinearLayoutManager(this.getContext()));
            recyclerView.setAdapter(new RecyclerView.Adapter() {
                @Override
                public RecyclerView.ViewHolder onCreateViewHolder(ViewGroup parent, int viewType) {
                    RecyclerView.ViewHolder cellHolder = new CellHolder(inflater.inflate(R.layout.list_cell, parent, false));
                    return cellHolder;
                }

                @Override
                public void onBindViewHolder(RecyclerView.ViewHolder holder, int position) {
                    CellHolder myHolder = (CellHolder) holder;
                    JSONObject item = null;
                    try {
                        item = array.getJSONObject(position);
                        byte[] imageAsBytes = Base64.decode(item.getString("picture").substring(22), Base64.DEFAULT);

                        myHolder.getImage().setImageBitmap(BitmapFactory.decodeByteArray(imageAsBytes, 0, imageAsBytes.length));
                        myHolder.getCaption().setText(item.getString("first_name") + " " + item.getString("last_name"));
                    } catch (JSONException e) {
                        e.printStackTrace();
                    }
                }

                @Override
                public int getItemCount() {
                    return array.length();
                }
            });

            return rootView;
        }
    }

    public static class CalculationsFragment extends Fragment {
        private TestExecutor testExecutor;

        public CalculationsFragment() {
        }

        public static CalculationsFragment newInstance() {
            return new CalculationsFragment();
        }

        @Override
        public View onCreateView(LayoutInflater inflater, ViewGroup container,
                                 Bundle savedInstanceState) {
            final View rootView = inflater.inflate(R.layout.fragment_calculations, container, false);
            testExecutor = new TestExecutor();

            Button button = (Button) rootView.findViewById(R.id.buttonCalculate);
            button.setOnClickListener(new View.OnClickListener() {
                @Override
                public void onClick(View view) {
                    AsyncTask.execute(new Runnable() {
                        @Override
                        public void run() {
                            final String arithmetic = "Arithmetic: " + testExecutor.Run(new ArithmeticTest());
                            final String collections = "Collections: " + testExecutor.Run(new CollectionsTest());
                            final String strings = "Strings: " + testExecutor.Run(new StringsTest(getActivity()));

                            Handler h = new Handler(Looper.getMainLooper());
                            h.post(new Runnable() {
                                @Override
                                public void run() {
                                    ((TextView) rootView.findViewById(R.id.textViewArithmetic)).setText(arithmetic);
                                    ((TextView) rootView.findViewById(R.id.textViewCollections)).setText(collections);
                                    ((TextView) rootView.findViewById(R.id.textViewStrings)).setText(strings);
                                }
                            });
                        }
                    });
                }
            });

            return rootView;
        }
    }

    public static class CellHolder extends RecyclerView.ViewHolder {
        private ImageView image;
        private TextView caption;

        public CellHolder(View itemView) {
            super(itemView);
            image = (ImageView) itemView.findViewById(R.id.imageView1);
            caption = (TextView) itemView.findViewById(R.id.textView1);
        }

        public ImageView getImage() {
            return image;
        }

        public TextView getCaption() {
            return caption;
        }
    }

    public class SectionsPagerAdapter extends FragmentPagerAdapter {
        public SectionsPagerAdapter(FragmentManager fm) {
            super(fm);
        }

        @Override
        public Fragment getItem(int position) {
            switch (position) {
                case 0:
                    return ListFragment.newInstance();
                case 1:
                    return CalculationsFragment.newInstance();
            }
            return null;
        }

        @Override
        public int getCount() {
            return 2;
        }

        @Override
        public CharSequence getPageTitle(int position) {
            switch (position) {
                case 0:
                    return "List";
                case 1:
                    return "Calculations";
            }
            return null;
        }
    }
}
