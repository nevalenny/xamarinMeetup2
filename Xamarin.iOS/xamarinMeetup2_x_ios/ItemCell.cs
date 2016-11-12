using System;
using CoreGraphics;
using Foundation;
using UIKit;

namespace xamarinMeetup2_x_ios
{
    public class ItemCell : UITableViewCell
    {
        // Be aware, when using the new reuse pattern with a custom cell class, 
        // you need to implement the constructor that takes an IntPtr, 
        // otherwise Objective-C won't be able to construct an instance of the cell class:
        public ItemCell(IntPtr p) : base(p)
        {
        }

        public ItemCell(NSString cellId) : base(UITableViewCellStyle.Default, cellId)
        {
            BackgroundView = new UIView { BackgroundColor = UIColor.White };

            SelectedBackgroundView = new UIView { BackgroundColor = UIColor.Gray };
        }
    }
}