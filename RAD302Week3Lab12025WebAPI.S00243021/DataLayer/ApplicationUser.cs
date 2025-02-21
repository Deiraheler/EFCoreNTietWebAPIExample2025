using Microsoft.AspNetCore.Identity;

namespace RAD302Week3Lab12025WebAPI.S00243021.DataLayer
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string SecondName { get; set; }
    }
}
