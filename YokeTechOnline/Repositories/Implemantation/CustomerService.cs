using YokeTechOnline.Models.Data;
using YokeTechOnline.Models.Domain;
using YokeTechOnline.Repositories.Abstract;
using Microsoft.EntityFrameworkCore;

namespace YokeTechOnline.Repositories.Implemantation
{
    public class CustomerService : ICustomerService
    {
        private readonly DataContext _context;
        public CustomerService(DataContext context)
        {
            this._context = context;
        }
        public bool Add(Customer customer)
        {
            try
            {
                _context.Customers.Add(customer);
                _context.SaveChanges();
                return true;
            }
            catch(Exception ex)
            {
                Console.WriteLine("Error message: {0}", ex.Message);
                return false;
            }
        }

        public bool Delete(int id)
        {
            try
            {
                var data = this.GetCustomerById(id);
                if(data == null)
                {
                    return false;
                }
                else
                {
                    _context.Customers.Remove(data);
                    _context.SaveChanges();
                    return true;
                }
            }
            catch(Exception ex)
            {

                Console.WriteLine("Error message: {0}", ex.Message);
                return false;
            }
            
        }

        public IEnumerable<Customer> GetAll()
        {
            return _context.Customers.ToList().OrderBy(u => u.LastName); 
        }

        public Customer GetCustomerById(int id)
        {
            return _context.Customers.Find(id);

        }

        public bool Update(Customer customer)
        {
            try
            {
                _context.Customers.Update(customer);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {

                Console.WriteLine("Error message: {0}", ex.Message);
                return false;
            }
        }
    }
}
