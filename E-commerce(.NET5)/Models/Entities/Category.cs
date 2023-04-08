using System.Collections.Generic;

namespace E_commerce_.NET5_.Models.Entities
{
    public class Category:BaseEntity
    {
        public int? ParentId { get; set; }
        public  Category Parent { get; set; }
        public  ICollection<Category> Children { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
         
    }
}
