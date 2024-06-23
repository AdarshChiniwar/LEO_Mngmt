using leomanagement.Pages;

namespace leomanagement
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute("login", typeof(Login));
        }

        private async void MenuItem_Clicked(object sender, EventArgs e)
        {
            MenuItem menuItem = sender as MenuItem;
            if (menuItem.CommandParameter.ToString() == "Bussiness")
            {
                var navigationParameters = new Dictionary<string, object>
                {
                { "mode", "Bussiness" },
                };
                await Shell.Current.GoToAsync("login", navigationParameters);
            }

            if (menuItem.CommandParameter.ToString() == "Kiosk")
            {
                var navigationParameters = new Dictionary<string, object>
                {
                { "mode", "Kiosk" },
                };
                await Shell.Current.GoToAsync("login", navigationParameters);
            }

            Shell.Current.FlyoutIsPresented = false;
        }
    }
}
