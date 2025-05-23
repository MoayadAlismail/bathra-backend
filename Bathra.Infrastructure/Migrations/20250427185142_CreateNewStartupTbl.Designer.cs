﻿// <auto-generated />
using Bathra.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Bathra.Infrastructure.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20250427185142_CreateNewStartupTbl")]
    partial class CreateNewStartupTbl
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Bathra.Domain.Entities.Startup", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<string>("Valuation")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("business_model")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("competition")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("contact_email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("created_at")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("exit_strategy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("financials")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("founded_date")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("founders")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("funding_required")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("image")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("industry")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("investment_terms")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("key_metrics")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("market_analysis")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("previous_funding")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("problem_solved")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("roadmap")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("stage")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("status")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("target_market")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("team_size")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("traction")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("use_of_funds")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("usp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("video_url")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("website")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("Startups");
                });
#pragma warning restore 612, 618
        }
    }
}
