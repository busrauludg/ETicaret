using Microsoft.AspNetCore.Identity;

namespace ETicaret.Models
{
    public class ApplicationRole:IdentityRole
    {
        public ApplicationRole() : base() { }
        public ApplicationRole(string roleName) : base(roleName)
        {
            // Ekstra özelliklerinizi buraya ekleyebilirsiniz
        }
    }
}
