using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuidMe1.Model
{
    public class RegisterBindingModel
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public Boolean Sex { get; set; }
        public String Nationality { get; set; }
        public Boolean TypeRole { get; set; }
        public Boolean IsOnline { get; set; }
        public decimal RankGuid { get; set; }

        public virtual Avatar avatar { get; set; }

        public RegisterBindingModel(string Email, string Password, string ConfirmPassword, String FirstName, String LastName, Boolean Sex, String Nationality)
        {
            this.Email = Email;
            this.Password = Password;
            this.ConfirmPassword = ConfirmPassword;
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.Sex = Sex;
            this.Nationality = Nationality;
            this.TypeRole = true;
            this.IsOnline = false;
            this.RankGuid = 0;
        }
    }
}
