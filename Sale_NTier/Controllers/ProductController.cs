using BusinessLayer.Concrete;
using BusinessLayer.FluentValidation;
using DataAccessLayer.EntitiyFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;

namespace Sale_NTier.Controllers
{
    public class ProductController : Controller
    {
        ProductManager productManager = new ProductManager(new EfProductDal());

        public IActionResult Index()
        {
            var values = productManager.GetList();
            return View(values);
        }

        [HttpGet]
        public IActionResult AddProduct()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddProduct(Product product)
        {
            ModelState.Clear();
            ProductValidator validationRules = new ProductValidator();
            ValidationResult result = validationRules.Validate(product);
            if (result.IsValid)
            {
                productManager.TAdd(product);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }

        [HttpGet]
        public IActionResult UpdateProduct(int id)
        {
            var vaule = productManager.GetById(id);
            return View(vaule);
        }

        [HttpPost]
        public IActionResult UpdateProduct(Product product)
        {
            ModelState.Clear();
            ProductValidator validationRules = new ProductValidator();
            ValidationResult result = validationRules.Validate(product);
            if (result.IsValid)
            {
                productManager.TUpdate(product);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }

        public IActionResult DeleteProduct(int id)
        {
            var vaule = productManager.GetById(id);
            productManager.TDelete(vaule);
            return RedirectToAction("Index");
        }
    }
}
