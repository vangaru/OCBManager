// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using OCBManager.Data.Data;

#nullable disable

namespace OCBManager.API.Migrations
{
    [DbContext(typeof(OCBContext))]
    [Migration("20221221170017_InitialMigration")]
    partial class InitialMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("OCBManager.Domain.Models.Bill", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("BillClassId")
                        .HasColumnType("int");

                    b.Property<int>("BillNumber")
                        .HasColumnType("int");

                    b.Property<decimal>("IncomingBalanceActive")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<decimal>("IncomingBalancePassive")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<decimal>("OutgoingBalanceActive")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<decimal>("OutgoingBalancePassive")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<decimal>("TurnoverCredit")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<decimal>("TurnoverDebit")
                        .HasColumnType("decimal(18, 2)");

                    b.HasKey("Id");

                    b.HasIndex("BillClassId");

                    b.ToTable("Bills");
                });

            modelBuilder.Entity("OCBManager.Domain.Models.BillClass", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<decimal>("IncomingBalanceActive")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<decimal>("IncomingBalancePassive")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("OutgoingBalanceActive")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<decimal>("OutgoingBalancePassive")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<decimal>("TurnoverCredit")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<decimal>("TurnoverDebit")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<int>("TurnoverSheetId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TurnoverSheetId");

                    b.ToTable("BillClasses");
                });

            modelBuilder.Entity("OCBManager.Domain.Models.TurnoverSheet", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("FilePath")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("IncomingBalanceActive")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<decimal>("IncomingBalancePassive")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("OutgoingBalanceActive")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<decimal>("OutgoingBalancePassive")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<decimal>("TurnoverCredit")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<decimal>("TurnoverDebit")
                        .HasColumnType("decimal(18, 2)");

                    b.HasKey("Id");

                    b.ToTable("TurnoverSheets");
                });

            modelBuilder.Entity("OCBManager.Domain.Models.Bill", b =>
                {
                    b.HasOne("OCBManager.Domain.Models.BillClass", "BillClass")
                        .WithMany("Bills")
                        .HasForeignKey("BillClassId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("BillClass");
                });

            modelBuilder.Entity("OCBManager.Domain.Models.BillClass", b =>
                {
                    b.HasOne("OCBManager.Domain.Models.TurnoverSheet", "TurnoverSheet")
                        .WithMany("BillClasses")
                        .HasForeignKey("TurnoverSheetId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TurnoverSheet");
                });

            modelBuilder.Entity("OCBManager.Domain.Models.BillClass", b =>
                {
                    b.Navigation("Bills");
                });

            modelBuilder.Entity("OCBManager.Domain.Models.TurnoverSheet", b =>
                {
                    b.Navigation("BillClasses");
                });
#pragma warning restore 612, 618
        }
    }
}
