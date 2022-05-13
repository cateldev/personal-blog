using BlogPessoal.src.dtos;
using BlogPessoal.src.models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlogPessoal.src.repositories
{
    /// <summary>
    /// <para>Resumo: Responsavel por representar ações de CRUD de postagem</para>
    /// <para>Criado por: Matheus Catel</para>
    /// <para>Versão 1.0</para>
    /// <para>Data: 29/04/2022</para>
    /// </summary>
    public interface IPost
    {
        Task<List<PostsModel>> GetAllPostsAsync();
        Task<PostsModel> GetPostByIdAsync(int id);
        Task<List<PostsModel>> GetPostBySearchAsync(string title, string descriptionTheme, string creator);
        Task NewPostAsync(NewPostDTO post);
        Task UpdatePostAsync(UpdatePostDTO post);
        Task DeletePostAsync(int id);
    }

}