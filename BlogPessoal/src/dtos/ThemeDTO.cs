using System.ComponentModel.DataAnnotations;

namespace BlogPessoal.src.dtos
{
    /// <summary>
    /// <para>Resume: Mirror class responsible for registering a new theme</para>
    /// <para>Created by: Matheus Catel</para>
    /// <para>Version: 1.0</para>
    /// <para>Date: 2022-04-29</para>
    /// </summary>
    
    public class NewThemeDTO
    {
        [Required, StringLength(20)]
        public string Description { get; set; }

        public NewThemeDTO(string description, int id)
        {
            Description = description;
        }
    }

    /// <summary>
    /// <para>Resume: Mirror class responsible for transporting a theme to update</para>
    /// <para>Created by: Matheus Catel</para>
    /// <para>Version: 1.0</para>
    /// <para>Date: 2022-04-29</para>
    /// </summary>

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