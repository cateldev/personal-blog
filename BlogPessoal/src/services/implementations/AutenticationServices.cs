using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using BlogPessoal.src.DTOS;
using BlogPessoal.src.models;
using BlogPessoal.src.repositories;
using BlogPessoal.src.services;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace BlogPessoal.src.servicos.implementations
{
    public class AutenticationServices : IAutentication
    {
        #region Attributes
        private readonly IUser _repository;
    public AutenticationServices(IConfiguration configuration) 
        {
          this.Configuration = configuration;
            
        }
                public IConfiguration Configuration { get; }
        #endregion Attributes

        #region Constructors
        public AutenticationServices(IUser repository, IConfiguration
        configuration)
        {
            _repository = repository;
            Configuration = configuration;
        }
        #endregion Constructors

        #region Methods
        public string CodifyPassword(string password)
        {
            var bytes = Encoding.UTF8.GetBytes(password);
            return Convert.ToBase64String(bytes);
        }

        public void CreateUserNoDuplicate(NewUserDTO dto)
        {
            var user = _repository.GetUserByEmail(dto.Email);
            if (user != null) throw new Exception("Este email já está sendo utilizado");
            dto.Password = CodifyPassword(dto.Password);
            _repository.NewUser(dto);
        }

        public string GetToken(UserModel user)
        {
            var tokenManipulator = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(Configuration["Settings:Secret"]);
            var tokenDescription = new SecurityTokenDescriptor
            {

                Subject = new ClaimsIdentity
                ( 
                new Claim[]
                {   
                    new Claim(ClaimTypes.Email, user.Email.ToString()),
                    new Claim(ClaimTypes.Role, user.Type.ToString())
                }),

                Expires = DateTime.UtcNow.AddHours(2),
                SigningCredentials = new SigningCredentials
                (
                new SymmetricSecurityKey(key),
                SecurityAlgorithms.HmacSha256Signature
                )
            };

            var token = tokenManipulator.CreateToken(tokenDescription);
            return tokenManipulator.WriteToken(token);
        }

        public AutorizationDTO GetAutorization(AutenticateDTO autentication)
        {
            var user = _repository.GetUserByEmail(autentication.Email);
            if (user == null) throw new Exception("Usuário não encontrado");
            if (user.Password != CodifyPassword(autentication.Password)) throw new
            Exception("Senha incorreta");
            return new AutorizationDTO(user.Id, user.Email, user.Type,
            GetToken(user));

        }
        #endregion Methods
  }

}