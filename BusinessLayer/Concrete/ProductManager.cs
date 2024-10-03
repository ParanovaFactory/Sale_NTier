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
    public class ProductManager : IGenericService<Product>
    {
        IProductDal _productDal;

        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

        public Product GetById(int id)
        {
            return _productDal.GetById(id);
        }

        public List<Product> GetList()
        {
            return _productDal.GetList();
        }

        public void TAdd(Product t)
        {
            _productDal.insert(t);
        }

        public void TDelete(Product t)
        {
            _productDal.delete(t);
        }

        public void TUpdate(Product t)
        {
            _productDal.update(t);
        }
    }
}
