using BusinessLayer.Concrete;
using BusinessLayer.FluentValidation;
using DataAccessLayer.EntitiyFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;

namespace Sale_NTier.Controllers
{
    public class CathegoryController : Controller
    {
        CathegoryManager cathegoryManager = new CathegoryManager(new EfCathegoryDal());

        public IActionResult Index()
        {
            var values = cathegoryManager.GetList();
            return View(values);
        }

        [HttpGet]
        public IActionResult AddCathegory()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddCathegory(Cathegory cathegory)
        {
            ModelState.Clear();
            CathegoryValidator validationRules = new CathegoryValidator();
            ValidationResult validationResult = validationRules.Validate(cathegory);

            if (validationResult.IsValid)
            {
                cathegoryManager.TAdd(cathegory);
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
        public IActionResult UpdateCathegory(int id)
        {
            var value = cathegoryManager.GetById(id);
            return View(value);
        }

        [HttpPost]
        public IActionResult UpdateCathegory(Cathegory cathegory)
        {
            ModelState.Clear();
            CathegoryValidator validationRules = new CathegoryValidator();
            ValidationResult validationResult = validationRules.Validate(cathegory);

            if (validationResult.IsValid)
            {
                cathegoryManager.TUpdate(cathegory);
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

        public IActionResult DeleteCathegory(int id)
        {
            var value = cathegoryManager.GetById(id);
            cathegoryManager.TDelete(value);
            return RedirectToAction("Index");
        }
    }
}
