using System.ComponentModel.DataAnnotations;

namespace BlogPessoal.src.dtos
{
    public class NewUserDTO
    {
        [Required, StringLength(50)]
        public string Name { get; set; }

        [Required, StringLength(30)]
        public string Email { get; set; }

        [Required, StringLength(30)]
        public string Password { get; set; }

        public string Photo { get; set; }

        public NewUserDTO(string name, string email, string password, string photo)
        {
            Name = name;
            Email = email;
            Password = password;
            Photo = photo;
        }
    }

    public class UpdateUserDTO
    {
    }
}