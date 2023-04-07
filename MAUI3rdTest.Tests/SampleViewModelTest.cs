using Domain.Entity;
using Domain.Repositories;
using MAUI3rdTest.ViewModels;
using Moq;
using System.Diagnostics;

namespace MAUI3rdTest.Tests;

public class SampleViewModelTest
{
    [Fact]
    public void 最初のモックテスト()
    {
        var viewModel = new SampleViewModel(new TairabaMock());

        viewModel.Search();//この中でGetLatestしてる
        Assert.Equal(1, viewModel.PhotoID);
        Assert.Equal("マダイ", viewModel.FishID_Text);
        Assert.Equal("タイラバ", viewModel.TypeFishingID_Text);
        Assert.Equal("00001", viewModel.TairabaDataID_Text);
        Assert.Equal("晴れ", viewModel.Weather_Text);
        Assert.Equal(12.30, viewModel.Temperture);
        Assert.Equal("12.30 ℃", viewModel.Temperture_Text);
        Assert.Equal("2023/03/10 8:00:00", viewModel.DataDate_Text);
        Assert.Equal("userID_A", viewModel.UserID_Text);
    }

    //テスト用にテストモックをここに作る（動作理解用）
    internal class TairabaMock : IPhotosRepository
    {
        public PhotoEntity GetLatest(int id)
        {
            var dt = new PhotoEntity(
                1,
                "マダイ",
                "タイラバ",
                "00001",
                "晴れ",
                Convert.ToDateTime("2023/03/10 8:00:00"),
                12.30,
                "userID_A");
            return dt;
        }
    }


    [Fact]
    public void 最初のmoqモックテスト()//通った　PhotoIDに1を入れておかないと、事前に設定したSetupの値が、Searchの中のGetLatestの中で値が返ってこない状態になっていた
    {
        //moqオブジェクトの生成
        var productMock = new Mock<IPhotosRepository>();
        productMock.Setup(x => x.GetLatest(1)).Returns(
            new PhotoEntity(
                1,
                "マダイ",
                "タイラバ",
                "00001",
                "晴れ",
                Convert.ToDateTime("2023/03/10 8:00:00"),
                12.30,
                "userID_A"
                ));//

        var viewModelmoq = new SampleViewModel(productMock.Object);//
        viewModelmoq.PhotoID = 1;//なんかいけた　ここが１になってないと通らないテストになってた
        viewModelmoq.Search();//entityがnullになってるのがうまくいってない原因

        string test2 = viewModelmoq.FishID_Text;
        Assert.Equal("マダイ",test2);
    }
}
