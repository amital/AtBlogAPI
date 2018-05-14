using System;
using System.Collections.Generic;
using System.Web.Http;
using AtBlogAPI.Models;
using AtBlogAPI.Models.Repository;
using AtBlogAPI.Models.ViewModel;


namespace AtBlogAPI.Controllers
{
    [RoutePrefix("api/blogs")]
    public class BlogsController : ApiController
    {
        private readonly BlogRepository repo = new BlogRepository();

        public IEnumerable<Blog> GetAllBlogEntitys()
        {
            return repo.GetAll();
        }

        [Route("GetTopRatedPosts")]
        public IEnumerable<Blog> GetTopRatedPosts()
        {
            return repo.GetTopPosts();
        }

        public IHttpActionResult GetBlogEntity(int id)
        {
            var blog = repo.Get(id);
            if (blog == null)
            {
                return NotFound();
            }
            return Ok(blog);
        }

        [HttpPost]
        //[ActionName("addBlog")]
        [Route("AddBlogEntity")]
        public IHttpActionResult AddBlogEntity(AddBlogVm d)
        {
            var blog = new Blog() {Text = d.Text, CreatedBy = d.CreatedBy, CreationDate = DateTime.Now};
            repo.Add(blog);
            repo.SaveChanges();
            return Ok(blog);
        }

        [HttpPost]
        [Route("UpdateBlogEntity")]
        public IHttpActionResult UpdateBlogEntity(UpdateBlogVm d)
        {
            var blog = repo.Get(d.Id);
            if (blog == null)
            {
                return NotFound();
            }

            blog.Text = d.Text;
            blog.UpdateDate = DateTime.Now;
            repo.SaveChanges();
            return Ok(blog);
        }
    }
}
