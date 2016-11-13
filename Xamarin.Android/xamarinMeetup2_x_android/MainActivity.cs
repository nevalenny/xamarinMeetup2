using Android.App;
using Android.OS;
using Android.Support.Design.Widget;
using Android.Support.V4.App;
using Android.Support.V4.View;
using Android.Support.V4.Widget;
using Android.Support.V7.App;
using Android.Support.V7.Widget;
using Fragment = Android.Support.V4.App.Fragment;

namespace xamarinMeetup2_x_android
{
    [Activity(Label = "xamarinMeetup2_x_android", MainLauncher = true, Theme = "@style/AppTheme.NoActionBar", Icon = "@mipmap/icon")]
    public class MainActivity : AppCompatActivity
    {
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

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            //this.Tab

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            // Create the adapter that will return a fragment for each of the three
            // primary sections of the activity.
            mSectionsPagerAdapter = new SectionsPagerAdapter(SupportFragmentManager);

            // Set up the ViewPager with the sections adapter.
            mViewPager = (ViewPager)FindViewById(Resource.Id.container);
            mViewPager.Adapter = mSectionsPagerAdapter;

            TabLayout tabLayout = (TabLayout)FindViewById(Resource.Id.tabs);
            tabLayout.SetupWithViewPager(mViewPager);
        }
    }
}