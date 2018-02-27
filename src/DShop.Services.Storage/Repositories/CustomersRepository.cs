using System;
using System.Threading.Tasks;
using DShop.Common.Mongo;
using DShop.Services.Storage.Models.Customers;
using MongoDB.Driver;

namespace DShop.Services.Storage.Repositories
{
    public class CustomersRepository : ICustomersRepository
    {
        private readonly IMongoRepository<Customer> _repository;

        public CustomersRepository(IMongoRepository<Customer> repository)
        {
            _repository = repository;
        }

        public async Task<Customer> GetAsync(Guid id)
            => await _repository.GetAsync(id);

        public async Task CreateAsync(Customer customer)
            => await _repository.CreateAsync(customer);
    }
}