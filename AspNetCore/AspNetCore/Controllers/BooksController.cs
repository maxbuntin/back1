using AspNetCore.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AspNetCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {

        private readonly BooksService books;

        public BooksController(BooksService books)
        {
            this.books = books;  
        }

        [HttpGet("getBooks")]
        public async Task<List<Books>> Get()
        {
            var data = await books.Get();
            return data;
        }

        [HttpGet("getBookById")]
        public async Task<Books> Get(string id)
        {
            var data = await books.Get(id);
            return data;
        }

        [HttpPost("createBooks")]
        public async Task<ActionResult> CreateBooks([FromBody] Books newBooks)
        {
            await books.Create(newBooks);
            return Ok();
        }

        [HttpPut("updateBooks")]
        public async Task UpdateBooks(string id, Books updateBooks)
        {
           await books.Update(id, updateBooks);
        }

        [HttpDelete("deleteBooks")]
        public async Task<ActionResult> DeleteBooks(string id)
        {
            await books.Remove(id);
            return Ok();
        }
    }
}
