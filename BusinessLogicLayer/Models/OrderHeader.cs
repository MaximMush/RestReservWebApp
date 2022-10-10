using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Models
{
    public class OrderHeader
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        [ForeignKey("UserId")]
        [ValidateNever]
        public User User { get; set; }
        [Required]
        public int NumberOfVisitors { get; set; }

        [Required]
        public DateTime OrderDate { get; set; }
        public DateTime BookingDate { get; set; }
        public string? OrderStatus { get; set; } 

        [Required]
        public string PhoneNumber { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
