using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RoviPractic.BL.Auth;
using RoviPractic.ViewMapper;
using RoviPractic.ViewModels;

namespace RoviPractic.Controllers
{
   
        public class LoginController : Controller
        {
            private readonly IAuthBL authBl;

            public LoginController(IAuthBL authBl)
            {
                this.authBl = authBl;
            }

            [HttpGet]
            [Route("/login")]
            public IActionResult Index()
            {
                return View("Index", new LoginViewModel());
            }

            [HttpPost]
            [Route("/login")]
            public async Task<IActionResult> IndexSave(LoginViewModel model)
            {
                if (ModelState.IsValid)
                {
                    await authBl.Authenticate(model.Email!, model.Password!, model.RememberMe == true);
                    return Redirect("/");
                }

                return View("Index", model);
            }
        }
    }

