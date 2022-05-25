using AspNetCore.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AspNetCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : Controller
    {

        private readonly UsersService books;

        public UsersController(UsersService books)
        {
            this.books = books;
        }

        [HttpGet("getUsers")]
        public async Task<List<User>> GetUsers()
        {
            var data = await books.Get();
            return data;
        }

        [HttpGet("getUserById")]
        public async Task<User> GetUserById(string id)
        {
            var data = await books.Get(id);
            return data;
        }

        [HttpPost("createUser")]
        public async Task<ActionResult> CreateUser([FromBody] User newBooks)
        {
            await books.Create(newBooks);
            return Ok();
        }

        [HttpPut("updateUser")]
        public async Task UpdateUser(string id, User updateBooks)
        {
            await books.Update(id, updateBooks);
        }

        [HttpDelete("deleteUser")]
        public async Task<ActionResult> DeleteUser(string id)
        {
            await books.Remove(id);
            return Ok();
        }
    }
}
