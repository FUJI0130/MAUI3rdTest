using Domain.ValueObjects;

namespace Domain.Entity
{
    public sealed class PhotoEntity
    {
        public PhotoEntity(int photoId, string fishID, string typeFishID, string tairabaDataID, string weather, DateTime dataDate, double temperature, string userID)
        {
            写真ID          = new PhotoID(photoId);
            釣れた魚ID           = fishID;
            釣り物ID       = typeFishID;
            タイラバデータID    = new TairabaDataID(tairabaDataID);
            天気          = new Weather(weather);
            日付         = dataDate;
            水温      = new Temperature(temperature);
            ユーザーID           = userID;
         }


        public PhotoID       写真ID             { get;}
        public string        釣れた魚ID         { get;}
        public string        釣り物ID           { get;}
        public TairabaDataID タイラバデータID   { get;}
        public Weather       天気               { get;}
        public DateTime      日付               { get;}
        public Temperature   水温               { get;}
        public string        ユーザーID         { get;}
    }
}
