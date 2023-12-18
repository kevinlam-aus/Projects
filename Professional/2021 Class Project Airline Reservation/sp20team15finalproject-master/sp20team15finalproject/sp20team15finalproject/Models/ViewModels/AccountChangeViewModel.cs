using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sp20team15finalproject.Models.ViewModels
{
    public class AccountChangeViewModel
    {
        public String newName { get; set; }
        public String newEmail { get; set; }
        public String newFirstName { get; set; }
        public String newMiddleInitial { get; set; }
        public String newLastName { get; set; }
        public DateTime newDOB { get; set; }
        public String newAddress { get; set; }
        public String newCity { get; set; }
        public String newState { get; set; }
        public String newZip { get; set; }
        public String newPhoneNumber { get; set; }
        public Int32 newRewardMiles { get; set; }

        public AppUser persontochange { get; set; }
    }
}
