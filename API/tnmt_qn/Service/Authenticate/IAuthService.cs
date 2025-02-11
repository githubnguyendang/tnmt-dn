using Microsoft.AspNetCore.Identity;
using tnmt_qn.Dto;

namespace tnmt_qn.Service
{
    public interface IAuthService
    {
        public Task<bool> RegisterAsync(UserDto dto);
        public Task<string> LoginAsync(LoginViewDto dto);
        public Task<bool> LogoutAsync(HttpContext context);
        public Task<bool> AssignRoleAsync(AssignRoleDto dto);
        public Task<bool> RemoveRoleAsync(AssignRoleDto dto);
        public Task<PasswordChangeResult> UpdatePasswordAsync(PasswordChange password);
        public Task<bool> SetPasswordAsync(string username, string newPassword);
        public Task<bool> CheckAccessPermission(string userName, string linkControl, string action);
    }
}
