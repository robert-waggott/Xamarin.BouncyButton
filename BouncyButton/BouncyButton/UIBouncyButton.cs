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
			this.TouchUpInside += this.OnTouch;
		}

		public UIBouncyButton(CGRect frame)
			: base(frame)
		{
			this.TouchUpInside += this.OnTouch;
		}

		public Action BeforeAnimation { get; set; }

		public Action DuringAnimation { get; set; }

		public Action AfterAnimation { get; set; }

		protected virtual void OnTouch(object sender, EventArgs e)
		{
			if (this.BeforeAnimation != null) 
			{
				this.BeforeAnimation.Invoke();
			}

			Animate(0.3, () => this.Transform = CGAffineTransform.MakeScale(0.83f, 0.83f));
			Animate(0.2, () => this.Transform = CGAffineTransform.MakeScale(0.86f, 0.86f));
			Animate(0.18, 
				() => this.Transform = CGAffineTransform.MakeScale(0.85f, 0.85f), 
				() => this.Highlighted = true);

			if (this.DuringAnimation != null)
			{
				this.DuringAnimation.Invoke();
			}

			Animate(0.1, 
				() => this.Transform = CGAffineTransform.MakeScale(0.85f, 0.85f),
				() => this.Highlighted = false);
			Animate(0.18, () => this.Transform = CGAffineTransform.MakeScale(1.05f, 1.05f));
			Animate(0.18, () => this.Transform = CGAffineTransform.MakeScale(0.98f, 0.98f));
			Animate(0.17, () => this.Transform = CGAffineTransform.MakeScale(1.01f, 1.01f));
			Animate(0.17, () => this.Transform = CGAffineTransform.MakeIdentity());

			if (this.AfterAnimation != null)
			{
				this.AfterAnimation.Invoke();
			}
		}
	}
}