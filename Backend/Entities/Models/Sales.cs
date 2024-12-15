using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class Sales
    {
        public Guid Id { get; set; }

        public decimal TotalAmount {  get; set; }

        public DateTime SaleDate { get;set; } = DateTime.Now;

        public ICollection<Cartitem> CartItems { get; set; } = new List<Cartitem>();
        public string PaymentMethod {  get; set; }
        public bool isPaid {  get; set; }
    }
}
