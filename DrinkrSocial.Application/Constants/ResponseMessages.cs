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

        public static string EmailIsAlreadyExist => "Email is already exist";
        public static string RegisterSuccessfully => "Register successfuly please look at your mail box for account confirmation.";
        public static string PasswordDontMatchWithConfirmation => "Password doesn't match its confirmation";
        public static string PasswordChangedSuccessfully => "Password changed successfully";
        public static string CurrentPasswordIsFalse => "Current Password is false";
    }
}
