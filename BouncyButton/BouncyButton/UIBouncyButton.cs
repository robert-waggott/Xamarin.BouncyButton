namespace BouncyButton
{
	using System;

	using CoreGraphics;
	using UIKit;

	public class UIBouncyButton : UIButton
	{
		public UIBouncyButton()
			: base()
		{
			this.TouchUpInside += this.OnTouch;
		}

		public UIBouncyButton(UIButtonType type)
			: base(type)
		{
		}

		public UIBouncyButton(CGRect frame)
			: base(frame)
		{
		}

		public Action BeforeAnimation { get; set; }

		public Action DuringAnimation { get; set; }

		public Action AfterAnimation { get; set; }

		protected void OnTouch(object sender, EventArgs e)
		{
					
		}
	}
}