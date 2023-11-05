using Authenticator.Common;
using Authenticator.DTO;

namespace Authenticator.Services
{
    public interface IUserService
    {
        Task<Result> BuscarUsuariosPorEmailAsync(string email);
        Task<Result> BuscarUsuariosPorRolesAsync(string name);
        Task<Result> CrearUsuariosAsync(AddUsersDto users);
        Task<Result> ActualizarUsuariosAsync(EditUsersDto users);
        Task<Result> ArchivarUsuariosAsync(string email);
        Task<Result> BuscarRolesAsync();

    }
}
