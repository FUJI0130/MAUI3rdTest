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
        public IReadOnlyList<PhotoEntity> GetLatestItem(int id)
        {
            var ResultList = new List<PhotoEntity>();           


            return ResultList;
        }


        //SQLからデータを取ってくる処理（その後Entityに変換する）        
        private IReadOnlyList<PhotoTables> GetAllItem()
        {
            using (var _database = new SQLiteConnection(SQLiteHelper.ConnectionString))
            {
                return _database.Table<PhotoTables>().ToList();
            }
        }



        public void InsertItem(PhotoTables InsertItems)
        {
            using (var _database = new SQLiteConnection(SQLiteHelper.ConnectionString))
            {
                int result = 0;

                result = _database.InsertOrReplace (InsertItems);
            }
        }

        //TablesからEntityに変換する処理
        public PhotoEntity ConvertEntity(List<PhotoTables> convertTables)
        {
            //●Tablesの中のカラムをひとつづつ取り出す方法

            SQLiteConnection _PutDatabase = new SQLiteConnection(SQLiteHelper.ConnectionString);
            //空のテーブルを作る
            _PutDatabase.CreateTable<PhotoTables>();

            //これだとTableQuery型になる
            //var test = _PutDatabase.Table<PhotoTables>();                          







        }


        //EntityからTablesに変換する処理
        public IReadOnlyList<PhotoTables> ConvertTables(PhotoEntity convertEntity)
        {
            //●Tablesの中のカラムにデータを入れる方法
              //convertEntity.DataDate;

        }








        //            string sql = @"
        //select 
        //釣れた魚ID,
        //釣り物ID,
        //タイラバデータID,
        //天気,
        //日付,
        //水温,
        //ユーザーID 
        //from 写真
        //where 写真ID= @PhotoId
        //order by DataDate desc
        //LIMIT 1
        //";
        //public PhotoID PhotoId { get; }
        //public string FishID { get; }
        //public string TypeFishID { get; }
        //public TairabaDataID TairabaDataId { get; }
        //public Weather Weather { get; }
        //public DateTime DataDate { get; }
        //public Temperature Temperature { get; }
        //public string UserID { get; }

        //DataTable dt = new DataTable();
        //using (var connection = new SQLiteConnection())



        //return dt;

    }
    }
}
