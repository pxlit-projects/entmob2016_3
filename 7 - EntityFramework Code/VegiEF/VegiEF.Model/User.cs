﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace VegiEF.Model
{
    public class User
    {
        [Key]     
        private int userId;
        private string username;
        private string password;

        public int UserId { get { return userId; } set { userId = value; } }
        public string Username { get { return username; } set { username = value; } }
        public string Password { get { return password; } set { password = value; } }
    }
}
