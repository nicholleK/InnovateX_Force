using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;  //include web namespace in order to use Http commands
using HashPass;  // include secrecy namespace 
using Microsoft.Extensions.Logging;

namespace backend1
{
    //METHODS WILL BE CALLED IN THE CODE-BEHIND FILES OF THE SPECIFIC FRONTEND PAGES (.aspx.cs files) ON THE SPECIFIC BUTTON (LOGIN, LOGOUT BUTTONS etc)  

    //Realize Interfaces and implement their methods
    public class Default_Helper : ILogout, ILogin, ISignOut, ISignUp
    {

        //variable for built-in Microsoft logging functionality
        private readonly ILogger<Default_Helper> logger;

        //create an instance of the dataclasses (LINQ to SQL)
        DataClasses1DataContext db = new DataClasses1DataContext();

        //Logging function variable instantiation
        public Default_Helper(ILogger<Default_Helper> logger)
        {
            this.logger = logger;
        }

        //LOGOUT FUNCTION IMPLEMENTATION

        public bool Login(HttpContext context, string email, string password)
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


        //LOGOUT FUNCTION IMPLEMENTATION
        public string Logout(HttpContext context)
        {
            try
            {
                //Clear the user's sessions
                context.Session.Clear();  //Clear the user's sessions
                context.Session.Abandon();  //Cancel the current session and release resources. (also generates a new ID for the next session)

                //Clear the client's cookie variables
                if (context.Request.Cookies[".ASPXAUTH"] != null)    //Check if the authentication cookie variable exists
                {
                    //create a cookie instance with an empty value
                    var cookie = new HttpCookie(".ASPXAUTH", string.Empty);
                    //delete the cookie
                    cookie.Expires = DateTime.Now.AddDays(-1);  //set the cookies expiration date to a past data to delete it
                                                                // add cookie to the response command of http to remove the cookie from the client-side
                    context.Response.Cookies.Add(cookie);
                }

                //Redirect the user to the landing page after successful log out
                context.Response.Redirect("~/landing-page.aspx");

                //Success message sent
                string logoutMssg = "Successfully Logged Out";
                context.Response.Write(logoutMssg);
                return logoutMssg;

            }
            catch (Exception ex)
            {
                //Error handling
                this.logger.LogError(ex, "Error occured during login for user with email: ");
                string failMssg = "Error logging out. Try again";
                context.Response.Write(failMssg);
                return failMssg + ":" + ex.Message;

            }


        }

        //SIGN OUT or DELETE ACCOUNT FUNCTION IMPLEMENTATION

        public bool SignOut(string UserName)
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

        //SIGN UP or REGISTER FUNCTION IMPLEMENTATION
        public bool SignUp(string UserName, string Email, string Password)
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
