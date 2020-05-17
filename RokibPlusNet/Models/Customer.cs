using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.InteropServices;
using System.Web;

namespace RokibPlusNet.Models
{
    public class Customer
    {
        public int CustomerId { get; set; }
        [Required(ErrorMessage ="Enter the Customers Name")]
        [StringLength(250)]
        public string CustomerName { get; set; }
        public bool IsSubscribedToNewslatter { get; set; }
        [Display(Name ="Date of Birth")]
        [Min18YearsIfAMember]
        public  DateTime? Birthdate { get; set; }
        [Display(Name = "Membership Type")]
        public virtual MembershipType MembershipType { get; set; }
        [Required]
        public int MembershipTypeId { get; set; }


    }
}