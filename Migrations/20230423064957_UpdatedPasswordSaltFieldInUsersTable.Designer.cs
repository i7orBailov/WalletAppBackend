﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using WalletAppBackend.Models.Database;

#nullable disable

namespace WalletAppBackend.Migrations
{
    [DbContext(typeof(BusinessDbContext))]
    [Migration("20230423064957_UpdatedPasswordSaltFieldInUsersTable")]
    partial class UpdatedPasswordSaltFieldInUsersTable
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Proxies:ChangeTracking", false)
                .HasAnnotation("Proxies:CheckEquality", false)
                .HasAnnotation("Proxies:LazyLoading", true)
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

                    b.ToTable("ExceptionsJournal");
                });

            modelBuilder.Entity("WalletAppBackend.Models.Database.Icon", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<byte[]>("Data")
                        .HasColumnType("bytea");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Icons");
                });

            modelBuilder.Entity("WalletAppBackend.Models.Database.Transaction", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<decimal>("Amount")
                        .HasColumnType("numeric");

                    b.Property<int?>("AuthorizedUserId")
                        .HasColumnType("integer");

                    b.Property<DateTimeOffset>("Date")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<int?>("IconId")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .IsUnicode(true)
                        .HasColumnType("character varying(100)");

                    b.Property<int?>("OwnerId")
                        .IsRequired()
                        .HasColumnType("integer");

                    b.Property<int?>("StatusId")
                        .HasColumnType("integer");

                    b.Property<string>("TypeTitle")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("AuthorizedUserId");

                    b.HasIndex("IconId");

                    b.HasIndex("OwnerId");

                    b.HasIndex("StatusId");

                    b.HasIndex("TypeTitle");

                    b.ToTable("Transactions");
                });

            modelBuilder.Entity("WalletAppBackend.Models.Database.TransactionStatus", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Title")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("Title")
                        .IsUnique();

                    b.ToTable("TransactionStatuses");
                });

            modelBuilder.Entity("WalletAppBackend.Models.Database.TransactionType", b =>
                {
                    b.Property<string>("Title")
                        .HasColumnType("text");

                    b.HasKey("Title");

                    b.ToTable("TransactionTypes");
                });

            modelBuilder.Entity("WalletAppBackend.Models.Database.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<decimal>("Balance")
                        .HasColumnType("numeric");

                    b.Property<decimal>("CardLimit")
                        .HasColumnType("numeric");

                    b.Property<int>("DailyPoints")
                        .HasColumnType("integer");

                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<string>("FirstName")
                        .HasColumnType("text");

                    b.Property<string>("LastName")
                        .HasColumnType("text");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<byte[]>("PasswordSalt")
                        .IsRequired()
                        .HasColumnType("bytea");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("WalletAppBackend.Models.Database.Transaction", b =>
                {
                    b.HasOne("WalletAppBackend.Models.Database.User", "AuthorizedUser")
                        .WithMany()
                        .HasForeignKey("AuthorizedUserId");

                    b.HasOne("WalletAppBackend.Models.Database.Icon", "Icon")
                        .WithMany()
                        .HasForeignKey("IconId");

                    b.HasOne("WalletAppBackend.Models.Database.User", "Owner")
                        .WithMany("Transactions")
                        .HasForeignKey("OwnerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WalletAppBackend.Models.Database.TransactionStatus", "Status")
                        .WithMany()
                        .HasForeignKey("StatusId");

                    b.HasOne("WalletAppBackend.Models.Database.TransactionType", "Type")
                        .WithMany()
                        .HasForeignKey("TypeTitle");

                    b.Navigation("AuthorizedUser");

                    b.Navigation("Icon");

                    b.Navigation("Owner");

                    b.Navigation("Status");

                    b.Navigation("Type");
                });

            modelBuilder.Entity("WalletAppBackend.Models.Database.User", b =>
                {
                    b.Navigation("Transactions");
                });
#pragma warning restore 612, 618
        }
    }
}
