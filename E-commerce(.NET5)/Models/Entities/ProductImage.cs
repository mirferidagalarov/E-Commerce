namespace E_commerce_.NET5_.Models.Entities
{
    public class ProductImage:BaseEntity
    {

        public string ImageName { get;set;}
        public bool IsMain { get; set;}
        public int  ProductId { get; set;}
        public  Product Product { get; set;}

    }
}
