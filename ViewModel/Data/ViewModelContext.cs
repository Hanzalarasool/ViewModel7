using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ViewModel.Models;

namespace ViewModel.Data
{
    public class ViewModelContext : DbContext
    {
        public ViewModelContext (DbContextOptions<ViewModelContext> options)
            : base(options)
        {
        }

        public DbSet<ViewModel.Models.A> A { get; set; } = default!;

        public DbSet<ViewModel.Models.B>? B { get; set; }

        public DbSet<ViewModel.Models.C>? C { get; set; }
    }
}
