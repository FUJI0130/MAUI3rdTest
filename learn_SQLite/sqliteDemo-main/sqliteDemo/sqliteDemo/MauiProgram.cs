namespace sqliteDemo;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {

        //ここからMAUIで新規に作成されるMauiProgramクラスの部分

        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");//これ新規作成される行

                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");//これも最初に新規作成されてるっぽい//これ追加されてる
            });
        //ここまで



        // 下記を追加
        //string dbPath = System.IO.Path.Combine(FileSystem.AppDataDirectory, "people.db3");//pathをくっつけてるだけの処理
        string dbPath = System.IO.Path.Combine("D:\\MAUI\\DB(test)", "test_people.db");//出来た    //任意の位置にファイル作れるか確認する


        builder . Services . AddSingleton<DemoTblRepository> ( s => ActivatorUtilities . CreateInstance<DemoTblRepository> ( s , dbPath ) );

        return builder .Build();
    }
}
