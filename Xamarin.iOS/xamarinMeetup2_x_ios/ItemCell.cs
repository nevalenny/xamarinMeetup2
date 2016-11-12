using System;
using CoreGraphics;
using Foundation;
using UIKit;

namespace xamarinMeetup2_x_ios
{
    public class ItemCell: UITableViewCell
    {
        UIImageView imageView;

        public ItemCell(IntPtr p):base(p)
  {
        }

        public ItemCell(NSString cellId) : base (UITableViewCellStyle.Default, cellId)
        {
            BackgroundView = new UIView { BackgroundColor = UIColor.White };

            SelectedBackgroundView = new UIView { BackgroundColor = UIColor.Gray };

            ContentView.Layer.BorderColor = UIColor.LightGray.CGColor;
            ContentView.Layer.BorderWidth = 1.0f;
            ContentView.BackgroundColor = UIColor.White;
            ContentView.Transform = CGAffineTransform.MakeScale(0.9f, 0.9f);
        }
    }
}