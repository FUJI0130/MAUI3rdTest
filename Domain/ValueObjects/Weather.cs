using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ValueObjects
{
    public sealed class Weather : ValueObject<Weather>
    {

        public static readonly Weather None = new Weather("");

        public static readonly Weather Sunny = new Weather("晴れ");

        public static readonly Weather Cloudy = new Weather("曇り");
        
        public static readonly Weather Rain = new Weather("雨");


       
        public Weather(string condition)
        {
            _condition = condition;
        }

        public string _condition { get; }
    
        public string DisplayValue
        {
            get
            {
                if(this == Sunny)
                {
                    return "晴れ";
                }
                if (this == Cloudy)
                {
                    return "曇り";
                }
                if (this == Rain)
                {
                    return "雨";
                }
                return "不明";
            }
        }


        protected override bool EqualsCore(Weather other)
        {
            return this._condition == other._condition;
        }
    }
}
