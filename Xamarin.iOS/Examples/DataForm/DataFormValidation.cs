﻿using System;
using TelerikUI;
using Foundation;
using UIKit;
using System.Collections.Generic;
using ObjCRuntime;

namespace Examples
{
	public class DataFormValidation : TKDataFormViewController
	{
		ValidationDataFormDelegate validationDelegate;
		TKDataFormEntityDataSourceHelper dataSource;
		RegistrationInfo registrationInfo;

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			this.registrationInfo = new RegistrationInfo ();
			this.validationDelegate = new ValidationDataFormDelegate (this);
			this.dataSource = new TKDataFormEntityDataSourceHelper (this.registrationInfo);

			TKEntityProperty emailProperty = this.dataSource["Email"];
			emailProperty.HintText = "E-mail (Required)";
			emailProperty.EditorClass = new Class (typeof(TKDataFormEmailEditor));
			emailProperty.Validators = new NSObject[] { new EmailValidator() };

			TKEntityProperty password = this.dataSource.PropertyWithName("Password");
			password.HintText = "Password (Minimum 6 characters)";
			password.EditorClass = new Class (typeof(TKDataFormPasswordEditor));
			password.Validators = new NSObject[] { new PasswordValidator () };

			TKEntityProperty repeatPassword = this.dataSource.PropertyWithName ("RepeatPassword");
			repeatPassword.HintText = "Confirm password";
			repeatPassword.EditorClass = new Class (typeof(TKDataFormPasswordEditor));
			repeatPassword.ErrorMessage = "The password does not match!";

			this.dataSource["Name"].HintText = "Name (Optional)";
			this.dataSource["Gender"].ValuesProvider = NSArray.FromStrings (new string[] { "Male", "Female" });
			this.dataSource ["Country"].ValuesProvider = NSArray.FromStrings (new string[] { "Bulgaria", "France", "Germany", "Italy", "United Kingdom" });
			this.dataSource["Country"].EditorClass = new ObjCRuntime.Class(typeof(TKDataFormPickerViewEditor));

			dataSource.AddGroup ("Account", new string[] { "Email", "Password", "RepeatPassword", "RememberMe" });
			dataSource.AddGroup ("Details", new string[] { "Name", "DateOfBirth", "Gender", "Country" });

			this.DataForm.BackgroundColor = new UIColor (0.937f, 0.937f, 0.960f, 1.0f);
			this.DataForm.Delegate = this.validationDelegate;
			this.DataForm.WeakDataSource = dataSource.NativeObject;
			this.DataForm.ValidationMode = TKDataFormValidationMode.Immediate;
		}

		class ValidationDataFormDelegate: TKDataFormDelegate
		{
	
			DataFormValidation owner;

			public ValidationDataFormDelegate(DataFormValidation owner) {

				this.owner = owner;
			}

			public override bool ValidateProperty (TKDataForm dataForm, TKEntityProperty property, TKDataFormEditor editor)
			{
				if (property.Name == "RepeatPassword") {
					return property.IsValid && property.ValueCandidate.IsEqual (this.owner.dataSource.PropertyWithName ("Password").ValueCandidate);
				}

				return property.IsValid;
			}

			public override void UpdateEditor (TKDataForm dataForm, TKDataFormEditor editor, TKEntityProperty property)
			{
				List<string> properties = new List<string> () { "Email", "Password", "RepeatPassword", "Name" };
				if (properties.Contains(property.Name)) {
					editor.Style.TextLabelDisplayMode = TKDataFormEditorTextLabelDisplayMode.Hidden;
					TKGridLayoutCellDefinition titleDef = editor.GridLayout.DefinitionForView (editor.TextLabel);
					editor.GridLayout.SetWidth (0, titleDef.Column.Int32Value);
				}

				if (!property.IsValid) {
					editor.Style.Fill = new TKSolidFill (new UIColor (1, 0, 0, 0.3f));
				} else {
					editor.Style.Fill = new TKSolidFill (UIColor.Clear);
				}
			}
		}
	}
}

