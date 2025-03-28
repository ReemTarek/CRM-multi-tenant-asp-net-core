using CRM.Model.IdentityModels;
using CRM.Model.InputModels;
using CRM.Service.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace CRM.Service
{
    public class AuthenticationService(UserManager<ApplicationUser> _userManager) : IAuthenticationService
    {
        public Task<bool> ChangePasswordAsync(ApplicationUserInputModel model)
        {
            throw new NotImplementedException();
        }
        public Task<bool> ForgotPasswordAsync(ApplicationUserInputModel model)
        {
            throw new NotImplementedException();
        }
        public Task<bool> LoginAsync(ApplicationUserInputModel model)
        {
            throw new NotImplementedException();
        }
        public Task<bool> RefreshTokenAsync(ApplicationUserInputModel model)
        {
            throw new NotImplementedException();
        }
        public async Task<bool> RegisterAsync(ApplicationUserInputModel model)
        {
            var user = new ApplicationUser
            {
                Email = model.Email,
                FirstName = model.FirstName,
                LastName = model.LastName,
                DateOfBirth = model.DateOfBirth,
                Gender = model.Gender,
                RegistrationDate = DateTime.UtcNow
            };
            var result = await _userManager.CreateAsync(user, model.Password);
            return result.Succeeded ? true : throw new Exception("Unable to create user, Errors: " + result.Errors);
        }
        public Task<bool> ResetPasswordAsync(ApplicationUserInputModel model)
        {
            throw new NotImplementedException();
        }

    }
}
