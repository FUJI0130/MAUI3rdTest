using Domain.DbContexts;
using Domain.Entity;
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

        //BindingContext = _viewModel._photoDbContext;//試してみる        

        //this.Loaded += _viewModel._photoSQLite.dbFileCopy_LocalToApp;　//これに戻してもなぜかｄｂファイル府反映されてない様に見える　          //dbContextに変わっても、これが無いと成立しないはず //名前変更

        Task.Run(() => _viewModel._photoSQLite.dbFileCopy_LocalToApp_Task());//出来た 　これでいつでもファイル反映できる     //戻しても反映されてなかったのでもう一度試す //ダメだった //Task.Run()書いてみた  //これだとビルドは通るけど、実行されてないっぽい

    }

    public void Test_Click_ConvertEntities(object sender, EventArgs args)
    {
        var dbcontext = _viewModel._photoDbContext;
        _viewModel._photoEntities = _viewModel._photoSQLite.ConvertEntities(ref dbcontext);//なんか入ってたので取れてるっぽい　３つ入ってた              

    }

    public void Test_Click_InsertDB(object sender, EventArgs args)
    {




    }

    private async void Test_Click_CheckDBdata(object sender, EventArgs args)
    {
        var dbcontext = _viewModel._photoDbContext;
        _viewModel._photoEntities = _viewModel._photoSQLite.ConvertEntities(ref dbcontext);

        ObservableCollection<PhotoEntity> items_obsv = new ObservableCollection<PhotoEntity>(_viewModel._photoEntities);

        coll.ItemsSource = items_obsv;
    }


    private Photos _item;

    //画面遷移最初のテスト
    private async void NewItemClicked(object sender,EventArgs e)
    {
        _item = new Photos();
        await this.Navigation.PushAsync(new AddNewItemPage() { BindingContext = _item });//これ、ContentView だとエラー出てダメだった　多分ContetPageからの遷移なのでContentPageじゃないとダメだったのでは
    }

    //戻ってきたときの処理
    protected override async void OnNavigatedTo(NavigatedToEventArgs args)
    {
        if (_item == null) return;
        if (_item.写真ID != 0) _viewModel._photoDbContext.Photos.Add(_item);//一応それっぽく動いた

        await _viewModel._photoDbContext.SaveChangesAsync();



        var items = await _viewModel._photoDbContext.Photos.ToListAsync();
        coll.ItemsSource = items;
    }


}
