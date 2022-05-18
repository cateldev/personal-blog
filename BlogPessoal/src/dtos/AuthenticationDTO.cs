using System.ComponentModel.DataAnnotations;
using BlogPessoal.src.utilities;

namespace BlogPessoal.src.dtos
{

    /// <summary>
    /// <para>Resume: Mirror class responsible for transporting login information</para>
    /// <para>Created by: Matheus Catel</para>
    /// <para>Version: 1.0</para>
    /// <para>Date: 2022-05-13</para>
    /// </summary>

    public class AuthenticateDTO
    {
        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        public AuthenticateDTO(string email, string password)
        {
            Email = email;
            Password = password;
        }   

    }

    /// <summary>
    /// <para>Resume: Mirror class responsible for transporting the Authorization data</para>
    /// <para>Created by: Matheus Catel</para>
    /// <para>Version: 1.0</para>
    /// <para>Date: 2022-05-13</para>
    /// </summary>

        public class AuthorizationDTO
        {
            public int Id { get; set; }
            public string Email { get; set; }
            public UserType Type { get; set; }
            public string Token { get; set; }
            public AuthorizationDTO(int id, string email, UserType type, string token)
            {
                Id = id;
                Email = email;
                Type = type;
                Token = token;
            }
        }
    }