
using YokeTechOnline.Models.Domain;

namespace YokeTechOnline.Repositories.Abstract
{
    public interface IInvoiceService 
    {
        bool Add(Invoice invoice);
        bool Update(Invoice invoice);
        bool Delete(int Id);
        Invoice InvoiceGetById(int Id);
        IEnumerable<Invoice> GetAll();

    }
}
