﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace JogaFacil.Api.Entities
{
    public class User : IdentityUser<int>
    {
        public string Name { get; set; }

        public UserType UserType { get; set; }

        public bool Deleted { get; set; }
    }

    public enum UserType
    {
        User = 0,
        Admin = 1,
        Owner = 2
    }
}
