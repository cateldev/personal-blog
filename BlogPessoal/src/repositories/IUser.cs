using BlogPessoal.src.DTOS;
using BlogPessoal.src.models;
using System.Collections.Generic;

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
    void NewUser(NewUserDTO newUser);
    void UpdateUser(UpdateUserDTO user);
    void DeleteUser(int id);
    UserModel GetUserById(int id);
    UserModel GetUserByEmail(string email);
    List<UserModel> GetUserByName (string name);
  }
  
}