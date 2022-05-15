using System.Linq;
using System.Threading.Tasks;
using BlogPessoal.src.data;
using BlogPessoal.src.dtos;
using BlogPessoal.src.repositories;
using BlogPessoal.src.repositories.implementation;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BlogPessoalTeste.Testes.repositories
{
    [TestClass]
    public class ThemeRepositoryTest
    {
        private BlogPessoalContext _context;
        private ITheme _repository;
     
        [TestMethod]
        public async Task CreateFourThemesInDataBaseReturnFourThemes2Async()
        {
            // Defining context
            var opt = new DbContextOptionsBuilder<BlogPessoalContext>()
                .UseInMemoryDatabase(databaseName: "db_blogPessoal1")
                .Options;

            _context = new BlogPessoalContext(opt);
            _repository = new ThemeRepository(_context);

            // GIVEN - register 4 themes in database
            await _repository.NewThemeAsync(new NewThemeDTO("C#"));
            await _repository.NewThemeAsync(new NewThemeDTO("Java"));
            await _repository.NewThemeAsync(new NewThemeDTO("Python"));
            await _repository.NewThemeAsync(new NewThemeDTO("JavaScript"));

            var themes = await _repository.GetAllThemesAsync();

            // THEN - Should return 4 themes
            Assert.AreEqual(4, temas.Count);
        }
        [TestMethod]
        public async Task GetThemeByIdReturnTheme1Async()
        {
            // Defining context
            var opt = new DbContextOptionsBuilder<BlogPessoalContext>()
                .UseInMemoryDatabase(databaseName: "db_blogPessoal2")
                .Options;

            _context = new BlogPessoalContext(opt);
            _repository = new TemaRepository(_context);

            //GIVEN - Register C# in Database
            await _repository.NewThemeAsync(new NewThemeDTO("C#"));

            //WHEN - When search by id 1
            var theme = await _repository.GetThemeByIdAsync(1);

            //THEN - Should return 1 theme
            Assert.AreEqual("C#", theme.Description);
        }

        [TestMethod]
        public async Task GetThemeByDescriptionReturnTwoThemesAsync()
        {
            // Defining context
            var opt = new DbContextOptionsBuilder<BlogPessoalContext>()
                .UseInMemoryDatabase(databaseName: "db_blogPessoal3")
                .Options;

            _context = new BlogPessoalContext(opt);
            _repository = new ThemeRepository(_context);

            //GIVEN - Register Java in Database
            await _repository.NewThemeAsync(new NewThemeDTO("Java"));

            //AND - Register JavaScript in Database
            await _repository.NewThemeAsync(new NewThemeDTO("JavaScript"));

            //WHEN - When search bu description Java
            var themes = await _repository.GetThemeByDescriptionAsync("Java");

            //THEN - Should return 2 themes
            Assert.AreEqual(2, temas.Count);
        }
        [TestMethod]
        public async Task AlternateThemePythonRetornThemeCobolAsync()
        {
            // Defining context
            var opt = new DbContextOptionsBuilder<BlogPessoalContext>()
                .UseInMemoryDatabase(databaseName: "db_blogPessoal4")
                .Options;

            _context = new BlogPessoalContext(opt);
            _repository = new ThemeRepository(_context);

            //GIVEN - Register Python in Database
            await _repository.NewThemeAsync(new NewThemeDTO("Python"));

            //WHEN - When pass Id 1 and theme COBOL
            await _repository.UpdateThemeAsync(new UpdateThemeDTO(1, "COBOL"));

            var theme = await _repository.GetThemeByIdAsync(1);

            //THEN - Should return theme COBOL
            Assert.AreEqual("COBOL", theme.Description);
        }
        [TestMethod]
        public async Task DeleteThemesReturnNullAsync()
        {
            // Defining context
            var opt = new DbContextOptionsBuilder<BlogPessoalContext>()
                .UseInMemoryDatabase(databaseName: "db_blogPessoal5")
                .Options;

            _context = new BlogPessoalContext(opt);
            _repository = new ThemeRepository(_context);

            //GIVEN - Register 1 theme in Database
            await _repository.NewThemeAsync(new NewThemeDTO("C#"));

            //WHEN - When pass the Id 1
            await _repository.DeleteThemeAsync(1);

            //THEN - Should return null
            Assert.IsNull(await _repository.GetThemeByIdAsync(1));
        }
    }
}