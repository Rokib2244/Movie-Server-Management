using RokibPlusNet.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RokibPlusNet.Dtos
{
    public class CustomerDto
    {
        public int CustomerId { get; set; }
        [Required(ErrorMessage = "Enter the Customers Name")]
        [StringLength(250)]
        public string CustomerName { get; set; }
        public bool IsSubscribedToNewslatter { get; set; }
        //[Min18YearsIfAMember]
        public DateTime? Birthdate { get; set; }      
        
        [Required]
        public int MembershipTypeId { get; set; }
        public MembershipTypeDto MembershipType { get; set; }

    }
}