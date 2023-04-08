using System.ComponentModel.DataAnnotations;

namespace E_commerce_.NET5_.AppCode.Application.BrandModule
{
    public class BrandViewModel
    {
        [Required]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
