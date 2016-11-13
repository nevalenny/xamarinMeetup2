using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Xamarin.Forms;

namespace xamarinMeetup2
{
    public partial class xamarinMeetup2Page
    {
        public xamarinMeetup2Page()
        {
            InitializeComponent();

            // get embedded resource into string first
            var assembly = typeof(xamarinMeetup2Page).GetTypeInfo().Assembly;
            Stream stream = assembly.GetManifestResourceStream("xamarinMeetup2.MOCK_DATA.json");
            string source = "";
            using (var reader = new StreamReader(stream))
            {
                source = reader.ReadToEnd();
            }

            // assign deserialized source to listview
            list.ItemsSource = JsonConvert.DeserializeObject<List<ItemModel>>(source);

            calculateButton.Clicked += Calculate;
        }

        void Calculate(object sender, EventArgs e)
        {
            var mathModel = new MathModel();
            Task.Run(() =>
                {
                    mathModel.RunTests();
                    Device.BeginInvokeOnMainThread(() =>
                                                   mathPage.BindingContext = mathModel);
                }
            );
        }
    }
}