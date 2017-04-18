using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace MvvmSeed.Domain.Model.Migrations
{
    [DbContext(typeof(LocalStorageContext))]
    partial class LocalStorageContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "1.1.1");

            modelBuilder.Entity("MvvmSeed.Domain.Model.RandomizedString", b =>
                {
                    b.Property<long>("Id").ValueGeneratedOnAdd();

                    b.Property<DateTimeOffset>("LastTransformationTimestamp");

                    b.Property<string>("LastTransformationValue");

                    b.Property<int>("RandomizationCount");

                    b.HasKey("Id");

                    b.ToTable("RandomizedStrings");
                });
        }
    }
}
