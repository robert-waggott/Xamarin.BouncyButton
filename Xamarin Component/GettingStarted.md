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

			};
	}
```

At the end of the shrink effect, before the rebound effect is applied the button's Highlighted status is set to true. Therefore to change the visual state/text of the button during the animation simply setup the highlighted state.
	
```
	public override void ViewDidLoad()
	{
		base.ViewDidLoad();

		var bouncyButton = new UIBouncyButton();
	}
```