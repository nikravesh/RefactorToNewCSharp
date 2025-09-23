using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

using RefactorToNewCSharp.ShopApiRefactored.Models;

namespace RefactorToNewCSharp.ShopApiRefactored.Data;
public class LoggingInterceptor : SaveChangesInterceptor
{
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
                Console.WriteLine($@"[Information Log] : 
                                     Adding product : {entry.Entity.Name}, Price : {entry.Entity.Price}");
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
                Console.WriteLine($@"[Information Log(async method)] : 
                                   Adding product : {entry.Entity.Name}, Price : {entry.Entity.Price}");
            }
        }
        return base.SavingChangesAsync(eventData, result, cancellationToken);
    }
}
