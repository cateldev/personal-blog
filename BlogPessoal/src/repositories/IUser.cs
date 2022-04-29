using System;

namespace BlogPessoal.src.repositories;
{
  ///<summary>
  ///<para>Resumo: Responsável por representar ações de CRUD de usuário</para>
  ///<para> Criado por: Gustavo Boaz</para>
  ///<para>Versão: 1.0</para>
  ///<para>Data: 29/04/2022</para>
  ///</summary>
}

public interface IUser
{
  void NewUser(NewUserDTO newUser);
  void UpdateUser(UpdateUserDTO user);
}