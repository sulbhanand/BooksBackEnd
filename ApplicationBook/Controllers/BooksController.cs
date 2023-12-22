using ApplicationBook.DTO;
using ApplicationBook.Service;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

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
                List<BooksDTO> books = new List<BooksDTO>();

                var result = await _elmTestDbService.GetElmTestDbsAsync(pageNumber);
                foreach (var item in result)
                {
                    BooksDTO dTO = JsonSerializer.Deserialize<BooksDTO>(item.BookInfo);
                    dTO.BookId = item.BookId;
                    books.Add(dTO);
                }
                return Ok(books);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
