using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace E_commerce_.NET5_.Models.Entities
{
    public class Brand:BaseEntity
    {
      
       
        public string Name { get; set; }
        public string Description { get; set; }
        public  ICollection<Product> Products { get; set; }

      

    }
}
