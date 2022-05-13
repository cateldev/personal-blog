using System.ComponentModel.DataAnnotations;

namespace BlogPessoal.src.dtos
{

    ///<summary>
    ///<for>Briefing: Mirror Class to create a new post</for>
    ///<for> Created by: Matheus Catel</for>
    ///<for>Version: 1.0</for>
    ///<for>Date: 29/04/2022</for>
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
    ///<for>Briefing: Mirror Class to update a new post</for>
    ///<for> Created by: Matheus Catel</for>
    ///<for>Version: 1.0</for>
    ///<for>Date: 29/04/2022</for>
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