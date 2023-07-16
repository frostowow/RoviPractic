using System;
using RoviPractic.ViewModels;
using RoviPractic.DAL.Models;
namespace RoviPractic.ViewMapper
{
    public class AuthMapper
    {
        
		public static UserModel MapRegisterationViewModelToUserModel(RegistrationViewModel model)
        {
            return new UserModel()
            {
                Email = model.Email!,
                Password = model.Password!
            };
        }
    }
}

