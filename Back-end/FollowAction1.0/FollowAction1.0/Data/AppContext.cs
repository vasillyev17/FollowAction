using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using FollowAction1._0.Models;

    public class AppContext : DbContext
    {
        public AppContext (DbContextOptions<AppContext> options)
            : base(options)
        {
        }

        public DbSet<FollowAction1._0.Models.Buyer> Buyer { get; set; }

        public DbSet<FollowAction1._0.Models.BuyerAction> BuyerAction { get; set; }

        public DbSet<FollowAction1._0.Models.BuyerMovement> BuyerMovement { get; set; }

        public DbSet<FollowAction1._0.Models.Department> Department { get; set; }

        public DbSet<FollowAction1._0.Models.Product> Product { get; set; }

        public DbSet<FollowAction1._0.Models.Purchase> Purchase { get; set; }
    }
