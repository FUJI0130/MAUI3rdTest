using Domain.DbContexts;
using Domain.Tables;
using Infrastructure.SQLite;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace MAUI3rdTest.Views;

public partial class SamplePageView : ContentPage
{
    //private PhotoDbContext _photoDbContext;

    public SamplePageViewModel _viewModel = new SamplePageViewModel();//test用に    

    public SamplePageView()
    {
        InitializeComponent();
        //BindingContext = _viewModel;//一応小細工したらビルド通って画面に表示できた23/4/20 11:11　 //viewModelの中のやつからバインディング出来るようにしたい//これ消すと、Click me の表示が消えた
        //BindingContext = _photoDbContext.Photos;//意味があるのかないのかわからない

        //BindingContext = _viewModel._photos.写真ID;//ここまでやったけど意味ないっぽい


        BindingContext = _viewModel._photoDbContext;//試してみる 

        

        this.Loaded += _viewModel._Test_tairaba.dbFileCopy_LocalToApp;//名前変更
    }

    public void Test_Click_ConvertEntities(object sender, EventArgs args)
    {
        _viewModel._photoEntities = _viewModel._Test_tairaba.ConvertEntities();//なんか入ってたので取れてるっぽい　３つ入ってた              

    }

    public void Test_Click_InsertDB(object sender, EventArgs args)
    {
        _viewModel._Test_tairaba.InsertNewData();
    }

    private async  void Test_Click_CheckDBdata(object sender, EventArgs args)
    {
        //List<PhotoTables> result = _viewModel._Test_tairaba.GetDBdatas();
        //coll.ItemsSource = result;//ここでwatchしたら、中身入ってたけど、画面には何も表示されなかった

        _viewModel._photoDbContext = new PhotoDbContext();

        var items = await _viewModel._photoDbContext.Photos.ToListAsync();//この中にデータ入ってるのは確認できた
        //var items = await _viewModel._photoDbContext.PhotosData.ToListAsync();//この中にデータ入ってるのは確認できた

        ObservableCollection<Photos> items_obsv = new ObservableCollection<Photos>(items);

        //一回viewModelの中にべた書きでプロパティに値設定してみる

        //確認はできたけど意味ない。
        //foreach(Photos photos in items)
        //{
        //    _viewModel.写真ID = photos.写真ID;
        //    //_viewModel.PhotoID = photos.PhotoID;//test //あかんかった
        //    _viewModel.FishID_Text = photos.釣れた魚ID;
        //    _viewModel.TypeFishID_Text = photos.釣り物ID;
        //    _viewModel.TairabaDataID_Text = photos.タイラバデータID;
        //    _viewModel.Weather_Text = photos.天気;
        //    _viewModel.DataDate_Text = photos.日付;
        //    _viewModel.Temperture_Text = photos.水温.ToString();
        //    _viewModel.UserID_Text = photos.ユーザーID.ToString();
        //}


        //_viewModel._items = items;//ここまでは中身入ってるのが確認できてる　この後のバインディングがうまくいかない
        _viewModel._items = items_obsv;//ここまでは中身入ってるのが確認できてる　この後のバインディングがうまくいかない

        coll.ItemsSource = _viewModel._items;//これ書かないと画面にListの表示されないっぽい
        //coll.ItemsSource = items;//

        //どっちでやってもバインドエラーの内容同じ



    }
}
