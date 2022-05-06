using BlogPessoal.src.DTOS;
using BlogPessoal.src.models;
using System.Collections.Generic;

namespace BlogPessoal.src.repositorios
public class ThemeRepository : ITheme
    {

        #region Atributos

        private readonly BlogPessoalContext _context;

        #endregion Atributos

        #region Construtores
        public ThemeRepository(PersonalBlogContext context)
        {
            _context = context;
        }

        #endregion Construtores

        #region Method
        public void AddTheme(NewThemeDTO newTheme)
        {
            _context.Themes.Add(new ThemeModel
            {
                Description = newTheme.Description

            });

            _context.SaveChanges();
        }

        public void AttTheme(UpdateThemeDTO newTheme)
        {
            var existingTheme = GetThemeById(newTheme.Id);
            existingTheme.Description = newTheme.Description;
            _context.Themes.Update(existingTheme);
            _context.SaveChanges();
}
