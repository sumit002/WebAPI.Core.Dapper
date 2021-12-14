using Core.WebApi.Dapper.Models.CustomModels;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Core.WebApi.Dapper.Business.Api.v1.CustomersFacade
{
    public interface ICustomersFacade
    {
        /// <summary>
        /// Get All CustomersAsync
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<IEnumerable<Customers>> GetAllCustomersAsync(CancellationToken cancellationToken);
    }
}
