using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
namespace _20jan.Model{


public class YourDbContextFactory : IDesignTimeDbContextFactory<yourDbContext>
{
    public yourDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<yourDbContext>();
        optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=dbAccessibility;Trusted_Connection=True;");
                // optionsBuilder.UseSqlServer("Server =(local)\\sqlexpress; Database=dbAccessibility; Trusted Connection=True; MultipleActive ResultSets=True;");



        return new yourDbContext(optionsBuilder.Options);
    }
}
}