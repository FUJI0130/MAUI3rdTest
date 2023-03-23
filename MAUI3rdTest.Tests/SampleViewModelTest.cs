using Domain.Entity;
using Domain.Repositories;
using MAUI3rdTest.ViewModels;

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
    internal class TairabaMock : ITairabaRepository
    {
        public PhotoEntity GetLatest(int id)
        {
            //throw new NotImplementedException();
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
}
