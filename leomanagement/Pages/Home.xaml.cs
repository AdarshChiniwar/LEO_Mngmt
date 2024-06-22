using leomanagement.ViewModels;
using System.Timers;

namespace leomanagement.Pages;

public partial class Home : ContentPage
{
    HomePageViewModel ViewModel { get; set; }
    public Home()
    {
        InitializeComponent();
        ViewModel = new HomePageViewModel();
        BindingContext = ViewModel;
        Timer_Elapsed(null, null);
        System.Timers.Timer timer = new System.Timers.Timer();
        timer.Interval = 30000;
        timer.Elapsed += Timer_Elapsed;
        timer.Start();
    }
    public async Task<bool> IsInternetAccessibleAsync()
    {
        try
        {
            using var httpClient = new HttpClient();
            var response = await httpClient.GetAsync("https://www.google.com");
            return response.IsSuccessStatusCode;
        }
        catch
        {
            return false;
        }
    }
    private bool IsInternetDisconneted = false;
    private async void Timer_Elapsed(object? sender, ElapsedEventArgs e)
    {
        bool val = await IsInternetAccessibleAsync();
        if (val)
        {
            Device.BeginInvokeOnMainThread(() =>
            {
                if (IsInternetDisconneted)
                {
                    
                    ViewModel.InitUI();
                }
                connectivityBorder.IsVisible = false;
                IsInternetDisconneted = false;
            });
        }
        else
        {
            Device.BeginInvokeOnMainThread(() =>
            {
                connectivityBorder.IsVisible = true;
                ViewModel.IsRunning = true;
                IsInternetDisconneted = true;
            });
        }

    }
    private void HomeWebView_Navigating(object sender, WebNavigatingEventArgs e)
    {
        ViewModel.IsRunning = true;
    }

    private void HomeWebView_Navigated(object sender, WebNavigatedEventArgs e)
    {
        ViewModel.IsRunning = false;
    }
}