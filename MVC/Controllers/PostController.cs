using System;
using System.Collections.Generic;
using System.Linq;
using Business.Models;
using Microsoft.AspNetCore.Mvc;

namespace MVC.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly List<Post> _posts = new List<Post>();

        // GET: api/Posts
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_posts);
        }

        // GET: api/Posts/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var post = _posts.FirstOrDefault(p => p.Id == id);
            if (post == null)
            {
                return NotFound();
            }
            return Ok(post);
        }

        // POST: api/Posts
        [HttpPost]
        public IActionResult Post([FromBody] Post post)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            post.Id = _posts.Count + 1;
            post.PostedOn = DateTime.Now;
            _posts.Add(post);
            return CreatedAtAction(nameof(Get), new { id = post.Id }, post);
        }

        // PUT: api/Posts/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Post post)
        {
            var existingPost = _posts.FirstOrDefault(p => p.Id == id);
            if (existingPost == null)
            {
                return NotFound();
            }

            existingPost.Title = post.Title;
            existingPost.Content = post.Content;
            existingPost.UserId = post.UserId;
            existingPost.CategoryId = post.CategoryId;

            return NoContent();
        }

        // DELETE: api/Posts/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var post = _posts.FirstOrDefault(p => p.Id == id);
            if (post == null)
            {
                return NotFound();
            }
            _posts.Remove(post);
            return NoContent();
        }
    }
}
