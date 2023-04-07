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

        internal const string ConnectionString = @"Data Source=D:\MAUI\DB(test)\tairaba.db;Version=3;";


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
