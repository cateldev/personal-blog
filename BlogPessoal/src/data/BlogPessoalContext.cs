using BlogPessoal.src.models;
using Microsoft.EntityFrameworkCore;

namespace BlogPessoal.src.data
{
    /// <summary>
    /// <para>Resume: Class responsible for data base Blog context</para>
    /// <para>Created by: Matheus Catel</para>
    /// <para>Version: 1.0</para>
    /// <para>Date: 2022-05-12</para>
    /// </summary>

    public class BlogPessoalContext : DbContext
    {
        public DbSet<UserModel> Users { get; set; }
        public DbSet<ThemeModel> Themes { get; set; }
        public DbSet<PostsModel> Posts { get; set; }

        public BlogPessoalContext(DbContextOptions<BlogPessoalContext>opt) : base(opt)
        {
        }
    }
}