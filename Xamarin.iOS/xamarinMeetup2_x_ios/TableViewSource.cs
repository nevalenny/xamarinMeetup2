using System;
using Foundation;
using UIKit;

namespace xamarinMeetup2_x_ios
{
    class TableViewSource : UITableViewSource
    {
        Func<UITableView, NSIndexPath, UITableViewCell> getCell;
        Func<UITableView, nint, nint> rowsInSection;

        public TableViewSource(Func<UITableView, NSIndexPath, UITableViewCell> getCell, Func<UITableView, nint, nint> rowsInSection)
        {
            this.getCell = getCell;
            this.rowsInSection = rowsInSection;
        }

        public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {
            return getCell(tableView, indexPath);
        }

        public override nint RowsInSection(UITableView tableview, nint section)
        {
            return rowsInSection(tableview, section);
        }
    }
}