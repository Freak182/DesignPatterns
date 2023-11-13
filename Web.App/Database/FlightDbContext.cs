using Microsoft.EntityFrameworkCore;
using Web.App.Entity.Mapping.Common;

namespace Web.App.Database
{
    public class FlightDbContext : DbContext
    {
        public FlightDbContext() { }

        public FlightDbContext(DbContextOptions<FlightDbContext> options) : base(options) { }

        /// <inheritdoc cref="Microsoft.EntityFrameworkCore.DbContext.OnModelCreating"/>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            this.RegisterMaps(modelBuilder, typeof(FlightDbContext));
            base.OnModelCreating(modelBuilder);
        }

        protected void RegisterMaps(ModelBuilder modelBuilder, Type type)
        {
            var mappings = type
                .Assembly
                .GetTypes()
                .Where(type => !string.IsNullOrEmpty(type.Namespace) &&
                               typeof(IEntityMapping).IsAssignableFrom(type) && CanCreateInstance(type)
                )
                .ToList();

            foreach (var mapping in mappings)
            {
                (Activator.CreateInstance(mapping, false) as IEntityMapping)?.Map(modelBuilder,
                    this.Database.IsInMemory());
            }
        }

        private static bool CanCreateInstance(Type type)
        {
            return type.IsClass &&
                   !type.ContainsGenericParameters &&
                   !type.IsAbstract;
        }
    }
}
