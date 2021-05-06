﻿using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cine__backend.Models
{
    public class CinePlusDBContext : IdentityDbContext<User>
    {
        public CinePlusDBContext(DbContextOptions<CinePlusDBContext> options) : base(options) { }

        public DbSet<User> User { get; set; }
    }
}
