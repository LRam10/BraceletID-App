using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BraceletID.Models;
using System.Data.SqlClient;
using System.Configuration;
using System.Net.Mail;
using System.Net;

namespace BraceletID.Controllers
{
    public class SignInController : Controller
    {

        // GET: SignIn
        [HttpGet]
        public ActionResult SignIn()
        {
            return View();
        }
       
            // creating the connection string with database server and database if using windows auth use integrated security =SSPi
            // else use your server id and password
            //conn.ConnectionString = "data source = LUISRAMIREZ61DC\\MYSQLRAMIREZ; database= UserLogin; user id =sa; password=Barcelona12";
        //post method same as in php,called when login button is clicked
        [HttpPost]
        public ActionResult Verify(UserAccount acc)
        {
            //conn.ConnectionString = "data source = LUISRAMIREZ61DC\\MYSQLRAMIREZ; database= UserLogin; user id =sa; password=Barcelona12";
            string CS = ConfigurationManager.ConnectionStrings["DB"].ConnectionString;
            //Creating the connection object
            // surrounded by a using statement to properly close connection
            using (SqlConnection conn = new SqlConnection(CS))
            {
                // command we are goin to create
                SqlCommand q = new SqlCommand();

                // reader needed when we need to read data from the database
                //SqlDataReader rd;

                // same as sqlcommand = new sqlcommand(query,connection name)
                q.Connection = conn;

                //Parameterized query to prevent sql injection
                q.CommandText = "SELECT * FROM UserLogin WHERE Email= @UserEmail AND Password =@UserPassword ";
                // execute the command 
                q.Parameters.AddWithValue("@Useremail",acc.Email);
                q.Parameters.AddWithValue("@UserPassword",acc.Password);
                //opening the connection
                conn.Open();

                q.ExecuteReader();
               
               return View("UserView");
                
            }
            
        }
        [HttpPost]
        public ActionResult CreateAcc (UserAccount acc)
        {
            bool Status = false;
            string message = "";
            //validate Model
            if (ModelState.IsValid)
            {
                var exist = EmailExists(acc.REmail);
                if (exist)
                {

                    TempData["msg"] ="<script>alert('Email already in use,please click \"Forgot Password\" link.');</script>" ;
                    return View("SignIn");
                }

                #region HashPassword
                acc.Password = Crypto.Hash(acc.Password);
                acc.ConfirmPassword = Crypto.Hash(acc.ConfirmPassword);
                #endregion
                acc.ActivationCode = Guid.NewGuid();
                acc.IsEmailVerified = false;
                //connect to database server
                string CS = ConfigurationManager.ConnectionStrings["DB"].ConnectionString;
                using (SqlConnection conn = new SqlConnection(CS))
                {
                    SqlCommand cmd = new SqlCommand();
                    SqlDataReader rd;
                    //connect the command with the database 
                    cmd.Connection = conn; 
                    //Query or command .....Order by in which fields are to filled
                    cmd.CommandText = "INSERT INTO UserLogin (FirstName,Lastname,Email,Password,IsEmailVerify,VerificationCode)" +
                        "VALUES" +
                        "(@FirstName,@LastName,@REmail,@Password,@EVerification,@ActivationCode);";

                    cmd.Parameters.AddWithValue("@FirstName",acc.FirstName);
                    cmd.Parameters.AddWithValue("@LastName",acc.LastName);
                    cmd.Parameters.AddWithValue("@REmail",acc.REmail);
                    cmd.Parameters.AddWithValue("@Password",acc.Password);
                    cmd.Parameters.AddWithValue("@EVerification",acc.IsEmailVerified);
                    cmd.Parameters.AddWithValue("@ActivationCode",acc.ActivationCode);
                    // open connection
                    conn.Open();
                    // command is executed and store in rd if we need to retrieve any data
                    rd = cmd.ExecuteReader();
                    SendVerificationLink(acc.REmail,acc.ActivationCode.ToString());
                    message = "Email verification link has been sent to:"+acc.REmail+ ",please verify account";
                    Status = true;
                    ViewBag.Message = message;
                    ViewBag.Status = Status;
                    return View("UserView");
                }
            }
            else
                message = "Invalid Request";

            return View("Error");
        }


        [NonAction]
        public bool EmailExists(string Email)
        {
            string CS = ConfigurationManager.ConnectionStrings["DB"].ConnectionString;
            //Creating the connection object
            // surrounded by a using statement to properly close connection
            using (SqlConnection conn = new SqlConnection(CS))
            {
                // command we are goin to create
                SqlCommand q = new SqlCommand();
                // reader
                SqlDataReader rd;
                // same as sqlcommand = new sqlcommand(query,connection name)
                q.Connection = conn;

                //Query for looking for email and userName
                q.CommandText = "SELECT * FROM UserLogin WHERE Email= @REmail";
                q.Parameters.AddWithValue("@REmail",Email);
                // execute the command 
                //opening the connection
                conn.Open();
                // execute the command 
                rd = q.ExecuteReader();
                if (rd.HasRows)
                {
                    return true;
                }
                else
                    return false;
            }
        }
        // send email for verification
        [NonAction]
        public void SendVerificationLink(string Email,string activationCode)
        {
            var verifyUrl = "/UserView/" + activationCode;
            var link = Request.Url.AbsoluteUri.Replace(Request.Url.PathAndQuery,verifyUrl);

            var fromEmail = new MailAddress("albertmess11@gmail.com","Bracelet ID");
            var toEmail = new MailAddress(Email);
            var fromEmailPassword = "Barcelona12-";

            string subject = "Your Account has been created";
            string body = "<br /><br /> We are excited to have on board! Please click on the link below to verify your account"
                +"<br/><a href='"+link+"'>"+link+"</a>";

            var smpt = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromEmail.Address,fromEmailPassword) 
            };
            using (var message = new MailMessage(fromEmail, toEmail)
            {
                Subject = subject,
                Body = body,
                IsBodyHtml = true
            })
                smpt.Send(message);
        }

    }
}