using Domain.Entity;
using Domain.Repositories;
using Domain.Tables;
using SQLite;
using System.Data;
using System.Xml.Linq;

using System.Collections.Generic;


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
        PhotoTables photoTables;

        private SQLiteHelper _SQLhelper = new SQLiteHelper();


        //最新のデータだけ　　（一応実装してみる　　使わないかもしれないが）
        public PhotoEntity GetLatest(int id)
        {  
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

        //製作中//  //SQLからデータを取ってくる処理（その後Entityに変換する）        
        private IReadOnlyList<PhotoTables> GetAllItem()
        {
            //using (var _database = new SQLiteConnection(SQLiteHelper.ConnectionString))
            var _SQLhelper = new SQLiteHelper();
            using (var _database = new SQLiteConnection(_SQLhelper.ConnectionString))
            {
                return _database.Table<PhotoTables>().ToList();
            }
        }


        //製作中//  
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

        //製作中//  //TablesからEntityに変換する処理（の予定）
        public List<PhotoEntity> ConvertEntities()
        {
            var result = new List<PhotoEntity>();
            var resultDBdatas = GetDBdatas();

            foreach(PhotoTables items in resultDBdatas)
            {
                PhotoTables resultitem = new PhotoTables();
                resultitem = items;
                result.Add(ConvertEntity(ref resultitem));
            }
            return result;
        }

        public PhotoEntity ConvertEntity(ref PhotoTables item)
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



        //製作中//  //TablesからEntityに変換する処理（の予定）
        public void Test_ConvertEntities()
        {
            //●Tablesの中のカラムをひとつづつ取り出す方法確率する必要ある

            //_SQLhelper.ConnectionString = "/data/user/0/com.companyname.MAUI3rdTest/files/tairaba.db";//test//●開けないと出た

            //接続の確立
            //SQLiteConnection conn = new SQLiteConnection(_SQLhelper.ConnectionString);
            SQLiteConnection conn = new SQLiteConnection(_SQLhelper.ConnectionString);
            //空のテーブルを作る
            //conn.CreateTable<PhotoTables>();

            //変数の初期化
            List<PhotoTables> query = new List<PhotoTables>();

            //query = conn.Query<PhotoTables>("select * from 写真","A%");
            //query = conn.Query<PhotoTables>("select * from Photos", "A%");
            //query = conn.Query<PhotoTables>("select * from Photos");//ここで止まる
            //query = conn.Query<PhotoTables>("select * from ワーム");//ここで止まる
            //query = conn.Query<PhotoTables>("select 写真ID from Photos");//ここで止まる
            //query = conn.Query<PhotoTables>("SELECT name FROM sqlite_master WHERE type='table' ORDER BY NAME;");//クリエイトテーブルやった後に見たら中身入ってるっぽい //中身何も入ってなかった可能性ある //なんか通った　テーブル名を取得するSQL文



            // 概要:
            //     Creates a SQLiteCommand given the command text (SQL) with arguments. Place a
            //     '?' in the command text for each of the arguments and then executes that command.
            //     It returns each row of the result using the mapping automatically generated for
            //     the given type.
            //  引数付きのコマンド テキスト(SQL) を指定して SQLiteCommand を作成します。配置する
            //  '?'各引数のコマンド テキストで、そのコマンドを実行します。
            //  自動生成されたマッピングを使用して、結果の各行を返します
            //  指定された型。
            //
            // パラメーター:
            //   query:
            //     The fully escaped SQL.
            //
            //   args:
            //     Arguments to substitute for the occurences of '?' in the query.
            //      '?' の出現を置換する引数クエリで。
            //
            // 戻り値:
            //     An enumerable with one result for each row returned by the query.
            //      クエリによって返される行ごとに 1 つの結果を持つ列挙型
            //public List<T> Query<T>(string query, params object[] args) where T : new()
            //{
            //    return CreateCommand(query, args).ExecuteQuery<T>();
            //}

            //CreateCommandの説明
            // 概要:
            //     Creates a new SQLiteCommand given the command text with arguments. Place a '?'
            //     in the command text for each of the arguments.

            //  引数付きのコマンド テキストを指定して、新しい SQLiteCommand を作成します。 「?」を配置します。
            //  各引数のコマンド テキスト内。
            //
            // パラメーター:
            //   cmdText:
            //     The fully escaped SQL.完全にエスケープされた SQL
            //
            //   ps:
            //     Arguments to substitute for the occurences of '?' in the command text.
            //     '?' の出現を置換する引数コマンドテキストで。
            //
            // 戻り値:
            //     A SQLite.SQLiteCommand
            //public SQLiteCommand CreateCommand(string cmdText, params object[] ps)
            //{
            //    if (!_open)
            //    {
            //        throw SQLiteException.New(SQLite3.Result.Error, "Cannot create commands from unopened database");
            //    }

            //    SQLiteCommand sQLiteCommand = NewCommand();
            //    sQLiteCommand.CommandText = cmdText;
            //    foreach (object val in ps)
            //    {
            //        sQLiteCommand.Bind(val);
            //    }

            //    return sQLiteCommand;
            //}


            //query = conn.Query<PhotoTables>("select * from Photos", "A%");//テストのビルドエラー出なくなったけど、ここでこれやっても中身何も入ってないっぽい
            query = conn.Query<PhotoTables>("select * from Photos", "");//第２引数は、第１引数のSQL文の中で　？　が書かれてた場合に、それと置き換える文字？を渡すっぽい


            //


            string check_TypeFishID = "";
            string check_FishID = "";

            foreach (PhotoTables item in query)
            {
                System.Diagnostics.Debug.WriteLine("item is : " + item);

                check_TypeFishID = item.釣り物ID.ToString();//なんかここでEntity作れそうな気がしてきた
                check_FishID = item.釣れた魚ID.ToString();
            }

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


        //製作中　 //テスト用にDBのデータを確認する処理が必要
        public List<PhotoTables> GetDBdatas()
        {
            SQLiteConnection conn = new SQLiteConnection(_SQLhelper.ConnectionString);
            //空のテーブルを作る
            //conn.CreateTable<PhotoTables>();

            //変数の初期化
            List<PhotoTables> query = new List<PhotoTables>();

            query = conn.Query<PhotoTables>("select * from Photos", "");//第２引数は、第１引数のSQL文の中で　？　が書かれてた場合に、それと置き換える文字？を渡すっぽい

            string check_TypeFishID = "";
            string check_FishID = "";

            foreach (PhotoTables item in query)
            {
                System.Diagnostics.Debug.WriteLine("item is : " + item);

                check_TypeFishID = item.釣り物ID.ToString();//なんかここでEntity作れそうな気がしてきた
                check_FishID = item.釣れた魚ID.ToString();
            }

            return query;
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


    }

}
