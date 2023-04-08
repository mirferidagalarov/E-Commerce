using System;

namespace E_commerce_.NET5_.Models.Entities
{
    public class BaseEntity
    {
        public int Id { get; set; }
        public int? CreatedByUserId { get; set; }
        public DateTime CreatedDate { get; set; }
        public int? DeletedByUserId { get; set; }
        public DateTime? DeletedDate { get; set; }
    }
}
