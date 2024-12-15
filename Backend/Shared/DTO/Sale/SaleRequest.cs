using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DTO.Sale
{
    public class SaleRequest
    {
            [Required]
            public Guid CustomerId { get; set; }

            [Required]
            [MinLength(1, ErrorMessage = "At least one product must be included in the order.")]
            public List<SaleProductRequestDto> Products { get; set; }

            [Required]
            public string PaymentMethod { get; set; } // e.g., "Credit Card", "Cash"

            [Required]
            [Range(0, double.MaxValue, ErrorMessage = "Total amount must be positive.")]
            public decimal TotalAmount { get; set; }

    }

        public class SaleProductRequestDto
        {
            [Required]
            public Guid ProductId { get; set; }

            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "Quantity must be at least 1.")]
            public int Quantity { get; set; }
        }


    public class SaleResponseDto
    {
        public Guid Id { get; set; }
        public Guid CustomerId { get; set; }
        public string CustomerName { get; set; }
        public List<SaleProductRequestDto> Products { get; set; }
        public string PaymentMethod { get; set; }
        public decimal TotalAmount { get; set; }
        public DateTime OrderDate { get; set; }
    }

    public class SaleProductResponseDto
    {
        public Guid ProductId { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
