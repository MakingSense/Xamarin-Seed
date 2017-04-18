using System;

namespace MvvmSeed.Domain.Services
{
    public interface IStringRandomizerService
    {
        /// <summary>
        /// Re-arranges string randomly
        /// </summary>
        /// <param name="input">String to be randomized</param>
        /// <returns>Randomized string</returns>
        string RandomizeString(string input);

        /// <summary> Last randomization date and time</summary>
        DateTimeOffset LastRandomizationTimestamp { get; }

        /// <summary> Number of randomizations performed by this service </summary>
        int RandomizationsCount { get; }

        /// <summary> Last value provided by <see cref="RandomizeString"/> </summary>
        string LastRandomizedValue { get; }
    }
}