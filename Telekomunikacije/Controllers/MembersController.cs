using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Telekomunikacije.Models;

namespace Telekomunikacije.Controllers
{
    public class MembersController : Controller
    {
        // GET: Students
        private ApplicationDbContext _Context;

        public MembersController()
        {
            _Context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _Context.Dispose();
        }
        public ActionResult Index()
        {
            return View();
        }
        
        public ActionResult GetMembers()
        {
            
            var members = _Context.Users.ToList();
            return View(members);
        }
        public ActionResult MembersInfo(int id)
        {
            



     //       .Where(x => x.Roles.Select(a => a.RoleId))
     //       .ToList();

            var member = _Context.Users.Include(m => m.Roles).ToList();
            return View(member);
        }


    }
}