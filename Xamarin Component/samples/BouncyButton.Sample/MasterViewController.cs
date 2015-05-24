using System;

using BouncyButton;

using CoreGraphics;
using Foundation;
using UIKit;

namespace BouncyButton.Sample
{
	public partial class MasterViewController : UIViewController
	{
		UIBouncyButton bouncyButton;

		public MasterViewController () : base ("MasterViewController", null)
		{
		}

		public override void DidReceiveMemoryWarning ()
		{
			// Releases the view if it doesn't have a superview.
			base.DidReceiveMemoryWarning ();
			
			// Release any cached data, images, etc that aren't in use.
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			bouncyButton = new UIBouncyButton(UIButtonType.Custom) 
			{ 
				Frame = new CGRect(10f, 50f, 250f, 100f),
				AfterAnimation = () => 
				{
					bouncyButton.Selected = true;
					bouncyButton.BackgroundColor = UIColor.Red;
				}
			};

			bouncyButton.BackgroundColor = UIColor.Clear;

			bouncyButton.Layer.CornerRadius = 5f;
			bouncyButton.Layer.BorderWidth = 1f;
			bouncyButton.Layer.BorderColor = UIColor.Red.CGColor;
				
			bouncyButton.SetTitle("Load", UIControlState.Normal);
			bouncyButton.SetTitle("Loading", UIControlState.Highlighted);
			bouncyButton.SetTitle("Loaded", UIControlState.Selected);

			bouncyButton.SetTitleColor(UIColor.Red, UIControlState.Normal);
			bouncyButton.SetTitleColor(UIColor.White, UIControlState.Selected);

			this.View.Add(bouncyButton);
		}
	}
}