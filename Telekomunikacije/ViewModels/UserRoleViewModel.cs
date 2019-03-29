using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Telekomunikacije.Models;

namespace Telekomunikacije.ViewModels
{
    public class UserRoleViewModel
    {
        public ApplicationUser ApplicationUser { get; set; }
        public List<string> Roles { get; set; }
    }
}