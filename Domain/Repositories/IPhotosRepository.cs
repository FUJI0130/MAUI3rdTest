using Domain.Entity;
using Domain.Tables;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories
{
    public interface IPhotosRepository
    {
        PhotoEntity GetLatest(int id);
        //IReadOnlyList<PhotoEntity> GetLatestItem(int id);
        //IReadOnlyList<PhotoTables> GetLatest(int id);

        public void dbFileCopy_LocalToApp(object sender, EventArgs e);

        public void InsertItem(PhotoTables InsertItems);
        public List<PhotoEntity> ConvertEntities();
        public PhotoEntity ConvertEntity(ref PhotoTables item);

        public void ConvertTables(PhotoEntity convertEntity);

        public void UploadImage();


        public void InsertNewData();


        public List<PhotoTables> GetDBdatas();


    }
}
