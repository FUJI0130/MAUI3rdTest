using SQLite;

namespace sqliteDemo 
{
    [Table ( "DemoTable" )]
    public class DemoTable 
    {
      [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
      [MaxLength ( 250 ), Unique]
        public string Name { get; set; }
    }
}
