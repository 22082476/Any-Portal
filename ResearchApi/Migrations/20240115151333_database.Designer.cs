﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ResearchApi.Migrations
{
    [DbContext(typeof(ResearchContext))]
    [Migration("20240115151333_database")]
    partial class database
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Allowed_AgeRange", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Allowed_AgeRangeId")
                        .HasColumnType("int");

                    b.Property<int>("ResearchId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("allowed_AgeRanges");
                });

            modelBuilder.Entity("Participant", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ResearchId")
                        .HasColumnType("int");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Participants");
                });

            modelBuilder.Entity("PostalCodeRange", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("From_Postalcode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ResearchId")
                        .HasColumnType("int");

                    b.Property<string>("Till_Postalcode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("PostalCodeRanges");
                });

            modelBuilder.Entity("Research", b =>
                {
                    b.Property<int>("Rcode")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Rcode"));

                    b.Property<bool>("Active")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<string>("Company")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CompanyId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Compensation")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Disability_Type")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Link_Research")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Type_Research")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Rcode");

                    b.ToTable("Research");
                });
#pragma warning restore 612, 618
        }
    }
}
