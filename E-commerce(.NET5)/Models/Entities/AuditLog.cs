using Microsoft.EntityFrameworkCore.ValueGeneration;
using System;

namespace E_commerce_.NET5_.Models.Entities
{
    public class AuditLog:BaseEntity
    {
        public string Path { get; set; }
        public bool IsHttps { get;set; }
        public string QueryString { get; set; }
        public string Method { get; set; }
        public string Area { get; set; }
        public string Controller { get; set; }
        public string Action { get; set; }
        public int StatusCode { get; set; }
        public DateTime RequestTime { get; set; }
        public DateTime ResponseTime { get; set; }

    }
}
