/*
 * Copyright (c) 2019, TopCoder, Inc. All rights reserved.
 */
using Microsoft.EntityFrameworkCore;
using WebAPI.Data.Entities;

namespace WebAPI.Data
{
    /// <summary>
    /// The application DB context.
    /// </summary>
    public class AppDbContext : DbContext
    {
        /// <summary>
        /// Gets or sets the users.
        /// </summary>
        /// <value>
        /// The users.
        /// </value>
        public DbSet<User> Users { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="AppDbContext"/> class.
        /// </summary>
        /// <param name="contextOptions">The context options.</param>
        public AppDbContext(DbContextOptions<AppDbContext> contextOptions)
            : base(contextOptions)
        {
        }

        /// <summary>
        /// Customizes mappings between entity model and database.
        /// </summary>
        /// <param name="builder">The model builder.</param>
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<User>()
                .HasIndex(u => u.Handle)
                .IsUnique();

            base.OnModelCreating(builder);
        }
    }
}
