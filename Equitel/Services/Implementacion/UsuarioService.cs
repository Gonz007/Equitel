using Microsoft.EntityFrameworkCore;
using Equitel.Models;
using Equitel.Services.Contrato;

namespace Equitel.Services.Implementacion
{
    public class UsuarioService : IUsuarioService
    {
        private EquitelContext _dbContext;

        public UsuarioService(EquitelContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Usuario> AddUsuario(Usuario modelo)
        {
            try
            {
                _dbContext.Usuarios.Add(modelo);
                await _dbContext.SaveChangesAsync();
                return modelo;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<bool> DeleteUsuario(Usuario modelo)
        {
            try
            {
                _dbContext.Usuarios.Remove(modelo);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<List<Usuario>> GetListUsuario()
        {
            try
            {
                List<Usuario> lista = new List<Usuario>();
                lista = await _dbContext.Usuarios.ToListAsync();
                return lista;
            }
            catch (Exception ex){
                throw ex;
            }
        }

        public async Task<Usuario> GetUsuario(int idUsuario)
        {
            try
            {
                Usuario? find = new Usuario();
                find = await _dbContext.Usuarios.FirstOrDefaultAsync(x => x.Id == idUsuario);
                return find;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<bool> UpdateUsuario(Usuario modelo)
        {
            try
            {
                _dbContext.Usuarios.Update(modelo);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
