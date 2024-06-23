using leomanagement.Converters;
using leomanagement.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace leomanagement.ViewModels
{
    public class LoginWindowViewModel : ViewModelBase
    {
        #region Full Properties
        private string userName;
        public string UserName
        {
            get { return userName; }
            set { userName = value; OnPropertyChanged(nameof(UserName)); }
        }

        private string password;
        public string Password
        {
            get { return password; }
            set { password = value; OnPropertyChanged(nameof(Password)); }
        }

        private bool layoutVisibleOnMode;
        public bool LayoutVisibleOnMode
        {
            get { return layoutVisibleOnMode; }
            set { layoutVisibleOnMode = value; OnPropertyChanged(nameof(LayoutVisibleOnMode)); }
        }
        private string location;
        public string Location
        {
            get { return location; }
            set { location = value; OnPropertyChanged(nameof(Location)); }
        }

        private string bussinessCode;
        public string BussinessCode
        {
            get { return bussinessCode; }
            set { bussinessCode = value; OnPropertyChanged(nameof(BussinessCode)); }
        }
        private string key;
        public string Key
        {
            get { return key; }
            set { key = value; OnPropertyChanged(nameof(Key)); }
        }
        public ICommand LoginKioskCmd { get; set; }
        public ICommand LoginBussinessCmd { get; set; }
        #endregion

        #region Constructor
        public LoginWindowViewModel(string mode)
        {
            LoginBussinessCmd = new Command(NavigateToMainPageInBussinessMode);
            LoginKioskCmd = new Command(NavigateToMainPageInKioskMode);
            if (string.IsNullOrEmpty(mode))
            {
                var data = Preferences.Get("mode", string.Empty);
                if (string.IsNullOrEmpty(data))
                {
                    LayoutVisibleOnMode = true;
                }
            }
            else
            {
                if (mode.Equals("Bussiness"))
                {
                    LayoutVisibleOnMode = true;
                }
                else if(mode.Equals("Kiosk"))
                {
                    LayoutVisibleOnMode = false; 
                }
            }
         
        }




        #endregion
        #region Functions
        private async void NavigateToMainPageInKioskMode(object obj)
        {
            if (string.IsNullOrEmpty(Location) || string.IsNullOrEmpty(BussinessCode) || string.IsNullOrEmpty(Key))
            {
                await Application.Current.MainPage.DisplayAlert("Incomplete input", "Fields cannot be empty", "Ok");
            }
            else
            {
                string data = Location + BussinessCode + Key;
                string base64String = Base64Converter.ConvertStringToBase64(data);
                ApplicationModel applicationModel = new ApplicationModel()
                {
                    EncData = base64String,
                    Mode = ModeEnum.Kiosk,
                    Link = string.Format(ApplicationLink.KioskLink, base64String)
                };
                string serialize = JsonConvert.SerializeObject(applicationModel);
                Preferences.Set("mode", serialize);
                Application.Current.MainPage = new AppShell();
            }
        }
        private async void NavigateToMainPageInBussinessMode()
        {
            //Navigate to mainpage and pass the argument based on preferences
            if (string.IsNullOrEmpty(UserName) || string.IsNullOrEmpty(Password))
            {
                await Application.Current.MainPage.DisplayAlert("Incomplete input", "Fields cannot be empty", "Ok");
            }
            else
            {
                string data = UserName + Password;
                string base64String = Base64Converter.ConvertStringToBase64(data);
                ApplicationModel applicationModel = new ApplicationModel()
                {
                    EncData = base64String,
                    Mode = ModeEnum.Bussiness,
                    Link = string.Format(ApplicationLink.BussinessLink, base64String)
                };
                string serialize = JsonConvert.SerializeObject(applicationModel);
                Preferences.Set("mode", serialize);
                Application.Current.MainPage = new AppShell();
            }
        }
        #endregion
    }
}
