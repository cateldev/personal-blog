using System.ComponentModel.DataAnnotations;
using BlogPessoal.src.utilities;

namespace BlogPessoal.src.DTOS
{
    public class AutenticateDTO
    {
        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        public AutenticateDTO(string email, string password)
        {
            Email = email;
            Password = password;
        }   

    }
        public class AutorizationDTO
        {
            public int Id { get; set; }
            public string Email { get; set; }
            public UserType Type { get; set; }
            public string Token { get; set; }
            public AutorizationDTO(int id, string email, UserType type, string token)
            {
                Id = id;
                Email = email;
                Type = type;
                Token = token;
            }
        }
    }