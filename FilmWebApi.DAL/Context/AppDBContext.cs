using FilmWebApi.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmWebApi.DAL.Context
{
	public  class AppDBContext :DbContext
	{
        public AppDBContext(DbContextOptions<AppDBContext> options) :base(options) 
        {


            
        }

        public AppDBContext()
        {
            
        }

        public DbSet<Actor> Actors { get; set; }
        public DbSet<Film> Films  { get; set; }
        public DbSet<Category> Categories{ get; set; }


    }
}
