namespace E_commerce_.NET5_.Models.Entities
{
    public class SpecificationValue:BaseEntity
    {
        public int SpecificationId { get; set; }
        public  Specification Specification { get; set; }
        public int ProductId { get; set; }
        public  Product Product { get; set; }
        public string Value { get; set; }
    }
}
