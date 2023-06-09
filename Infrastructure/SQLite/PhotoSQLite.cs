﻿using Domain.Entity;
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
        private SQLiteHelper _SQLhelper = new SQLiteHelper();

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

        //一旦製作完了    //製作中//  //TablesからEntityに変換する処理（の予定）
        public List<PhotoEntity> ConvertEntities(ref DomainDbContext dbcontext)
        {
            var result = new List<PhotoEntity>();
            //var resultDBdatas = new DomainDbContext();
            var resultDBdatas = dbcontext;

            foreach (Photos items in resultDBdatas.Photos)
            {
                var resultItems = items;
                result.Add(ConvertEntity(ref resultItems));
            }
            return result;
        }

        //一旦製作完了    //public PhotoEntity ConvertEntity(ref PhotoTables item)
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

        //製作中//DbContextで、データ追加する方法調べないといけない  　本に載ってる？？
        public void InsertItem(Photos InsertItems)
        {
            //using (var _database = new SQLiteConnection(SQLiteHelper.ConnectionString))
            //var _SQLhelper = new SQLiteHelper();
            //using (var _database = new SQLiteConnection(_SQLhelper.ConnectionString))
            //{
            //    int result = 0;

            //    result = _database.InsertOrReplace(InsertItems);
            //}



            //参考コード（MauiSQLiteからコピペしてきた）

            ///// <summary>
            ///// 新規作成
            ///// </summary>
            ///// <param name="sender"></param>
            ///// <param name="e"></param>
            //private async void NewItemClicked(object sender, EventArgs e)
            //{
            //    _item = new Users();
            //    await this.Navigation.PushAsync(new NewItemPage() { BindingContext = _item });
            //}



        }

        //製作中　 //テスト用に写真をDBにアップする処理が必要
        public void UploadImage()
        {

        }


        //
        public async void dbFileCopy_AppToLocal_Task()
        {
            System.Diagnostics.Debug.WriteLine("test");
            string path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "/tairaba.db";//欲しいファイルパス出た　 //こっちはアプリの保存先の設定　//☆ここの保存先のパスは別の所から読み込むときに使うので、使うクラスに設定するようにしないといけない

            _SQLhelper.ConnectionString = path;//test

            System.Diagnostics.Debug.WriteLine($"path: {path}");

            ////アプリパッケージに含まれるファイルのストリームを開く                
            using var stream = await FileSystem.OpenAppPackageFileAsync("tairaba.db");//上でそれっぽいパスが出たので試してみる//逆だった。　こっちがRawファイルっぽい//これ違った。上のpathで開いてるsample.dbとこれは別。こっちはアプリパッケージに含まれるファイル

            //変更予定
            using var streamData = new StreamReader(path);//これでいけるか？？(アプリ上でデータが追加されたDBのデータを入れたい)//多分、Dbcontextでusesqliteしてるパスと同じパスは指定出来てるように思う


            using var reader = new BinaryReader(stream);//ストリームで開いてから、バイナリリーダーに渡す

            ////ファイルの書込み先の設定
            //using var fs = System.IO.File.OpenWrite(path);//ファイルの書込み？

            //変更予定  //ここのパスは、dbファイルのパスなので、そのままtairaba.dbで、rawフォルダのファイルが更新される・・・？？
            string raw_dir_tairabaDB_path = "tairaba.db";
            using var fs = System.IO.File.OpenWrite(raw_dir_tairabaDB_path);
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
