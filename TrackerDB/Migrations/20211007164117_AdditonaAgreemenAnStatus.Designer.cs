﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TrackerDB;

namespace TrackerDB.Migrations
{
    [DbContext(typeof(ContextDB))]
    [Migration("20211007164117_AdditonaAgreemenAnStatus")]
    partial class AdditonaAgreemenAnStatus
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.7")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("TrackerDB.Models.AdditionalAgreementPIR", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ContractID")
                        .HasColumnType("int");

                    b.Property<int?>("ContractPIRID")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateOfSigned")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("NewCloseDate")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("NewSumm")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("Number")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("ContractPIRID");

                    b.ToTable("AdditionalAgreementPIRs");
                });

            modelBuilder.Entity("TrackerDB.Models.AdditionalAgreementSMR", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ContractID")
                        .HasColumnType("int");

                    b.Property<int?>("ContractSMRID")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateOfSigned")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("NewCloseFirstStage")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("NewCloseSecondtStage")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("NewSumm")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("Number")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("ContractSMRID");

                    b.ToTable("AdditionalAgreementSMRs");
                });

            modelBuilder.Entity("TrackerDB.Models.ContractPIR", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Closed")
                        .HasColumnType("bit");

                    b.Property<decimal>("ContractSum")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("DateOfComplete")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateOfSigned")
                        .HasColumnType("datetime2");

                    b.Property<int>("Number")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.ToTable("ContractPIRs");
                });

            modelBuilder.Entity("TrackerDB.Models.ContractSMR", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("ContractSum")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime?>("DateOfCompleteFirstStage")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateOfCompleteSecondtStage")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateOfSigned")
                        .HasColumnType("datetime2");

                    b.Property<int>("Number")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.ToTable("ContractSMRs");
                });

            modelBuilder.Entity("TrackerDB.Models.InternalNote", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Department")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Number")
                        .HasColumnType("int");

                    b.Property<int>("PowerlineID")
                        .HasColumnType("int");

                    b.Property<string>("Theme")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("PowerlineID");

                    b.ToTable("InternalNotes");
                });

            modelBuilder.Entity("TrackerDB.Models.Powerline", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Comments")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ConractSMRID")
                        .HasColumnType("int");

                    b.Property<int?>("ContractPIRID")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("ConractSMRID");

                    b.HasIndex("ContractPIRID");

                    b.ToTable("Powerlines");
                });

            modelBuilder.Entity("TrackerDB.Models.TypeOfContract", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("TypeOfContracts");
                });

            modelBuilder.Entity("TrackerDB.Models.AdditionalAgreementPIR", b =>
                {
                    b.HasOne("TrackerDB.Models.ContractPIR", null)
                        .WithMany("AdditionalAgreements")
                        .HasForeignKey("ContractPIRID");
                });

            modelBuilder.Entity("TrackerDB.Models.AdditionalAgreementSMR", b =>
                {
                    b.HasOne("TrackerDB.Models.ContractSMR", null)
                        .WithMany("AdditionalAgreements")
                        .HasForeignKey("ContractSMRID");
                });

            modelBuilder.Entity("TrackerDB.Models.InternalNote", b =>
                {
                    b.HasOne("TrackerDB.Models.Powerline", null)
                        .WithMany("InternalNotes")
                        .HasForeignKey("PowerlineID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("TrackerDB.Models.Powerline", b =>
                {
                    b.HasOne("TrackerDB.Models.ContractSMR", "ConractSMR")
                        .WithMany()
                        .HasForeignKey("ConractSMRID");

                    b.HasOne("TrackerDB.Models.ContractPIR", "ContractPIR")
                        .WithMany()
                        .HasForeignKey("ContractPIRID");

                    b.Navigation("ConractSMR");

                    b.Navigation("ContractPIR");
                });

            modelBuilder.Entity("TrackerDB.Models.ContractPIR", b =>
                {
                    b.Navigation("AdditionalAgreements");
                });

            modelBuilder.Entity("TrackerDB.Models.ContractSMR", b =>
                {
                    b.Navigation("AdditionalAgreements");
                });

            modelBuilder.Entity("TrackerDB.Models.Powerline", b =>
                {
                    b.Navigation("InternalNotes");
                });
#pragma warning restore 612, 618
        }
    }
}
