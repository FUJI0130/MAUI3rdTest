using Domain.DbContexts;
using Domain.Tables;
using Infrastructure.SQLite;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace MAUI3rdTest.Views;

public partial class SamplePageView : ContentPage
{

    private PhotoDbContext _photoDbContext;


    public SamplePageViewModel _viewModel = new SamplePageViewModel();//test用に


    

    public SamplePageView()
    {
        InitializeComponent();
        BindingContext = _viewModel;//viewModelの中のやつからバインディング出来るようにしたい//これ消すと、Click me の表示が消えた
        //BindingContext = _photoDbContext.Photos;//意味があるのかないのかわからない

        //BindingContext = _viewModel._photos.写真ID;//ここまでやったけど意味ないっぽい

        this.Loaded += _viewModel._Test_tairaba.dbFileCopy_LocalToApp;//名前変更

    }

    public void Test_Click_ConvertEntities(object sender, EventArgs args)
    {
        _viewModel._Test_tairaba.ConvertEntities();//なんか入ってたので取れてるっぽい　３つ入ってた              

    }


    public void Test_Click_InsertDB(object sender, EventArgs args)
    {
        _viewModel._Test_tairaba.InsertNewData();

    }

    private async  void Test_Click_CheckDBdata(object sender, EventArgs args)
    {
        //List<PhotoTables> result = _viewModel._Test_tairaba.GetDBdatas();
        //coll.ItemsSource = result;//ここでwatchしたら、中身入ってたけど、画面には何も表示されなかった

        _photoDbContext = new PhotoDbContext();

        var items = await _photoDbContext.Photos.ToListAsync();//この中にデータ入ってるのは確認できた
        _viewModel._items = items;
        coll.ItemsSource = _viewModel._items;
    }


}
