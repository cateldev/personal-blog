using BlogPessoal.src.dtos;
using BlogPessoal.src.models;
using System.Collections.Generic;

namespace BlogPessoal.src.repositorios
{
    /// <summary>
    /// <para>Resumo: Responsavel por representar ações de CRUD de postagem</para>
    /// <para>Criado por: Matheus Catel</para>
    /// <para>Versão 1.0</para>
    /// <para>Data: 29/04/2022</para>
    /// </summary>
    public interface IPost
    {
        void NewPost(NewPostDTO post);
        void UpdatePost(UpdatePostDTO post);
        void DeletePost(int id);
        PostsModel TakePostById(int id);
        List<PostsModel> TakeAllPosts();
        
        List<PostsModel> TakePostBySearch(string title, string desciptionTheme, string nameCreator);
    }
}