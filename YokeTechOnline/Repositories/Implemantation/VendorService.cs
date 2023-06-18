using YokeTechOnline.Models.Data;
using YokeTechOnline.Models.Domain;
using YokeTechOnline.Repositories.Abstract;
using Microsoft.EntityFrameworkCore;

namespace YokeTechOnline.Repositories.Implemantation
{
    public class VendorService : IVendorService
    {
        private readonly DataContext context;
        public VendorService(DataContext ctx)
        {
            this.context = ctx;
        }
        public bool Add(Vendor vendor)
        {
            try
            {
                context.Vendors.Add(vendor);
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
                var record = this.GetVendorById(id);
                if (record == null)
                {
                    return false;
                }
                else
                {
                    context.Vendors.Remove(record);
                    context.SaveChanges();
                    return true;
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public IEnumerable<Vendor> GetAll()
        {
           
            
                return context.Vendors.ToList();
            
        }

        public Vendor GetVendorById(int? id)
        {
            return context.Vendors.Find(id);
        }

        public bool Update(Vendor vendor)
        {
            try
            {
                context.Vendors.Update(vendor);
                context.SaveChanges();
                return true;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
    }
}
