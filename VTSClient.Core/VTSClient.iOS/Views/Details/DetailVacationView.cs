using System;

using UIKit;

namespace VTSClient.iOS.Views.Details
{
    public partial class DetailVacationView : UIViewController
    {
        public DetailVacationView() : base("DetailVacationView", null)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            // Perform any additional setup after loading the view, typically from a nib.
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }
    }
}

