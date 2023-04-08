using System.Collections.Generic;

namespace E_commerce_.NET5_.Models.FormModels
{
    public class ShopFilterFormModel
    {
        public List<int> Brands { get; set; }
        public List<int> Colors { get; set; }
        public List<int> Size { get; set; }
    }
}
