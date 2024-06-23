using leomanagement.ViewModels;
namespace leomanagement.Pages;

[QueryProperty(nameof(Mode), "mode")]
public partial class Login : ContentPage, IQueryAttributable
{
    public string Mode { get; set; }
    public Login()
	{
		InitializeComponent();
		
	}
    public Login(string mode)
    {
        InitializeComponent();
        BindingContext = new LoginWindowViewModel(mode);

    }
    public void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        if(query != null)
		{
			string mode = query.ContainsKey("mode") ? query["mode"].ToString() : string.Empty;
            BindingContext = new LoginWindowViewModel(mode);

        }
		else
		{
            BindingContext = new LoginWindowViewModel(string.Empty);
        }
    }
}