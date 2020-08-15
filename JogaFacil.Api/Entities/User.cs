using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace JogaFacil.Api.Entities
{
    public class User
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Username { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        public string Phone { get; set; }

        [Required]
        public string Password { get; set; }

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
