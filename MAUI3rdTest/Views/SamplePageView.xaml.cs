using Domain.Tables;
using Infrastructure.SQLite;

namespace MAUI3rdTest.Views;

public partial class SamplePageView : ContentPage
{



    public SamplePageViewModel _viewModel = new SamplePageViewModel();//test用に


    public SamplePageView()
    {
        InitializeComponent();
        BindingContext = _viewModel;//viewModelの中のやつからバインディング出来るようにしたい

        //this.Loaded += dbFileCopy;//これを他に書いた物を渡して大丈夫かテストしたい //DDDでもViewModelのコンストラクタに〇〇SQLiteを渡していた

        //this.Loaded += testPhotoSQLite.dbFileCopy;//テストで製作　テストOK //なんかこの形で試したら出来たので、今度はviewModelの中に書いて、その中から同様に書いても出来るか試す

        //this.Loaded += _viewModel._Test_tairaba.dbFileCopy;//Interfaceに書いてからの流れで動作確認できた //Interfaceの中に書いておいて、〇〇SQLiteの中で実装　という形にすれば使えそうな気がする      //これだとIPhotoRepositoryの扱いになってPhotoSQLiteの関数使えない
        this.Loaded += _viewModel._Test_tairaba.dbFileCopy_LocalToApp;//名前変更
    }

    public void Test_Click_ConvertEntities(object sender, EventArgs args)
    {
        //Debug.WriteLine("Click_ConvertEntity");//動作確認OK

        _viewModel._Test_tairaba.ConvertEntities();//なんか入ってたので取れてるっぽい　３つ入ってた              

    }


    public void Test_Click_InsertDB(object sender, EventArgs args)
    {
        _viewModel._Test_tairaba.InsertNewData();

    }

    public void Test_Click_CheckDBdata(object sender, EventArgs args)
    {
        //List<PhotoTables> result = _viewModel._Test_tairaba.GetDBdatas();
        //coll.ItemsSource = result;//ここでwatchしたら、中身入ってたけど、画面には何も表示されなかった




    }


}
