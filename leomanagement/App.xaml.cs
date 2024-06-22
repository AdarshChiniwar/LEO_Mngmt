using leomanagement.Pages;

namespace leomanagement
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            UserAppTheme = AppTheme.Light;
            try
            {
                
                var data = Preferences.Get("mode", string.Empty);
                if(string.IsNullOrEmpty(data)) 
                {
                    //loginpage
                    //take username and pwd move to main page
                    //In main page check the mode and redirect to the specific page
                    MainPage = new NavigationPage(new Login(string.Empty));

                }
                else
                {
                    //mainpage
                    MainPage = new NavigationPage(new MainPage());
                }
            }
            catch(Exception ex)
            {

            }
          
        }
    }
}
