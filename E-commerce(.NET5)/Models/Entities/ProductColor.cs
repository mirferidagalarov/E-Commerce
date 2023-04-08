using System;

namespace E_commerce_.NET5_.Models.Entities
{
    public class ProductColor:BaseEntity
    {
     
        public string HexCode { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

       
    }
}
