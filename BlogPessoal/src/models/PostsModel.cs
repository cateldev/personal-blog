using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlogPessoal.src.models
{
    /// <summary>
    /// <para>Resume: Class responsible for representing a posts in the database.</para>
    /// <para>Created by: Matheus Catel</para>
    /// <para>Version: 1.0</para>
    /// <para>Date: 2022-04-29</para>
    /// </summary>

    [Table("tb_posts")]
    public class PostsModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required, StringLength(50)]
        public string Title { get; set; }

        [Required, StringLength(50)]
        public string Description { get; set; }

        public string Photo { get; set; }

        [ForeignKey("fk_user"), InverseProperty("MinhasPostagens")]
        public UserModel Creator { get; set; }

        [ForeignKey("fk_theme"), InverseProperty("PostagensRelacionadas")]
        public ThemeModel Theme { get; set; }

    }
}