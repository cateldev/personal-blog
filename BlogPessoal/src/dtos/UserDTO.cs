using System.ComponentModel.DataAnnotations;

namespace BlogPessoal.src.dtos
{

///<summary>
///<para>Resumo: Classe espelho para criar um novo usuário</para>
///<para> Criado por: Gustavo Boaz</para>
///<para>Versão: 1.0</para>
///<para>Data: 29/04/2022</para>
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
        [Required, StringLength(50)]
        public string Name { get; set; }

        [Required, StringLength(30)]

        public string Password { get; set; }

        public string Photo { get; set; }

         public UpdateUserDTO(string name, string password, string photo)
        {
            Name = name;
            Password = password;
            Photo = photo;
        }
    }
}