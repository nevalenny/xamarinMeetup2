using System.Threading.Tasks;
using Android.OS;
using Android.Support.V4.App;
using Android.Views;
using Android.Widget;
using xamarinMeetup2;

namespace xamarinMeetup2_x_android
{
    public class CalculationsFragment : Fragment
    {
        readonly MathModel model = new MathModel();

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

            var buttonCalculate = (Button)rootView.FindViewById(Resource.Id.buttonCalculate);
            buttonCalculate.Click += (sender, e) =>
            {
                Task.Run(() =>
                    {
                        // calculate in background
                        var arithmetic = "Arithmetic: " + model.ArithmeticPerformance;
                        var collections = "Collections: " + model.CollectionPerformance;
                        var strings = "Strings: " + model.StringPerformance;

                        // update in UI thread
                        using (var h = new Handler(Looper.MainLooper))
                        {
                            h.Post(() =>
                            {
                                ((TextView)rootView.FindViewById(Resource.Id.textViewArithmetic))
                                    .Text = arithmetic;

                                ((TextView)rootView.FindViewById(Resource.Id.textViewCollections))
                                    .Text = collections;

                                ((TextView)rootView.FindViewById(Resource.Id.textViewStrings))
                                    .Text = strings;
                            });
                        }
                    });
            };

            return rootView;
        }
    }
}