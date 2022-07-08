using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Practice.Data;
using Practice.Models;
using Microsoft.EntityFrameworkCore;
namespace Practice.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BookController : Controller
    {
        private readonly BookDb db;
        public BookController(BookDb db)
        {
            this.db = db;
        }

        [HttpGet]
        public async Task <IActionResult> GetBooks(){

            return Ok(await db.Books.ToListAsync());

        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task <IActionResult> GetBook(int id){

            return await db.Books.FindAsync(id)
            is Book n
                ? Ok(n)
                : NotFound();

        }

        [HttpPost]
        public async Task<IActionResult> NewBook(Book b){
            var book = new Book();


            await db.Books.AddAsync(book);
            await db.SaveChangesAsync();

            return Ok(book);

        }


        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> UpdateBook(int id, Book b){


            var book = await db.Books.FindAsync(id); 
    
            if (book is null) return NotFound();

            book.Atheneum = b.Atheneum;
            book.Authors = b.Authors;
            book.quantity = b.quantity;
            book.DateOfPublishing = b.DateOfPublishing;
            await db.SaveChangesAsync();
            return Ok(book);

        }


        [HttpDelete]
        [Route("{id:int}")]
        public async Task <IActionResult> DeleteBook(int id){


            var book = await db.Books.FindAsync(id);
            if (book is not null){
                db.Books.Remove(book);
                await db.SaveChangesAsync();
            }
            return NoContent();
        }
    }
}