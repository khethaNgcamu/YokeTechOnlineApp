using Microsoft.AspNetCore.Mvc;
using YokeTechOnline.Models.Domain;
using YokeTechOnline.Repositories.Abstract;
using Microsoft.EntityFrameworkCore;

namespace YokeTechOnline.Controllers
{
    public class InvoiceController : Controller
    {
        private readonly IInvoiceService service;
        public InvoiceController(IInvoiceService service)
        {
            this.service = service;
        }
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Invoice invoice)
        {
            if(ModelState.IsValid)
            {
                return View(invoice);
            }
            
            var result = service.Add(invoice);
            if (result)
            {
                TempData["msg"] = "Invoice added successfully!";
                return RedirectToAction(nameof(Add));
            }
            else
            {
                TempData["msg"] = "Error occurred on server side!";
                
            }
            return View(invoice);
        }

        public IActionResult Update(int id) 
        { 
            var record = service.InvoiceGetById(id);
            return View(record);
        }

        [HttpPost]
        public IActionResult Update(Invoice invoice)
        {
            if(ModelState.IsValid)
            {
                return View(invoice);
            }
            var result = service.Update(invoice);
            if (result)
            {
                TempData["msg"] = "Invoce updated successfully!";
                return RedirectToAction(nameof(Add));
            }
            else
            {
                TempData["msg"] = "Error occured on server side!";
            }
            return View(invoice);

        }
        public IActionResult Delete(int id)
        {
            var result = service.Delete(id);
            return RedirectToAction(nameof(GetAll));
        }

        public IActionResult GetAll()
    {
        var result = service.GetAll();
        return View(result);
    } 
    }
}
