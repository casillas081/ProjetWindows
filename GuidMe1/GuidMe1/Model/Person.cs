using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuidMe1.Model
{ /// <summary>
/// Modifier cette classe en : RegisterBindingModel
/// </summary>
    public class Person
    {
        public String Email { get; set; }
        public String Password { get; set; }
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public Boolean Sex { get; set; }
        
        public String Nationality { get; set; }
        public Boolean TypeRole { get; set; }
        
        public Boolean IsOnline { get; set; }
        public double Rank { get; set; }


        public Person(String em, String psw, String fN, String lN, Boolean sx,  String natio)
        {
            Email = em;
            Password = psw;
            FirstName = fN;
            LastName = lN;
            Sex = sx;            
            Nationality = natio;
            TypeRole = true;
            IsOnline = false;
            Rank = 0;
        }
    }
}
