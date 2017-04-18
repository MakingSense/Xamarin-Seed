using System;
using System.ComponentModel.DataAnnotations;

namespace MvvmSeed.Domain.Model
{
    public class RandomizedString
    {
        [Key]
        public long Id { get; set; }

        public string LastTransformationValue { get; set; }

        public int RandomizationCount { get; set; }

        public DateTimeOffset LastTransformationTimestamp { get; set; }
    }
}
