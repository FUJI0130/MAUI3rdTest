using SQLite;
using TodoSQLite.Models;

namespace TodoSQLite.Data;


//データベースにアクセスするクラス

public class TodoItemDatabase
{
    SQLiteAsyncConnection Database;
    public TodoItemDatabase()
    {
    }

    async Task Init()
    {
        if (Database is not null)
            return;

        //"/data/user/0/com.companyname.todosqlite/files/TodoSQLite.db3"
        string check = Constants.DatabasePath;//dbファイルの場所特定するのに使用
        Database = new SQLiteAsyncConnection(Constants.DatabasePath, Constants.Flags);
        //var result = await Database.CreateTableAsync<TodoItem>();
        _ = await Database.CreateTableAsync<TodoItem>();//これ（破棄）でも行けた
    }

    public async Task<List<TodoItem>> GetItemsAsync()
    {
        await Init();
        //return await Database.Table<TodoItem>().ToListAsync();//ToListAsync・・・Tableメソッドを非同期的に実行

        return await Database.QueryAsync<TodoItem>("SELECT * FROM [TodoItem]");//なんか行けてたみたい //これで行けるか？
    }

    //使われてなかった
    public async Task<List<TodoItem>> GetItemsNotDoneAsync()
    {
        await Init();
        //return await Database.Table<TodoItem>().Where(t => t.Done).ToListAsync();

        // SQL queries are also possible
        return await Database.QueryAsync<TodoItem>("SELECT * FROM [TodoItem] WHERE [Done] = 0");
    }

    //使われてない
    public async Task<TodoItem> GetItemAsync(int id)
    {
        await Init();
        return await Database.Table<TodoItem>().Where(i => i.ID == id).FirstOrDefaultAsync();
    }

    public async Task<int> SaveItemAsync(TodoItem item)
    {
        await Init();
        if (item.ID != 0)
        {
            return await Database.UpdateAsync(item);
        }
        else
        {
            return await Database.InsertAsync(item);
        }
    }

    public async Task<int> DeleteItemAsync(TodoItem item)
    {
        await Init();
        return await Database.DeleteAsync(item);
    }
}