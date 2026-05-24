using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using TicketManagmentSystem.Server.Models;

namespace TicketManagmentSystem.Server.DataAcess.Interceptors;

public class AuditFieldsInterceptor : SaveChangesInterceptor
{
    public override ValueTask<InterceptionResult<int>> SavingChangesAsync(
        DbContextEventData eventData,
        InterceptionResult<int> result,
        CancellationToken cancellationToken = default)
    {
        ApplyAudit(eventData);
        return base.SavingChangesAsync(eventData, result, cancellationToken);
    }

    public override InterceptionResult<int> SavingChanges(
        DbContextEventData eventData,
        InterceptionResult<int> result)
    {
        ApplyAudit(eventData);
        return base.SavingChanges(eventData, result);
    }

    private static void ApplyAudit(DbContextEventData eventData)
    {
        var context = eventData.Context;
        if (context is null) return;

        var now = DateTime.UtcNow;
        foreach (var entry in context.ChangeTracker.Entries<AuditableEntity>())
        {
            if (entry.State == EntityState.Added)
            {
                entry.Entity.CreatedDate = now;
                entry.Entity.UpdatedDate = now;
            }
            else if (entry.State == EntityState.Modified)
            {
                entry.Entity.UpdatedDate = now;
                entry.Property(nameof(AuditableEntity.CreatedDate)).IsModified = false;
            }
        }
    }
}