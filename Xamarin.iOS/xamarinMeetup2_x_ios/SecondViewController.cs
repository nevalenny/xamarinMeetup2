using System;

using UIKit;
using xamarinMeetup2;

namespace xamarinMeetup2_x_ios
{
    public partial class SecondViewController : UIViewController
    {
        MathModel mathModel;

        protected SecondViewController(IntPtr handle) : base(handle)
        {
            // Note: this .ctor should not contain any initialization logic.
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            // Perform any additional setup after loading the view, typically from a nib.
            mathModel = new MathModel();
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }

        partial void CalculateButton_TouchUpInside(UIButton sender)
        {
            arithmeticLabel.Text = "Arithmetic: " + mathModel?.ArithmeticPerformance;
            collectionsLabel.Text = "Collections: " + mathModel?.CollectionPerformance;
            stringsLabel.Text = "Strings: " + mathModel?.StringPerformance;
        }
    }
}