using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Practice.Models
{
    public record Book(){

    
        public int id{get;}= default!;
        public string BookName{get;set;}= default!;
        public string Atheneum{get;set;}= default!;
        public string Authors{get;set;}= default!;
        public int DateOfPublishing{get;set;}= default!;
        public int quantity{get;set;}= default!;

    }
}