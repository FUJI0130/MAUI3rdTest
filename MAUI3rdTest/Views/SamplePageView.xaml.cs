namespace MAUI3rdTest.Views;

public partial class SamplePageView : ContentPage
{
	public SamplePageView(SampleViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}
