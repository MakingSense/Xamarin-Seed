using System.Threading.Tasks;
using MvvmSeed.Domain.Model;

namespace MvvmSeed.Application.Initializers
{
    public class ApplicationInitializer : IApplicationInitializer
    {
        private readonly LocalStorageContext _dbContext;

        public ApplicationInitializer(LocalStorageContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task PostBootsrapInitializationAsync()
        {
            await _dbContext.InitializeAsync();
        }
    }
}