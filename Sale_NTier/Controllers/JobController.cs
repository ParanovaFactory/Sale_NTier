using BusinessLayer.Concrete;
using BusinessLayer.FluentValidation;
using DataAccessLayer.EntitiyFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;

namespace Sale_NTier.Controllers
{
    public class JobController : Controller
    {
        JobManager jobManager = new JobManager(new EfJobDal());

        public IActionResult Index()
        {
            var values = jobManager.GetList();
            return View(values);
        }

        [HttpGet]
        public IActionResult AddJob()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddJob(Job job)
        {
            ModelState.Clear();
            JobValidator validationRules = new JobValidator();
            ValidationResult validationResult = validationRules.Validate(job);
            if (validationResult.IsValid)
            {
                jobManager.TAdd(job);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in validationResult.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                return View();
            }
        }

        [HttpGet]
        public IActionResult UpdateJob(int id)
        {
            var value = jobManager.GetById(id);
            return View(value);
        }
        [HttpPost]
        public IActionResult UpdateJob(Job job)
        {
            ModelState.Clear();
            JobValidator validationRules = new JobValidator();
            ValidationResult validationResult = validationRules.Validate(job);
            if (validationResult.IsValid)
            {
                jobManager.TUpdate(job);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in validationResult.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                return View();
            }
        }

        public IActionResult DeleteJob(int id)
        {
            var value = jobManager.GetById(id);
            jobManager.TDelete(value);
            return RedirectToAction("Index");
        }

        public IActionResult DetailsJob()
        {
            return View();
        }
    }
}
