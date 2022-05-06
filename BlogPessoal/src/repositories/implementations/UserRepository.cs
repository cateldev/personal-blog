using BlogPessoal.src.data;
using BlogPessoal.src.DTOS;
using BlogPessoal.src.models;
using BlogPessoal.src.repositories;
using System.Collections.Generic;
using System.Linq;

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
    public void  NewUser(NewUserDTO userDTO)
    {
      _context.Users.Add(new UserModel
      {
        Email = userDTO.Email,
        Name = userDTO.Name,
        Password = userDTO.Password,
        Photo = userDTO.Photo
      });
        _context.SaveChanges();
    }
    public void UpdateUser(UpdateUserDTO user)
    {
      var UserExistance = GetUserById(user.Id);
      UserExistance.Name = user.Name;
      UserExistance.Password = user.Password;
      UserExistance.Photo = user.Photo;
      _context.Users.Update(UserExistance);
      _context.SaveChanges();
    }
    public void DeleteUser(int id)
    {
      _context.Users.Remove(GetUserById(id));
      _context.SaveChanges();
    }

    public UserModel GetUserById(int id)
    {
      return _context.Users.FirstOrDefault(u => u.Id == id);
    }

    public UserModel GetUserByEmail(string email)
    {
      return _context.Users.FirstOrDefault(u => u.Email == email);
    }

    public List<UserModel> GetUserByName(string name)
    {
        return _context.Users.Where(u => u.Name.Contains(name)).ToList();
    }
    #endregion Methods
  }
}


        