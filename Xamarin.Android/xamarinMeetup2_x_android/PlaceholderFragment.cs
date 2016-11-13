using Android.OS;
using Android.Support.V4.App;
using Android.Views;
using Android.Widget;

namespace xamarinMeetup2_x_android
{
    public class PlaceholderFragment : Fragment
    {
        /**
         * The fragment argument representing the section number for this
         * fragment.
         */
        private static readonly string ARG_SECTION_NUMBER = "section_number";

        public PlaceholderFragment()
        {
        }

        /**
         * Returns a new instance of this fragment for the given section
         * number.
         */
        public static PlaceholderFragment NewInstance(int sectionNumber)
        {
            PlaceholderFragment fragment = new PlaceholderFragment();
            Bundle args = new Bundle();
            args.PutInt(ARG_SECTION_NUMBER, sectionNumber);
            fragment.Arguments = args;
            return fragment;
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container,
                                 Bundle savedInstanceState)
        {
            View rootView = inflater.Inflate(Resource.Layout.fragment_main, container, false);
            TextView textView = (TextView)rootView.FindViewById(Resource.Id.section_label);
            textView.Text = GetString(Resource.String.section_format, Arguments.GetInt(ARG_SECTION_NUMBER));
            return rootView;
        }
    }
}