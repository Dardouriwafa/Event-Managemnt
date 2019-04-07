using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using static Solution.Domain.Entities.GeneralUser;

namespace Solution.Domain.Entities
{public  class GeneralUser : IdentityUser<int, CustomUserLogin, CustomUserRole, CustomUserClaim>
    {


        public String nom { get; set; }
        public String prenom { get; set; }
        public int cin { get; set; }

        public DateTime birthDate { get; set; }
        
        public String address { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<GeneralUser, int> manager)
        {
            // Note the authenticationType must match the one defined in
            // CookieAuthenticationOptions.AuthenticationType 
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here 
            return userIdentity;
        }



        public class CustomUserLogin : IdentityUserLogin<int>
        {
            public int Id { get; set; }

        }
        public class CustomUserRole : IdentityUserRole<int>
        {
            public int Id { get; set; }
        }
        public class CustomUserClaim : IdentityUserClaim<int>
        {

        }
        public class CustomRole : IdentityRole<int, CustomUserRole>
        {
            public CustomRole() { }
            public CustomRole(string name) { Name = name; }
        }
    }
}
