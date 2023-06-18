using YokeTechOnline.Models.Data;
using YokeTechOnline.Models.Domain;
using YokeTechOnline.Repositories.Abstract;
using Microsoft.EntityFrameworkCore;

namespace YokeTechOnline.Repositories.Implemantation
{
    public class ProductService : IProductService
    {
        private readonly DataContext context;
        public ProductService(DataContext context)
        {
            this.context = context;
        }

        public bool Add(Product product)
        {
            try
            {
                context.Products.Add(product);
                context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public bool Delete(int? id)
        {
            try
            {
                var record = this.FindById(id);
                if (record != null)
                {
                    context.Products.Remove(record);
                    context.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }

        }

        public Product FindById(int? id)
        {
             return context.Products.Include(u => u.Vendor).FirstOrDefault(l => l.Id == id);
        }

        public IEnumerable<Product> GetAll()
        {
            return context.Products.Include(u => u.Vendor).ToList();
        }

        public bool Update(Product product)
        {
            try
            {
                context.Products.Update(product);
                context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
    }
}
