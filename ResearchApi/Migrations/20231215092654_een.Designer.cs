﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ResearchApi;

#nullable disable

namespace ResearchApi.Migrations
{
    [DbContext(typeof(ResearchContext))]
    [Migration("20231215092654_een")]
    partial class een
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ResearchApi.Research", b =>
                {
                    b.Property<int>("Rcode")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Rcode"));

                    b.Property<string>("Allowed_AgeRange")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Compensation")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Disabillity_Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Link_Research")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Participant")
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
