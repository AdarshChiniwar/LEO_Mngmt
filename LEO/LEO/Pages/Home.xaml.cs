using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace LEO.Pages
{	
	public partial class Home : ContentPage
	{	
		public Home ()
		{
			InitializeComponent ();
		}

        void HomeWebView_Navigating(System.Object sender, Xamarin.Forms.WebNavigatingEventArgs e)
        {
            Loader.IsVisible = true;
        }

        void HomeWebView_Navigated(System.Object sender, Xamarin.Forms.WebNavigatedEventArgs e)
        {
            Loader.IsVisible = false;
        }
    }
}