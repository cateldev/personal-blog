using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using BlogPessoal.src.dtos;
using BlogPessoal.src.models;
using BlogPessoal.src.repositories;
using BlogPessoal.src.services;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace BlogPessoal.src.servicos.implementations
{
    public class AuthenticationServices : IAuthentication
    {
        #region Attributes

        private readonly IUser _repository;
        public IConfiguration Configuration { get; }

        #endregion Attributes

        #region Constructors
    public AuthenticationServices(IUser repository, IConfiguration configuration) 
        {
            _repository = repository;
            Configuration = configuration;  
        }

        #endregion Constructors

        #region Methods

        public string EncodePassword(string password)
        {
            var bytes = Encoding.UTF8.GetBytes(password);
            return Convert.ToBase64String(bytes);
        }

        public async Task CreateUserNoDuplicateAsync(NewUserDTO dto)
        {
            var user = await _repository.GetUserByEmailAsync(dto.Email);
            if (user != null) throw new Exception("Este email já está sendo utilizado");
            dto.Password = EncodePassword(dto.Password);
            await _repository.NewUserAsync(dto);
        }

        public string CreateToken(UserModel user)
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

        public async Task<AuthorizationDTO> GetAuthorizationAsync(AuthenticateDTO dto)
        {
            var user = await _repository.GetUserByEmailAsync(dto.Email);
            if (user == null) throw new Exception("Usuário não encontrado");
            if (user.Password != EncodePassword(dto.Password)) throw new Exception("Senha incorreta");
            return new AuthorizationDTO(user.Id, user.Email, user.Type,
            CreateToken(user));

        }
    #endregion Methods
  }

}