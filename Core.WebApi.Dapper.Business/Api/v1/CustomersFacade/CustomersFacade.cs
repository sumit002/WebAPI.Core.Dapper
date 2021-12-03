using Core.WebApi.Dapper.Models.CustomModels;
using Core.WebApi.Dapper.Repository.CustomersRepository;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Core.WebApi.Dapper.Business.Api.v1.CustomersFacade
{
    public class CustomersFacade : ICustomersFacade
    {
        private readonly ILogger _logger;
        private readonly ICustomersRepository _customersRepository;
        public CustomersFacade(ILogger<CustomersFacade> logger, ICustomersRepository customersRepository)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _customersRepository = customersRepository ?? throw new ArgumentNullException(nameof(customersRepository));
        }

        public Task<IEnumerable<Customers>> GetAllCustomersAsync(CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            try
            {
                var result = _customersRepository.GetAllCustomersAsync(cancellationToken);
                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed Retrieving Customers Information!");
                return null;
            }
        }
    }
}
