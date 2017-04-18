using System.Threading.Tasks;

namespace MvvmSeed.Application.Initializers
{
    /// <summary>
    /// Initalizer to be executed post bootstrap and during loading screen (a.k.a. Splash view)
    /// </summary>
    public interface IApplicationInitializer
    {
        Task PostBootsrapInitializationAsync();
    }
}
