namespace MAUI3rdTest.Views;

public partial class AddNewItemPage : ContentPage
{
	public AddNewItemPage()
	{
		InitializeComponent();
	}

    private async void Button_Clicked(object sender, EventArgs e)
    {
        await this.Navigation.PopAsync();
    }
}