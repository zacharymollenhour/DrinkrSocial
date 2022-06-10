using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrinkrSocial.Application.Constants
{
    public class ResponseMessages
    {
        public static string UserRolesUpdatedSuccessfully => "User Roles Updated Successfully";

        public static string UpdatedSuccessfully => "Updated Successfully";

        public static string PasswordSuccessfullyReset => "Your password has been successfully reset.Your new password has been sent to your email address.We recommend that you change your password.";
        public static string ResetPasswordCodeInvalid => "Your Reset Password Code is invalid";

        public static string UserNotFound => "User not found";
        public static string AlreadyEmailConfirmed => "Already your email confirmed";
        public static string SuccessfullyEmailConfirmed => "Email confirmed successfully.You can login now";
        public static string DeletedSuccessfully => "Deleted Successfully";

        public static string EmailConfirmationRequired => "Please Confirm your Email Address";
        public static string AuthenticationFailed => "Username or password is incorrect";
        public static string UsernameAlreadyExists => "Username is already exist";
        public static string RefreshTokenNotFound => "Refresh Token Not Found";
        public static string RefreshTokenExpired => "Refresh Token Expired";
        public static string IfEmailTrue => "If your email address is entered correctly, you will receive a link to reset your password.";

        public static string EmailIsAlreadyExist => "Email is already exist";
        public static string RegisterSuccessfully => "Register successfuly please look at your mail box for account confirmation.";
        public static string PasswordDontMatchWithConfirmation => "Password doesn't match its confirmation";
        public static string PasswordChangedSuccessfully => "Password changed successfully";
        public static string CurrentPasswordIsFalse => "Current Password is false";
        public static string EmailSuccessfullyChangedConfirmYourEmail => "Email Successfully Changed.Please confirm your email";

    }
}
