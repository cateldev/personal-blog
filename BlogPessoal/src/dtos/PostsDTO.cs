using System.ComponentModel.DataAnnotations;

namespace BlogPessoal.src.dtos
{

    ///<summary>
    ///<para>Briefing: Mirror Class to create a new post</para>
    ///<para> Created by: Matheus Catel</para>
    ///<para>Version: 1.0</para>
    ///<para>Date: 2022-04-29</para>
    ///</summary>

    public class NewPostDTO
    {
        public NewPostDTO(string title, string description, string photo, string creatorEmail, string themeDescription)
        {
            Title = title;
            Description = description;
            Photo = photo;
            CreatorEmail = creatorEmail;
            ThemeDescription = themeDescription;
        }

        [Required, StringLength(30)]
        public string Title { get; set; }

        [Required, StringLength(100)]
        public string Description { get; set; }

        public string Photo { get; set; }

        [Required, StringLength(30)]
        public string CreatorEmail { get; set; }

        [Required]
        public string ThemeDescription { get; set; }

    }

    ///<summary>
    ///<para>Briefing: Mirror Class to update a new post</para>
    ///<para> Created by: Matheus Catel</para>
    ///<para>Version: 1.0</para>
    ///<para>Date: 2022-04-29</para>
    ///</summary>
    
    public class UpdatePostDTO
    {
        public UpdatePostDTO(string title, string description, string photo, string themeDescription)
        {
            Title = title;
            Description = description;
            Photo = photo;
            ThemeDescription = themeDescription;
        }

        [Required]
        public int Id { get; set; }

        [Required, StringLength(30)]
        public string Title { get; set; }

        [Required, StringLength(100)]
        public string Description { get; set; }

        public string Photo { get; set; }

        [Required]
        public string ThemeDescription { get; set; }
    }

}