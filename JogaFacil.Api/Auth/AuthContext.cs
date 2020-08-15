using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using JogaFacil.Api.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace JogaFacil.Api.Auth
{
    public class AuthContext : IdentityDbContext
    {
        public AuthContext() : base()
        {
        }

        public AuthContext (DbContextOptions<AuthContext> options)
            : base(options)
        {
        }
    }
}
