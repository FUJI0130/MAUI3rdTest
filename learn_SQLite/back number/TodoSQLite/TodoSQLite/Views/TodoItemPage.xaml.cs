using TodoSQLite.Data;
using TodoSQLite.Models;

namespace TodoSQLite.Views;

//最初の引数はデータを受け取るプロパティの名前を指定し、　２番目の引数はパラメータIDを指定

//パラメータIDが何を指してるのかわからない

//[QueryProperty("Item", "Item")] //QueryProperty属性を使って、ページ遷移時のパラメータの受け渡しをしている？？ //違ったかもしれない //多分、これ　Community Toolkit ってやつかもしれない
[QueryProperty("TestItem", "Test")]//第１引数：このクラスの中でページ遷移時に渡したいプロパティの変数名　　第２引数：引き渡し先で使用するパラメータID　ここで設定して、引き渡し先でこれを指定して使う
public partial class TodoItemPage : ContentPage
{
	TodoItem item;
	//public TodoItem Item//多分上のQueryPropertyの第１引数は、これを指してる
	public TodoItem TestItem//合ってた
    {
		get => BindingContext as TodoItem;
		set => BindingContext = value;
	}

    TodoItemDatabase database;

    public TodoItemPage(TodoItemDatabase todoItemDatabase)
    {
        InitializeComponent();
        database = todoItemDatabase;
    }

    async void OnSaveClicked(object sender, EventArgs e)
    {
        //if (string.IsNullOrWhiteSpace(Item.Name))
        if (string.IsNullOrWhiteSpace(TestItem.Name))
        {
            await DisplayAlert("Name Required", "Please enter a name for the todo item.", "OK");
            return;
        }

        //await database.SaveItemAsync(Item);
        await database.SaveItemAsync(TestItem);
        await Shell.Current.GoToAsync("..");//前の画面へ戻る　という意味らしい
    }

    async void OnDeleteClicked(object sender, EventArgs e)
    {
        //if (Item.ID == 0)
        if (TestItem.ID == 0)
            return;
        //await database.DeleteItemAsync(Item);
        await database.DeleteItemAsync(TestItem);
        await Shell.Current.GoToAsync("..");
    }

    async void OnCancelClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("..");//前の画面へ戻る　という意味らしい
    }
}