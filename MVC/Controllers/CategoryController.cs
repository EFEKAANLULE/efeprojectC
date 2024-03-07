using System;
using System.Collections.Generic;
using System.Linq;
using Business.Models;
using Microsoft.AspNetCore.Mvc;

namespace MVC.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly List<Category> _categories = new List<Category>();

        // GET: api/Categories
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_categories);
        }

        // GET: api/Categories/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var category = _categories.FirstOrDefault(c => c.Id == id);
            if (category == null)
            {
                return NotFound();
            }
            return Ok(category);
        }

        // POST: api/Categories
        [HttpPost]
        public IActionResult Post([FromBody] Category category)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            category.Id = _categories.Count + 1;
            _categories.Add(category);
            return CreatedAtAction(nameof(Get), new { id = category.Id }, category);
        }

        // PUT: api/Categories/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Category category)
        {
            var existingCategory = _categories.FirstOrDefault(c => c.Id == id);
            if (existingCategory == null)
            {
                return NotFound();
            }

            existingCategory.Name = category.Name;

            return NoContent();
        }

        // DELETE: api/Categories/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var category = _categories.FirstOrDefault(c => c.Id == id);
            if (category == null)
            {
                return NotFound();
            }
            _categories.Remove(category);
            return NoContent();
        }
    }
}
