using System.Linq;
using System.Threading.Tasks;
using BlogPessoal.src.data;
using BlogPessoal.src.dtos;
using BlogPessoal.src.repositories;
using BlogPessoal.src.repositories.implementation;
using BlogPessoal.src.utilities;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BlogPessoalTest.Testes.repositories
{
    [TestClass]
    public class UserRepositoryTest
    {
        private BlogPessoalContext _context;
        private IUser _repository;

        [TestMethod]
        public async Task CreateFourUsersInDataBaseReturnFourUser()
        {
            // Defining context
            var opt= new DbContextOptionsBuilder<BlogPessoalContext>()
                .UseInMemoryDatabase(databaseName: "db_blogPessoal1")
                .Options;

            _context = new BlogPessoalContext(opt);
            _repositorio = new UserRepository(_context);

            //GIVEN - Register 4 users in database
            await _repository.NewUserAsync(
                new NewUserDTO("Matheus Catel","catel@email.com","134652","URLFOTO", UserType.NORMAL)
            );
            
            await _repository.NewUserAsync(
                new NewUserDTO("Isabela Catel","isa@email.com","134652","URLFOTO", UserType.NORMAL)
            );
            
            await _repository.NewUserAsync(
                new NewUserDTO("Gustavo Catel","gustavo@email.com","134652","URLFOTO", UserType.NORMAL)
            );
 
            await _repository.NewUserAsync(
                new NewUserDTO("Alex Catel","alex@email.com","134652","URLFOTO", UserType.NORMAL)
            );
            
			//WHEN - Search total list            
            //THEN - Receive 4 users
            Assert.AreEqual(4, _context.Users.Count());
        }
        
        [TestMethod]
        public async Task GetrUserByEmailReturnNotNull()
        {
            // Defining context
            var opt= new DbContextOptionsBuilder<BlogPessoalContext>()
                .UseInMemoryDatabase(databaseName: "db_blogPessoal2")
                .Options;

            _context = new BlogPessoalContext(opt);
            _repository = new UserRepository(_context);

            //GIVEN - Register a new user in database
            await _repository.NewUserAsync(
                new NewUserDTO("Luana Catel","luana@email.com","134652","URLFOTO", UserType.NORMAL)
            );
            
            //WHEN - Quando pesquiso pelo email deste usuario
            var user = await _repository.GetUserByEmailAsync("luana@email.com");
			
            //THEN - Obtain a user
            Assert.IsNotNull(user);
        }

        [TestMethod]
        public async Task GetUserByIdReturnNotNullandUserName()
        {
            // Defining context
            var opt= new DbContextOptionsBuilder<BlogPessoalContext>()
                .UseInMemoryDatabase(databaseName: "db_blogPessoal3")
                .Options;

            _context = new BlogPessoalContext(opt);
            _repository = new UserRepository(_context);

            //GIVEN - Register a new user in database
            await _repository.NewUserAsync(
                new NewUserDTO("Andrea Catel","andrea@email.com","134652","URLFOTO", UserType.NORMAL)
            );
            
			//WHEN - When search by id 1
            var user = await _repository.GetUserByIdAsync(1);

            //THEN - Should return an element not null
            Assert.IsNotNull(user);
            //THEN - Should return Andrea Catel
            Assert.AreEqual("Andrea Catel", usuario.Nome);
        }

        [TestMethod]
        public async Task UpdateUserReturnUserUpdated()
        {
            // Defining context
            var opt= new DbContextOptionsBuilder<BlogPessoalContext>()
                .UseInMemoryDatabase(databaseName: "db_blogPessoal4")
                .Options;

            _context = new BlogPessoalContext(opt);
            _repository = new UserRepository(_context);

            //GIVEN - Register a new user in database
            await _repository.NewUserAsync(
                new NewUserDTO("Ignez Catel","ignez@email.com","134652","URLFOTO", UserType.NORMAL)
            );
            
            //WHEN - Update User
            await _repository.UpdateUserAsync(
                new UpdateUserDTO(1,"Ignez Catel","123456","URLFOTONOVA")
            );
            
            //THEN - when validate the search should return the name Ignez Catel
            var old = await _repository.GetUserByEmailAsync("ignez@email.com");

            Assert.AreEqual(
                "Ignez Catel",
                _context.User.FirstOrDefault(u => u.Id == old.Id).Name
            );
            
            //THEN - when validate the search should return password 123456
            Assert.AreEqual(
                "123456",
                _context.Users.FirstOrDefault(u => u.Id == old.Id).Password
            );
        }

    }
}