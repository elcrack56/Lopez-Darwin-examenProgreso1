using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Lopez_Darwin_examenProgreso1.Models;

namespace Lopez_Darwin_examenProgreso1.Data
{
    public class Lopez_Darwin_examenProgreso1Context : DbContext
    {
        public Lopez_Darwin_examenProgreso1Context (DbContextOptions<Lopez_Darwin_examenProgreso1Context> options)
            : base(options)
        {
        }

        public DbSet<Lopez_Darwin_examenProgreso1.Models.Lopez> Lopez { get; set; } = default!;
        public DbSet<Lopez_Darwin_examenProgreso1.Models.Celular> Celular { get; set; } = default!;
    }
}
