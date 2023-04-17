using Domain.Entity;
using Domain.Tables;
using Microsoft.Data.Sqlite;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.SQLite
{
    internal class SQLiteHelper
    {
        private SQLiteConnection _database;


        //internal const string ConnectionString = @"Data Source=D:\MAUI\STEP\STEP4\MAUI3rdTest\DB(test)\tairaba.db;Version=3;";//ダメ
        //internal const string ConnectionString = @"Data Source=D:\MAUI\STEP\STEP4\MAUI3rdTest\DB(test)\sample.db;Version=3;";//ダメ
        //internal const string ConnectionString = @"Data Source=C:\Users\TIPC0038\デスクトップ一時梱包\学習\ドメイン駆動開発の学習\Domain駆動開発学習　プログラム\DDD.db;Version=3;";//参考　なんかこれも読み込めないとか出た
        //internal const string ConnectionString = "Data Source=C:/Users/TIPC0038/デスクトップ一時梱包/学習/ドメイン駆動開発の学習/Domain駆動開発学習　プログラム/DDD.db;Version=3;";//ダメだった //＠外してみた
        //internal const string ConnectionString = @"Data Source=D:\MAUI\STEP\STEP4\MAUI3rdTest\MAUI3rdTest\Resources\Raw\tairaba.db;Version=3;";//Resourceフォルダにコピーした
        //internal const string ConnectionString = @"Data Source=D:\\MAUI\\STEP\\STEP4\\MAUI3rdTest\\MAUI3rdTest\\Resources\\Raw\\tairaba.db;Version=3;";//\から\\に変えた
        //internal const string ConnectionString = @"Data Source=tairaba.db;Version=3;";//開けてるけど、テーブル見つからないって出る //Resource/Rawに入れてるからそのまま試してみる
        //internal const string ConnectionString = @"Data Source=D:\\MAUI\\STEP\\STEP4\\MAUI3rdTest\\MAUI3rdTest\\Resources\\Raw\\tairaba.db;Version=3;";//やっぱりこれだとダメ
        //internal const string ConnectionString = @"Data Source=tairaba.db;";//これだと開けるけど、中身が空？？ //Version外してみる
        //internal const string ConnectionString = @"Data Source=D:\\MAUI\\STEP\\STEP4\\MAUI3rdTest\\MAUI3rdTest\\Resources\\Raw\\tairaba.db;";//やはり開けない
        //internal const string ConnectionString = @"Data Source=D:\\MAUI\\tairaba.db;";//NG
        //internal const string ConnectionString = @"Data Source=D:\MAUI\tairaba.db;";//NG
        //internal const string ConnectionString = @"Data Source=D:\MAUI\tairaba.db;Version=3;";//NG
        //internal const string ConnectionString = @"Data Source=D:/MAUI/tairaba.db;Version=3;";//NG
        //internal const string ConnectionString = "Data Source=D:\\MAUI\\tairaba.db;";//NG
        //internal const string ConnectionString = "Data Source=D:\\MAUI\\tairaba.db;";//NG

        //internal const string ConnectionString = @"Data Source=tairaba.db;Version=3;";//開けてるけど、テーブル見つからないって出る //Resource/Rawに入れてるからそのまま試してみる

        private string CurrentDirPath = "";
        //string ConnectionString = "Data Source=" + CurrentDirPath +"tairaba.db";
        public string ConnectionString = @"Data Source=tairaba.db;Version=3;";


        public SQLiteHelper()
        {
            //CurrentDirPath = FileSystem.Current.AppDataDirectory;//ここでエラーが出てしまう
            //ConnectionString = "Data Source=" + CurrentDirPath + "tairaba.db";

            Console.WriteLine("test");//ここ通ってるはずだけど通らない（非同期処理？？）
            //Console.WriteLine("test DirPath is : " + FileSystem.CacheDirectory );

            //var checkPath = FileSystem.OpenAppPackageFileAsync("tairaba.db");//これで行けると思ったけどダメっぽい


        }



        //Query ・・・　SQLでデータを取ってきて、その値を使ってEntityを作る　そこからListを作って返す処理

        //internal static object SetEntity<T>(
        //    Func<List<T>, T> createEntity)         
        //{
        //    var result = new List<T>();
        //    using (var _database = new SQLiteConnection(ConnectionString))
        //    {
        //        //空のテーブルを作成
        //        _database.CreateTable<T>();//●この先の処理で、Tだと不都合が生じてしまって先に進めない
        //        T objects = new T();
        //        //SQLでデータを取ってくる
        //        var argList = new List<T>();
        //        //Funcの中でEntityを作って返す
        //        var result_object = createEntity(argList);
        //        //Entityを返す
        //        return result;
        //    }
        //}

    }
}
