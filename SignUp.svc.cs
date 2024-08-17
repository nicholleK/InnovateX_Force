using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace backend1
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "SignUp" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select SignUp.svc or SignUp.svc.cs at the Solution Explorer and start debugging.
    public class SignUp : ISignUp
    {
        DataClasses1DataContext db = new DataClasses1DataContext();
        bool ISignUp.SignUp(string UserName, string Email, string Password)
        {
            var user = new User();
            UserName = user.Username;
            Email = user.Email;
            Password = user.Password_Hash;

            db.Users.InsertOnSubmit(user);
            try
            {
                db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                ex.GetBaseException();
                return false;
            }
        }
    }
}
