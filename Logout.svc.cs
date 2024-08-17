using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Web;

namespace backend1
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Logout" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Logout.svc or Logout.svc.cs at the Solution Explorer and start debugging.
    public class Logout : ILogout
    {
        private readonly ILogger<Logout> logger;
        string ILogout.Logout(HttpContext context)
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
    }
}

