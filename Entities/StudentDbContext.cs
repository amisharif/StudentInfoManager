﻿using Entities.IdentityEntities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class StudentDbContext : IdentityDbContext<ApplicationUser,ApplicationRole,Guid>
    {
        public StudentDbContext(DbContextOptions options) : base(options)
        {
         
        }

        public DbSet<Student> Students { get; set; }
    }
}
