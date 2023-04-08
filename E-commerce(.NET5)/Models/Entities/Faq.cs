using System.ComponentModel.DataAnnotations;

namespace E_commerce_.NET5_.Models.Entities
{
    public class Faq:BaseEntity
    {
        [Required]
        public string Question { get;set; }
        [Required]
        public string Answer { get; set; }  
    }
}
