using leomanagement.ViewModels;

namespace leomanagement.Pages;

public partial class ContactUs : ContentPage
{
	public ContactUs()
	{
		InitializeComponent();
		this.BindingContext = new ContactUsViewModel();
	}
}