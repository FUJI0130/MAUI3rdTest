using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//using Microsoft.EntityFrameworkCore;
//using System.ComponentModel.DataAnnotations;


namespace Domain.Tables
{
    //これ、ここに変えたらビルド通った
    [Table("Photos")]//一旦コメントアウト　23/4/19 10:21
    public sealed class PhotoTables
    {
        public byte[] 画像 { get; set; }//これで行けるか？
       [PrimaryKey, AutoIncrement]// 一旦コメントアウト　23/4/19 10:21
                                  //[key]
        public int 写真ID { get; set; }
        [MaxLength(250), Unique]// 一旦コメントアウト　23/4/19 10:21
        public string 釣れた魚ID { get; set; }
            public string 釣り物ID { get; set; }
            public string タイラバデータID { get; set; }
            public string 天気 { get; set; }
            public string 日付 { get; set; }
            public double 水温 { get; set; }
            public string ユーザーID { get; set; }
        //}
    }
}
