using HotelManagement_Blazor.Constants;
using HotelManagement_Blazor.Data;
using Microsoft.AspNetCore.Identity;

namespace HotelManagement_Blazor.Services
{
    public class SeedService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IUserStore<ApplicationUser> _userStore;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IRoleStore<IdentityRole> _roleStore;
        private readonly IConfiguration _configuration;

        public SeedService(UserManager<ApplicationUser> userManager, IUserStore<ApplicationUser> userStore,
            RoleManager<IdentityRole> roleManager, IRoleStore<IdentityRole> roleStore,
            IConfiguration configuration)
        {
            _userManager = userManager;
            _userStore = userStore;
            _roleManager = roleManager;
            _roleStore = roleStore;
            this._configuration = configuration;    
        }

        public async Task SeedDatabaseAsync()
        {
            var adminUserEmail = _configuration.GetSection("AdminUser")["Email"];

            var dbAdmin = await _userManager.FindByEmailAsync(adminUserEmail);
            if (dbAdmin is not null)
                return;


            var applicationUser = new ApplicationUser()
            {
                FirstName = _configuration.GetValue<string>("AdminUser:FirstName"),
                LastName= _configuration.GetValue<string>("AdminUser:LastName"),
                Email= adminUserEmail,
                RoleName=RoleTypeEnum.Admin.ToString(),
                ContactNumber=_configuration.GetValue<string>("AdminUser:ContactNumber"),
                Designation="Administration"
            };

           await _userStore.SetUserNameAsync(applicationUser, adminUserEmail, default);

            var result = await _userManager.CreateAsync(applicationUser, password: _configuration.GetValue<string>("AdminUser:Password"));

            if(!result.Succeeded)
            {
                var error = string.Join(Environment.NewLine, result.Errors.Select(s => s.Description));
                throw new Exception(error);
            }

            var isRole = await _roleManager.FindByNameAsync(RoleTypeEnum.Admin.ToString());
            if (isRole is null)
            {
                foreach(var roleName in Enum.GetNames<RoleTypeEnum>())
                {
                    var newRole = new IdentityRole
                    {
                        Name = roleName,
                    };

                    await _roleManager.CreateAsync(newRole);
                }
            }

           result= await _userManager.AddToRoleAsync(applicationUser, RoleTypeEnum.Admin.ToString());
            if(!result.Succeeded)
            {
                var errors = string.Join(Environment.NewLine, result.Errors.Select(s => s.Description));
                throw new Exception($"Error is adding user {errors}");
            }
        }
    }

}
