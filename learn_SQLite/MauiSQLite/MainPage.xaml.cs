//using System.IO;
using System.Text;

namespace MauiSQLite;

public partial class MainPage : ContentPage
{
	public MainPage()
	{
		InitializeComponent();
		this.Loaded += MainPage_Loaded;
	}


	
    //DBのデータをdbファイルからコピーしてくる必要があるらしい	//☆この処理だと、アプリを落とすと全部リセットされてた
    private async void MainPage_Loaded(object sender, EventArgs e)
	{
        //"/data/user/0/net.moonmile.sample.maui.mauisqlite/files/sample.db"
        string path			= Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "/sample.db";//こっちはアプリの保存先の設定androidの時はデバッグログで場所追えるらしい

        System.Diagnostics.Debug.WriteLine($"path: {path}");

		//アプリパッケージに含まれるファイルhwのストリームを開く
        using var stream	= await FileSystem.OpenAppPackageFileAsync("sample.db");//逆だった。　こっちがRawファイルっぽい//これ違った。上のpathで開いてるsample.dbとこれは別。こっちはアプリパッケージに含まれるファイル//Rawフォルダに入れとけば相対パス入れなくてもファイル名でいけるかも？

        using var reader	= new BinaryReader(stream);//ストリームで開いてから、バイナリリーダーに渡す

		//ファイルの書込み先の設定
        using var fs		= System.IO.File.OpenWrite(path);//ファイルの書込み？
        using var writer	= new BinaryWriter(fs);

		long size = 0;
		while ( true )
		{
            var data = reader.ReadBytes(1024 * 1024);
			writer.Write(data);
			size += data.Length;
			if (data.Length < 1024 * 1024) break;
        }
		System.Diagnostics.Debug.WriteLine($"total: {size}");
    }
}

