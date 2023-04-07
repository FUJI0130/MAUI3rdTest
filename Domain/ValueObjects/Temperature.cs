

using Domain.Helpers;

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
            //_temp = FloatHelpers.RoundDouble(_temp,decimalPoint);
            _temp = _temp.RoundDouble(decimalPoint);//拡張メソッドを使用した形に変更

        }

        protected override bool EqualsCore(Temperature other)
        {
            return _temp == other._temp;//ここで異なるインスタンスでも同じ物として扱えるかを確認する
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
