using BlogPessoal.src.data;
using BlogPessoal.src.dtos;
using BlogPessoal.src.models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogPessoal.src.repositories
{

    /// <summary>
    /// <para>Resume: Class responsible for implement methos CRUD Theme.</para>
    /// <para>Created by: Matheus Catel</para>
    /// <para>Version: 1.0</para>
    /// <para>Date: 2022-04-29</para>
    /// </summary>

  public class ThemeRepository : ITheme
  {
    #region Attributes
    private readonly BlogPessoalContext _context;

    #endregion Attributes

    #region Constructors

      /// <summary>
      /// <para>Resume: Constructor of class.</para>
      /// </summary>
      /// <param name="context">AppBlogContext</param>

    public ThemeRepository(BlogPessoalContext context)
    {
      _context = context;
    }
    #endregion Constructors

    #region Method

    /// <summary>
    /// <para>Resume: method for add a new theme.</para>
    /// </summary>
     /// <param name="theme">ThemeRegisterDTO</param>

    public async Task NewThemeAsync(NewThemeDTO theme)
    {
      _context.Themes.Add(new ThemeModel
      { 
        Description = theme.Description
      });
       await _context.SaveChangesAsync();
    }

    /// <summary>
    /// <para>Resume: Implement method for update a theme.</para>
    /// </summary>
    /// <param name="theme">ThemeUpdateDTO</param>

    public async Task UpdateThemeAsync(UpdateThemeDTO theme)
    {
      var ThemeExistance = await GetThemeByIdAsync(theme.Id);
      ThemeExistance.Description = theme.Description;
      _context.Themes.Update(ThemeExistance);
      await _context.SaveChangesAsync();
    }

    /// <summary>
    /// <para>Resume: method for delete a theme.</para>
    /// </summary>
    /// <param name="id">Id of theme</param>
    
    public async Task DeleteThemeAsync(int id)
    {
      _context.Themes.Remove(await GetThemeByIdAsync(id));
      await _context.SaveChangesAsync();
    }

    /// <summary>
    /// <para>Resume: method for get theme by id.</para>
    /// </summary>
    /// <param name="id">Id of theme</param>

    public async Task<ThemeModel> GetThemeByIdAsync(int id)
    {
      return await _context.Themes.FirstOrDefaultAsync(t => t.Id == id);
    }

    /// <summary>
    /// <para>Resume: method for get all themes.</para>
    /// </summary>
    /// <returns>List of ThemeModel</returns>

    public async Task<List<ThemeModel>> GetAllThemesAsync()
    {
      return await _context.Themes.ToListAsync();
    }

    /// <summary>
    /// <para>Resume: method for get theme by description.</para>
    /// </summary>
    /// <param name="description">Description of theme</param>
    /// <returns>List of ThemeModel</returns>

    public async Task<List<ThemeModel>> GetThemeByDescriptionAsync(string description)
    {
      return await _context.Themes
                          .Where(u => u.Description.Contains(description))
                          .ToListAsync();
    }

    #endregion Methods
  }
}