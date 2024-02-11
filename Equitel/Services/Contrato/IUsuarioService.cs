using Equitel.Models;

namespace Equitel.Services.Contrato
{
    public interface IUsuarioService
    {
        Task<List<Usuario>> GetListUsuario();
        Task<Usuario> GetUsuario(int idUsuario);
        Task<Usuario> AddUsuario(Usuario modelo);
        Task<bool> UpdateUsuario(Usuario modelo);
        Task<bool> DeleteUsuario(Usuario modelo);

    }
}
