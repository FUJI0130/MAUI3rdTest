using SQLite;

namespace sqliteDemo 
{
    public class DemoTblRepository 
    {
        string _dbPath;

        private SQLiteConnection _database;

        public DemoTblRepository ( string dbPath ) 
        {
            _dbPath = dbPath;
            _database = new SQLiteConnection ( _dbPath );
            _database . CreateTable<DemoTable> ( );
        }

        public List<DemoTable> GetAllItem ( ) 
        {
            return _database . Table<DemoTable> ( ) . ToList ( );
        }

        public void insertItem ( string name ) 
        {
            int result = 0;
            if ( string . IsNullOrEmpty ( name ) ) throw new Exception ( "Valid name required" );
            result = _database . Insert ( new DemoTable { Name = name } );
        }
    }
}