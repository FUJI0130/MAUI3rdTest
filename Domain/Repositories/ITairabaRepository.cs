using Domain.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories
{
    public interface ITairabaRepository
    {
        //DataTable型からEntityの型に変更する
        
        //DataTable GetLatest(int id);
        PhotoEntity GetLatest(int id);

    }
}
