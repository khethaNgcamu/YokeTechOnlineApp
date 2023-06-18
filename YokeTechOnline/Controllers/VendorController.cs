using Microsoft.AspNetCore.Mvc;
using YokeTechOnline.Repositories.Abstract;
using Microsoft.EntityFrameworkCore;
using YokeTechOnline.Models.Domain;

namespace YokeTechOnline.Controllers
{
    public class VendorController : Controller
    {
        IVendorService service;
        public VendorController(IVendorService vendor) 
        { 
            this.service = vendor;

        }
        public IActionResult Index()
        {
            var dataList = service.GetAll();
            return View(dataList);
        }

        public IActionResult Add() 
        { 
            return View();
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public IActionResult Add(Vendor vendor)
        {
            if(!ModelState.IsValid)
            {
                return View(vendor);
            }
            var data = service.Add(vendor);
            if (data)
            {
                TempData["msg"] = "Added succcessfully.";
                return RedirectToAction(nameof(Index));
            }
            else
            {
                TempData["msg"] = "Error occurred on the server.";
                return View(data);
            }
            
        }

        public IActionResult Update(int? id)
        {
            var record = service.GetVendorById(id);
            return View(record);
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public IActionResult Update(Vendor vendor)
        {
            if(!ModelState.IsValid)
            {
                return View(vendor);
            }
            var data = service.Update(vendor);
            if (data)
            {
                TempData["msg"] = "Updated successfully";
                return RedirectToAction(nameof(Index));
            }
            else
            {
                TempData["msg"] = "Error occurred on the server";
                return View(data);
            }
        }

        public IActionResult Delete(int? id)
        {
            service.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
