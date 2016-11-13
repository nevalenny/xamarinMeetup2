using Android.OS;
using Android.Support.V4.App;
using Android.Views;

namespace xamarinMeetup2_x_android
{
    public class CalculationsFragment : Fragment
    {
        public CalculationsFragment()
        {
        }

        /**
         * Returns a new instance of this fragment for the given section
         * number.
         */
        public static CalculationsFragment NewInstance()
        {
            var fragment = new CalculationsFragment();
            return fragment;
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container,
                                 Bundle savedInstanceState)
        {
            View rootView = inflater.Inflate(Resource.Layout.fragment_calculations, container, false);
            return rootView;
        }
    }
}