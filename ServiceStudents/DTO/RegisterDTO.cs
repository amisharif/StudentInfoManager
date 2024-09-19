using Microsoft.AspNetCore.Mvc;
using ServiceStudents.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace ServiceStudents.DTO
{
    public class RegisterDTO
    {
        [Required(ErrorMessage ="Name can't be blank")]
        public string PersonName { get; set; }
    

        //valid if return true
        [Required(ErrorMessage = "Email can't be blank")]
        [EmailAddress(ErrorMessage = "Email should be in a proper email address format")]
        [Remote(action: "IsEmailAlreadyRegistered", controller: "Account", ErrorMessage = "Email is already is use")]
        public String Email { get; set; }
        public string Phone { get; set; }
        [Required(ErrorMessage ="Password can't be blank")]
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }

        public UserTypeOptions UserType { get; set; } = UserTypeOptions.User;

    }
}
