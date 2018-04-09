using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using TourManagement.API.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace TourManagement.API.Services
{
    public class TourManagementContext : DbContext
    {
        public DbSet<Tour> Tours { get; set; }
        public DbSet<Show> Shows { get; set; }
        public DbSet<Band> Bands { get; set; }
        public DbSet<Manager> Managers { get; set; }

        private readonly IUserInfoService _userInfoService;

        //public TourManagementContext(DbContextOptions<TourManagementContext> options )
        //  : base(options)
        //{ 

        //}
        public TourManagementContext(DbContextOptions<TourManagementContext> options,
            IUserInfoService userInfoService)
           : base(options)
        {
            // userInfoService is a required argument
            _userInfoService = userInfoService ?? throw new ArgumentNullException(nameof(userInfoService));
        }
        
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            // get added or updated entries
            var addedOrUpdatedEntries = ChangeTracker.Entries()
                    .Where(x => (x.State == EntityState.Added || x.State == EntityState.Modified));

            // fill out the audit fields
            foreach (var entry in addedOrUpdatedEntries)
            {
                var entity = entry.Entity as AuditableEntity;

                if (entry.State == EntityState.Added)
                {
                    entity.CreatedBy = _userInfoService.UserId;
                    entity.CreatedOn = DateTime.UtcNow;
                }

                entity.UpdatedBy = _userInfoService.UserId;
                entity.UpdatedOn = DateTime.UtcNow;
            }

            return base.SaveChangesAsync(cancellationToken);
        }        
    }
}
