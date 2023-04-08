using E_commerce_.NET5_.Models.Entities;
using System.Collections.Generic;

namespace E_commerce_.NET5_.Models.ViewModels
{
    public class ShopFilterViewModel
    {

        public List<Brand> Brands { get; set; }
        public List<ProductColor> ProductColors { get; set; }
        public List<ProductSize> ProductSizes { get; set; }
        public List<Category> Categories { get; set; }
        public List<Product> Products { get; set; }

    }
}
