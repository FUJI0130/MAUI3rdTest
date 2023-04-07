namespace sqliteDemo;

public partial class MainPage : ContentPage 
{
    public MainPage ( ) 
    {
        InitializeComponent ( );
    }

    public void OnNewButtonClicked ( object sender , EventArgs args ) 
    {

        App . repository . insertItem ( newItem . Text );
    }

    public void OnGetButtonClicked ( object sender , EventArgs args ) 
    {

        List<DemoTable> people = App.repository.GetAllItem();
        peopleList . ItemsSource = people;
    }
}