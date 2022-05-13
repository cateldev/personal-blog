using BlogPessoal.src.data;
using BlogPessoal.src.dtos;
using BlogPessoal.src.models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogPessoal.src.repositories.implementations
{
  public class UserRepository : IUser
  {
    #region Attributes    
    private readonly BlogPessoalContext _context;
    #endregion

    #region Constructors
    public UserRepository(BlogPessoalContext context)
    {
      _context = context;
    }
    #endregion

    #region Methods
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
    public async Task UpdateUserAsync(UpdateUserDTO user)
    {
      var UserExistance = await GetUserByIdAsync(user.Id);
      UserExistance.Name = user.Name;
      UserExistance.Password = user.Password;
      UserExistance.Photo = user.Photo;
      _context.Users.Update(UserExistance);
      await _context.SaveChangesAsync();
    }
    public async Task DeleteUserAsync(int id)
    {
      _context.Users.Remove(await GetUserByIdAsync(id));
      await _context.SaveChangesAsync();
    }

    public async Task<UserModel> GetUserByIdAsync(int id)
    {
      return await _context.Users.FirstOrDefaultAsync(u => u.Id == id);
    }

    public async Task<List<UserModel>> GetUserByNameAsync(string nome)
    {
      return await _context.Users 
                        .Where(u => u.Name.Contains(nome))
                        .ToListAsync();
    }

    public async Task<UserModel> GetUserByEmailAsync(string email)
    {
      return await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
    }
    #endregion Methods
  }
}


        