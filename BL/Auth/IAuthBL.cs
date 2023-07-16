using System;
using System.ComponentModel.DataAnnotations;
namespace RoviPractic.BL.Auth
{
    public interface IAuthBL
    {
        Task<int> CreateUser(RoviPractic.DAL.Models.UserModel user);
        Task<int> Authenticate(string email, string password, bool rememberMe);
        Task<ValidationResult?> ValidateEmail(string email);
    }
}
