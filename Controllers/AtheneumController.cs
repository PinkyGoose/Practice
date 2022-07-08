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
    public class AtheneumController : Controller
    {
        private readonly AtheneumDb db;
        public AtheneumController(AtheneumDb db)
        {
            this.db = db;
        }

        [HttpGet]
        public async Task <IActionResult> GetBooks(){

            return Ok(await db.Atheneums.ToListAsync());

        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task <IActionResult> GetBook(int id){

            return await db.Atheneums.FindAsync(id)
            is Atheneum n
                ? Ok(n)
                : NotFound();

        }

        [HttpPost]
        public async Task<IActionResult> NewBook(Atheneum a){
            var atheneum = new Atheneum();


            await db.Atheneums.AddAsync(atheneum);
            await db.SaveChangesAsync();

            return Ok(atheneum);

        }


        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> UpdateBook(int id, Atheneum a){


            var atheneum = await db.Atheneums.FindAsync(id); 
    
            if (atheneum is null) return NotFound();

            atheneum.AtheneumName = a.AtheneumName;
            await db.SaveChangesAsync();
            return Ok(atheneum);

        }


        [HttpDelete]
        [Route("{id:int}")]
        public async Task <IActionResult> DeleteBook(int id){


            var atheneum = await db.Atheneums.FindAsync(id);
            if (atheneum is not null){
                db.Atheneums.Remove(atheneum);
                await db.SaveChangesAsync();
            }
            return NoContent();
        }
    }
    
}