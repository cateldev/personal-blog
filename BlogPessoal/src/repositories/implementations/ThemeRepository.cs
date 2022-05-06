using BlogPessoal.src.data;
using BlogPessoal.src.DTOS;
using BlogPessoal.src.models;
using System.Collections.Generic;
using System.Linq;

namespace BlogPessoal.src.repositories
{
  public class ThemeRepository : ITheme
  {
    #region Attributes
    private readonly BlogPessoalContext _context;

    #endregion Attributes

    #region Constructors
    public ThemeRepository(BlogPessoalContext context)
    {
      _context = context;
    }
    #endregion Constructors

    #region Method

    public void NewTheme(NewThemeDTO newThemeDTO)
    {
      _context.Themes.Add(new ThemeModel
      { 
        Description = newThemeDTO.Description
      });
       _context.SaveChanges();
    }

    public void UpdateTheme(UpdateThemeDTO newTheme)
    {
      var ThemeExistance = GetThemeById(newTheme.Id);
      ThemeExistance.Description = newTheme.Description;
      _context.Themes.Update(ThemeExistance);
      _context.SaveChanges();
    }

    public void DeleteTheme(int id)
    {
      _context.Themes.Remove(GetThemeById(id));
      _context.SaveChanges();
    }

    public ThemeModel GetThemeById(int id)
    {
      return _context.Themes.FirstOrDefault(u => u.Id == id);
    }

    public List<ThemeModel> GetAllThemes()
    {
      return _context.Themes.ToList();
    }

    public List<ThemeModel> GetThemeByDescription(string description)
    {
      return _context.Themes.ToList();
    }
    #endregion Methods
  }
}