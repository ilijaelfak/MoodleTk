using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Telekomunikacije.Models;
using Telekomunikacije.ViewModels;



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


            var users = _Context.Users.ToList();

            var usersWithRoles = new List<UserRoleViewModel>();

            

            foreach (var item in users)
            {
                var roles = new List<String>();

                foreach (var item2 in item.Roles)
                {
                    roles.Add(_Context.Roles.Single(x => x.Id == item2.RoleId).Name);
                }
                var user = new UserRoleViewModel
                {
                    Id = item.Id,
                    Roles = roles,
                    UserName = item.UserName
                };
                usersWithRoles.Add(user);
            }
            return View(usersWithRoles);
            //var userswithroles = (from user in _context.users
            //                      select new
            //                      {
            //                          id = user.id,
            //                          user = user.username,
            //                          roles = (from userrole in user.roles
            //                                   join role in _context.roles on userrole.roleid
            //                                   equals role.id
            //                                   select role.name).tolist()
            //                      }).tolist().select(p => new userroleviewmodel()
            //                      {
            //                          id = p.id,
            //                          username = p.user,
            //            //              roles = string.join(",", p.roles)
            //                      });

            //return view(userswithroles);
        }
        public ActionResult MembersInfo(string id)
        {

            var user = _Context.Users.Single(x => x.Id == id);

            var roles = new List<string>();
            foreach(var item in user.Roles)
            {
                roles.Add(_Context.Roles.Single(x => x.Id == item.RoleId).Name);
            }
            var userViewModel = new UserRoleViewModel
            {
               
                Roles = roles,
                UserName = user.UserName
            };

          
            

            return View(userViewModel);

            
            

        }

        public ActionResult Pomocni()
        {
            
            return View();
        }
    }
}