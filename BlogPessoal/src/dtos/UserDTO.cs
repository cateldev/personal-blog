using System.ComponentModel.DataAnnotations;
using BlogPessoal.src.utilities;

namespace BlogPessoal.src.dtos
{

    /// <summary>
    /// <para>Resume: Mirror class responsible for registering a new user</para>
    /// <para>Created by: Matheus Catel</para>
    /// <para>Version: 1.0</para>
    /// <para>Date: 2022-04-29</para>
    /// </summary>
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

    /// <summary>
    /// <para>Resume: Mirror class responsible for transporting a user to update</para>
    /// <para>Created by: Matheus Catel</para>
    /// <para>Version: 1.0</para>
    /// <para>Date: 2022-04-29</para>
    /// </summary>

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