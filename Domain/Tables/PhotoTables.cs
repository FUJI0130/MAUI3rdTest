using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Tables
{
    public sealed class PhotoTables
    {
        [Table("写真")]
        public class 写真
        {
            public byte[] 画像 { get; set; }//これで行けるか？
            [PrimaryKey, AutoIncrement]
            public int 写真ID { get; set; }
            [MaxLength(250), Unique]
            public string 釣れた魚ID { get; set; }
            public string 釣り物ID { get; set; }
            public string タイラバデータID { get; set; }
            public string 天気 { get; set; }
            public string 日付 { get; set; }
            public double 水温 { get; set; }
            public string ユーザーID { get; set; }
        }
    }
}
