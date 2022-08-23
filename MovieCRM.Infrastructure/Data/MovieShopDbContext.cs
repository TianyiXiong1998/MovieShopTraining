using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MovieCRM.Core.Entities;


namespace MovieCRM.Infrastructure.Data
{
    public class MovieShopDbContext:IdentityDbContext<ApplicationUser>
    {
        public MovieShopDbContext(DbContextOptions<MovieShopDbContext> options): base(options)
        {

        }
        
        public DbSet<MovieActors> Actor { get; set; }


    }
}
