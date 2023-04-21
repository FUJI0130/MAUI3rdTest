using Domain.DbContexts;
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
        public void dbFileCopy_LocalToApp_Task();

        //public List<PhotoEntity> ConvertEntities();
        public List<PhotoEntity> ConvertEntities(ref DomainDbContext dbcontext);

        public PhotoEntity ConvertEntity(ref Photos item);

        public void InsertItem(Photos InsertItems);

        public void UploadImage();
    }
}
