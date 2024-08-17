using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace backend1
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "SignOut" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select SignOut.svc or SignOut.svc.cs at the Solution Explorer and start debugging.
    public class SignOut : ISignOut
    {
        DataClasses1DataContext db = new DataClasses1DataContext();

        bool ISignOut.SignOut(string UserName)
        {
            var user = db.Users.SingleOrDefault(u => u.Username == UserName);

            if (user == null)
            {
                return false;
            }

            db.Users.DeleteOnSubmit(user);
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
