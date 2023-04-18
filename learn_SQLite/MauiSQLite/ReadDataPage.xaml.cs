using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyModel;
using System.Linq;

namespace MauiSQLite;

public partial class ReadDataPage : ContentPage
{
	public ReadDataPage()
	{
		InitializeComponent();
	
	}
	FisheriesDbContext context;

	//���f�[�^��ǂݍ��ރ{�^�����N���b�N���ꂽ���̏���
    private async void Button_Clicked(object sender, EventArgs e)
	{
		//�����R���X�g���N�^���ǂݍ��܂ꂽ���_��OnConfiguring�Ńf�[�^��ǂݍ���ł� // SQLite����ǂݍ���
		context = new FisheriesDbContext();
		//�񓯊������Ńf�[�^��ǂ݂ɍs���Ă���ۂ��@ToList��List�Ɋi�[�H
		var items = await context.Users.ToListAsync();
		//xaml�̒��Œ�`����Ă��iCollectionView)
		coll.ItemsSource = items;//�\�����鍀�ڂ�ݒ肵�Ă���i��ʂɕ\������j
    }

	private Users _item;

	/// <summary>
	/// �V�K�쐬
	/// </summary>
	/// <param name="sender"></param>
	/// <param name="e"></param>
	private async void NewItemClicked(object sender, EventArgs e)
	{
		_item = new Users();
        await this.Navigation.PushAsync(new NewItemPage() { BindingContext = _item });
    }
	// �V�K/�X�V��ʂ���߂�����
	protected override async void OnNavigatedTo(NavigatedToEventArgs args)
	{
		if (_item == null)	return;
		if (_item.Id == 0 )	context.Users.Add(_item);
        
        await context.SaveChangesAsync();
        var items = await context.Users.ToListAsync();
		coll.ItemsSource = items;
    }

    /// <summary>
    /// �X�V
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private async void UpdateItemClicked(object sender, EventArgs e)
	{
		if (coll.SelectedItem == null) return;
		var item = coll.SelectedItem;
        await this.Navigation.PushAsync(new UpdateItemPage() {  BindingContext = item });
    }
}

