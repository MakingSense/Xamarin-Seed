using System.IO;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace MvvmSeed.Domain.Model
{
    public abstract class DbContextBase : DbContext
    {
        private enum DatabaseMode
        {
            /// <summary>
            /// Sqlite database used for Android and iOS
            /// </summary>
            Sqlite,
            /// <summary>
            /// InMemory database used for UnitTests
            /// </summary>
            InMemory
        }

        private readonly string _databaseFolder;
        private readonly string _databaseFullPath;
        private readonly DatabaseMode _databaseMode;

        /// <summary>
        /// Initializes an InMemory database context to be used on UnitTests
        /// </summary>
        /// <param name="optionsBuilder"><see cref="DbContextOptions"/> specifying 'UseInMemoryDatabase' option</param>
        protected DbContextBase(DbContextOptions optionsBuilder) : base(optionsBuilder)
        {
            // NOTES:
            // I thought about creating a parameterless constructor that creates its own DbContextOptions with UseInMemoryDatabase option set,
            // but that will require referencing the InMemory package in this project and I prefer to avoid that.
            _databaseMode = DatabaseMode.InMemory;
        }

        /// <summary>
        /// Initializes a Sqlite database context
        /// </summary>
        /// <param name="databaseFolder"> Full path where the database will be created/open </param>
        /// <param name="databaseName"> Database file name </param>
        protected DbContextBase(string databaseFolder, string databaseName)
        {
            _databaseMode = DatabaseMode.Sqlite;
            _databaseFolder = databaseFolder;
            _databaseFullPath = Path.Combine(_databaseFolder, databaseName);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (_databaseMode == DatabaseMode.Sqlite)
                optionsBuilder.UseSqlite($"Filename={_databaseFullPath}");
        }

        /// <summary>
        /// Initializes database file
        /// </summary>
        public async Task InitializeAsync()
        {
            if (_databaseMode != DatabaseMode.Sqlite)
                return;

            // TODO - Double check the need for this code after the fix for Android 7 is released (https://github.com/aspnet/EntityFramework/issues/7777)
            await Task.Run(() =>
            {
                if (!Directory.Exists(_databaseFolder))
                    Directory.CreateDirectory(_databaseFolder);
                if (!File.Exists(_databaseFullPath))
                    using (var stream = File.Create(_databaseFullPath)) { /* DB context creation fails on real devices if the file doesn't exit, review while improving DbContext initialization*/ }
            });
            await Database.EnsureCreatedAsync();
        }
    }
}
