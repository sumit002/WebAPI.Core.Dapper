using Core.WebApi.Dapper.Models.CustomModels;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Core.WebApi.Dapper.Repository.CustomersRepository
{
    public interface ICustomersRepository
    {
        Task<IEnumerable<Customers>> GetAllCustomersAsync(CancellationToken cancellationToken);
    }
}
