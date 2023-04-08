namespace E_commerce_.NET5_.Models.Entities
{
    public class ProductSizeColorItem:BaseEntity
    {
        public int ProductId { get; set; }
        public  Product Product { get; set; }
        public int ColorId { get; set; }
        public  ProductColor Color { get; set; }
        public  int SizeId { get; set; }

        public  ProductSize Size { get; set; }

    }
}
