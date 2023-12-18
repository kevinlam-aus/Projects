using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


//This model stores the roles and the role ID on the database.

namespace sp20team15finalproject.Models
{
    public class Role
    {

        //This is the role ID.

        [Display(Name = "Role ID")]
        public Int32 RoleID { get; set; }

        //This is the role name.

        [Display(Name = "Role Name")]
        public string RoleName { get; set; }

        //This is the list of users that have each role.

        [Display(Name = "People within each role")]
        public List<AppUser> Appusers { get; set; }
    }
}