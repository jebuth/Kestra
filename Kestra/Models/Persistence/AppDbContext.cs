using Kestra.Util;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kestra.Models.Persistence
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Ticker> Tickers { get; set; }

        /// <summary>
        /// Seed data.
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // create dbo.Order records
            modelBuilder.Entity<Order>().HasData(new Order { Id = 1, Name = Enumerations.OrderTypeNames.BUY.ToString(), Deleted = false });
            modelBuilder.Entity<Order>().HasData(new Order { Id = 2, Name = Enumerations.OrderTypeNames.SELL.ToString(), Deleted = false });

            // create dbo.Ticker records
            modelBuilder.Entity<Ticker>().HasData(new Ticker { Id = 1, Name = "AAPL", Deleted = false });
            modelBuilder.Entity<Ticker>().HasData(new Ticker { Id = 2, Name = "GOOG", Deleted = false });
            modelBuilder.Entity<Ticker>().HasData(new Ticker { Id = 3, Name = "CRM", Deleted = false });
            modelBuilder.Entity<Ticker>().HasData(new Ticker { Id = 4, Name = "AMZN", Deleted = false });
            modelBuilder.Entity<Ticker>().HasData(new Ticker { Id = 5, Name = "SNOW", Deleted = false });
            modelBuilder.Entity<Ticker>().HasData(new Ticker { Id = 6, Name = "NFLX", Deleted = false });
            modelBuilder.Entity<Ticker>().HasData(new Ticker { Id = 7, Name = "BABA", Deleted = false });
            modelBuilder.Entity<Ticker>().HasData(new Ticker { Id = 8, Name = "FRT", Deleted = false });
            modelBuilder.Entity<Ticker>().HasData(new Ticker { Id = 9, Name = "TSLA", Deleted = false });
            modelBuilder.Entity<Ticker>().HasData(new Ticker { Id = 10, Name = "SQ", Deleted = false });

            DateTime createdOnUtc = DateTime.UtcNow;

            // create dbo.Transaction records
            modelBuilder.Entity<Transaction>().HasData(new Transaction
            {
                Id = 1,
                OrderId = 1, 
                TickerId = 1,
                Quantity = 100,
                Deleted = false,
                CreatedOnUtc = createdOnUtc,
            });

            modelBuilder.Entity<Transaction>().HasData(new Transaction
            {
                Id = 2,
                OrderId = 1,
                TickerId = 3,
                Quantity = 50,
                Deleted = false,
                CreatedOnUtc = createdOnUtc,
            });

            modelBuilder.Entity<Transaction>().HasData(new Transaction
            {
                Id = 3,
                OrderId = 1,
                TickerId = 6,
                Quantity = 50,
                Deleted = false,
                CreatedOnUtc = createdOnUtc,
            });

            modelBuilder.Entity<Transaction>().HasData(new Transaction
            {
                Id = 4,
                OrderId = 2,
                TickerId = 4,
                Quantity = 10,
                Deleted = false,
                CreatedOnUtc = createdOnUtc,
            });

            modelBuilder.Entity<Transaction>().HasData(new Transaction
            {
                Id = 5,
                OrderId = 1,
                TickerId = 9,
                Quantity = 1000,
                Deleted = false,
                CreatedOnUtc = createdOnUtc,
            });

        }

    }
}
