using RegisterAndLoginApp.Models;
using System.Collections.Generic;
using System.Linq;

namespace RegisterAndLoginApp.Services
{
    public class SecurityService
    {
        
        UsersDAO usersDAO = new UsersDAO();

        public SecurityService()
        {
            
        }

        public bool IsValid(UserModel user)
        {
            // a lookup to see if there is an item in the db
            return usersDAO.FindUserByNameAndPassword(user);
        }
    }
}
