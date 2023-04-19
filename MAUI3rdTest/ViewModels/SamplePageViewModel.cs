using Domain.DbContexts;
using Domain.Repositories;
using Infrastructure.SQLite;
using System.ComponentModel.DataAnnotations;

namespace MAUI3rdTest.ViewModels;

public partial class SamplePageViewModel : ViewModel
{
	private IPhotosRepository _tairaba;
	public IPhotosRepository _Test_tairaba;

	int count = 0;


    public List<Photos> _items { get; set; }

	public Photos _photos { get; set; }


    //とりあえずテストの間だけでも置いとく
    public SamplePageViewModel()
	:this(new PhotoSQLite())
	{ 
	}

    //引数無い場合のコンストラクタ書いたら動いた //●sample開こうとしたときにここでエラー出てる
    public SamplePageViewModel(IPhotosRepository tairaba)
	{
		_tairaba = tairaba;
		_Test_tairaba = tairaba;

		//テスト用
		//Search();//ダメだった　という事は渡されてるインターフェースがおかしい？
	}

	[ObservableProperty]
	public string message = "Click me";

	[RelayCommand]
	private void OnCounterClicked()
	{
		count++;

		if (count == 1)
			Message = $"Clicked {count} time";
		else
			Message = $"Clicked {count} times";

		SemanticScreenReader.Announce(Message);
	}

	public int	  PhotoID { get; set; } = 0;
	public string FishID_Text { get; set; }	= string.Empty;
	public string TypeFishID_Text { get; set; }	= string.Empty;
	public string TairabaDataID_Text { get; set; } = string.Empty;
	public string Weather_Text { get; set; } = string.Empty;
	public string DataDate_Text { get; set; } = string.Empty;
	public double Temperture { get; set; } = 0;
	public string Temperture_Text { get; set; } = string.Empty;
	public string UserID_Text { get; set; } = string.Empty;


	//要はEntityからデータを取得する関数
	public void Search()
	{
		//var entity = _tairaba.GetLatestItem(PhotoID);
		var entity = _tairaba.GetLatest(PhotoID);//名前が不適切なので変える。+適切な機能を持った関数を作る

		if (entity != null)//moqのテストだと、ここがnullになっててスルーされてしまう
		{
			PhotoID				= entity.PhotoId._id;
			FishID_Text			= entity.FishID.ToString();
			TypeFishID_Text		= entity.TypeFishID.ToString();
			TairabaDataID_Text	= entity.TairabaDataId._id;
			Weather_Text		= entity.Weather._condition;
			DataDate_Text		= entity.DataDate.ToString();
			Temperture			= entity.Temperature._temp;
			Temperture_Text		= entity.Temperature.DisplayValueWithSpace();
			UserID_Text			= entity.UserID.ToString();
		}
	}
}
