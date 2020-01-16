using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EasyTravel.Models.PagesViewModels
{
    public class BookingDetailsViewModel
    {
        public Guid id { get; set; }
        public string First_Name { get; set; }
        public string Last_Name { get; set; }
        public string Age { get; set; }
        public string Gender { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Prefered_Seat { get; set; }
    }
}
