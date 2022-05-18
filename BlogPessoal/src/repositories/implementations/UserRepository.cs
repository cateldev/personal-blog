using BlogPessoal.src.data;
using BlogPessoal.src.dtos;
using BlogPessoal.src.models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogPessoal.src.repositories.implementations
{
    /// <summary>
    /// <para>Resume: Class responsible for implement methos CRUD Users.</para>
    /// <para>Created by: Matheus Catel</para>
    /// <para>Version: 1.0</para>
    /// <para>Date: 2022-05-02</para>
    /// </summary>

  public class UserRepository : IUser
  {
    #region Attributes    
    private readonly BlogPessoalContext _context;
    #endregion

    #region Constructors

    /// <summary>
    /// <para>Resume: Constructor of class.</para>
    /// </summary>
    /// <param name="context">AppBlogContext</param>

    public UserRepository(BlogPessoalContext context)
    {
      _context = context;
    }
    #endregion

    #region Methods

    /// <summary>
    /// <para>Resume: method for add a new user.</para>
    /// </summary>
    /// <param name="user">UserRegisterDTO</param>

    public async Task NewUserAsync(NewUserDTO user)
    {
      await _context.Users.AddAsync(new UserModel
      {
        Email = user.Email,
        Name = user.Name,
        Password = user.Password,
        Photo = user.Photo,
        Type = user.Type
      });

        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// <para>Resume: method for update am existent user.</para>
    /// </summary>
    /// <param name="user">UpdateUserDTO</param>

    public async Task UpdateUserAsync(UpdateUserDTO user)
    {
      var UserExistance = await GetUserByIdAsync(user.Id);
      UserExistance.Name = user.Name;
      UserExistance.Password = user.Password;
      UserExistance.Photo = user.Photo;
      _context.Users.Update(UserExistance);
      await _context.SaveChangesAsync();
    }

    /// <summary>
    /// <para>Resume: method for delete a existent user.</para>
    /// </summary>
    /// <param name="id">Id of user</param>

    public async Task DeleteUserAsync(int id)
    {
      _context.Users.Remove(await GetUserByIdAsync(id));
      await _context.SaveChangesAsync();
    }

    /// <summary>
    /// <para>Resume: method for get user by id.</para>
    /// </summary>
    /// <param name="id">Id of user</param>
    /// <returns>UserModel</returns>

    public async Task<UserModel> GetUserByIdAsync(int id)
    {
      return await _context.Users.FirstOrDefaultAsync(u => u.Id == id);
    }

    /// <summary>
    /// <para>Resume: method for get user by name.</para>
    /// </summary>
    /// <param name="name">Name of user</param>
    /// <returns>List of UserModel</returns>

    public async Task<List<UserModel>> GetUserByNameAsync(string nome)
    {
      return await _context.Users 
                        .Where(u => u.Name.Contains(nome))
                        .ToListAsync();
    }

    /// <summary>
    /// <para>Resume: method for get user by email.</para>
    /// </summary>
    /// <param name="email">Email of user</param>
    /// <returns>UserModel</returns>

    public async Task<UserModel> GetUserByEmailAsync(string email)
    {
      return await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
    }
    
    #endregion Methods
  }
}


        