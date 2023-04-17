using Infrastructure.SQLite;

namespace MAUI3rdTest.Views;

public partial class SamplePageView : ContentPage
{
    //public PhotoSQLite testPhotoSQLite = new PhotoSQLite();


    SamplePageViewModel _viewModel = new SamplePageViewModel();

    //public SamplePageView(SamplePageViewModel viewModel)
    public SamplePageView()
    {
        InitializeComponent();
        BindingContext = _viewModel;

        //this.Loaded += dbFileCopy;//これを他に書いた物を渡して大丈夫かテストしたい //DDDでもViewModelのコンストラクタに〇〇SQLiteを渡していた

        //this.Loaded += testPhotoSQLite.dbFileCopy;//テストで製作　テストOK //なんかこの形で試したら出来たので、今度はviewModelの中に書いて、その中から同様に書いても出来るか試す

        this.Loaded += _viewModel._Test_tairaba.dbFileCopy;//Interfaceに書いてからの流れで動作確認できた //Interfaceの中に書いておいて、〇〇SQLiteの中で実装　という形にすれば使えそうな気がする      //これだとIPhotoRepositoryの扱いになってPhotoSQLiteの関数使えない
    }


}
