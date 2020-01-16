using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EasyTravel.Models
{
    public class Booking
    {
        [Key]
        public Guid Id { get; private set; }
        public string First_Name { get; set; }
        public string Last_Name { get; set; }
        public string Age { get; set; }
        public string Gender { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public string Travel_Date { get; set; }
        public string Depature_Time { get; set; }
        public string Payment_Ref { get; set; }
        public string Motor_park { get; set; }
        public string Vehicle { get; set; }
        public string Prefered_Seat { get; set; }
        public string Fare { get; set; }

    }
}
