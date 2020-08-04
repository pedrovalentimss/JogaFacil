using JogaFacil.Client.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JogaFacil.Client.Services
{
    public interface IArenasService
    {
        Task<Arena> GetArena(int id);
    }
}
