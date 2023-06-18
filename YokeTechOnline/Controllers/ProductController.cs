using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Identity.Client;
using YokeTechOnline.Models.Domain;
using YokeTechOnline.Repositories.Abstract;

namespace YokeTechOnline.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService productService;
        private readonly IVendorService vendor;
        public ProductController(IProductService service, IVendorService vService)
        {
            this.productService = service;
            this.vendor = vService;
        }
        public IActionResult Index()
        {
            var dataList = productService.GetAll();
            return View(dataList);
        }

        public IActionResult Update(int id) 
        {
            var record = productService.FindById(id);
            ViewData["VendorId"] = new SelectList(vendor.GetAll(), "Id", "Id");
            return View(record);
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public IActionResult Update(Product product)
        {
            if(!ModelState.IsValid)
            {
                return View(product);
            }

            var result = productService.Update(product);
            if (result)
            {
                TempData["msg"] = "Updated successfully!";
                return RedirectToAction(nameof(Index));
            }
            else
            {
                TempData["msg"] = "Error occurred on server";
                return View(result);
            }
        }

        public IActionResult Add()
        {
            ViewData["VendorId"] = new SelectList(vendor.GetAll(), "Id", "Id");
            return View();
            
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public IActionResult Add(Product product)
        {
            if (!ModelState.IsValid)
            {
                return View(product);
            }
            var result = productService.Add(product);
            if (result)
            {
                TempData["msg"] = "Added successfully!";
                ViewData["VendorId"] = new SelectList(vendor.GetAll(), "Id", "Id", product.VendorId);
                return RedirectToAction(nameof(Index));
            }
            else
            {
                TempData["msg"] = "Error occured on a sever!";
                return View(result);
            }
            
           
        }

        public IActionResult Delete(int id)
        {
             productService.Delete(id);
             return RedirectToAction(nameof(Index));
        }
    }
}
