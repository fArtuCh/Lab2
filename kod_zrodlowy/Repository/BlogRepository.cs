using System.Collections.Generic;
using Blog.DAL.Infrastructure;
using Blog.DAL.Model;
using System;

namespace Blog.DAL.Repository
{
    public class BlogRepository
    {
        private readonly BlogContext _context;

        public BlogRepository()
        {
            _context = new BlogContext();
        }

        public IEnumerable<Post> GetAllPosts()
        {
            return _context.Posts;
        }

        public IEnumerable<Comment> GetAllComments()
        {
            return _context.Comments;
        }


        public Post AddPosts(string author, string content)
        {
            Post a = new Post();
            a.Author = author;
            a.Content = content;
            _context.Posts.Add(a);
            _context.SaveChanges();
            return a;
        }

        public Post AddPosts(string author)
        {
            Post a = new Post();
            a.Author = author;
            _context.Posts.Add(a);
            _context.SaveChanges();
            return a;
        }

        public Comment AddComment(string author, string content, long id_post)
        {
            Comment a = new Comment();
            a.Author = author;
            a.Content = content;
            a.Id2 = id_post;
            _context.Comments.Add(a);
            _context.SaveChanges();
            return a;
        }


        public string show_comments (long ID_post)
        {
             var t = GetAllComments();

            string wiadomosci = "";

           foreach (Comment x in t)
            {
                if (x.Id2 == ID_post)
                {
                    wiadomosci += x.Content + "; ";
                }
            }
                
            
            return wiadomosci;
        }


    }
}
