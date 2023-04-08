using System.ComponentModel.DataAnnotations;

namespace E_commerce_.NET5_.AppCode.Application. SpecificationModule
{
    public class SpecificationViewModel
    {
        [Required]
        public int Id { get; set; }
        public string Name { get; set; }
   
    }
}
