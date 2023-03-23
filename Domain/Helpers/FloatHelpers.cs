

namespace Domain.Helpers
{
    public static class FloatHelpers
    {
        public static double RoundDouble(double Value,int decimalPoint)
        {
            double result;
            result = Math.Round(Convert.ToSingle(Value), decimalPoint);
            return result;
        }
    }
}
