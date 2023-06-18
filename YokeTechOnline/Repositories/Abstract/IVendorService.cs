using YokeTechOnline.Models.Domain;

namespace YokeTechOnline.Repositories.Abstract
{
    public interface IVendorService
    {
        bool Add(Vendor vendor);
        bool Update(Vendor vendor);
        bool Delete(int? id);
        Vendor GetVendorById(int? id);
        IEnumerable<Vendor> GetAll();
    }
}
