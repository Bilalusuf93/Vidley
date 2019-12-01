using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidley.Models
{
    public class Customer
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Please Enter customer's name")]
        [StringLength(255)]
        public string Name { get; set; }

        public bool IsSubscribedToNewsLetter { get; set; }
       
        [Display(Name ="Date of Birth")]
        [Min18YearsForMembership]
        public DateTime? Dob { get; set; }

        [Display(Name ="Membership Type")]
        public MemberShipType MemberShipType { get; set; }
        [Required]
        [Display(Name = "Membership Type")]
        public byte MemberShipTypeId { get; set; }
    }
}