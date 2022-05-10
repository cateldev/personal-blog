using BlogPessoal.src.DTOS;
using BlogPessoal.src.models;
namespace BlogPessoal.src.services
{
    public interface IAutentication
    {
        string CodifyPassword(string password);
        void CreateUserNoDuplicate(NewUserDTO user);
        string GetToken(UserModel user);
        AutorizationDTO GetAutorization(AutenticateDTO autentication);
    }
}