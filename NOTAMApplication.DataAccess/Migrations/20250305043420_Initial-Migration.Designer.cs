﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NOTAMApplication.DataAccess.Entities;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace NOTAMApplication.DataAccess.Migrations
{
    [DbContext(typeof(NOTAMDbContext))]
    [Migration("20250305043420_Initial-Migration")]
    partial class InitialMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("NOTAMApplication.DataAccess.Entities.CrawlJob", b =>
                {
                    b.Property<int>("JobId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("JobId"));

                    b.Property<DateOnly>("CreatedAt")
                        .HasColumnType("date");

                    b.Property<int>("DataCount")
                        .HasColumnType("integer");

                    b.Property<string>("ErrorMessage")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("JobName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("RunTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("JobId");

                    b.ToTable("CrawlJobs");
                });

            modelBuilder.Entity("NOTAMApplication.DataAccess.Entities.NOTAM", b =>
                {
                    b.Property<int>("NOTAMId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("NOTAMId"));

                    b.Property<string>("AccountId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("AirportName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("CancelledOrExpired")
                        .HasColumnType("boolean");

                    b.Property<DateOnly>("CollectDate")
                        .HasColumnType("date");

                    b.Property<bool>("ContractionsExpandedForPlainLanguage")
                        .HasColumnType("boolean");

                    b.Property<string>("CrossoverAccountID")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<long>("CrossoverTransactionID")
                        .HasColumnType("bigint");

                    b.Property<bool>("DefaultIcao")
                        .HasColumnType("boolean");

                    b.Property<bool>("DigitalTppLink")
                        .HasColumnType("boolean");

                    b.Property<bool>("DigitallyTransformed")
                        .HasColumnType("boolean");

                    b.Property<string>("EndDate")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("FacilityDesignator")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("FeatureName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Geometry")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("HasHistory")
                        .HasColumnType("boolean");

                    b.Property<string>("IcaoId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("IcaoMessage")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("IssueDate")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("JobId")
                        .HasColumnType("integer");

                    b.Property<string>("Keyword")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("LocID")
                        .HasColumnType("integer");

                    b.Property<string>("MapPointer")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("MessageDisplayed")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("MoreThan300Chars")
                        .HasColumnType("boolean");

                    b.Property<string>("NotamNumber")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("PlainLanguageMessage")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("Procedure")
                        .HasColumnType("boolean");

                    b.Property<int>("RequestID")
                        .HasColumnType("integer");

                    b.Property<bool>("ShowingFullText")
                        .HasColumnType("boolean");

                    b.Property<bool>("Snowtam")
                        .HasColumnType("boolean");

                    b.Property<string>("Source")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("SourceType")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("StartDate")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("TraditionalMessage")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("TraditionalMessageFrom4thWord")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<long>("TransactionID")
                        .HasColumnType("bigint");

                    b.Property<int>("UserID")
                        .HasColumnType("integer");

                    b.HasKey("NOTAMId");

                    b.HasIndex("JobId");

                    b.ToTable("NOTAMs");
                });

            modelBuilder.Entity("NOTAMApplication.DataAccess.Entities.NOTAM", b =>
                {
                    b.HasOne("NOTAMApplication.DataAccess.Entities.CrawlJob", null)
                        .WithMany()
                        .HasForeignKey("JobId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
