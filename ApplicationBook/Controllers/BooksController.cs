using ApplicationBook.Service;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApplicationBook.Controllers
{
    [Route("api/[controller]")]
    [EnableCors()]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IElmTestDbService _elmTestDbService;
        public BooksController(IElmTestDbService elmTestDbService)
        {
                _elmTestDbService = elmTestDbService;
        }


        [Route("GetBooks/{pageNumber}")]
        [HttpGet]
        public async Task<IActionResult> GetBooks(int pageNumber)
        {
            try
            {
                var result = await _elmTestDbService.GetElmTestDbsAsync(pageNumber);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
