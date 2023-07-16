using System;
using RoviPractic.BL.Auth;
using RoviPractic.ViewModels;
using Microsoft.AspNetCore.Mvc;
using RoviPractic.ViewMapper;

namespace RoviPractic.Controllers
{

    public class RegisterController : Controller
    {

        private readonly IAuthBL authBl;

        public RegisterController(IAuthBL authBl)
        {
            this.authBl = authBl;
        }

        [HttpGet]
        [Route("/register")]
        public IActionResult Index()
        {
            return View("Index", new RegistrationViewModel());
        }

        [HttpPost]
        [Route("/register")]
        public async Task<IActionResult> IndexSave(RegistrationViewModel model)
        {
            if (ModelState.IsValid)
            {
                var errorModel = await authBl.ValidateEmail(model.Email ?? "");
                if (errorModel != null)
                {
                    ModelState.TryAddModelError("Email", errorModel.ErrorMessage!);
                }
            }

            if (ModelState.IsValid)
            {
                await authBl.CreateUser(AuthMapper.MapRegisterationViewModelToUserModel(model));
                return Redirect("/");
            }

            return View("Index", model);
        }
    }
}
        

