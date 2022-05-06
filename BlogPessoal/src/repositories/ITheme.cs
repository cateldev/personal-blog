using BlogPessoal.src.DTOS;
using BlogPessoal.src.models;
using System.Collections.Generic;

namespace BlogPessoal.src.repositories
{
    ///<summary>
    ///<para>Resumo: Responsavel por representar ações de CRUD de tema</para>
    ///<para>Criado por: Matheus Catel</para>
    ///<para>Versão 1.0</para>
    ///<para>Data: 29/04/2022</para>
    ///</summary>

    public interface ITema
    {
        void NewTheme(NewThemeDTO theme);
        void UpdateTheme(UpdateThemeDTO theme);
        void DeleteTheme(int id);
        ThemeModel GetThemeById(int id);
        List<ThemeModel> GetThemeByDescription(string description);
    }

}
