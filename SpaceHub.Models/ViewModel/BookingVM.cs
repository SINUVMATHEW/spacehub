using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceHub.Models.ViewModel
{
    public class BookingVM
    {
        public Booking Booking { get; set; }

        [ValidateNever]
        public IEnumerable<SelectListItem> WorkspaceList { get; set; }
        [ValidateNever]
        public IEnumerable<SelectListItem> UserList { get; set; }
    }
}
