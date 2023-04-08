using System.Collections.Generic;

namespace E_commerce_.NET5_.Models.Entities
{
    public class Product: BaseEntity
    {
        public string Name { get;set; }
        public string StockKeepingUnit { get;set;}
        public int BrandId { get; set; }
        public  Brand Brand { get; set; }
        public string ShortDescription { get; set; }
        public string Description { get; set; }

        public  ICollection<ProductImage> Images { get; set; }
        public  ICollection<ProductSizeColorItem> ProductSizeColorCollection { get; set; }
        public  ICollection<SpecificationValue> SpecificationValues { get; set; }



    }
}
