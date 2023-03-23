using Domain.ValueObjects;

namespace Domain.Entity
{
    public sealed class PhotoEntity
    {
        public PhotoEntity(int photoId, string fishID, string typeFishID, string tairabaDataID, string weather, DateTime dataDate, double temperature, string userID)
        {
            PhotoId = new PhotoID(photoId);
            FishID = fishID;
            TypeFishID = typeFishID;
            TairabaDataId = new TairabaDataID(tairabaDataID);
            Weather = weather;
            DataDate = dataDate;
            Temperature = new Temperature(temperature);
            UserID = userID;
         }

        //ValueObjectに変えていく
        //public int      PhotoId         { get;}
        public PhotoID       PhotoId         { get;}
        public string        FishID          { get;}
        public string        TypeFishID      { get;}
        //public string        TairabaDataID   { get;}
        public TairabaDataID TairabaDataId   { get;}
        public string        Weather         { get;}
        public DateTime      DataDate        { get;}
        public Temperature   Temperature     { get;}
        public string        UserID          { get;}
    }
}
