using Entities.Models;
using Shared.DTO.Sale;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface ISalesRepository
    {

        Task<IEnumerable<Sales>> GetAllSalesAsync(bool trackChanges);
        Task<Sales> GetSaleByIdAsync(Guid saleId, bool trackChanges);
        Task<Sales> GetSaleByDateAsync(DateTime saleDate, bool trackChanges);
        Task<IEnumerable<Sales>> GetSalesByCustomerAsync(Guid customerId, bool trackChanges);

        void CreateSale(Sales sale);
        void UpdateSale(Sales sale);
        void DeleteSale(Sales sale);


        Task<Sales> ProcessSaleAsync(Sales sale);
        Task<decimal> GetTotalSalesAsync(DateTime startDate, DateTime endDate);
    }
}
