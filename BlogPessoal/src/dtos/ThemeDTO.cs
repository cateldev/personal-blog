using System.ComponentModel.DataAnnotations;

namespace BlogPessoal.src.dtos
{
    ///<summary>
    ///<for>Briefing: Mirror Class to create a new theme</for>
    ///<for> Created by: Matheus Catel</for>
    ///<for>Version: 1.0</for>
    ///<for>Date: 29/04/2022</for>
    ///</summary>
    
    public class NewThemeDTO
    {
        [Required, StringLength(20)]
        public string Description { get; set; }

        public NewThemeDTO(string description, int id)
        {
            Description = description;
        }
    }

    ///<summary>
    ///<for>Briefing: Mirror Class to update a new theme</for>
    ///<for> Created by: Matheus Catel</for>
    ///<for>Version: 1.0</for>
    ///<for>Date: 29/04/2022</for>
    ///</summary>

    public class UpdateThemeDTO
    {
        [Required]
        public int Id { get; set; }

        [Required, StringLength(20)]
        public string Description { get; set; }
        
        public UpdateThemeDTO(string description, int id)
        {
            Description = description;
            Id = id;
        }
    }

}