using Contracts;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Shared.DTO.Sale;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class SalesRepository: RepositoryBase<Sales>,ISalesRepository
    {
        public SalesRepository(RepositoryContext repositoryContext)
           : base(repositoryContext)
        {
        }
        public async Task<IEnumerable<Sales>> GetAllSalesAsync(bool trackChanges)
        {
            return await FindAll(trackChanges)
                .Include(s => s.CartItems)
                .OrderBy(s=>s.SaleDate)
                .ToListAsync();
        }

        public async Task<Sales> GetSaleByIdAsync(Guid saleId, bool trackChanges)
        {
            return await FindByCondition(s => s.Id.Equals(saleId), trackChanges)
                .Include(s => s.CartItems)
                .FirstOrDefaultAsync();
        }

        public async Task<Sales> GetSaleByDateAsync(DateTime saleDate, bool trackChanges)
        {
            return await FindByCondition(s => s.SaleDate.Date == saleDate.Date, trackChanges)
                .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Sales>> GetSalesByCustomerAsync(Guid customerId, bool trackChanges)
        {
            return await FindByCondition(s => s.CartItems.Equals(customerId), trackChanges)
                .Include(s => s.CartItems)
                .OrderByDescending(s => s.SaleDate)
                .ToListAsync();
        }

        public void CreateSale(Sales sale)
        {
            Create(sale);
        }

        public void UpdateSale(Sales sale)
        {
            Update(sale);
        }

        public void DeleteSale(Sales sale)
        {
            Delete(sale);
        }

        public async Task<Sales> ProcessSaleAsync(Sales sale)
        {
           
            using (var transaction = await RepositoryContext.Database.BeginTransactionAsync())
            {
                try
                {
                    
                    foreach (var saleItem in sale.CartItems)
                    {
                        var product = await RepositoryContext.Devices
                            .FindAsync(saleItem.ProductId);

                        if (product == null)
                            throw new Exception($"Product not found: {saleItem.ProductId}");

                        if (product.Quantity < saleItem.Quantity)
                            throw new Exception($"Insufficient stock for product: {product.Name}");

                        // Reduce stock
                        product.Quantity -= saleItem.Quantity;
                        RepositoryContext.Devices.Update(product);
                    }

                    // Create the sale
                    Create(sale);
                    await RepositoryContext.SaveChangesAsync();

                    await transaction.CommitAsync();
                    return sale;
                }
                catch (Exception)
                {
                    await transaction.RollbackAsync();
                    throw;
                }
            }
        }

        public async Task<decimal> GetTotalSalesAsync(DateTime startDate, DateTime endDate)
        {
            return await FindByCondition(
                s => s.SaleDate >= startDate && s.SaleDate <= endDate,
                false)
                .SumAsync(s => s.TotalAmount);
        }

       
 
    }
}
