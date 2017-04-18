using System;
using System.Linq;
using MvvmSeed.Domain.Model;

namespace MvvmSeed.Domain.Services
{
    /// <summary>
    /// Simple implementation of <see cref="IStringRandomizerService"/> that stores randomization info on local storage
    /// </summary>
    public class StringRandomizerService : IStringRandomizerService
    {
        private readonly LocalStorageContext _localStorage;

        public StringRandomizerService(LocalStorageContext localStorage)
        {
            _localStorage = localStorage;
        }

        public string RandomizeString(string input)
        {
            var random = new Random();
            var randomizedString = new string(input.ToCharArray().OrderBy(s => random.Next(2) % 2 == 0).ToArray());

            var lastRandomizedString = GetLastEntyFromDb() ?? new RandomizedString();
            lastRandomizedString.LastTransformationTimestamp = DateTimeOffset.UtcNow;
            lastRandomizedString.RandomizationCount++;
            lastRandomizedString.LastTransformationValue = randomizedString;
            if (lastRandomizedString.Id == 0)
                _localStorage.Add(lastRandomizedString);

            _localStorage.SaveChanges();
            return randomizedString;
        }

        public DateTimeOffset LastRandomizationTimestamp => GetLastEntyFromDb()?.LastTransformationTimestamp ??  DateTimeOffset.MinValue;

        public int RandomizationsCount => GetLastEntyFromDb()?.RandomizationCount ?? 0;

        public string LastRandomizedValue => GetLastEntyFromDb()?.LastTransformationValue ?? "Hello World!";

        private RandomizedString GetLastEntyFromDb() => _localStorage.RandomizedStrings.FirstOrDefault();
    }
}