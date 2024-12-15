using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface ICartItemRepository
    {
       
        Task<Cartitem> GetCartItemByIdAsync(Guid cartitemId, bool trackChanges);
        void CreateCartItems(Cartitem cartitem);
        void DeleteCartItems(Cartitem cartitem);

    }
}
