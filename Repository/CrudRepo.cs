using CrudBoard.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrudBoard.Repository
{
    public class CrudRepo:ICrudRepo
    {
        private readonly CrudContext _context;

        public CrudRepo()
        {

        }
        public CrudRepo(CrudContext context)
        {
            _context = context;
        }

        public IEnumerable<PersonInfo> GetPerson()
        {
            return _context.PersonInfos.ToList();
        }
        public PersonInfo GetById(int id)
        {
            PersonInfo bk = _context.PersonInfos.FirstOrDefault(P => P.Personid == id);
            return bk;
        }

        public async Task<PersonInfo> PostProduct(PersonInfo per)
        {

            await _context.PersonInfos.AddAsync(per);
            _context.SaveChanges();
            return per;
        }

        public async Task<PersonInfo> DeletePerson(int id)
        {
            PersonInfo sp = await _context.PersonInfos.FindAsync(id);
            if (sp == null)
            {
                throw new NullReferenceException();
            }
            else
            {
                _context.Remove(sp);
                _context.SaveChanges();
            }
            return sp;
        }

        public async Task<PersonInfo> PutPerson(int id, PersonInfo item)
        {
            PersonInfo Sp = await _context.PersonInfos.FindAsync(id);
            //Sp.Pid = item.Pid;
            Sp.Personid = item.Personid;
            Sp.Name = item.Name;
            Sp.Phoneno= item.Phoneno;
            Sp.Address = item.Address;
            Sp.Pincode = item.Pincode;
            _context.SaveChanges();
            return Sp;
        }

    }
}
