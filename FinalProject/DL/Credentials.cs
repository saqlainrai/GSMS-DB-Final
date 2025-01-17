﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.DL
{
    public class Credentials
    {
        private int id;
        private int userId;
        protected string userName;
        private string password;
        private string role;
        public string UserName { get => userName; set => userName = value; }
        public string Password { get => password; set => password = value; }
        public string Role { get => role; set => role = value; }
        public Credentials(string UserName, string Password, string Role)
        {
            this.userName = UserName;
            this.password = Password;
            this.Role = Role;
        }
        public Credentials(string UserName, string Password)
        {
            this.userName = UserName;
            this.password = Password;
        }


    }
}
