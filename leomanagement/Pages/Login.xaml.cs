using leomanagement.ViewModels;

namespace leomanagement.Pages;

public partial class Login : ContentPage
{
	public Login(string mode)
	{
		InitializeComponent();
		BindingContext = new LoginWindowViewModel(mode);
	}
}