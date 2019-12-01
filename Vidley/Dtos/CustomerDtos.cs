using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Vidley.Models;

namespace Vidley.Dtos
{
    public class CustomerDtos
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Please Enter customer's name")]
        [StringLength(255)]
        public string Name { get; set; }

        public bool IsSubscribedToNewsLetter { get; set; }
        
        //[Min18YearsForMembership]
        public DateTime? Dob { get; set; }

        [Required]
        public byte MemberShipTypeId { get; set; }
        public MemberSHipTypeDto memberShipType { get; set; }
    }
}