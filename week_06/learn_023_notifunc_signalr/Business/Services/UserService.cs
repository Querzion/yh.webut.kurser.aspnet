using System.Diagnostics;
using Business.Models;
using Data.Entities;
using Data.Interfaces;
using Domain.DTOs;
using Domain.Extensions;
using Microsoft.AspNetCore.Identity;

namespace Business.Services;

public interface IUserService
{
    Task<UserServiceResult> GetUsersAsync();
    Task<UserServiceResult> AddUserToRole(string userId, string roleName);
    Task<UserServiceResult> CreateUserAsync(SignUpFormData formData, string roleName = "User");
    Task<string> GetDisplayNameAsync(string? username);
}

public class UserService(IUserRepository userRepository, UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager) : IUserService
{
    private readonly IUserRepository _userRepository = userRepository;
    private readonly UserManager<AppUser> _userManager = userManager;
    private readonly RoleManager<IdentityRole> _roleManager = roleManager;

    #region CRUD

        #region Create

            public async Task<UserServiceResult> CreateUserAsync(SignUpFormData formData, string roleName = "User")
            {
                if (formData == null)
                    return new UserServiceResult { Succeeded = false, StatusCode = 400, Error = "Form data cannot be null." };
                
                var existsResult = await _userRepository.ExistsAsync(u => u.Email == formData.Email);
                if (existsResult.Succeeded)
                    return new UserServiceResult { Succeeded = false, StatusCode = 409, Error = "Email already exists." };

                try
                {
                    var userEntity = formData.MapTo<AppUser>();
                    
                    var result = await _userManager.CreateAsync(userEntity, formData.Password);
                    if (result.Succeeded)
                    {
                        var addToRoleResult = await AddUserToRole(userEntity.Id, roleName);
                        return result.Succeeded
                            ? new UserServiceResult { Succeeded = true, StatusCode = 201 }
                            : new UserServiceResult { Succeeded = false, StatusCode = 201, Error = "User created, but not added to role." };
                    }
                    
                    return new UserServiceResult { Succeeded = false, StatusCode = 500, Error = "Unable to create user."};
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                    return new UserServiceResult { Succeeded = false, StatusCode = 500, Error = ex.Message};
                }
            }

        #endregion
    
        #region Read

            public async Task<UserServiceResult> GetUsersAsync()
            {
                var result = await _userRepository.GetAllAsync();
                return result.MapTo<UserServiceResult>();
            }

        #endregion

    #endregion

    public async Task<UserServiceResult> AddUserToRole(string userId, string roleName)
    {
        if (!await _roleManager.RoleExistsAsync(roleName))
            return new UserServiceResult { Succeeded = false, StatusCode = 404, Error = "Role doesn't exist."};

        var user = await _userManager.FindByIdAsync(userId);
        if (user == null)
            return new UserServiceResult { Succeeded = false, StatusCode = 404, Error = "User doesn't exist."};
        
        var result = await _userManager.AddToRoleAsync(user, roleName);
        return result.Succeeded
            ? new UserServiceResult { Succeeded = true, StatusCode = 200 }
            : new UserServiceResult { Succeeded = false, StatusCode = 500, Error = "Unable to add user to role."};
    }

    public async Task<string> GetDisplayNameAsync(string? username)
    {
        if (username == null)
            return "";
        
        var user = await _userManager.FindByNameAsync(username);
        return user == null ? "" : $"{user.FirstName} {user.LastName}";
    }
}