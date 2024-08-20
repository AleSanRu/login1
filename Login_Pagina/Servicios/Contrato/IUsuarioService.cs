using Microsoft.EntityFrameworkCore;
using Login_Pagina.Models;

namespace Login_Pagina.Servicios.Contrato
{
    public interface IUsuarioService
    {
        Task<Usuario> GetUsuarios(string Correo,string clave);
        Task<Usuario> SaveUsuario(Usuario modelo);
    }
}
