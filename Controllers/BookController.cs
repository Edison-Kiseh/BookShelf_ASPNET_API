using System.Collections.Generic;
using aspnet.DTO;
using aspnet.Models;
using aspnet.Repositories;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
// using webapi.Models;
// using webapi.Services;
namespace webapi.Controllers{
    [Route("api/books")] //Define default route for all methods in this class
    [ApiController] //Define class as a controller class which can be found by the startup class
    public class BooksController : ControllerBase{ //derive from ControllerBase, mapping this class as a controller class
        private readonly IBookRepo _repo;
        private readonly IMapper _map;
        public BooksController(IBookRepo repo, IMapper map){
            _repo = repo;
            _map = map;
        }

        [HttpGet] //request type using default route (GET, POST, ...): GET /api/persons
        public ActionResult GetAllBooks(){
            return Ok(_map.Map<IEnumerable<BookReadDto>>(_repo.GetAllBooks())); //return HTTP 200 OK, Ok method is method from ControllerBase base class
        }

        // [HttpGet("{id}")] //request type adding var id to the default route: GET /api/persons/1
        // [HttpPost]
        // public ActionResult <String> GetBookById(int id){ //get id var from route returning string
        //     return Ok(id.ToString()); //return HTTP 200 OK
        // }
        
        [HttpGet("{id}", Name = "GetBookById")] //request type using default route (GET, POST, ...): GET /api/persons
        public ActionResult GetBookById(int id){ //get id var from route returning string
            return Ok(_map.Map<BookReadDto>(_repo.GetBookById(id))); //return HTTP 200 OK
        }

        [HttpPost]
        public ActionResult AddBook(BookWriteDto b){
            var book = _map.Map<Book>(b);

            _repo.AddBook(book);
            _repo.SaveChanges();

            return CreatedAtRoute(nameof(GetBookById), new {Id = book.Id}, book);
        }

        [HttpPut("{id}")]
        public ActionResult UpdateBook(int id, BookUpdateDto b) {
            var existingBook = _repo.GetBookById(id);

            if(existingBook == null){
                return NotFound();
            }

            _map.Map(b, existingBook);

            _repo.UpdateBook(existingBook);

            _repo.SaveChanges();

            return Ok();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteTodo(int id) {
            var existingBook = _repo.GetBookById(id);

            if(existingBook == null){
                return NotFound();
            }

            _repo.DeleteBook(existingBook);

            _repo.SaveChanges();

            return Ok();
        }

        [HttpPost("upload")]
        public async Task<IActionResult> UploadImage(IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                return BadRequest("No file uploaded.");
            }

            // Generate a unique filename (or save it as needed)
            var fileName = Path.GetFileName(file.FileName);
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads", fileName);

            // Save the file
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            // Return the file URL or some metadata
            var fileUrl = $"{Request.Scheme}://{Request.Host}/uploads/{fileName}";
            return Ok(new { FileUrl = fileUrl });
        }

    }

}