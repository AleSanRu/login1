using Microsoft.EntityFrameworkCore;
using Login_Pagina.Models;
using Login_Pagina.Servicios.Contrato;

namespace Login_Pagina.Servicios.Implementacion
{
    public class UsuarioService : IUsuarioService
    {
        private readonly DbloginUserContext _dbContext;
        public UsuarioService(DbloginUserContext dbContext) 
        {
            _dbContext = dbContext; 
        }
        public async Task<Usuario> GetUsuarios(string Correo, string clave)
        {
            Usuario usuario_encontrado=await _dbContext.Usuarios.Where(u=>u.Correo==Correo && u.Clave == clave)
                .FirstOrDefaultAsync();

            return usuario_encontrado;
        }

        public async Task<Usuario> SaveUsuario(Usuario modelo)
        {
            _dbContext.Usuarios.Add(modelo);
            await _dbContext.SaveChangesAsync();
            return modelo;
        }
    }
}
