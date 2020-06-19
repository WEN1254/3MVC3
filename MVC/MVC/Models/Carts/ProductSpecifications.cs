namespace MVC.Models.Carts
{
    internal class ProductSpecifications
    {
        public int ProductSpecificationID { get; set; }
        public int ProductID { get; set; }
        public decimal Price { get; set; }
        public string Colour { get; set; }
        public string Image { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
    }
}