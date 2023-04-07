namespace TodoSQLite;

public static class Constants
{
    public const string DatabaseFilename = "TodoSQLite.db3";

    public const SQLite.SQLiteOpenFlags Flags =
        // open the database in read/write mode
        SQLite.SQLiteOpenFlags.ReadWrite |
        // create the database if it doesn't exist
        SQLite.SQLiteOpenFlags.Create |
        // enable multi-threaded database access
        SQLite.SQLiteOpenFlags.SharedCache;

    public static string DatabasePath => 
        Path.Combine(FileSystem.AppDataDirectory, DatabaseFilename);
    //Path.Combine("Resources/Raw/", DatabaseFilename);//これだとダメだった
    //Path.Combine("./Resources/Raw/", DatabaseFilename);//ダメ
    //Path.Combine("D:\\MAUI\\learn_SQLite\\TodoSQLite\\TodoSQLite\\Resources\\Raw\\", DatabaseFilename);//いけた　　が、これだとなんか処理が遅くて２回タップしたことになって２回連続で出る事がある
}
