
namespace Domain.ValueObjects
{
    public sealed class PhotoID : ValueObject<PhotoID>
    {
        public PhotoID(int id)
        {
            _id = id;
        }
        public int _id { get; }

        protected override bool EqualsCore(PhotoID other)
        {
            return _id == other._id;//ここで異なるインスタンスでも同じ物として扱えるかを確認する
        }

        public string DisplayValue()
        {
            return _id.ToString();
        }
    }
}
