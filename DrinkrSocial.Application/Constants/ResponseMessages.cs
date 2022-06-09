using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrinkrSocial.Application.Constants
{
    public class ResponseMessages
    {
        public static string UserNotFound => "User not found";
        public static string EmailConfirmationRequired => "Please Confirm your Email Address";
        public static string AuthenticationFailed => "Username or password is incorrect";
        public static string UsernameAlreadyExists => "Username is already exist";
        public static string RefreshTokenNotFound => "Refresh Token Not Found";
        public static string RefreshTokenExpired => "Refresh Token Expired";


    }
}
