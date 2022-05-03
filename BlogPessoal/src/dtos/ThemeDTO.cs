using System.ComponentModel.DataAnnotations;

namespace BlogPessoal.src.DTOS
{
    /// <summary>
    /// <para>Resumo: Classe espelho para criar um novo tema</para>
    /// <para>Criado por: Kauane Farias</para>
    /// <para>Versão 1.0</para>
    /// <para>Data: 29/04/2022</para>
    /// </summary>
    public class NewThemeDTO
    {
        [Required, StringLength(20)]
        public string Description { get; set; }
        public NewThemeDTO(string description)
        {
            Description = description;
        }
    }

    /// <summary>
    /// <para>Resumo: Classe espelho para alterar um tema</para>
    /// <para>Criado por: Kauane Farias</para>
    /// <para>Versão 1.0</para>
    /// <para>Data: 29/04/2022</para>
    /// </summary>
    public class UpdateThemeDTO
    {
        [Required, StringLength(20)]
        public string Description { get; set; }
        public UpdateThemeDTO(string description)
        {
            Description = description;
        }
    }

}