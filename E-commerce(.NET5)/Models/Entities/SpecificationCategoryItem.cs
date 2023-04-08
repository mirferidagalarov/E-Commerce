namespace E_commerce_.NET5_.Models.Entities
{
    public class SpecificationCategoryItem:BaseEntity
    {
        public Specification Specification { get; set; }
        public int SpecificationId { get; set; }
        public Category Category { get; set; }
        public int CategoryId { get; set; }
       
    }
}
