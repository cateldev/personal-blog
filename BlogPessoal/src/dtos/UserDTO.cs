using System.ComponentModel.DataAnnotations;
using BlogPessoal.src.utilities;

namespace BlogPessoal.src.dtos
{

///<summary>
///<for>Briefing: Mirror Class to create a new user</for>
///<for> Created by: Matheus Catel</for>
///<for>Version: 1.0</for>
///<for>Date: 29/04/2022</for>
///</summary>
    public class NewUserDTO
    {

        [Required, StringLength(50)]
        public string Name { get; set; }

        [Required, StringLength(30)]
        public string Email { get; set; }

        [Required, StringLength(30)]
        public string Password { get; set; }

        public string Photo { get; set; }

        [Required]
        public UserType Type { get; set; }


        public NewUserDTO(string name, string email, string password, string photo, UserType type)
        {
            Name = name;
            Email = email;
            Password = password;
            Photo = photo;
            Type = type;
        }
    }

    ///<summary>
    ///<for>Briefing: Mirror Class to update user</for>
    ///<for> Created by: Matheus Catel</for>
    ///<for>Version: 1.0</for>
    ///<for>Date: 29/04/2022</for>
    ///</summary>

    public class UpdateUserDTO
    {
        [Required]
         public int Id { get; set; }
         
        [Required, StringLength(50)]
        public string Name { get; set; }

        [Required, StringLength(30)]

        public string Password { get; set; }

        public string Photo { get; set; }

         public UpdateUserDTO(int id, string name, string password, string photo)
        {
            Id = id;
            Name = name;
            Password = password;
            Photo = photo;
        }
    }
}