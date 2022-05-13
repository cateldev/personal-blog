using System.Threading.Tasks;
using BlogPessoal.src.dtos;
using BlogPessoal.src.models;
namespace BlogPessoal.src.services
{
    public interface IAuthentication
    {
        string EncodePassword(string password);
        Task CreateUserNoDuplicateAsync(NewUserDTO dto);
        string CreateToken(UserModel user);
        Task<AuthorizationDTO> GetAuthorizationAsync(AuthenticateDTO dto);
    }
}