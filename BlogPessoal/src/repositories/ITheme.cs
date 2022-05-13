using BlogPessoal.src.dtos;
using BlogPessoal.src.models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlogPessoal.src.repositories
{
    ///<summary>
    ///<para>Resumo: Responsavel por representar ações de CRUD de tema</para>
    ///<para>Criado por: Matheus Catel</para>
    ///<para>Versão 1.0</para>
    ///<para>Data: 29/04/2022</para>
    ///</summary>

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
