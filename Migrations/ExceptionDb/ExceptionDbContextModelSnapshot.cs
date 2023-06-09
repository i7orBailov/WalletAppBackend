﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using WalletAppBackend.Models.Database.Exception;

#nullable disable

namespace WalletAppBackend.Migrations.ExceptionDb
{
    [DbContext(typeof(ExceptionDbContext))]
    partial class ExceptionDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("Exception")
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("WalletAppBackend.Models.Database.ExceptionJournal", b =>
                {
                    b.Property<string>("EventId")
                        .HasColumnType("text");

                    b.Property<string>("BodyParams")
                        .HasColumnType("text");

                    b.Property<string>("QueryParams")
                        .HasColumnType("text");

                    b.Property<string>("StackTrace")
                        .HasColumnType("text");

                    b.Property<DateTime>("Timestamp")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("EventId");

                    b.ToTable("ExceptionsJournal", "Exception");
                });
#pragma warning restore 612, 618
        }
    }
}
