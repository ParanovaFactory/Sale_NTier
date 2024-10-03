using BusinessLayer.Concrete;
using BusinessLayer.FluentValidation;
using DataAccessLayer.EntitiyFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;

namespace Sale_NTier.Controllers
{
    public class CustomerController : Controller
    {
        CustomerManager customerManager = new CustomerManager(new EfCustomerDal());

        public IActionResult Index()
        {
            var values = customerManager.GetCustomersListWithJob();
            return View(values);
        }

        [HttpGet]
        public IActionResult AddCustomer()
        {
            JobManager jobManager = new JobManager(new EfJobDal());
            List<SelectListItem> values = (from x in jobManager.GetList()
                                           select new SelectListItem
                                           {
                                               Text = x.Name,
                                               Value = x.JobId.ToString()
                                           }).ToList();
            ViewBag.v = values;
            return View();
        }

        [HttpPost]
        public IActionResult AddCustomer(Customer customer)
        {
            ModelState.Clear();
            CustomerValidator validationRules = new CustomerValidator();
            ValidationResult validationResult = validationRules.Validate(customer);

            if (validationResult.IsValid)
            {
                customerManager.TAdd(customer);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in validationResult.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }

        [HttpGet]
        public IActionResult UpdateCustomer(int id)
        {
            JobManager jobManager = new JobManager(new EfJobDal());
            List<SelectListItem> values = (from x in jobManager.GetList()
                                           select new SelectListItem
                                           {
                                               Text = x.Name,
                                               Value = x.JobId.ToString()
                                           }).ToList();
            ViewBag.v = values;
            var value = customerManager.GetById(id);
            return View(value);
        }

        [HttpPost]
        public IActionResult UpdateCustomer(Customer customer)
        {
            ModelState.Clear();
            CustomerValidator validationRules = new CustomerValidator();
            ValidationResult validationResult = validationRules.Validate(customer);

            if (validationResult.IsValid)
            {
                customerManager.TUpdate(customer);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in validationResult.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }

        public IActionResult DeleteCustomer(int id)
        {
            var value = customerManager.GetById(id);
            customerManager.TDelete(value);
            return RedirectToAction("Index");
        }
    }
}
