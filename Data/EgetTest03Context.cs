using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using EgetTest03.Models;

namespace EgetTest03.Data
{
    public class EgetTest03Context : DbContext
    {
        public EgetTest03Context (DbContextOptions<EgetTest03Context> options)
            : base(options)
        {
        }

        public DbSet<Arena> Arena { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PlayerTeam>()
                .HasKey(pt => new { pt.PlayerId, pt.TeamId });

            modelBuilder.Entity<PlayerTeam>()
                .HasOne(pt => pt.Player)
                .WithMany(p => p.PlayerTeams)
                .HasForeignKey(pt => pt.PlayerId);

            modelBuilder.Entity<PlayerTeam>()
                .HasOne(pt => pt.Team)
                .WithMany(t => t.PlayerTeams)
                .HasForeignKey(pt => pt.TeamId);
        }

        public DbSet<EgetTest03.Models.Player> Player { get; set; }

        public DbSet<EgetTest03.Models.Team> Team { get; set; }
    }
}
