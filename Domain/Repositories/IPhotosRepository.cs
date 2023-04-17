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

        public void dbFileCopy(object sender, EventArgs e);


    }
}
