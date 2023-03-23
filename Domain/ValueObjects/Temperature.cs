using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ValueObjects
{
    public sealed class Temperature : ValueObject<Temperature>
    {
        public double _temp { get; }
        private int decimalPoint = 2;
        private string UnitName = "℃";
        private string UnitNameWithSpace = " ℃";

        public Temperature(double temp)
        {
            _temp = temp;
            _temp = RoundDouble();

        }

        protected override bool EqualsCore(Temperature other)
        {
            return _temp == other._temp;//ここで異なるインスタンスでも同じ物として扱えるかを確認する
        }

        private double RoundDouble()
        {
            double result;
            result = Math.Round(Convert.ToSingle( _temp), decimalPoint);
            return result;
        }

        public string DisplayValue()
        {
            return _temp.ToString("F"+ decimalPoint) + UnitName;
        }
        public string DisplayValueWithSpace()
        {
            return _temp.ToString("F" + decimalPoint) + UnitNameWithSpace;
        }
    }
}
