using Domain.DbContexts;
using Domain.Entity;
using Domain.Repositories;
using Domain.Tables;
using Infrastructure.SQLite;
using System.ComponentModel.DataAnnotations;

namespace MAUI3rdTest.ViewModels;

public partial class SamplePageViewModel : ViewModel
{
	private IPhotosRepository _tairaba;
	public IPhotosRepository _photoSQLite;

	int count = 0;

	public DomainDbContext _photoDbContext { get; set; }//ここに設定する意味無かった可能性ある

	public List<PhotoEntity> _photoEntities = new List<PhotoEntity>();

    //とりあえずテストの間だけでも置いとく
    public SamplePageViewModel()
	:this(new PhotoSQLite())
	{ 
	}

    //引数無い場合のコンストラクタ書いたら動いた //●sample開こうとしたときにここでエラー出てる
    public SamplePageViewModel(IPhotosRepository tairaba)
	{
		_tairaba = tairaba;
		_photoSQLite = tairaba;
		_photoDbContext = new DomainDbContext();

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

	//要はEntityからデータを取得する関数
	public void Search()
	{
		////var entity = _tairaba.GetLatestItem(PhotoID);
		//var entity = _tairaba.GetLatest(PhotoID);//名前が不適切なので変える。+適切な機能を持った関数を作る
		////var entity = _tairaba.GetLatest(写真ID);//test

		//if (entity != null)//moqのテストだと、ここがnullになっててスルーされてしまう
		//{
		//	//写真ID				= entity.PhotoId._id;//test

		//	//PhotoID				= entity.PhotoId._id;
		//	//FishID_Text			= entity.FishID.ToString();
		//	//TypeFishID_Text		= entity.TypeFishID.ToString();
		//	//TairabaDataID_Text	= entity.TairabaDataId._id;
		//	//Weather_Text		= entity.Weather._condition;
		//	//DataDate_Text		= entity.DataDate.ToString();
		//	//Temperture			= entity.Temperature._temp;
		//	//Temperture_Text		= entity.Temperature.DisplayValueWithSpace();
		//	//UserID_Text			= entity.UserID.ToString();
		//}
	}
}
