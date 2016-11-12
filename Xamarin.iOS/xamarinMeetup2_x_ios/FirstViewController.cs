using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using Foundation;
using Newtonsoft.Json;
using UIKit;
using xamarinMeetup2;

namespace xamarinMeetup2_x_ios
{
    public partial class FirstViewController : UIViewController
    {
        List<ItemModel> itemsSource;
        static NSString cellId = new NSString("ItemCell");

        protected FirstViewController(IntPtr handle) : base(handle)
        {
            // Note: this .ctor should not contain any initialization logic.
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            // Perform any additional setup after loading the view, typically from a nib.

            // get embedded resource into string first
            var assembly = typeof(FirstViewController).GetTypeInfo().Assembly;
            Stream stream = assembly.GetManifestResourceStream("xamarinMeetup2_x_ios.MOCK_DATA.json");
            string source = "";
            using (var reader = new StreamReader(stream))
            {
                source = reader.ReadToEnd();
            }

            // assign deserialized source to listview
            itemsSource = JsonConvert.DeserializeObject<List<ItemModel>>(source);

            //collectionSource.
            tableView.RegisterClassForCellReuse(typeof(ItemCell), cellId);
            tableView.Source = new TableViewSource(GetCell, RowsInSection);

        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }

        public UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {
            var item = itemsSource[indexPath.Row];
            var cell = tableView.DequeueReusableCell(cellId, indexPath);

            if (cell == null)
            {
                cell = new ItemCell(cellId);
            }

            cell.TextLabel.Text = item.Text;
            cell.ImageView.Image = item.Picture;

            return cell;
        }

        public nint RowsInSection(UITableView tableview, nint section)
        {
            return itemsSource?.Count ?? 0;
        }
    }
}