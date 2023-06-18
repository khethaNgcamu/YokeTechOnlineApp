using YokeTechOnline.Models.Domain;

namespace YokeTechOnline.Repositories.Abstract
{
    public interface ICustomerService
    {
        bool Add(Customer customer);
        bool Update(Customer customer);
        bool Delete(int id);
        Customer GetCustomerById(int id);
        IEnumerable<Customer> GetAll();
    }
}
