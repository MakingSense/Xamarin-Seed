using System;
using System.Runtime.CompilerServices;
using Microsoft.EntityFrameworkCore;
using MvvmSeed.Domain.Model;
using MvvmSeed.Domain.Services;
using Xunit;

namespace MvvmSeed.UnitTests.Services
{
    public class StringRandomizerServiceTest
    {
        private readonly RandomizedString _testEntity = new RandomizedString
        {
            Id = 1,
            LastTransformationTimestamp = DateTimeOffset.Now.AddDays(-3),
            RandomizationCount = 5,
            LastTransformationValue = "lleHo! orWdl"
        };

        [Fact]
        public void RandomizationsCount_ShouldReadLastValueFromLocalDb()
        {
            using (var dbContext = GetCleanContext())
            {
                //Arrange
                dbContext.RandomizedStrings.Add(_testEntity);
                dbContext.SaveChanges();
                var randomizerService = new StringRandomizerService(dbContext);

                //Act
                var randomizationCount = randomizerService.RandomizationsCount;

                //Assert
                Assert.Equal(_testEntity.RandomizationCount, randomizationCount);
            }
        }

        [Fact]
        public void LastTransformationValue_ShouldReadLastValueFromLocalDb()
        {
            using (var dbContext = GetCleanContext())
            {
                //Arrange
                dbContext.RandomizedStrings.Add(_testEntity);
                dbContext.SaveChanges();
                var randomizerService = new StringRandomizerService(dbContext);

                //Act
                var lastRandomizedValue = randomizerService.LastRandomizedValue;

                //Assert
                Assert.Equal(_testEntity.LastTransformationValue, lastRandomizedValue);
            }
        }

        [Fact]
        public void LastRandomizationTimestamp_ShouldReadLastValueFromLocalDb()
        {
            using (var dbContext = GetCleanContext())
            {
                //Arrange
                dbContext.RandomizedStrings.Add(_testEntity);
                dbContext.SaveChanges();
                var randomizerService = new StringRandomizerService(dbContext);

                //Act
                var lastTimestamp = randomizerService.LastRandomizationTimestamp;

                //Assert
                Assert.Equal(_testEntity.LastTransformationTimestamp, lastTimestamp);
            }
        }

        [Fact]
        public void RandomizationsCount_ShouldReturnDefaultValue_WhenDbIsEmpty()
        {
            using (var dbContext = GetCleanContext())
            {
                //Arrange
                var randomizerService = new StringRandomizerService(dbContext);

                //Act
                var randomizationCount = randomizerService.RandomizationsCount;

                //Assert
                Assert.Equal(0, randomizationCount);
            }
        }

        [Fact]
        public void LastTransformationValue_ShouldReturnDefaultValue_WhenDbIsEmpty()
        {
            using (var dbContext = GetCleanContext())
            {
                //Arrange
                var randomizerService = new StringRandomizerService(dbContext);

                //Act
                var lastRandomizedValue = randomizerService.LastRandomizedValue;

                //Assert
                Assert.Equal("Hello World!", lastRandomizedValue);
            }
        }

        [Fact]
        public void LastRandomizationTimestamp_ShouldReturnDefaultValue_WhenDbIsEmpty()
        {
            using (var dbContext = GetCleanContext())
            {
                //Arrange
                var randomizerService = new StringRandomizerService(dbContext);

                //Act
                var lastTimestamp = randomizerService.LastRandomizationTimestamp;

                //Assert
                Assert.Equal(DateTimeOffset.MinValue, lastTimestamp);
            }
        }

        [Fact]
        public void RandomizeString_ShouldUpdateExposedProperties()
        {
            using (var dbContext = GetCleanContext())
            {
                //Arrange
                dbContext.RandomizedStrings.Add(_testEntity);
                dbContext.SaveChanges();
                var randomizerService = new StringRandomizerService(dbContext);

                var initialTimestamp = _testEntity.LastTransformationTimestamp;
                var initialCount = _testEntity.RandomizationCount;

                //Act
                var newRandomizationValue = randomizerService.RandomizeString(randomizerService.LastRandomizedValue);

                //Assert
                Assert.Equal(newRandomizationValue, randomizerService.LastRandomizedValue);
                Assert.True(randomizerService.LastRandomizationTimestamp > initialTimestamp);
                Assert.True(randomizerService.RandomizationsCount > initialCount);
            }
        }

        private LocalStorageContext GetCleanContext([CallerMemberName] string contextName = null)
        {
            var optionsBuilder = new DbContextOptionsBuilder<LocalStorageContext>();
            optionsBuilder.UseInMemoryDatabase(contextName);
            return new LocalStorageContext(optionsBuilder.Options);
        }
    }
}
