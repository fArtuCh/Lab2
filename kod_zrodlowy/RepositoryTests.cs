using System;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Reflection;
using Blog.DAL.Infrastructure;
using Blog.DAL.Model;
using Blog.DAL.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics;
using TDD.DbTestHelpers.Core;
using TDD.DbTestHelpers.Yaml;

/*
// -- prepare data in db
context.Posts.ToList().ForEach(x => context.Posts.Remove(x));
context.Posts.Add(new Post
{
    Author = "test",
    Content = "test, test, test..."
});
*/
namespace Blog.DAL.Tests
{
    [TestClass]
    public class RepositoryTests :BlogFixtures
    {
  
        [TestMethod]
        public void Add_post()
        {
            // arrange
            var context = new BlogContext();
            context.Database.CreateIfNotExists();
            var repository = new BlogRepository();
            // act
            var result = repository.AddPosts("autor","tresc2");
            // assert
            var dodane =repository.GetAllPosts();

            Assert.AreEqual(result, dodane.Last());
        }

        [TestMethod]
        [ExpectedException(typeof(System.Data.Entity.Validation.DbEntityValidationException))]
        public void Add_post_required()
        {
            // arrange
            var context = new BlogContext();
            context.Database.CreateIfNotExists();
            var repository = new BlogRepository();
            // act
            var result = repository.AddPosts("autor");
            // assert
            var dodane = repository.GetAllPosts();

            Assert.AreEqual(result, dodane.Last());
        }

        [TestMethod]
        public void Show_comment()
        {
            // arrange
            var context = new BlogContext();
            context.Database.CreateIfNotExists();
            var repository = new BlogRepository();
            // act
            var dodane = repository.GetAllPosts();
            var result = repository.AddPosts("Nowy", "Post");
            repository.AddComment("autor", "tresc", dodane.Last().Id);
            repository.AddComment("autor2", "tresc2", dodane.Last().Id);
            // assert

            string wzorzec = "tresc; tresc2; ";
            var xx = repository.show_comments(dodane.Last().Id);

            Assert.AreEqual(wzorzec, xx);
        }


    }

    public class BlogFixtures: YamlDbFixture<BlogContext, BlogFixturesModel>
    {
        public BlogFixtures()
        {
            this.RefillBeforeEachTest = true;
            SetYamlFiles("posts.yml");       
        }
    }

    public class BlogFixturesModel
    {
        public FixtureTable<Post> Posts { get; set; }
        public FixtureTable<Comment> Comments { get; set; }
    }



}
