using Domain.Entity;
using Domain.Repositories;
using Domain.Tables;
using SQLite;
using System.Data;
using System.Xml.Linq;

using System.Collections.Generic;


namespace Infrastructure.SQLite
{
    static class CollectionHelper
    {
        /// <summary>Collection&lt;T&gt;がnullまたは空であれば真</summary>
        public static bool IsNullOrEmpty<T>(this ICollection<T> collection)
        {
            return (collection == null || collection.Count == 0);
        }
    }


    //私用するViewModelのコンストラクタでnew している
    public sealed class PhotoSQLite : IPhotosRepository
    {
        PhotoTables photoTables;


        //最新のデータだけ　　（一応実装してみる　　使わないかもしれないが）
        public PhotoEntity GetLatest(int id)
        //public IReadOnlyList<PhotoEntity> GetLatestItem(int id)
        {
            //var ResultList = new List<PhotoEntity>();           
            var ResultList = new PhotoEntity(
                1,
                "fishID",
                "typeFishID",
                "tairabaDataID",
                "weather",
                Convert.ToDateTime("2023/04/10 14:41:00"),
                10.00,
                "fishID"
                );


            return ResultList;
        }

        //SQLからデータを取ってくる処理（その後Entityに変換する）        
        private IReadOnlyList<PhotoTables> GetAllItem()
        {
            //using (var _database = new SQLiteConnection(SQLiteHelper.ConnectionString))
            var _SQLhelper = new SQLiteHelper();
            using (var _database = new SQLiteConnection(_SQLhelper.ConnectionString))
            {
                return _database.Table<PhotoTables>().ToList();
            }
        }

        public void InsertItem(PhotoTables InsertItems)
        {
            //using (var _database = new SQLiteConnection(SQLiteHelper.ConnectionString))
            var _SQLhelper = new SQLiteHelper();
            using (var _database = new SQLiteConnection(_SQLhelper.ConnectionString))
            {
                int result = 0;

                result = _database.InsertOrReplace(InsertItems);
            }
        }

        //TablesからEntityに変換する処理
        //public PhotoEntity ConvertEntity(List<PhotoTables> convertTables)
        //public void ConvertEntity(List<PhotoTables> convertTables)
        public void ConvertEntity()
        {
            //●Tablesの中のカラムをひとつづつ取り出す方法確率する必要ある


            var _SQLhelper = new SQLiteHelper();


            //接続の確立
            //SQLiteConnection conn = new SQLiteConnection(SQLiteHelper.ConnectionString);
            SQLiteConnection conn = new SQLiteConnection(_SQLhelper.ConnectionString);
            //空のテーブルを作る
            conn.CreateTable<PhotoTables>();

            //変数の初期化
            List<PhotoTables> query = new List<PhotoTables>();

            //query = conn.Query<PhotoTables>("select * from 写真","A%");
            //query = conn.Query<PhotoTables>("select * from Photos", "A%");
            //query = conn.Query<PhotoTables>("select * from Photos");//ここで止まる
            //query = conn.Query<PhotoTables>("select * from ワーム");//ここで止まる
            //query = conn.Query<PhotoTables>("select 写真ID from Photos");//ここで止まる
            //query = conn.Query<PhotoTables>("SELECT name FROM sqlite_master WHERE type='table' ORDER BY NAME;");//クリエイトテーブルやった後に見たら中身入ってるっぽい //中身何も入ってなかった可能性ある //なんか通った　テーブル名を取得するSQL文
            query = conn.Query<PhotoTables>("select * from Photos", "A%");//テストのビルドエラー出なくなったけど、ここでこれやっても中身何も入ってないっぽい

            foreach (PhotoTables item in query)
            {
                System.Diagnostics.Debug.WriteLine("item is : " + item);
            }

        }


        //EntityからTablesに変換する処理
        //public IReadOnlyList<PhotoTables> ConvertTables(PhotoEntity convertEntity)
        public void ConvertTables(PhotoEntity convertEntity)
        {
            //●Tablesの中のカラムにデータを入れる方法
            //convertEntity.DataDate;



        }


        public async void dbFileCopy(object sender, EventArgs e)
        {
            ////"/data/user/0/net.moonmile.sample.maui.mauisqlite/files/sample.db"
            //"/data/user/0/com.companyname.MAUI3rdTest/files/tairaba.db"// デバッグしてみたら出た
            System.Diagnostics.Debug.WriteLine("test");
            string path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "/tairaba.db";//欲しいファイルパス出た　 //こっちはアプリの保存先の設定　//☆ここの保存先のパスは別の所から読み込むときに使うので、使うクラスに設定するようにしないといけない


            //C:\Users\TIPC0038\Documents/sample.db
            //"C:\\Users\\TIPC0038\\Documents/tairaba.db"
            System.Diagnostics.Debug.WriteLine($"path: {path}");

            ////アプリパッケージに含まれるファイルhwのストリームを開く                
            using var stream = await FileSystem.OpenAppPackageFileAsync("tairaba.db");//上でそれっぽいパスが出たので試してみる//逆だった。　こっちがRawファイルっぽい//これ違った。上のpathで開いてるsample.dbとこれは別。こっちはアプリパッケージに含まれるファイル

            using var reader = new BinaryReader(stream);//ストリームで開いてから、バイナリリーダーに渡す

            ////ファイルの書込み先の設定
            using var fs = System.IO.File.OpenWrite(path);//ファイルの書込み？
            using var writer = new BinaryWriter(fs);

            long size = 0;
            while (true)
            {
                var data = reader.ReadBytes(1024 * 1024);
                writer.Write(data);
                size += data.Length;
                if (data.Length < 1024 * 1024) break;
            }
            System.Diagnostics.Debug.WriteLine($"total: {size}");
        }
    }

}
