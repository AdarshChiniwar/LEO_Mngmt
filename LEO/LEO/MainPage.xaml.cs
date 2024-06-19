using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LEO.Helpers;
using LEO.Models;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LEO
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : FlyoutPage
    {
        string _uri = string.Empty;
        public MainPage()
        {
            InitializeComponent();

            MessagingCenter.Subscribe<object, SideMenuModel>(this, AppResource.MenuItemSelect, async (sender, item) =>
            {
                if (item != null && item.TargetType != null)
                {
                    var page = (Page)Activator.CreateInstance(item.TargetType);
                    if (Detail.Navigation.NavigationStack.LastOrDefault() != page)
                    {
                        Detail = new NavigationPage(page);
                        IsPresented = false;
                    }
                }
                else
                {
                    if (item != null)
                    {
                        if (Device.RuntimePlatform == Device.iOS)
                        {
                            _uri = Constants.iOS_APP_STORE;
                        }
                        else
                        {
                            _uri = Constants.ANDROID_PLAY_STORE;
                        }

                        if (item.Id == 4)
                        {
                            if (await Launcher.CanOpenAsync(_uri))
                            {
                                await Launcher.OpenAsync(_uri);
                            }
                            else
                            {
                                await App.Current.MainPage.DisplayAlert("Error", "Your device can't open the app on the store.", "OK");
                            }
                        }
                        else if (item.Id == 5)
                        {
                            await Share.RequestAsync(new ShareTextRequest
                            {
                                Uri = _uri,
                                Title = "Leo business; SPA & Salons"
                            });
                        }
                    }
                    IsPresented = false;
                }
            });

            FlyoutLayoutBehavior = FlyoutLayoutBehavior.Popover;
        }
    }
}

