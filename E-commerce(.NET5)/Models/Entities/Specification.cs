using System.Collections.Generic;

namespace E_commerce_.NET5_.Models.Entities
{
    public class Specification:BaseEntity
    {
        public string Name { get; set; }
        public  ICollection<SpecificationCategoryItem> SpecificationCategoryItems { get; set; }
    }
}
