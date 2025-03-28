﻿using CRM.Model.ApplicationModel;
using CRM.Model.InputModels;

namespace CRM.Service.Interfaces
{
    public interface IAuthenticationService
    {
        Task<ResponseModel<bool>> LoginAsync(ApplicationUserLoginInputModel model);
        Task<bool> RegisterAsync(ApplicationUserRegisterInputModel model);
        Task<bool> ForgotPasswordAsync(ApplicationUserRegisterInputModel model);
        Task<bool> ResetPasswordAsync(ApplicationUserRegisterInputModel model);
        Task<bool> ChangePasswordAsync(ApplicationUserRegisterInputModel model);
        Task<bool> RefreshTokenAsync(ApplicationUserRegisterInputModel model);

    }
}
