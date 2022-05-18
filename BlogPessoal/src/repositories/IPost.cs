using BlogPessoal.src.dtos;
using BlogPessoal.src.models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlogPessoal.src.repositories
{
    /// <summary>
    /// <para>Resume: Interface responsible for representing CRUD actions posts.</para>
    /// <para>Created by: Matheus Catel</para>
    /// <para>Version: 1.0</para>
    /// <para>Date: 2022-04-29</para>
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