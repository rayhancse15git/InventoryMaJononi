﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InventoryMaJononi.Data.Entity;
using InventoryMaJononi.Data.MasterData;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace InventoryMaJononi.Data
{
    public class InventoryMaJononiDbContext : IdentityDbContext<ApplicationUser>
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public InventoryMaJononiDbContext(DbContextOptions<InventoryMaJononiDbContext> options, IHttpContextAccessor _httpContextAccessor) : base(options)
        {
            this._httpContextAccessor = _httpContextAccessor;
        }

        #region Master Data

        public DbSet<UserType> UserTypes { get; set; }
        public DbSet<Branch> Branches { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }
        public DbSet<ProductBrand> ProductBrands { get; set; }
        public DbSet<ProductGroup> ProductGroups { get; set; }
        public DbSet<WeightCategory> WeightCategories { get; set; }

        #endregion



        #region Settings Configs
        public override int SaveChanges()
        {
            AddTimestamps();
            return base.SaveChanges();
        }

        public async Task<int> SaveChangesAsync()
        {
            AddTimestamps();
            return await base.SaveChangesAsync();
        }

        private void AddTimestamps()
        {

            var entities = ChangeTracker.Entries().Where(x => x.Entity is Base && (x.State == EntityState.Added || x.State == EntityState.Modified));

            var currentUsername = !string.IsNullOrEmpty(_httpContextAccessor?.HttpContext?.User?.Identity?.Name)
                ? _httpContextAccessor.HttpContext.User.Identity.Name
                : "Anonymous";

            foreach (var entity in entities)
            {
                if (entity.State == EntityState.Added)
                {
                    ((Base)entity.Entity).createdAt = DateTime.Now;
                    ((Base)entity.Entity).createdBy = currentUsername;
                }
                else
                {
                    entity.Property("createdAt").IsModified = false;
                    entity.Property("createdBy").IsModified = false;
                    ((Base)entity.Entity).updatedAt = DateTime.Now;
                    ((Base)entity.Entity).updatedBy = currentUsername;
                }

            }
        }
        #endregion

    }


}
