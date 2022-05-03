using Microsoft.EntityFrameworkCore;
using BlogPessoal.src.data;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BlogPessoal.src.models;
using System.Linq;

namespace BlogPessoalTeste.Testes.data
{
    [TestClass]
    public class BlogPessoalContextTest
    {
        private BlogPessoalContext _context;

        [TestInitialize]
        public void inicio()
        {
            var opt = new DbContextOptionsBuilder<BlogPessoalContext>().UseInMemoryDatabase(databaseName: "db_blogPessoal").Options;

            _context = new BlogPessoalContext(opt);
        }

        [TestMethod]
        public void InsertNewUserInDataBaseReturnsUser()
        {
            UserModel user = new UserModel();

            user.Name = "Karol Conká";
            user.Email = "conka@email.com";
            user.Password = "12345";
            user.Photo = "PhotoLinkHere";

            _context.Users.Add(user);

            _context.SaveChanges();

            Assert.IsNotNull(_context.Users.FirstOrDefault
            (u => u.Email == "conka@email.com"));
        }
    }
}
