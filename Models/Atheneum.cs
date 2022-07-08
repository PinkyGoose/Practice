using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Practice.Models
{
    public record Atheneum(){

    
        public int id{get;}= default!;
        public string AtheneumName{get;set;}= default!;

    }
}