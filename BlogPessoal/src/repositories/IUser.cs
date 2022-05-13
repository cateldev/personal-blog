using BlogPessoal.src.dtos;
using BlogPessoal.src.models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlogPessoal.src.repositories
{
  ///<summary>
  ///<para>Resumo: Responsável por representar ações de CRUD de usuário</para>
  ///<para> Criado por: Matheus Catel</para>
  ///<para>Versão: 1.0</para>
  ///<para>Data: 29/04/2022</para>
  ///</summary>>
  public interface IUser
  {
    Task<UserModel> GetUserByIdAsync(int id);
    Task<List<UserModel>> GetUserByNameAsync(string name);
    Task<UserModel> GetUserByEmailAsync(string email);
    Task NewUserAsync(NewUserDTO user);
    Task UpdateUserAsync(UpdateUserDTO user);
    Task DeleteUserAsync(int id);
  }
  
}