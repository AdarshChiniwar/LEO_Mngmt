using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using LEO.Helpers;
using LEO.Models;
using Xamarin.Forms;

namespace LEO.Pages
{	
	public partial class SideMenu : ContentPage
	{	
		public SideMenu ()
		{
			InitializeComponent ();
			BindingContext = this;

			var list = new List<SideMenuModel>()
			{
				new SideMenuModel(){ Id = 1, Title = AppResource.Home, TargetType = typeof(Home) },
				new SideMenuModel(){ Id = 2, Title = AppResource.AboutUs, TargetType = typeof(AboutUs) },
				new SideMenuModel(){ Id = 3, Title = AppResource.ContactUs, TargetType = typeof(ContactUs) },
				new SideMenuModel(){ Id = 4, Title = AppResource.RateApp, Action = ExecuteRateApp },
				new SideMenuModel(){ Id = 5, Title = AppResource.ShareFriends, Action = ExecuteShareApp }
				//new SideMenuModel(){ Id = 6, Title = AppResource.DeleteAccount, Action = ExecuteDeleteAccount },
				//new SideMenuModel(){ Id = 7, Title = AppResource.Logout, Action = ExecuteLogout }
            };

			SideItems = new ObservableCollection<SideMenuModel>(list);
			
		}


        private void ExecuteRateApp()
        {
            MessagingCenter.Instance.Send<object, SideMenuModel>(this, AppResource.MenuItemSelect, null);
        }

        private void ExecuteLogout()
        {
            MessagingCenter.Instance.Send<object, SideMenuModel>(this, AppResource.MenuItemSelect, null);
        }

        private void ExecuteDeleteAccount()
        {
            MessagingCenter.Instance.Send<object, SideMenuModel>(this, AppResource.MenuItemSelect, null);
        }

        private void ExecuteShareApp()
        {
            MessagingCenter.Instance.Send<object, SideMenuModel>(this, AppResource.MenuItemSelect, null);
        }

        private ObservableCollection<SideMenuModel> sideItems;

		public ObservableCollection<SideMenuModel> SideItems
		{
			get => sideItems;
			set
			{
				sideItems = value;
				OnPropertyChanged(nameof(SideItems));
			}
		}

        void Item_Tapped(System.Object sender, System.EventArgs e)
        {
			if (e is TappedEventArgs args)
			{
				if (args != null)
				{
					var selectedItem = args.Parameter as SideMenuModel;
					MessagingCenter.Instance.Send<object, SideMenuModel>(this, AppResource.MenuItemSelect, selectedItem);
				}
			}
        }

        void TwitterButton_Clicked(System.Object sender, System.EventArgs e)
        {
			Xamarin.Essentials.Launcher.OpenAsync(new Uri(Constants.TwitterUrl));
        }

        void FbButton_Clicked(System.Object sender, System.EventArgs e)
        {
            Xamarin.Essentials.Launcher.OpenAsync(new Uri(Constants.FBUrl));
        }

        void YouTubeButton_Clicked(System.Object sender, System.EventArgs e)
        {
            Xamarin.Essentials.Launcher.OpenAsync(new Uri(Constants.YouTubeUrl));
        }

        void LinkedinButton_Clicked(System.Object sender, System.EventArgs e)
        {
            Xamarin.Essentials.Launcher.OpenAsync(new Uri(Constants.LinkedInUrl));
        }
    }
}