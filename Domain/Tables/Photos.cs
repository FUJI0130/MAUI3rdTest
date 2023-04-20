using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Tables
{
    public sealed class Photos
    {
        public byte[] 画像 { get; set; }
        [Key]//Kが小文字になっていた
        //public int PhotoID { get; set; }//あかんかった　SQLのエラーになった（データベースにPhotoID が無いと出た）
        public int 写真ID { get; set; }
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
