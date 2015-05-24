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

		protected async virtual void OnTouch(object sender, EventArgs e)
		{
			if (this.BeforeAnimation != null) 
			{
				this.BeforeAnimation.Invoke();
			}

			await AnimateAsync(0.3, () => this.Transform = CGAffineTransform.MakeScale(0.83f, 0.83f));
			await AnimateAsync(0.17, () => this.Transform = CGAffineTransform.MakeScale(0.86f, 0.86f));
			await AnimateAsync(0.1, () => this.Transform = CGAffineTransform.MakeScale(0.85f, 0.85f));

			this.Highlighted = true;

			if (this.DuringAnimation != null)
			{
				this.DuringAnimation.Invoke();
			}

			this.Highlighted = false;

			await AnimateAsync(0.1, () => this.Transform = CGAffineTransform.MakeScale(0.85f, 0.85f));
			await AnimateAsync(0.18, () => this.Transform = CGAffineTransform.MakeScale(1.05f, 1.05f));
			await AnimateAsync(0.18, () => this.Transform = CGAffineTransform.MakeScale(0.98f, 0.98f));
			await AnimateAsync(0.17, () => this.Transform = CGAffineTransform.MakeScale(1.01f, 1.01f));
			await AnimateAsync(0.17, () => this.Transform = CGAffineTransform.MakeIdentity());

			if (this.AfterAnimation != null)
			{
				this.AfterAnimation.Invoke();
			}
		}
	}
}