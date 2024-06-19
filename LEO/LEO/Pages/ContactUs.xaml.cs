using System;
using System.Collections.Generic;
using LEO.Helpers;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace LEO.Pages
{	
	public partial class ContactUs : ContentPage
	{	
		public ContactUs ()
		{
			InitializeComponent ();
            BindingContext = this;

            PhoneNumber = $"{AppResource.PhoneTel} {Constants.Phone}";
            Email = $"{AppResource.Email} {Constants.Email}";
		}

        #region properties

        private string phoneNumber;
        public string PhoneNumber
        {
            get => phoneNumber;
            set
            {
                phoneNumber = value;
                OnPropertyChanged(nameof(PhoneNumber));
            }
        }

        private string email;
        public string Email
        {
            get => email;
            set
            {
                email = value;
                OnPropertyChanged(nameof(Email));
            }
        }

        #endregion

        async void EmailButton_Clicked(System.Object sender, System.EventArgs e)
        {
            try
            {
                var message = new EmailMessage
                {
                    Subject = "",
                    Body = "",
                    To = new List<string>() { Constants.Email },
                    //Cc = ccRecipients,
                    //Bcc = bccRecipients
                };
                await Xamarin.Essentials.Email.ComposeAsync(message);
            }
            catch (FeatureNotSupportedException fbsEx)
            {
                await DisplayAlert("Alert", fbsEx.Message, "OK");
            }
            catch (Exception ex)
            {
                await DisplayAlert("Alert", ex.Message, "OK");
            }
        }

        async void CallButton_Clicked(System.Object sender, System.EventArgs e)
        {
            try
            {
                PhoneDialer.Open(Constants.Phone);
            }
            catch (ArgumentNullException anEx)
            {
                await DisplayAlert("Alert", anEx.Message, "OK");
            }
            catch (FeatureNotSupportedException ex)
            {
                await DisplayAlert("Alert", ex.Message, "OK");
            }
            catch (Exception ex)
            {
                await DisplayAlert("Alert", ex.Message, "OK");
            }
        }
    }
}