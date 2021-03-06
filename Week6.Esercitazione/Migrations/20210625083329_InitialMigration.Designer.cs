// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Week6.Esercitazione.Context;

namespace Week6.Esercitazione.Migrations
{
    [DbContext(typeof(InsuranceContext))]
    [Migration("20210625083329_InitialMigration")]
    partial class InitialMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.7")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Week6.Esercitazione.Model.Client", b =>
                {
                    b.Property<string>("CF")
                        .HasMaxLength(16)
                        .HasColumnType("nchar(16)")
                        .IsFixedLength(true);

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("CF");

                    b.ToTable("Client");
                });

            modelBuilder.Entity("Week6.Esercitazione.Model.Policy", b =>
                {
                    b.Property<int>("Number")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CFClient")
                        .HasColumnType("nchar(16)");

                    b.Property<DateTime>("DateOfSign")
                        .HasColumnType("datetime2");

                    b.Property<double>("InsuredAmount")
                        .HasColumnType("float");

                    b.Property<double>("MonthlyRate")
                        .HasColumnType("float");

                    b.Property<string>("Policy_type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Number");

                    b.HasIndex("CFClient");

                    b.ToTable("Policy");

                    b.HasDiscriminator<string>("Policy_type").HasValue("Policy");
                });

            modelBuilder.Entity("Week6.Esercitazione.Model.PolicyLife", b =>
                {
                    b.HasBaseType("Week6.Esercitazione.Model.Policy");

                    b.Property<int>("AgeClient")
                        .HasColumnType("int");

                    b.HasDiscriminator().HasValue("life");
                });

            modelBuilder.Entity("Week6.Esercitazione.Model.PolicyRCCar", b =>
                {
                    b.HasBaseType("Week6.Esercitazione.Model.Policy");

                    b.Property<int>("Displacement")
                        .HasColumnType("int");

                    b.Property<string>("Plate")
                        .HasColumnType("nvarchar(max)");

                    b.HasDiscriminator().HasValue("RCcar");
                });

            modelBuilder.Entity("Week6.Esercitazione.Model.PolicyTheft", b =>
                {
                    b.HasBaseType("Week6.Esercitazione.Model.Policy");

                    b.Property<int>("PercentageCovered")
                        .HasColumnType("int");

                    b.HasDiscriminator().HasValue("theft");
                });

            modelBuilder.Entity("Week6.Esercitazione.Model.Policy", b =>
                {
                    b.HasOne("Week6.Esercitazione.Model.Client", "Client")
                        .WithMany("Policies")
                        .HasForeignKey("CFClient");

                    b.Navigation("Client");
                });

            modelBuilder.Entity("Week6.Esercitazione.Model.Client", b =>
                {
                    b.Navigation("Policies");
                });
#pragma warning restore 612, 618
        }
    }
}
