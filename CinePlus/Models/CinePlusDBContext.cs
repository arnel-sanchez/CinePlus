using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinePlus.Models
{
    public class CinePlusDBContext : IdentityDbContext<User>
    {
        public CinePlusDBContext(DbContextOptions<CinePlusDBContext> options) : base(options) { }

        public DbSet<User> User { get; set; }

        public DbSet<ArmChair> ArmChair { get; set; }

        public DbSet<Discount> Discount { get; set; }

        public DbSet<DiscountsByShow> DiscountsByShow { get; set; }

        public DbSet<Movie> Movie { get; set; }

        public DbSet<MovieOnTop10> MovieOnTop10 { get; set; }

        public DbSet<MovieType> MovieType { get; set; }

        public DbSet<Partner> Partner { get; set; }

        public DbSet<Room> Room { get; set; }

        public DbSet<Show> Show { get; set; }

        public DbSet<Top10> Top10 { get; set; }

        public DbSet<UserBoughtArmChair> UserBoughtArmChair { get; set; }
    }
}
