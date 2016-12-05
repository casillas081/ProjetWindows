﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuidMe1.Model
{
    public class Person
    {
        public String Pseudo { get; set; }
        public String Password { get; set; }
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public Boolean Sex { get; set; }
        
        public String Nationality { get; set; }
        public Boolean TypeRole { get; set; }
        
        public Boolean IsOnline { get; set; }
        public double Rank { get; set; }
        public String IdPicture { get; set; }


        public Person(String ps, String psw, String fN, String lN, Boolean sx,  String natio, Boolean rol = true, Boolean isOn = false,Double ran = 0, String pic = "pic001")
        {
            Pseudo = ps;
            FirstName = fN;
            LastName = lN;
            Sex = sx;
            Password = psw;
            Nationality = natio;
            TypeRole = rol;
            Rank = ran;
            IdPicture = pic;
        }
    }
}
