using TodoSQLite.Data;
using TodoSQLite.Models;

namespace TodoSQLite.Views;

//�ŏ��̈����̓f�[�^���󂯎��v���p�e�B�̖��O���w�肵�A�@�Q�Ԗڂ̈����̓p�����[�^ID���w��

//�p�����[�^ID�������w���Ă�̂��킩��Ȃ�

//[QueryProperty("Item", "Item")] //QueryProperty�������g���āA�y�[�W�J�ڎ��̃p�����[�^�̎󂯓n�������Ă���H�H //�������������Ȃ� //�����A����@Community Toolkit ���Ă��������Ȃ�
[QueryProperty("TestItem", "Test")]//��P�����F���̃N���X�̒��Ńy�[�W�J�ڎ��ɓn�������v���p�e�B�̕ϐ����@�@��Q�����F�����n����Ŏg�p����p�����[�^ID�@�����Őݒ肵�āA�����n����ł�����w�肵�Ďg��
public partial class TodoItemPage : ContentPage
{
	TodoItem item;
	//public TodoItem Item//�������QueryProperty�̑�P�����́A������w���Ă�
	public TodoItem TestItem//�����Ă�
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
        await Shell.Current.GoToAsync("..");//�O�̉�ʂ֖߂�@�Ƃ����Ӗ��炵��
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
        await Shell.Current.GoToAsync("..");//�O�̉�ʂ֖߂�@�Ƃ����Ӗ��炵��
    }
}