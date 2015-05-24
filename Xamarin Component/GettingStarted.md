Reference the component and adding a Using statement to `BouncyButton`.

`UIBouncyButton` simply inherits from UIButton so all properties on UIButton will work on UIBouncyButton. 

There are three additional properties on `UIBouncyButton` which are all of type System.Action:

* BeforeAnimation - fired before the animation occurs 
* DuringAnimation - fired after the 'shrink' animation finishes, but before the 'rebound' animation has started
* AfterAnimation - fired after the 'rebound' animation finishes

```
	public override void ViewDidLoad()
	{
		base.ViewDidLoad();

		var bouncyButton = new UIBouncyButton()
			{
				BeforeAnimation = () => Console.WriteLine("Before Animation"),
				DuringAnimation = () => Console.WriteLine("During Animation"),
				AfterAnimation = () => Console.WriteLine("After Animation")
			};
	}
```
