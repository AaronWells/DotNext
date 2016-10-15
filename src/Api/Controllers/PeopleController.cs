using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    public class PeopleController
    {
        private readonly DotNextContext _context;

        public PeopleController(DotNextContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<People>> GetAll()
        {
            return await _context.People.ToListAsync();
        }
    }
}
