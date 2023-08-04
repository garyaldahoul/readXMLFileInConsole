﻿// <auto-generated />
using Etteplant_XMLFile_API.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Etteplant_XMLFile_API.Migrations
{
    [DbContext(typeof(ApplicationDBContext))]
    partial class ApplicationDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Etteplant_XMLFile_API.Models.TransUnit", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Source")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Target")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("TransUnits");

                    b.HasData(
                        new
                        {
                            Id = 42006,
                            Source = "WARNING",
                            Target = "VARNING"
                        },
                        new
                        {
                            Id = 42007,
                            Source = "Note",
                            Target = "Obs!"
                        },
                        new
                        {
                            Id = 42008,
                            Source = "DANGER",
                            Target = "FARA"
                        },
                        new
                        {
                            Id = 42009,
                            Source = "CAUTION",
                            Target = "FÖRSIKTIGHET"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
