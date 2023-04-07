namespace sqliteDemo;

public partial class App : Application 
{

    // 追記
    public static DemoTblRepository repository { get; private set; }

    //　変更
    public App( DemoTblRepository repo )
    {
        InitializeComponent();

        MainPage = new AppShell();

        // 追記
        repository = repo;
    }
}
