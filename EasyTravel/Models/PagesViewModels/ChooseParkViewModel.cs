using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EasyTravel.Models.PagesViewModels
{
    public class ChooseParkViewModel
    {
        public Guid Id { get; set; }
        public string Motor_park { get; set; }
        public string Vehicle { get; set; } 
        public string Depature_Time { get; set; }
        public string Fare { get; set; }
        public string Address { get; set; }
    }
}
