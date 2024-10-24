﻿// <auto-generated />
using System;
using BlazorApp1.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BlazorApp1.Migrations
{
    [DbContext(typeof(CryptoDCAContext))]
    [Migration("20241024153215_Changes")]
    partial class Changes
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BlazorApp1.Models.Crypto", b =>
                {
                    b.Property<int>("CryptoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CryptoId"));

                    b.Property<decimal>("CurrentPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Symbol")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CryptoId");

                    b.ToTable("Cryptos");

                    b.HasData(
                        new
                        {
                            CryptoId = 1,
                            CurrentPrice = 0m,
                            Name = "Bitcoin",
                            Symbol = "BTC"
                        },
                        new
                        {
                            CryptoId = 2,
                            CurrentPrice = 0m,
                            Name = "Ethereum",
                            Symbol = "ETH"
                        },
                        new
                        {
                            CryptoId = 3,
                            CurrentPrice = 0m,
                            Name = "Ripple",
                            Symbol = "XRP"
                        },
                        new
                        {
                            CryptoId = 4,
                            CurrentPrice = 0m,
                            Name = "Solana",
                            Symbol = "SOL"
                        });
                });

            modelBuilder.Entity("BlazorApp1.Models.DCAInvestment", b =>
                {
                    b.Property<int>("DCAInvestmentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DCAInvestmentId"));

                    b.Property<int>("CryptoId")
                        .HasColumnType("int");

                    b.Property<decimal>("MonthlyInvestmentAmount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.HasKey("DCAInvestmentId");

                    b.HasIndex("CryptoId");

                    b.ToTable("DCAInvestments");
                });

            modelBuilder.Entity("BlazorApp1.Models.InvestmentRecord", b =>
                {
                    b.Property<int>("InvestmentRecordId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("InvestmentRecordId"));

                    b.Property<decimal>("CryptoAmount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("DCAInvestmentId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("InvestedAmount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("ValueToday")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("InvestmentRecordId");

                    b.HasIndex("DCAInvestmentId");

                    b.ToTable("InvestmentRecords");
                });

            modelBuilder.Entity("BlazorApp1.Models.DCAInvestment", b =>
                {
                    b.HasOne("BlazorApp1.Models.Crypto", "Crypto")
                        .WithMany("Investments")
                        .HasForeignKey("CryptoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Crypto");
                });

            modelBuilder.Entity("BlazorApp1.Models.InvestmentRecord", b =>
                {
                    b.HasOne("BlazorApp1.Models.DCAInvestment", "DCAInvestment")
                        .WithMany("InvestmentRecords")
                        .HasForeignKey("DCAInvestmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DCAInvestment");
                });

            modelBuilder.Entity("BlazorApp1.Models.Crypto", b =>
                {
                    b.Navigation("Investments");
                });

            modelBuilder.Entity("BlazorApp1.Models.DCAInvestment", b =>
                {
                    b.Navigation("InvestmentRecords");
                });
#pragma warning restore 612, 618
        }
    }
}
