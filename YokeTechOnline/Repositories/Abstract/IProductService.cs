using YokeTechOnline.Models.Domain;

namespace YokeTechOnline.Repositories.Abstract
{
    public interface IProductService
    {
        bool Add(Product product);
        bool Update(Product product);
        bool Delete(int? id);
        Product FindById(int? id);
        IEnumerable<Product> GetAll();
    }
}
