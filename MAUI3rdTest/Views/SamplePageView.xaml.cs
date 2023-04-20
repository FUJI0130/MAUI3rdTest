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

        //this.Loaded += _viewModel._Test_tairaba.dbFileCopy_LocalToApp;　//これに戻してもなぜかｄｂファイル府反映されてない様に見える　          //dbContextに変わっても、これが無いと成立しないはず //名前変更

        Task.Run(() => _viewModel._Test_tairaba.dbFileCopy_LocalToApp_Task());//出来た 　これでいつでもファイル反映できる     //戻しても反映されてなかったのでもう一度試す //ダメだった //Task.Run()書いてみた  //これだとビルドは通るけど、実行されてないっぽい

    }

    public void Test_Click_ConvertEntities(object sender, EventArgs args)
    {
        _viewModel._photoEntities = _viewModel._Test_tairaba.ConvertEntities();//なんか入ってたので取れてるっぽい　３つ入ってた              

    }

    public void Test_Click_InsertDB(object sender, EventArgs args)
    {

        ///// <summary>
        ///// 新規作成
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //private async void NewItemClicked(object sender, EventArgs e)
        //{
        //    _item = new Users();
        //    await this.Navigation.PushAsync(new NewItemPage() { BindingContext = _item });
        //}


    }

    private async void Test_Click_CheckDBdata(object sender, EventArgs args)
    {
        _viewModel._photoEntities = _viewModel._Test_tairaba.ConvertEntities();

        ObservableCollection<PhotoEntity> items_obsv = new ObservableCollection<PhotoEntity>(_viewModel._photoEntities);

        coll.ItemsSource = items_obsv;
    }
}
