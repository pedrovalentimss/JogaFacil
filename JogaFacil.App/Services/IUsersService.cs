using JogaFacil.App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JogaFacil.App.Services
{
    public interface IUsersService
    {
        Task<User> GetUser(string id);
    }
}
