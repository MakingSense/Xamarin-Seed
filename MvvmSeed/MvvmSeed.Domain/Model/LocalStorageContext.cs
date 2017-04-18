using Microsoft.EntityFrameworkCore;

namespace MvvmSeed.Domain.Model
{
    public class LocalStorageContext : DbContextBase
    {
        private const string DatabaseName = "LocalStorage.db";

        /// <summary>
        /// Initializes an InMemory database context to be used on UnitTests
        /// </summary>
        /// <param name="optionsBuilder"><see cref="DbContextOptions"/> specifying 'UseInMemoryDatabase' option</param>
        public LocalStorageContext(DbContextOptions optionsBuilder) : base(optionsBuilder) { }

        /// <summary>
        /// Initializes a Sqlite database context
        /// </summary>
        /// <param name="databaseFolder">Full path where the database will be created/open </param>
        public LocalStorageContext(string databaseFolder) : base(databaseFolder, DatabaseName) { }

        public DbSet<RandomizedString> RandomizedStrings { get; set; }
    }
}
