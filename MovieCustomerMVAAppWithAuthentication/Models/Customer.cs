using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MovieCustomerMVAAppWithAuthentication.Models
{
    
    public class Customer
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Customer name is Mandatory")]
        [StringLength(40,ErrorMessage = "Customer name cannot exceed 40 characters")]
        public string Name { get; set; }
        [Min18YrsIfMember]
        public DateTime DOB { get; set; }
        public bool IsSubscribedToNewsLetter { get; set; }
        public MembershipType MembershipType { get; set; }
        public int MembershipTypeId { get; set; }
        
        
    }
}