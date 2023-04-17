using Domain.Entity;
using Domain.Repositories;
using Infrastructure.SQLite;
using MAUI3rdTest.ViewModels;
using MAUI3rdTest.Views;
using Microsoft.EntityFrameworkCore.Sqlite.Storage.Internal;
using Moq;
using System.Diagnostics;
using System.Threading.Tasks;

namespace MAUI3rdTest.Tests;

public class SampleViewModelTest
{
    [Fact]
    public void 最初のモックテスト()
    {
        //var viewModel = new SamplePageViewModel(new TairabaMock());

        //viewModel.Search();//この中でGetLatestしてる
        //Assert.Equal(1, viewModel.PhotoID);
        //Assert.Equal("マダイ", viewModel.FishID_Text);
        //Assert.Equal("タイラバ", viewModel.TypeFishingID_Text);
        //Assert.Equal("00001", viewModel.TairabaDataID_Text);
        //Assert.Equal("晴れ", viewModel.Weather_Text);
        //Assert.Equal(12.30, viewModel.Temperture);
        //Assert.Equal("12.30 ℃", viewModel.Temperture_Text);
        //Assert.Equal("2023/03/10 8:00:00", viewModel.DataDate_Text);
        //Assert.Equal("userID_A", viewModel.UserID_Text);
    }

    //テスト用にテストモックをここに作る（動作理解用）
    //internal class TairabaMock : IPhotosRepository
    //{
    //    //public PhotoEntity GetLatest(int id)
    //    public PhotoSQLite GetLatest(int id)
    //    {
    //        var dt = new PhotoEntity(
    //            1,
    //            "マダイ",
    //            "タイラバ",
    //            "00001",
    //            "晴れ",
    //            Convert.ToDateTime("2023/03/10 8:00:00"),
    //            12.30,
    //            "userID_A");
    //        return dt;
    //    }
    //}


    [Fact]
    public void 最初のmoqモックテスト()//通った　PhotoIDに1を入れておかないと、事前に設定したSetupの値が、Searchの中のGetLatestの中で値が返ってこない状態になっていた
    {
        //moqオブジェクトの生成
        //var productMock = new Mock<IPhotosRepository>();
        //productMock.Setup(x => x.GetLatest(1)).Returns(
        //    new PhotoEntity(
        //        1,
        //        "マダイ",
        //        "タイラバ",
        //        "00001",
        //        "晴れ",
        //        Convert.ToDateTime("2023/03/10 8:00:00"),
        //        12.30,
        //        "userID_A"
        //        ));//

        //var viewModelmoq = new SampleViewModel(productMock.Object);//
        //viewModelmoq.PhotoID = 1;//なんかいけた　ここが１になってないと通らないテストになってた
        //viewModelmoq.Search();//entityがnullになってるのがうまくいってない原因

        //string test2 = viewModelmoq.FishID_Text;
        //Assert.Equal("マダイ", test2);
    }

    [Fact]
    public void 最初のSQLite関数のテスト()
    {
        PhotoSQLite test_PhotoSQLite = new PhotoSQLite();

        //var PhotoSQLite_Mock = new Mock<PhotoSQLite>();

        //string path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);//"C:\\Users\\TIPC0038\\Documents"
        //string path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);//

        //Console.WriteLine(path);

        //test_PhotoSQLite.ConvertEntity();

        //●ここで非同期処理のテストしたいけど方法がわからん //privateになってたから、それだけか？？

        //test_PhotoSQLite.dbFileCopy_LocalToApp();
    }


    [Fact]
    public void SamplePageView上でパスを確認するテスト()
    {
        SamplePageViewModel viewModel = new SamplePageViewModel();  
        //SamplePageView view = new SamplePageView(viewModel);//これ書くとエラー出る
        //SamplePageView view = new SamplePageView();//エラー消えない  //コンストラクタ無しでテスト
        //SamplePageView view = new SamplePageView();//これをここでテストすること自体が不可能な気がしてきた  //ダメだった　//既に消してた///非同期処理の関数消してみる
        //viewModel._Test_tairaba



    }


    [Fact]
    public void PhotoSQLiteのConvertEntityのテスト()
    {
        SamplePageViewModel viewModel = new SamplePageViewModel();

        //await Task.Run(() => viewModel._Test_tairaba.dbFileCopyAsyncTest());//たぶん非同期の書き方は出来てる気がするけど、前に出たエラーと同じエラーが出た（viewに渡すようにしたら解決した部分） //これでいけるか？？

        //もうview呼んだ方がいいのでは？？？

        //view呼べない

        PhotoSQLite testPhotoSQLite = new PhotoSQLite();

        //Task.Run(() => testPhotoSQLite.dbFileCopyNotAsyncTest());//なぜか通らない？      //ビルド通った

        //Invoke を掛けてないからダメだった？？（タスクが動かないままになってる？）

        

        testPhotoSQLite.ConvertEntity();
    }


}
