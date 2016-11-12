// WARNING
//
// This file has been generated automatically by Xamarin Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace xamarinMeetup2_x_ios
{
    [Register ("SecondViewController")]
    partial class SecondViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel arithmeticLabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton calculateButton { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel collectionsLabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel stringsLabel { get; set; }

        [Action ("CalculateButton_TouchUpInside:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void CalculateButton_TouchUpInside (UIKit.UIButton sender);

        void ReleaseDesignerOutlets ()
        {
            if (arithmeticLabel != null) {
                arithmeticLabel.Dispose ();
                arithmeticLabel = null;
            }

            if (calculateButton != null) {
                calculateButton.Dispose ();
                calculateButton = null;
            }

            if (collectionsLabel != null) {
                collectionsLabel.Dispose ();
                collectionsLabel = null;
            }

            if (stringsLabel != null) {
                stringsLabel.Dispose ();
                stringsLabel = null;
            }
        }
    }
}