using BusinessLayer.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GraphqlAPI.Controllers
{
    //[Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly IAuthorService _authorService;
        public AuthorController(IAuthorService authorService)
        {
            _authorService=authorService;
        }
        [HttpGet]
        [Route("/Authors")]
        public IActionResult GetAuthors()
        {
            var authors = _authorService.GetAll(); // Call service method

            if (authors == null || !authors.Any()) // Handle null/empty result
            {
                return NotFound("No authors found.");
            }

            return Ok(authors);
        }
    }
}
