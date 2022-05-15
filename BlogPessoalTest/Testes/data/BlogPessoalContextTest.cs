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
        public void start()
        {
            var opt = new DbContextOptionsBuilder<BlogPessoalContext>().UseInMemoryDatabase(databaseName: "db_blogPessoal").Options;

            _context = new BlogPessoalContext(opt);
        }

        [TestMethod]
        public void InsertNewUserInDataBaseReturnUser()
        {
            UserModel user = new UserModel();

            user.Name = "Karol Conká";
            user.Email = "conka@email.com";
            user.Password = "12345";
            user.Photo = "PhotoLinkHere";

            _context.Users.Add(user); //Added user

            _context.SaveChanges(); //Commits creation

            Assert.IsNotNull(_context.Users.FirstOrDefault
            (u => u.Email == "conka@email.com"));
        }
    }
}
