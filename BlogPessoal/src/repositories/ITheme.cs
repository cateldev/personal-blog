using BlogPessoal.src.dtos;
using BlogPessoal.src.models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlogPessoal.src.repositories
{
    /// <summary>
    /// <para>Resume: Interface responsible for representing CRUD actions themes.</para>
    /// <para>Created by: Matheus Catel</para>
    /// <para>Version: 1.0</para>
    /// <para>Date: 2022-04-29</para>
    /// </summary>

    public interface ITheme
    {
        Task<List<ThemeModel>> GetAllThemesAsync();
        Task<ThemeModel> GetThemeByIdAsync(int id);
        Task<List<ThemeModel>> GetThemeByDescriptionAsync(string description);
        Task NewThemeAsync(NewThemeDTO thema);
        Task UpdateThemeAsync(UpdateThemeDTO thema);
        Task DeleteThemeAsync(int id);
    }

}
