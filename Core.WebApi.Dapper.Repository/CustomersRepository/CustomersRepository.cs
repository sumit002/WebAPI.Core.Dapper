using Core.WebApi.Dapper.Models.CustomModels;
using Core.WebApi.Dapper.Repository.Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading;
using System.Threading.Tasks;

namespace Core.WebApi.Dapper.Repository.CustomersRepository
{
    public class CustomersRepository : ICustomersRepository
    {
        private readonly IDapper _dapper;
        public CustomersRepository(IDapper dapper)
        {
            _dapper = dapper;
        }
        public async Task<IEnumerable<Customers>> GetAllCustomersAsync(CancellationToken cancellationToken)
        {
            IEnumerable<Customers> customers = new List<Customers>();
            try
            {
                customers = _dapper.GetAll<Customers>("Select * from [Customers]", null, commandType: CommandType.Text);
                return customers;
            }
            catch (Exception ex)
            {
                return customers;
            }
        }
    }
}
