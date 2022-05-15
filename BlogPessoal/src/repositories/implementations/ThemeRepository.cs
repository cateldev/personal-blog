using BlogPessoal.src.data;
using BlogPessoal.src.dtos;
using BlogPessoal.src.models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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

    public async Task NewThemeAsync(NewThemeDTO theme)
    {
      _context.Themes.Add(new ThemeModel
      { 
        Description = theme.Description
      });
       await _context.SaveChangesAsync();
    }

    public async Task UpdateThemeAsync(UpdateThemeDTO theme)
    {
      var ThemeExistance = await GetThemeByIdAsync(theme.Id);
      ThemeExistance.Description = theme.Description;
      _context.Themes.Update(ThemeExistance);
      await _context.SaveChangesAsync();
    }

    public async Task DeleteThemeAsync(int id)
    {
      _context.Themes.Remove(await GetThemeByIdAsync(id));
      await _context.SaveChangesAsync();
    }

    public async Task<ThemeModel> GetThemeByIdAsync(int id)
    {
      return await _context.Themes.FirstOrDefaultAsync(t => t.Id == id);
    }

    public async Task<List<ThemeModel>> GetAllThemesAsync()
    {
      return await _context.Themes.ToListAsync();
    }

    public async Task<List<ThemeModel>> GetThemeByDescriptionAsync(string description)
    {
      return await _context.Themes
                          .Where(u => u.Description.Contains(description))
                          .ToListAsync();
    }
    #endregion Methods
  }
}