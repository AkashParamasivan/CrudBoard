using CrudBoard.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrudBoard.Repository
{
    public interface ICrudRepo
    {
        IEnumerable<PersonInfo> GetPerson();

        PersonInfo GetById(int id);

        Task<PersonInfo> PostProduct(PersonInfo per);

        Task<PersonInfo> DeletePerson(int id);

        Task<PersonInfo> PutPerson(int id, PersonInfo item);
    }
}
