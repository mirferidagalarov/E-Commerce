using E_commerce_.NET5_.Models.Entities;
using Resource;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Security.AccessControl;

namespace e_commerce_.net5.Models.Entities
{
    public class ContactPost:BaseEntity
    {
        [Display(ResourceType=typeof(ContactResource),Name ="Name")]
        [Required(ErrorMessageResourceType =typeof(ContactResource),ErrorMessageResourceName ="CantBeEmpty")]
        public string Name { get; set; }
        [Required(ErrorMessageResourceType = typeof(ContactResource), ErrorMessageResourceName = "CantBeEmpty")]
        [EmailAddress(ErrorMessageResourceType = typeof(ContactResource), ErrorMessageResourceName = "InvalidEmailAddress")]
        public string Email { get; set; }
        [Required(ErrorMessageResourceType = typeof(ContactResource), ErrorMessageResourceName = "CantBeEmpty")]
        public string Comment { get; set; }
        public string Answer { get; set; }
        public DateTime? AnsweredDate { get; set; }
        public int? AnswerByUserId { get; set; }
    }
}
