using System.Linq;
using System.Threading.Tasks;
using PersonalBlog.src.data;
using PersonalBlog.src.dtos;
using PersonalBlog.src.repositories;
using PersonalBlog.src.repositories.implementations;
using PersonalBlog.src.utils;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BlogPessoalTest.Testes.repositories
{

    [TestClass]
    public class PostRepositoryTest
    {
        private BlogPessoalContext _context;
        private IUser _userRepo;
        private ITheme _themeRepo;
        private IPost _postRepo;

        [TestMethod]
        public async Task CreateThreePostsReturnsCountComparison()
        {

            var opt = new DbContextOptionsBuilder<BlogPessoalContext>()
            .UseInMemoryDatabase(databaseName: "db_blogPessoal1")
            .Options;
            _context = new BlogPessoalContext(opt);
            _userRepo = new UserRepository(_context);
            _themeRepo = new ThemeRepository(_context);
            _postRepo = new PostRepository(_context);

            await _userRepo.CreateUserAsync(
            new NewUserDTO("testname", "testemail@email.com", "testpassword", "pictureUrl", UserType.NORMAL));

            await _userRepo.CreateUserAsync(
            new NewUserDTO("testname", "testemail@email.com", "testpassword", "pictureUrl", UserType.NORMAL));

            await _themeRepo.NewThemeAsync(new NewThemeDTO("C#"));
            await _themeRepo.NewThemeAsync(new NewThemeDTO("Java"));

            await _postRepo.NewPostAsync(
            new NewPostDTO(
            "TestTitle",
            "TestDescription",
            "PhotoURL",
            "teste@email.com",
            "TestThemeDescription"
            )
            );
            
            await _postRepo.NewPostAsync(
            new NewPostDTO(
            "TestTitle",
            "TestDescription",
            "PhotoURL",
            "teste@email.com",
            "TestThemeDescription"
            )
            );

            await _postRepo.NewPostAsync(
            new NewPostDTO(
            "TestTitle",
            "TestDescription",
            "PhotoURL",
            "teste@email.com",
            "TestThemeDescription"
            )
            );

            var postagens = await _postRepo.GetAllPostsAsync();

            Assert.AreEqual(3, postagens.Count());
        }

        [TestMethod]
        public async Task UpdatePostReturnsPostUpdated()
        {

            var opt = new DbContextOptionsBuilder<BlogPessoalContextt>()
            .UseInMemoryDatabase(databaseName: "db_blogPessoal2")
            .Options;
            _context = new BlogPessoalContext(opt);
            _userRepo = new UserRepository(_context);
            _themeRepo = new ThemeRepository(_context);
            _postRepo = new PostRepository(_context);

            await _userRepo.CreateUserAsync(
            new NewUserDTO("testname", "testemail@email.com", "testpassword", "pictureUrl", UserType.NORMAL));

            await _themeRepo.NewThemeAsync(new NewThemeDTO("COBOL"));
            await _themeRepo.NewThemeAsync(new NewThemeDTO("C#"));

            await _postRepo.NewPostAsync(
            new NewPostDTO(
            "TestTitle",
            "TestDescription",
            "PhotoURL",
            "teste@email.com",
            "TestThemeDescription"
            )
            );

            await _postRepo.UpdatePostAsync(
            new UpdatePostDTO(
            "TestTitle",
            "TestDescription",
            "PhotoURL",
            "TestThemeDescription"
            )
            );
            var postagem = await _postRepo.GetPostByIdAsync(1);

            Assert.AreEqual("TestTitle", postagem.Title);
            Assert.AreEqual("TestDescription",
            postagem.Description);
            Assert.AreEqual("PhotoURLUpdated", postagem.Photo);
            Assert.AreEqual("TestThemeDescription", postagem.Theme.Description);
        }

        [TestMethod]
        public async Task GetPostsBySearchReturnsCountComparison()
        {

            var opt = new DbContextOptionsBuilder<BlogPessoalContext>()
            .UseInMemoryDatabase(databaseName: "db_blogPessoal3")
            .Options;
            _context = new BlogPessoalContext(opt);
            _userRepo = new UserRepository(_context);
            _themeRepo = new ThemeRepository(_context);
            _postRepo = new PostRepository(_context);

            await _userRepo.CreateUserAsync(
            new NewUserDTO("testname", "testemail@email.com", "testpassword", "pictureUrl", UserType.NORMAL));

            await _userRepo.CreateUserAsync(
            new NewUserDTO("testname2", "testemail@email.com2", "testpassword2", "pictureUrl2", UserType.ADMIN));

            await _themeRepo.NewThemeAsync(new NewThemeDTO("C#"));
            await _themeRepo.NewThemeAsync(new NewThemeDTO("Java"));

            await _postRepo.NewPostAsync(
            new NewPostDTO(
            "TestTitle",
            "TestDescription",
            "PhotoURL",
            "teste@email.com",
            "TestThemeDescription"
            )
            );
            await _postRepo.NewPostAsync(
            new NewPostDTO(
            "TestTitle",
            "TestDescription",
            "PhotoURL",
            "teste@email.com",
            "TestThemeDescription"
            )
            );
            await _postRepo.NewPostAsync(
            new NewPostDTO(
            "TestTitle",
            "TestDescription",
            "PhotoURL",
            "teste@email.com",
            "TestThemeDescription"
            )
            );

            var postsTests1 = await
            _postRepo.GetPostBySearchAsync("TestTitle", null, null);
            var postsTests2 = await
            _postRepo.GetPostBySearchAsync(null, "TestDescription", null);
            var postsTests3 = await
            _postRepo.GetPostBySearchAsync(null, null, "testname");

            Assert.AreEqual(2, postsTests1.Count);
            Assert.AreEqual(2, postsTests2.Count);
            Assert.AreEqual(2, postsTests3.Count);
        }
    }
}