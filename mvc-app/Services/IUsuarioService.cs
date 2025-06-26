using mvc_app.DTOs;
using System.Threading.Tasks;

namespace mvc_app.Services
{
    public interface IUsuarioService
    {
        Task<bool> RegistrarUsuarioAsync(UserRegisterDto dto);
    }
}
