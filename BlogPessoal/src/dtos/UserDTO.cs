using System.ComponentModel.DataAnnotations;

namespace BlogPessoal.src.DTOS
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

/// <summary>
/// <para>Resumo: Classe espelho para atualizar um usuario</para>
/// <para>Criado por: Kauane Farias</para>
/// <para>Versão 1.0</para>
/// <para>Data: 29/04/2022</para>
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
            Name = name;
            Password = password;
            Photo = photo;
            Id = id;
        }
    }
}