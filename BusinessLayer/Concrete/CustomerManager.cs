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
    public class CustomerManager : IGenericService<Customer>
    {
        ICustomerDal _customerDal;

        public CustomerManager(ICustomerDal customerDal)
        {
            _customerDal = customerDal;
        }

        public Customer GetById(int id)
        {
            return _customerDal.GetById(id);
        }

        public List<Customer> GetCustomersListWithJob()
        {
            return _customerDal.GetCustomerListWithJob();
        }

        public List<Customer> GetList()
        {
            return _customerDal.GetList();
        }

        public void TAdd(Customer t)
        {
            _customerDal.insert(t);
        }

        public void TDelete(Customer t)
        {
            _customerDal.delete(t);
        }

        public void TUpdate(Customer t)
        {
            _customerDal.update(t);
        }
    }
}
