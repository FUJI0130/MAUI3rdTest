using Domain.ValueObjects;

namespace Domain.Entity
{
    public sealed class PhotoEntity
    {
        public PhotoEntity(int photoId, string fishID, string typeFishID, string tairabaDataID, string weather, DateTime dataDate, double temperature, string userID)
        {
            PhotoId          = new PhotoID(photoId);
            FishID           = fishID;
            TypeFishID       = typeFishID;
            TairabaDataId    = new TairabaDataID(tairabaDataID);
            Weather          = new Weather(weather);
            DataDate         = dataDate;
            Temperature      = new Temperature(temperature);
            UserID           = userID;
         }


        public PhotoID       PhotoId         { get;}
        public string        FishID          { get;}
        public string        TypeFishID      { get;}
        public TairabaDataID TairabaDataId   { get;}
        public Weather       Weather         { get;}
        public DateTime      DataDate        { get;}
        public Temperature   Temperature     { get;}
        public string        UserID          { get;}
    }
}
