using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using _20jan.Model;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;

namespace _20jan.Controller
{

    [Route("api/gebruiker")]
    [ApiController]
    public class GebruikerController : ControllerBase
    {
        public GebruikerController(yourDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        private readonly yourDbContext _dbContext;

        [HttpGet("getAll")]
        public async Task<ActionResult<IEnumerable<dbGebruiker>>> GetAllUsers()
        {
            var users = await _dbContext.Gebruikers.ToListAsync();
            return Ok(users);
        }

        [HttpPost("addUser")]
        public async Task<ActionResult<dbGebruiker>> AddUser([FromBody] dbGebruiker newUser)
        {
            try
            {
                newUser.Datum_Registratie = DateTime.Now; // Set the registration date

                _dbContext.Gebruikers.Add(newUser);
                await _dbContext.SaveChangesAsync();

                return CreatedAtAction("GetAllUsers", new { id = newUser.GebruikerID }, newUser);
            }
            catch (Exception ex)
            {
                return BadRequest($"Failed to add user. Error: {ex.Message}");
            }
        }





    }
}
