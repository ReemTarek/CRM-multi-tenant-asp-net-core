using CRM.Model.InputModels;
using CRM.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;

namespace CRM.Api.Areas.Identity
{
    [Area("Identity")]
    [DisplayName("Authentication Controller")]
    [Route("api/[Area]/[controller]")]
    [ApiController]
    public class AuthenticationController(IAuthenticationService _authenticationService) : ControllerBase
    {
        [HttpPost("login")]
        [DisplayName("Login")]
        public async Task<IActionResult> Login([FromBody] ApplicationUserInputModel model)
        {
            var response = await _authenticationService.LoginAsync(model);
            return Ok(response);
        }
        [HttpPost("register")]
        [DisplayName("Register")]
        public async Task<IActionResult> Register([FromBody] ApplicationUserInputModel model)
        {
            var response = await _authenticationService.RegisterAsync(model);
            return Ok(response);
        }
        [HttpPost("forgot-password")]
        [DisplayName("Forgot Password")]
        public async Task<IActionResult> ForgotPassword([FromBody] ApplicationUserInputModel model)
        {
            var response = await _authenticationService.ForgotPasswordAsync(model);
            return Ok(response);
        }
        [HttpPost("reset-password")]
        [DisplayName("Reset Password")]
        public async Task<IActionResult> ResetPassword([FromBody] ApplicationUserInputModel model)
        {
            var response = await _authenticationService.ResetPasswordAsync(model);
            return Ok(response);
        }
        [HttpPost("change-password")]
        [DisplayName("Change Password")]
        public async Task<IActionResult> ChangePassword([FromBody] ApplicationUserInputModel model)
        {
            var response = await _authenticationService.ChangePasswordAsync(model);
            return Ok(response);
        }
        [HttpPost("refresh-token")]
        [DisplayName("Refresh Token")]
        public async Task<IActionResult> RefreshToken([FromBody] ApplicationUserInputModel model)
        {
            var response = await _authenticationService.RefreshTokenAsync(model);
            return Ok(response);
        }

    }
}
