using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using QA_byBuka.Models;

namespace QA_byBuka.Controllers
{
    public class LoginController : Controller
    {
        IUserRepository repo;
        IEnumerable<User> users;
        public LoginController(IUserRepository r)
        {
            repo = r;
            users = repo.GetAllUsers();
        }
        // GET: /<controller>/
        public IActionResult Login()
        {
            return View("Views/Home/Login.cshtml");
        }
        public IActionResult Index(string login, string password)
        {
            
            foreach (var user in users)
            {
                if (login == user.login && password == user.password)
                {
                    return View("Views/Home/Index.cshtml");
                }
            }

            return View("Views/Home/Login.cshtml");

        }
        public IActionResult SignIn(string login, string password)
        {
         
            foreach (var user in users)
            {
                  if (user.login == login)
                {
                    return View("Views/Home/Login.cshtml");
                }
            }
            repo.Create(new User {id = users.Count(), login = login, password = password });
            return View("Views/Home/Index.cshtml");

        }
    }
}
