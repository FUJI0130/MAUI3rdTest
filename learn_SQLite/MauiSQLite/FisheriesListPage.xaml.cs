using Microsoft.EntityFrameworkCore;

namespace MauiSQLite;

public partial class FisheriesListPage : ContentPage
{
	public FisheriesListPage()
	{
		InitializeComponent();
	}

	private async void Button_Clicked(object sender, EventArgs e)
	{
        //多分コンストラクタが読み込まれた時点でOnConfiguringでデータを読み込んでる　// SQLiteから読み込み
        var context = new FisheriesDbContext();
		
		//LINQで書かれてる

				//from【<データ型>】<範囲変数名> in <データオブジェクトモデル名>
		var q = from oroshi in context.T卸売				
				//join　【<データ型>】<範囲変数名> in <データオブジェクトモデル名> on <キー(左)> equals <キー(右)>【into <グループ名>】 
				join subject in context.T品名 on oroshi.品名Id equals subject.Id
				join market in context.T市場 on oroshi.市場Id equals market.Id
				join sale in context.T販売方法 on oroshi.販売方法Id equals sale.Id
				//クエリの昇順降順を指定できる　
				orderby oroshi.日付 descending
				//selectでnewを使った匿名型のオブジェクトで結果データを生成している？
				select new T卸売()
				{
					//左側はデータベースのカラム名　FisheriesDbContextの中で定義
					Id = oroshi.Id,
					品名Id = oroshi.品名Id,
					販売方法Id = oroshi.販売方法Id,
					市場Id = oroshi.市場Id,
					卸売数 = oroshi.卸売数,
					日付 = oroshi.日付,
					品名 = subject,
					市場 = market,
					販売方法 = sale,
				};
        var items = await q.Take(100).ToListAsync();
        coll.ItemsSource = items;

    }
}