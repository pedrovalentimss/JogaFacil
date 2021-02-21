using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using JogaFacil.Api.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace JogaFacil.Api.Auth
{
    public class AuthContext : IdentityDbContext<User, IdentityRole<int>, int>
    {
        public AuthContext() : base()
        {
        }

        public AuthContext (DbContextOptions<AuthContext> options)
            : base(options)
        {
        }

        public DbSet<Reservation> Reservations { get; set; }

        public DbSet<Place> Places { get; set; }

        public DbSet<Arena> Arenas { get; set; }
    }
}
