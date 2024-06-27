using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Microsoft.Maui.ApplicationModel.Communication;

namespace leomanagement.ViewModels
{
    public class ContactUsViewModel : ViewModelBase
    {
        #region Properties
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
        public string EmailData
        {
            get => email;
            set
            {
                email = value;
                OnPropertyChanged(nameof(EmailData));
            }

        }

        public ICommand EmailCmd { get; set; }
        public ICommand PhoneCmd { get; set; }
        public ICommand FbCmd { get; set; }
        public ICommand YtCmd { get; set; }
        #endregion

        #region Constructor
        public ContactUsViewModel()
        {
            PhoneNumber = $"{AppResource.PhoneTel} {Constants.Phone}";
            EmailData = $"{AppResource.Email} {Constants.Email}";
            EmailCmd = new Command(SendEmail);
            PhoneCmd = new Command(PhoneNow);
            FbCmd = new Command(OpenFb);
            YtCmd = new Command(OpenYt);
        }






        #endregion

        #region Functions

        private async void OpenYt()
        {
           await Launcher.OpenAsync(new Uri(Constants.YouTubeUrl));
          
        }

        private async void OpenFb()
        {
           await Launcher.OpenAsync(new Uri(Constants.FBUrl));
        }
        private async void SendEmail()
        {
            try
            {
                var message = new EmailMessage
                {
                    Subject = "",
                    Body = "",
                    To = new List<string>() { Constants.Email },
                };
                await Email.ComposeAsync(message);
            }
            catch (FeatureNotSupportedException fbsEx)
            {
                await Application.Current.MainPage.DisplayAlert("Alert", fbsEx.Message, "OK");
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Alert", ex.Message, "OK");
            }

        }
        private async void PhoneNow()
        {
            try
            {
                PhoneDialer.Open(Constants.Phone);
            }
            catch (ArgumentNullException anEx)
            {
                await Application.Current.MainPage.DisplayAlert("Alert", anEx.Message, "OK");
            }
            catch (FeatureNotSupportedException ex)
            {
                await Application.Current.MainPage.DisplayAlert("Alert", ex.Message, "OK");
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Alert", ex.Message, "OK");
            }
        }
        #endregion
    }
}
