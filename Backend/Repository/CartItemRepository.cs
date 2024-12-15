using Contracts;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class CartItemRepository : RepositoryBase<Cartitem>, ICartItemRepository
    {
        public CartItemRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }

        public async Task<Cartitem> GetCartItemByIdAsync(Guid cartitemId, bool trackChanges)
        {
            return await FindByCondition(cartitem => cartitem.Id.Equals(cartitemId), trackChanges)
    .FirstOrDefaultAsync();
        }

        public void CreateCartItems(Cartitem cartitem)
        {
            Create(cartitem);
        }

        public void DeleteCartItems(Cartitem cartitem)
        {
            Delete(cartitem);
        }

    }

}
