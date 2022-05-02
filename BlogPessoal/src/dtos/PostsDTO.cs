using System.ComponentModel.DataAnnotations;

namespace BlogPessoal.src.dtos
{
    /// <summary>
    /// <para>Resumo: Classe espelho para criar uma nova postagem</para>
    /// <para>Criado por: Kauane Farias</para>
    /// <para>Versão 1.0</para>
    /// <para>Data: 29/04/2022</para>
    /// </summary>
    public class NewPostDTO
    {
        [Required, StringLength(30)]
        public string Title { get; set; }

        [Required, StringLength(100)]
        public string Description { get; set; }

        public string Photo { get; set; }

        [Required, StringLength(30)]
        public string EmailCreate { get; set; }

        [Required]
        public string DescriptionTheme { get; set; }

        public NewPostDTO(string title, string description, string photo, string emailCreate, string descriptionTheme)
        {
            Title = title;
            Description = description;
            Photo = photo;
            EmailCreate = emailCreate;
            DescriptionTheme = descriptionTheme;
        }

    }
    /// <summary>
    /// <para>Resumo: Classe espelho para atualizar uma postagem</para>
    /// <para>Criado por: Kauane Farias</para>
    /// <para>Versão 1.0</para>
    /// <para>Data: 29/04/2022</para>
    /// </summary>
    public class UpdatePostDTO
    {
        [Required, StringLength(30)]
        public string Title { get; set; }

        [Required, StringLength(100)]
        public string Description { get; set; }

        public string Photo { get; set; }

        [Required]
        public string descriptionTheme { get; set; }

        public UpdatePostDTO(string title, string description, string photo, string DescriptionTheme)
        {
            Title = title;
            Description = description;
            Photo = photo;
            DescriptionTheme = descriptionTheme;
        }
    }

}