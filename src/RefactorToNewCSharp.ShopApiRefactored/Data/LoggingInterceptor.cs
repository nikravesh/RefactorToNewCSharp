using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Diagnostics;

using RefactorToNewCSharp.ShopApiRefactored.Models;

namespace RefactorToNewCSharp.ShopApiRefactored.Data;
public class LoggingInterceptor : SaveChangesInterceptor
{
    private int userId = 1;
    public override InterceptionResult<int> SavingChanges(
        DbContextEventData eventData,
        InterceptionResult<int> result)
    {
        var context = eventData.Context;

        if (context is not null)
        {
            var entiries = context.ChangeTracker.Entries<Product>().Where(p => p.State == EntityState.Added);

            foreach (var entry in entiries)
            {
                LogAndSetShadowProperties(entry);
            }
        }

        return base.SavingChanges(eventData, result);
    }

    public override ValueTask<InterceptionResult<int>> SavingChangesAsync(
        DbContextEventData eventData,
        InterceptionResult<int> result,
        CancellationToken cancellationToken = default)
    {
        var context = eventData.Context;

        if (context is not null)
        {
            var entries = context.ChangeTracker.Entries<Product>().Where(p => p.State == EntityState.Added);

            foreach (var entry in entries)
            {
                LogAndSetShadowProperties(entry); 
            }
        }
        return base.SavingChangesAsync(eventData, result, cancellationToken);
    }

    private void LogAndSetShadowProperties(EntityEntry<Product> entry)
    {
        Console.WriteLine($@"[Information Log]: Adding product : {entry.Entity.Name}, Price: {entry.Entity.Price}");

        entry.Property("CreatedAt").CurrentValue = DateTime.Now;
        entry.Property("CreatedBy").CurrentValue = userId;

        Console.WriteLine($"Adding time: {entry.Property("CreatedAt").CurrentValue}");
        Console.WriteLine($"Adding by: {entry.Property("CreatedBy").CurrentValue}");
    }
}
