using System.Collections.Generic;
using System.Linq;
using BlogPessoal.src.models;
using BlogPessoal.src.data;
using BlogPessoal.src.dtos;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

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
        public async Task NewPostAsync(NewPostDTO post)
        {
            await _context.Posts.AddAsync(new PostsModel
            {
                Title = post.Title,
                Description = post.Description,
                Photo = post.Photo,
                Creator = _context.Users.FirstOrDefault(u => u.Email == post.CreatorEmail),
                Theme = _context.Themes.FirstOrDefault(t => t.Description == post.ThemeDescription)
            });
            await _context.SaveChangesAsync();
        }

        public async Task UpdatePostAsync(UpdatePostDTO post)
        {
            var postExistance = await GetPostByIdAsync(post.Id);
            postExistance.Title = post.Title;
            postExistance.Description = post.Description;
            postExistance.Photo = post.Photo;
            postExistance.Theme = _context.Themes.FirstOrDefault(t => t.Description == post.ThemeDescription);

            _context.Posts.Update(postExistance);
            await _context.SaveChangesAsync();
        }

        public async Task DeletePostAsync(int id)
        {
            _context.Posts.Remove(await GetPostByIdAsync(id));
            await _context.SaveChangesAsync();
        }

        public async Task<List<PostsModel>> GetAllPostsAsync()
        {
            return await _context.Posts
                .Include(p => p.Creator)
                .Include(p => p.Theme)
                .ToListAsync();
        }

        public async Task<PostsModel> GetPostByIdAsync(int id)
        {
            return await _context.Posts
                .Include(p => p.Creator)
                .Include(p => p.Theme)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public  async Task<List<PostsModel>> GetPostBySearchAsync(string title, string description, string creator)
        {
            switch (title, description, creator)
            {
                case (null, null, null):
                    return await GetAllPostsAsync();

                case (null, null, _):
                    return await _context.Posts
                        .Include(p => p.Theme)
                        .Include(p => p.Creator)
                        .Where(p => p.Creator.Name.Contains(creator))
                        .ToListAsync();

                case (null, _, null):
                    return await _context.Posts
                        .Include(p => p.Theme)
                        .Include(p => p.Creator)
                        .Where(p => p.Theme.Description.Contains(description))
                        .ToListAsync();

                case (_, null, null):
                    return await _context.Posts
                        .Include(p => p.Theme)
                        .Include(p => p.Creator)
                        .Where(p => p.Title.Contains(title))
                        .ToListAsync();

                case (_, _, null):
                    return await _context.Posts
                        .Include(p => p.Theme)
                        .Include(p => p.Creator)
                        .Where(p => p.Title.Contains(title) & p.Theme.Description.Contains(description))
                        .ToListAsync();

                case (null, _, _):
                    return await _context.Posts
                        .Include(p => p.Theme)
                        .Include(p => p.Creator)
                        .Where(p => p.Theme.Description.Contains(description) & p.Creator.Name.Contains(creator))
                        .ToListAsync();

                case (_, null, _):
                    return await _context.Posts
                        .Include(p => p.Theme)
                        .Include(p => p.Creator)
                        .Where(p => p.Title.Contains(title) & p.Creator.Name.Contains(creator))
                        .ToListAsync();

                case (_, _, _):
                    return await _context.Posts
                        .Include(p => p.Theme)
                        .Include(p => p.Creator)
                        .Where(p => p.Title.Contains(title) | 
                            p.Theme.Description.Contains(description) |
                            p.Creator.Name.Contains(creator))
                        .ToListAsync();
            }
        }
    #endregion Methods
  }
}