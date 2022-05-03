using BlogPessoal.src.models;
using BlogPessoal.src. dtos;
using BlogPessoal.src.repositorios;
using BlogPessoal.src.data;
using System.Linq;
using System.Collections.Generic;

namespace BlogPessoal.src.repositories.implementations
{
  public class UserRepository : IUser
  {
    #region Atributes
    private readonly BlogPessoalContext _context;
    #endregion Atributes

    #region Constructors
    public UserRepository(BlogPessoalContext context)
    {
         _context = context;
    }
    #endregion Constructors

    #region Methods
    public void DeleteUser(int id)
    {
      _context.Users.Remove(TakeUserById(id));
      _context.SaveChanges();
    }

    public void NewUser(NewUserDTO user)
    {
      _context.Users.Add(new UserModel
      {
          Email = user.Email,
          Name = user.Name,
          Password = user.Password,
          Photo = user.Photo
      });
    }

    public UserModel TakeUserByEmail(string email)
    {
      return _context.Users.FirstOrDefault(u => u.Email == email);
    }
    public UserModel TakeUserById(int id)
    {
      return _context.Users.FirstOrDefault(u => u.Id == id);
    }

    public List<UserModel> TakeUserByName(string name)
    {
        return _context.Users.Where(u => u.Name.Contains(name)).ToList();
    }

    public void UpdateUser(UpdateUserDTO user)
    {
      var UserExistance = TakeUserById(user.Id);
      UserExistance.Name = user.Name;
      UserExistance.Password = user.Password;
      UserExistance.Photo = user.Photo;
      _context.Users.Update(UserExistance);
      _context.SaveChanges();
    }
    
    #endregion Methods
  }
}