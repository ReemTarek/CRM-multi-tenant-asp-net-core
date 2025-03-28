using CRM.Model.ApplicationModel;
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
        public async Task<ResponseModel<bool>> LoginAsync(ApplicationUserLoginInputModel model)
        {
            var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, false, false);

            if (result.Succeeded)
            {
                return new ResponseModel<bool>
                {
                    Data = true,
                    Message = "Login successful",
                    IsSuccess = true
                };
            }
            else
            {
                string? errorMessage =
                    result.IsNotAllowed ? "User is not allowed to login" :
                    result.IsLockedOut ? "User is locked out" :
                    result.RequiresTwoFactor ? "Requires two factor authentication":null ;

                return new ResponseModel<bool>
                {
                    Data = false,
                    Message = errorMessage,
                    IsSuccess = false
                };
            }

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
