namespace Entities.Models
{
    public class Device
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? SerialNumber { get; set; }
        public Guid CategoryId { get; set; }
        public Category? Category { get; set; }
        public Guid BrandId { get; set; }
        public Brand? Brand { get; set; }
        public Guid SupplierId { get; set; }
        public Supplier? Supplier { get; set; }
        public bool Status { get; set; }
        public bool IsAvailable { get; set; } = true;
        public  string imageUrl {  get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }


    }


}
