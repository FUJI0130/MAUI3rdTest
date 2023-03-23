
namespace Domain.ValueObjects
{
    public sealed class TairabaDataID : ValueObject<TairabaDataID>
    {
        public string _id { get; }

        public TairabaDataID(string id) 
        {
            _id = id;
        }

        protected override bool EqualsCore(TairabaDataID other)
        {
            throw new NotImplementedException();
        }
    }
}
