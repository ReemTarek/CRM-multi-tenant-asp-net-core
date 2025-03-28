using CRM.Model.IdentityModels;
using CRM.Model.InputModels;
using CRM.Service.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace CRM.Service
{
    public class AuthenticationService(UserManager<ApplicationUser> _userManager,
        SignInManager<ApplicationUser> _signInManager
        ) : IAuthenticationService
    {
        public Task<bool> ChangePasswordAsync(ApplicationUserRegisterInputModel model)
        {
            throw new NotImplementedException();
        }
        public Task<bool> ForgotPasswordAsync(ApplicationUserRegisterInputModel model)
        {
            throw new NotImplementedException();
        }
        public async Task<bool> LoginAsync(ApplicationUserLoginInputModel model)
        {
            var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, false, false);
            return result.Succeeded ? true : throw new Exception("Unable to login user, Errors: " + result.ToString());

        }
        public Task<bool> RefreshTokenAsync(ApplicationUserRegisterInputModel model)
        {
            throw new NotImplementedException();
        }
        public async Task<bool> RegisterAsync(ApplicationUserRegisterInputModel model)
        {
            var user = new ApplicationUser
            {
                Email = model.Email,
                FirstName = model.FirstName,
                LastName = model.LastName,
                DateOfBirth = model.DateOfBirth,
                Gender = model.Gender,
                RegistrationDate = DateTime.UtcNow,
                UserName=model.Email
            };
            var result = await _userManager.CreateAsync(user, model.Password);
            return result.Succeeded ? true : throw new Exception("Unable to create user, Errors: " + result.Errors);
        }
        public Task<bool> ResetPasswordAsync(ApplicationUserRegisterInputModel model)
        {
            throw new NotImplementedException();
        }

    }
}
