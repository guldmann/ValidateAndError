using Microsoft.Extensions.Caching.Memory;
using System.Threading.Tasks;
using ValidationAndError.Models;

namespace ValidationAndError
{
    public class CustomerService
    {
        private readonly IMemoryCache _cache;

        public CustomerService(IMemoryCache cache)
        {
            _cache = cache;
        }

        public async Task<Customer> GetCustomer(string name)
        {
            return _cache.Get<Customer>(name);
        }

        public async Task SetCustomer(Customer customer)
        {
            _cache.Set<Customer>(customer.Forename, customer);
        }
    }
}