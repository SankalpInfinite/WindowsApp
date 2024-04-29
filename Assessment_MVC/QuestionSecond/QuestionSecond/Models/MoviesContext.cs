using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace QuestionSecond.Models
{
    public class MoviesContext: DbContext
    {
        public MoviesContext() : base("abc")
        { }
        public DbSet<Movie> Movies { get; set; }

    }
}