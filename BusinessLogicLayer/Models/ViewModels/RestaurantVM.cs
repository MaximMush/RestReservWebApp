using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using Stripe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Models.ViewModels
{
    public class RestaurantVM
    {
        public Restaurant Restaurant { get; set; }
        [ValidateNever]
        public IEnumerable<SelectListItem> CategoryList { get; set; }


    }
}
