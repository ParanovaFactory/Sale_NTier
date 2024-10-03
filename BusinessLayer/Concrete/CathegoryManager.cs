using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class CathegoryManager : IGenericService<Cathegory>
    {
        ICathegoryDal _cathegoryDal;

        public CathegoryManager(ICathegoryDal cathegoryDal)
        {
            _cathegoryDal = cathegoryDal;
        }

        public Cathegory GetById(int id)
        {
            return _cathegoryDal.GetById(id);
        }

        public List<Cathegory> GetList()
        {
            return _cathegoryDal.GetList();
        }

        public void TAdd(Cathegory t)
        {
            _cathegoryDal.insert(t);
        }

        public void TDelete(Cathegory t)
        {
            _cathegoryDal.delete(t);
        }

        public void TUpdate(Cathegory t)
        {
            _cathegoryDal.update(t);
        }
    }
}
