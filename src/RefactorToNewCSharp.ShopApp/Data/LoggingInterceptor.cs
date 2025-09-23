using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

using ShopApp.Models;

namespace ShopApp.Data;
public class LoggingInterceptor : SaveChangesInterceptor
{
    public override InterceptionResult<int> SavingChanges(
        DbContextEventData eventData,
        InterceptionResult<int> result)
    {
        var context = eventData.Context;

        if (context != null)
        {
            var entries = context.ChangeTracker.Entries<Product>()
                .Where(e => e.State == EntityState.Added);

            foreach (var entry in entries)
            {
                Console.WriteLine($"[LOG] Adding product: {entry.Entity.Name}, Price: {entry.Entity.Price}");
            }
        }

        return base.SavingChanges(eventData, result);
    }
}
