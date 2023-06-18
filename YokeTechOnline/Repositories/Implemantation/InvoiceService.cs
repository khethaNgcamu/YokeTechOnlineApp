using YokeTechOnline.Models.Data;
using YokeTechOnline.Models.Domain;
using YokeTechOnline.Repositories.Abstract;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

namespace YokeTechOnline.Repositories.Implemantation
{
    public class InvoiceService : IInvoiceService
    {
        private readonly DataContext dataContext;
        public InvoiceService(DataContext context)
        {
            this.dataContext = context;
        }

        public bool Add(Invoice invoice)
        {
            try
            {
                dataContext.Invoices.Add(invoice);
                dataContext.SaveChanges();
                return true;
            }
            catch(Exception ex)  
            { 
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public bool Delete(int Id)
        {
            try
            {
                var record = this.InvoiceGetById(Id);
                if (record == null)
                {
                    return false;
                }
                else
                {
                    dataContext.Invoices.Remove(record);
                    dataContext.SaveChanges();
                    return true;
                    
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
          
        }

        public IEnumerable<Invoice> GetAll()
        {
            return dataContext.Invoices.Include(u => u.Customer).Include(v => v.Lines).ThenInclude(w => w.Product).ToList().OrderBy(u => u.InvoiceDate);
        }

        public Invoice InvoiceGetById(int Id)
        {
            var record = dataContext.Invoices.Include(u => u.Customer).Include(l => l.Lines).ThenInclude(p => p.Product).FirstOrDefault(n => n.Id == Id);
            return record;
        }

        public bool Update(Invoice invoice)
        {
            try
            {
                dataContext.Invoices.Update(invoice);
                dataContext.SaveChanges();
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
