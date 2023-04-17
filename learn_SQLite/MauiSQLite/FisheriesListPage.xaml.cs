using Microsoft.EntityFrameworkCore;

namespace MauiSQLite;

public partial class FisheriesListPage : ContentPage
{
	public FisheriesListPage()
	{
		InitializeComponent();
	}

	private async void Button_Clicked(object sender, EventArgs e)
	{
        //�����R���X�g���N�^���ǂݍ��܂ꂽ���_��OnConfiguring�Ńf�[�^��ǂݍ���ł�@// SQLite����ǂݍ���
        var context = new FisheriesDbContext();
		
		//LINQ�ŏ�����Ă�

				//from�y<�f�[�^�^>�z<�͈͕ϐ���> in <�f�[�^�I�u�W�F�N�g���f����>
		var q = from oroshi in context.T����				
				//join�@�y<�f�[�^�^>�z<�͈͕ϐ���> in <�f�[�^�I�u�W�F�N�g���f����> on <�L�[(��)> equals <�L�[(�E)>�yinto <�O���[�v��>�z 
				join subject in context.T�i�� on oroshi.�i��Id equals subject.Id
				join market in context.T�s�� on oroshi.�s��Id equals market.Id
				join sale in context.T�̔����@ on oroshi.�̔����@Id equals sale.Id
				//�N�G���̏����~�����w��ł���@
				orderby oroshi.���t descending
				//select��new���g���������^�̃I�u�W�F�N�g�Ō��ʃf�[�^�𐶐����Ă���H
				select new T����()
				{
					//�����̓f�[�^�x�[�X�̃J�������@FisheriesDbContext�̒��Œ�`
					Id = oroshi.Id,
					�i��Id = oroshi.�i��Id,
					�̔����@Id = oroshi.�̔����@Id,
					�s��Id = oroshi.�s��Id,
					������ = oroshi.������,
					���t = oroshi.���t,
					�i�� = subject,
					�s�� = market,
					�̔����@ = sale,
				};
        var items = await q.Take(100).ToListAsync();
        coll.ItemsSource = items;

    }
}