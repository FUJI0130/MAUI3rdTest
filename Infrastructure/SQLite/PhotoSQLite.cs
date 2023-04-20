using Domain.Entity;
using Domain.Repositories;
using Domain.Tables;
using SQLite;
using System.Data;
using System.Xml.Linq;

using System.Collections.Generic;
using Domain.DbContexts;

namespace Infrastructure.SQLite
{
    //●これ何に使ってるのかわからない（理解できていない）
    static class CollectionHelper
    {
        /// <summary>Collection&lt;T&gt;がnullまたは空であれば真</summary>
        public static bool IsNullOrEmpty<T>(this ICollection<T> collection)
        {
            return (collection == null || collection.Count == 0);
        }
    }


    //製作中//  //私用するViewModelのコンストラクタでnew している
    public sealed class PhotoSQLite : IPhotosRepository
    {
        //PhotoTables photoTables;
        Photos photos;

        private SQLiteHelper _SQLhelper = new SQLiteHelper();


        //最新のデータだけ　　（一応実装してみる　　使わないかもしれないが）
        //public PhotoEntity GetLatest(int id)
        //{  
        //    var ResultList = new PhotoEntity(
        //        1,
        //        "fishID",
        //        "typeFishID",
        //        "tairabaDataID",
        //        "weather",
        //        Convert.ToDateTime("2023/04/10 14:41:00"),
        //        10.00,
        //        "fishID"
        //        );
        //    return ResultList;
        //}

        //製作中//  //SQLからデータを取ってくる処理（その後Entityに変換する）        
        //private IReadOnlyList<PhotoTables> GetAllItem()
        //private IReadOnlyList<Photos> GetAllItem()
        //{
        //    //using (var _database = new SQLiteConnection(SQLiteHelper.ConnectionString))
        //    var _SQLhelper = new SQLiteHelper();
        //    using (var _database = new SQLiteConnection(_SQLhelper.ConnectionString))
        //    {
        //        //return _database.Table<PhotoTables>().ToList();
        //        return _database.Table<Photos>().ToList();
        //    }
        //}


        //製作中//  
        //public void InsertItem(PhotoTables InsertItems)
        public void InsertItem(Photos InsertItems)
        {
            //using (var _database = new SQLiteConnection(SQLiteHelper.ConnectionString))
            var _SQLhelper = new SQLiteHelper();
            using (var _database = new SQLiteConnection(_SQLhelper.ConnectionString))
            {
                int result = 0;

                result = _database.InsertOrReplace(InsertItems);
            }
        }

        //製作中//  //TablesからEntityに変換する処理（の予定）
        public List<PhotoEntity> ConvertEntities()
        {
            var result = new List<PhotoEntity>();
            var resultDBdatas = new DomainDbContext();

            foreach (Photos items in resultDBdatas.Photos)
            {
                var resultItems = items;
                result.Add(ConvertEntity(ref resultItems));
            }
            return result;
        }

        //public PhotoEntity ConvertEntity(ref PhotoTables item)
        public PhotoEntity ConvertEntity(ref Photos item)
        {
            PhotoEntity result = new PhotoEntity(
                item.写真ID,//1
                item.釣れた魚ID,//2
                item.釣り物ID,//3
                item.タイラバデータID,//4
                item.天気,//5
                Convert.ToDateTime(item.日付),//6
                item.水温,//7
                item.ユーザーID//8
                );

            return result;
        }


        //製作中//  //EntityからTablesに変換する処理
        public void ConvertTables(PhotoEntity convertEntity)
        {
            //●Tablesの中のカラムにデータを入れる方法
        }


        //製作中　 //テスト用に写真をDBにアップする処理が必要
        public void UploadImage()
        {

        }

        //製作中　 //テスト用にデータをアップロードする処理が必要
        public void InsertNewData()
        {

        }    


        //製作中//  ほぼ完成？　 dbファイルをアプリで使う場所にコピーする処理   //●Viewが開かれた時に処理されるようになっていると、Viewはデバッグしづらい場所なので、この処理の中身自体もデバッグしづらくなってしまうのでは？？？ //☆Viewの所でAddして処理されてる（View が開かれた時の動作で、この中の処理が行われている）
        public async void dbFileCopy_LocalToApp(object sender, EventArgs e)
        {
            ////"/data/user/0/net.moonmile.sample.maui.mauisqlite/files/sample.db"
            //"/data/user/0/com.companyname.MAUI3rdTest/files/tairaba.db"// デバッグしてみたら出た
            System.Diagnostics.Debug.WriteLine("test");
            string path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "/tairaba.db";//欲しいファイルパス出た　 //こっちはアプリの保存先の設定　//☆ここの保存先のパスは別の所から読み込むときに使うので、使うクラスに設定するようにしないといけない

            _SQLhelper.ConnectionString = path;//test


            //C:\Users\TIPC0038\Documents/sample.db
            //"C:\\Users\\TIPC0038\\Documents/tairaba.db"
            System.Diagnostics.Debug.WriteLine($"path: {path}");

            ////アプリパッケージに含まれるファイルのストリームを開く                
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



        //public async Task dbFileCopy_LocalToApp_Task()
        public async void dbFileCopy_LocalToApp_Task()
        {
            System.Diagnostics.Debug.WriteLine("test");
            string path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "/tairaba.db";//欲しいファイルパス出た　 //こっちはアプリの保存先の設定　//☆ここの保存先のパスは別の所から読み込むときに使うので、使うクラスに設定するようにしないといけない

            _SQLhelper.ConnectionString = path;//test

            System.Diagnostics.Debug.WriteLine($"path: {path}");

            ////アプリパッケージに含まれるファイルのストリームを開く                
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
