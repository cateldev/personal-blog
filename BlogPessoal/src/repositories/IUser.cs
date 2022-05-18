using BlogPessoal.src.dtos;
using BlogPessoal.src.models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlogPessoal.src.repositories
{

/// <summary>
/// <para>Resume: Interface responsible for representing CRUD actions users.</para>
/// <para>Created by: Matheus Catel</para>
/// <para>Version: 1.0</para>
/// <para>Date: 2022-04-29</para>
/// </summary>
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