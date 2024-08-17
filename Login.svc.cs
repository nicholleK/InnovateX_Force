using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Web;
using HashPass;
using Microsoft.Extensions.Logging;

namespace backend1
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Login" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Login.svc or Login.svc.cs at the Solution Explorer and start debugging.
    public class Login : ILogin
    {
        DataClasses1DataContext db = new DataClasses1DataContext();
        private readonly ILogger<Login> logger;
        public Login(ILogger<Login> logger)
        {
            this.logger = logger;
        }
        bool ILogin.Login(HttpContext context, string email, string password)
        {
            bool isAuthenticated = false;
            HttpResponse response = HttpContext.Current.Response;

            try
            {

                //fetch user infor from db and compare
                var u = (from dbUser in db.Users
                         where dbUser.Email.Equals(email) && dbUser.Password_Hash == Secrecy.HashPassword(password)
                         select dbUser).FirstOrDefault();


                //check if user exists
                if (u != null)
                {
                    //get the user type
                    bool role = u.User_Type;

                    if (role)
                    {
                        //redirect user to Admin page if role is true
                        response.Redirect("~/admin.aspx");
                    }

                }
                else
                {

                    //redirect user to Home page if role is true
                    response.Redirect("~/Home.aspx");
                }

                isAuthenticated = true;

            }
            catch (Exception ex)
            {
                //Add a error meassage log
                this.logger.LogError(ex, "Error occured during login for user with email: ", email);

                isAuthenticated = false;
                return isAuthenticated;
            }
            return isAuthenticated;
        }
    }
}

