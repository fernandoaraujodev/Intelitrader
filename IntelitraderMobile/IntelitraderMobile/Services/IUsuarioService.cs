using IntelitraderMobile.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IntelitraderMobile.Services
{
    public interface IUsuarioService
    {
        Task<Usuario> GetUser(string id);
        Task<IEnumerable<Usuario>> GetUsers();

        Task AddUser(Usuario usuario);
        Task UpdateUser(string id, Usuario usuario);
        Task DeleteUser(string id);
    }
}
