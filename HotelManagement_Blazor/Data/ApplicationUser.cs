using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace HotelManagement_Blazor.Data
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {
        [Required,MaxLength(10),RegularExpression(@"^[a-zA-Z]+$"),Unicode(false)]
        public string FirstName { get; set; }

        [MaxLength(10),Unicode(false)]
        public string LastName { get; set; }
        [Required, MaxLength(10), Unicode(false)]
        public string RoleName {  get; set; }

        [Required, MaxLength(15),RegularExpression(@"[^0-9\+\(\)\s]")]
        public string ContactNumber { get; set; }

        [MaxLength(50),Unicode(false)]
        public string Designation { get; set; }

        [MaxLength(150)]
        public string? Image { get; set; }
    }

}