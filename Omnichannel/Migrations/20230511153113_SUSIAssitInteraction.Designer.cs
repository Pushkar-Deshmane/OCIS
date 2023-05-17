﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Omnichannel.Data;

#nullable disable

namespace Omnichannel.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20230511153113_SUSIAssitInteraction")]
    partial class SUSIAssitInteraction
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0-preview.3.23174.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Omnichannel.Models.CallDriver", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CallDriverName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("CallDrivers");
                });

            modelBuilder.Entity("Omnichannel.Models.CallReason", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CallReasonName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("CallReasons");
                });

            modelBuilder.Entity("Omnichannel.Models.FurtherDetail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("FurtherDetailName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SubCategoryId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("SubCategoryId");

                    b.ToTable("FurtherDetails");
                });

            modelBuilder.Entity("Omnichannel.Models.QueryStatus", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("QueryStatusName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("QueryStatuses");
                });

            modelBuilder.Entity("Omnichannel.Models.SUSIAssistlineInteraction", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CallDriverId")
                        .HasColumnType("int");

                    b.Property<long>("CallId")
                        .HasColumnType("bigint");

                    b.Property<int>("CallReasonId")
                        .HasColumnType("int");

                    b.Property<string>("Comment")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("FurtherDetailId")
                        .HasColumnType("int");

                    b.Property<string>("InfoToAgent")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("QueryStatusId")
                        .HasColumnType("int");

                    b.Property<int>("SubCategoryId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CallDriverId");

                    b.HasIndex("CallReasonId");

                    b.HasIndex("FurtherDetailId");

                    b.HasIndex("QueryStatusId");

                    b.HasIndex("SubCategoryId");

                    b.ToTable("SUSIAssistlineInteractions");
                });

            modelBuilder.Entity("Omnichannel.Models.SubCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CallReasonId")
                        .HasColumnType("int");

                    b.Property<string>("SubCategoryName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CallReasonId");

                    b.ToTable("SubCategories");
                });

            modelBuilder.Entity("Omnichannel.Models.FurtherDetail", b =>
                {
                    b.HasOne("Omnichannel.Models.SubCategory", "SubCategory")
                        .WithMany()
                        .HasForeignKey("SubCategoryId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("SubCategory");
                });

            modelBuilder.Entity("Omnichannel.Models.SUSIAssistlineInteraction", b =>
                {
                    b.HasOne("Omnichannel.Models.CallDriver", "CallDriver")
                        .WithMany()
                        .HasForeignKey("CallDriverId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Omnichannel.Models.CallReason", "CallReason")
                        .WithMany()
                        .HasForeignKey("CallReasonId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Omnichannel.Models.FurtherDetail", "FurtherDetail")
                        .WithMany()
                        .HasForeignKey("FurtherDetailId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Omnichannel.Models.QueryStatus", "QueryStatus")
                        .WithMany()
                        .HasForeignKey("QueryStatusId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Omnichannel.Models.SubCategory", "SubCategory")
                        .WithMany()
                        .HasForeignKey("SubCategoryId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("CallDriver");

                    b.Navigation("CallReason");

                    b.Navigation("FurtherDetail");

                    b.Navigation("QueryStatus");

                    b.Navigation("SubCategory");
                });

            modelBuilder.Entity("Omnichannel.Models.SubCategory", b =>
                {
                    b.HasOne("Omnichannel.Models.CallReason", "CallReason")
                        .WithMany()
                        .HasForeignKey("CallReasonId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("CallReason");
                });
#pragma warning restore 612, 618
        }
    }
}
