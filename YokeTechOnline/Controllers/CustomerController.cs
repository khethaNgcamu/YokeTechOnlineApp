using Microsoft.AspNetCore.Mvc;
using YokeTechOnline.Repositories.Abstract;
using YokeTechOnline.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace YokeTechOnline.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ICustomerService service;
        public CustomerController(ICustomerService service)
        {
            this.service = service;
        }
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(Customer customer)
        {
            if (!ModelState.IsValid)
            {
                return View(customer);
            }

            var result = service.Add(customer);
            if (result)
            {
                TempData["msg"] = "Added successfully!";
                return RedirectToAction(nameof(Add));
            }
            else
            {
                TempData["msg"] = "Error occured on a sever!";
            }
            return View(customer);
        }

        public IActionResult Update(int id)
        {
            var record = service.GetCustomerById(id);
            return View(record);
        }

        [HttpPost]
        public IActionResult Update(Customer customer)
        {
            if (!ModelState.IsValid)
            {
                return View(customer);
            }

            var result = service.Update(customer);
            if (result)
            {
                TempData["msg"] = "Updated successfully!";
                return RedirectToAction(nameof(Add));
            }
            else
            {
                TempData["msg"] = "Error occured on a sever!";
            }

            return View(customer);
        }
        public IActionResult Delete(int id)
        {
            var result = service.Delete(id);
            return RedirectToAction(nameof(GetAll));
        }

        public IActionResult GetAll()
        {
            var data = service.GetAll();
            return View(data);
        }
        
    }
}
