using System.Collections.Generic;
using System.Linq;
using BlogPessoal.src.models;
using BlogPessoal.src.data;
using BlogPessoal.src.DTOS;
using Microsoft.EntityFrameworkCore;

namespace BlogPessoal.src.repositories.implementations
{
    public class PostRepository : IPost
    {
        #region Attribute
        private readonly BlogPessoalContext _context;
        #endregion Attributes

        #region Constructors
        public PostRepository(BlogPessoalContext context)
        {
            _context = context;
        }
        #endregion Constructors

        #region Methods
        public void NewPost(NewPostDTO post)
        {
            _context.Posts.Add(new PostsModel
            {
                Title = post.Title,
                Description = post.Description,
                Photo = post.Photo,
            });
            _context.SaveChanges();
        }

        public void UpdatePost(UpdatePostDTO post)
        {
            PostsModel model = GetPostById(post.Id);
            model.Title = post.Title;
            model.Description = post.Description;
            model.Photo = post.Photo;
            _context.Update(model);
            _context.SaveChanges();
        }

        public void DeletePost(int id)
        {
            _context.Posts.Remove(GetPostById(id));
            _context.SaveChanges();
        }

        public List<PostsModel> GetAllPosts()
        {
            return _context.Posts.ToList();
        }

        public PostsModel GetPostById(int id)
        {
            return _context.Posts.FirstOrDefault(p => p.Id == id);
        }

        public List<PostsModel> GetPostBySearch(string title, string description, string creator)
        {
            switch (title, description, creator)
            {
                case (null, null, null):
                    return GetAllPosts();

                case (null, null, _):
                    return _context.Posts
                        .Include(p => p.Theme)
                        .Include(p => p.Creator)
                        .Where(p => p.Creator.Name.Contains(creator))
                        .ToList();

                case (null, _, null):
                    return _context.Posts
                        .Include(p => p.Theme)
                        .Include(p => p.Creator)
                        .Where(p => p.Theme.Description.Contains(description))
                        .ToList();

                case (_, null, null):
                    return _context.Posts
                        .Include(p => p.Theme)
                        .Include(p => p.Creator)
                        .Where(p => p.Title.Contains(title))
                        .ToList();

                case (_, _, null):
                    return _context.Posts
                        .Include(p => p.Theme)
                        .Include(p => p.Creator)
                        .Where(p => p.Title.Contains(title) & p.Theme.Description.Contains(description))
                        .ToList();

                case (null, _, _):
                    return _context.Posts
                        .Include(p => p.Theme)
                        .Include(p => p.Creator)
                        .Where(p => p.Theme.Description.Contains(description) & p.Creator.Name.Contains(creator))
                        .ToList();

                case (_, null, _):
                    return _context.Posts
                        .Include(p => p.Theme)
                        .Include(p => p.Creator)
                        .Where(p => p.Title.Contains(title) & p.Creator.Name.Contains(creator))
                        .ToList();

                case (_, _, _):
                    return _context.Posts
                        .Include(p => p.Theme)
                        .Include(p => p.Creator)
                        .Where(p => p.Title.Contains(title) | 
                            p.Theme.Description.Contains(description) |
                            p.Creator.Name.Contains(creator))
                        .ToList();
            }
        }       
        #endregion Methods
    }
}