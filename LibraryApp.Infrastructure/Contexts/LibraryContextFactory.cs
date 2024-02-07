using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using LibraryApp.Infrastructure.Contexts;

namespace LibraryApp.Infrastructure.Contexts
{
    public class LibraryContextFactory : IDesignTimeDbContextFactory<LibraryContext>
    {
        public LibraryContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<LibraryContext>();
            optionsBuilder.UseSqlServer(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\plugg\CSHARP\Datalagring\Datalagring_Assignment\Datalagring_Assignment\LibraryApp.Infrastructure\Data\library_database_cf.mdf;Integrated Security=True;Connect Timeout=30");

            return new LibraryContext(optionsBuilder.Options);
        }
    }
}
