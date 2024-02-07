using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace GestaoProdutos.Core.Data.Interceptors
{
    public class SoftDeleteSaveChangesInterceptor : SaveChangesInterceptor
    {
        internal bool Wheres(EntityEntry where)
        {
            return where.State == EntityState.Deleted &&
                    where.Entity
                        .GetType()
                        .GetInterfaces()
                        .Contains(typeof(ISoftDelete));
        }

        internal IList<EntityEntry> GetEntityEntries(DbContextEventData eventData)
        {
            return eventData
                .Context
                .ChangeTracker
                .Entries()
                .Where(Wheres)
                .ToList();
        }

        internal void SoftDelete(DbContextEventData eventData)
        {
            IList<EntityEntry> entityEntries = GetEntityEntries(eventData);
            if (entityEntries.Any())
            {
                foreach (var entity in entityEntries)
                {
                    entity.Property("Situacao").CurrentValue = false;
                    entity.State = EntityState.Modified;
                }
            }
        }

        public override InterceptionResult<int> SavingChanges(
            DbContextEventData eventData,
            InterceptionResult<int> result)
        {
            SoftDelete(eventData);
            return result;
        }

        public override ValueTask<InterceptionResult<int>> SavingChangesAsync(
            DbContextEventData eventData,
            InterceptionResult<int> result,
            CancellationToken cancellationToken = new CancellationToken())
        {
            SoftDelete(eventData);
            return new ValueTask<InterceptionResult<int>>(result);
        }

        public static SoftDeleteSaveChangesInterceptor Create()
        {
            return new SoftDeleteSaveChangesInterceptor();
        }
    }
}
