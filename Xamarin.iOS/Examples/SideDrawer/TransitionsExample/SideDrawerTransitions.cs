﻿using System;
using UIKit;
using Foundation;
using CoreGraphics;
using ObjCRuntime;
using TelerikUI;

namespace Examples
{
	public class SideDrawerTransitions : SideDrawerGettingStarted
	{
		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			this.AddButtons ();
		}

		public virtual void AddButtons ()
		{
			this.CreateButton ("Push", this, new Selector ("PushTransition"), new CGPoint (15, 80));
			this.CreateButton ("Reveal", this, new Selector ("RevealTransition"), new CGPoint (15, 130));
			this.CreateButton ("Reverse Slide Out", this, new Selector ("ReverseSlideOutTransition"), new CGPoint (15, 180));
			this.CreateButton ("Slide Along", this, new Selector ("SlideAlongTransition"), new CGPoint (15, 230));
			this.CreateButton ("Slide In On Top", this, new Selector ("SlideInOnTopTransition"), new CGPoint (15, 280));
			this.CreateButton ("Scale Up", this, new Selector ("ScaleUpTransition"), new CGPoint (15, 330));
			this.CreateButton ("Fade In", this, new Selector ("FadeInTransition"), new CGPoint (15, 380));
		}

		[Export ("PushTransition")]
		private void PushTransition() 
		{
			this.SideDrawerView.SideDrawer.Transition = TKSideDrawerTransitionType.Push;
			this.SideDrawerView.SideDrawer.Fill = new TKSolidFill (UIColor.Gray);
			this.SideDrawerView.SideDrawer.HeaderView = new SideDrawerHeader (false, null, null);
			this.SideDrawerView.SideDrawer.Show ();
		}

		[Export ("RevealTransition")]
		private void RevealTransition()
		{
			this.SideDrawerView.SideDrawer.Transition = TKSideDrawerTransitionType.Reveal;
			this.SideDrawerView.SideDrawer.Fill = new TKSolidFill (UIColor.Gray);
			this.SideDrawerView.SideDrawer.HeaderView = new SideDrawerHeader (false, null, null);
			this.SideDrawerView.SideDrawer.Show ();
		}

		[Export ("ReverseSlideOutTransition")]
		private void ReverseSlideOutTransition()
		{
			this.SideDrawerView.SideDrawer.Transition = TKSideDrawerTransitionType.ReverseSlideOut;
			this.SideDrawerView.SideDrawer.Fill = new TKSolidFill (UIColor.Gray);
			this.SideDrawerView.SideDrawer.HeaderView = new SideDrawerHeader (false, null, null);
			this.SideDrawerView.SideDrawer.Show ();
		}

		[Export ("SlideAlongTransition")]
		private void SlideAlongTransition()
		{
			this.SideDrawerView.SideDrawer.Transition = TKSideDrawerTransitionType.SlideAlong;
			this.SideDrawerView.SideDrawer.Fill = new TKSolidFill (UIColor.Gray);
			this.SideDrawerView.SideDrawer.HeaderView = new SideDrawerHeader (false, null, null);
			this.SideDrawerView.SideDrawer.Show ();
		}

		[Export ("SlideInOnTopTransition")]
		private void SlideInOnTopTransition()
		{
			this.SideDrawerView.SideDrawer.Transition = TKSideDrawerTransitionType.SlideInOnTop;
			this.SideDrawerView.SideDrawer.Fill = new TKSolidFill (UIColor.Clear);
			this.SideDrawerView.SideDrawer.HeaderView = new SideDrawerHeader (true, this, new Selector("DismissSideDrawer"));
			this.SideDrawerView.SideDrawer.Show ();
		}

		[Export ("ScaleUpTransition")]
		private void ScaleUpTransition()
		{
			this.SideDrawerView.SideDrawer.Transition = TKSideDrawerTransitionType.ScaleUp;
			this.SideDrawerView.SideDrawer.Fill = new TKSolidFill (UIColor.Gray);
			this.SideDrawerView.SideDrawer.HeaderView = new SideDrawerHeader (false, null, null);
			this.SideDrawerView.SideDrawer.Show ();
		}

		[Export ("FadeInTransition")]
		private void FadeInTransition()
		{
			this.SideDrawerView.SideDrawer.Transition = TKSideDrawerTransitionType.FadeIn;
			this.SideDrawerView.SideDrawer.Fill = new TKSolidFill (UIColor.Gray);
			this.SideDrawerView.SideDrawer.HeaderView = new SideDrawerHeader (true, this, new Selector("DismissSideDrawer"));
			this.SideDrawerView.SideDrawer.Show ();
		}

		public void CreateButton(string title, NSObject target, Selector selector, CGPoint origin)
		{
			NSString titleString = new NSString (title);
			UIStringAttributes attributes = new UIStringAttributes () { Font = UIFont.SystemFontOfSize (18) };
			CGSize titleSize = titleString.GetSizeUsingAttributes(attributes);
			UIButton button = new UIButton (new CGRect (origin.X, origin.Y, titleSize.Width, 44));
			button.TitleLabel.Font = UIFont.SystemFontOfSize (14);
			button.Layer.BorderWidth = 1.0f;
			button.Layer.BorderColor = UIColor.White.CGColor;
			button.Layer.CornerRadius = 3.0f;
			button.SetTitle (title, UIControlState.Normal);
			button.SetTitleColor (UIColor.White, UIControlState.Normal);
			button.AddTarget (target, selector, UIControlEvent.TouchUpInside);
			this.SideDrawerView.MainView.AddSubview (button);
		}
	}
}

