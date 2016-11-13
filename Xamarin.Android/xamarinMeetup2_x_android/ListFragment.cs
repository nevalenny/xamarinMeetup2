using System.Collections.Generic;
using System.IO;
using System.Reflection;
using Android.OS;
using Android.Support.V4.App;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;
using Newtonsoft.Json;
using xamarinMeetup2;

namespace xamarinMeetup2_x_android
{
    public class ListFragment : Fragment
    {
        List<ItemModel> itemsSource;
        
        public ListFragment()
        {
        }

        /**
         * Returns a new instance of this fragment for the given section
         * number.
         */
        public static ListFragment NewInstance()
        {
            var fragment = new ListFragment();
            return fragment;
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container,
                                 Bundle savedInstanceState)
        {
            View rootView = inflater.Inflate(Resource.Layout.fragment_list, container, false);

            // get embedded resource into string first
            var assembly = typeof(ListFragment).GetTypeInfo().Assembly;
            Stream stream = assembly.GetManifestResourceStream("xamarinMeetup2_x_android.MOCK_DATA.json");
            using (var reader = new StreamReader(stream))
            {
                itemsSource = JsonConvert.DeserializeObject<List<ItemModel>>(reader.ReadToEnd());
            }

            var recyclerView = (RecyclerView)rootView.FindViewById(Resource.Id.recyclerView1);
            recyclerView.HasFixedSize = true;
            recyclerView.SetLayoutManager(new LinearLayoutManager(this.Context));
            recyclerView.SetAdapter(new ListAdapter(itemsSource, Context));

            return rootView;
        }
    }
}