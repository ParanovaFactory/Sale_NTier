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
    public class JobManager : IGenericService<Job>
    {
        IJobDal _jobDal;

        public JobManager(IJobDal jobDal)
        {
            _jobDal = jobDal;
        }

        public Job GetById(int id)
        {
            return _jobDal.GetById(id);
        }

        public List<Job> GetList()
        {
            return _jobDal.GetList();
        }

        public void TAdd(Job t)
        {
            _jobDal.insert(t);
        }

        public void TDelete(Job t)
        {
            _jobDal.delete(t);
        }

        public void TUpdate(Job t)
        {
            _jobDal.update(t);
        }
    }
}
