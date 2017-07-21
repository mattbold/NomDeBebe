using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using NomDeBebe.Data;

namespace NomDeBebe.Data.Migrations
{
    [DbContext(typeof(BebeContext))]
    [Migration("20170721142824_addedGender")]
    partial class addedGender
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.2")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("NomDeBebe.Data.Entities.BabyName", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Gender");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("BabyNames");
                });

            modelBuilder.Entity("NomDeBebe.Data.Entities.YearEntry", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("BabyNameId");

                    b.Property<int>("NumberInYear");

                    b.Property<int>("RankInYear");

                    b.Property<int>("Year");

                    b.HasKey("Id");

                    b.HasIndex("BabyNameId");

                    b.ToTable("YearEntries");
                });

            modelBuilder.Entity("NomDeBebe.Data.Entities.YearEntry", b =>
                {
                    b.HasOne("NomDeBebe.Data.Entities.BabyName", "BabyName")
                        .WithMany("YearEntries")
                        .HasForeignKey("BabyNameId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
