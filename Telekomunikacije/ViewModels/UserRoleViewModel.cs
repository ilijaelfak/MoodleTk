﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Telekomunikacije.Models;

namespace Telekomunikacije.ViewModels
{
    public class UserRoleViewModel
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public List<string> Roles { get; set; }
    }
}