using Microsoft.AspNetCore.Identity;
using Social.AuthAPI.Models;

namespace Social.AuthApi.Models
{
    public class Users : IdentityUser,IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string SurName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}