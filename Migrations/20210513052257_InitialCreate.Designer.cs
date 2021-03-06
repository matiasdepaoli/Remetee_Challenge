// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Remetee_Challenge.Services;

namespace Remetee_Challenge.Migrations
{
    [DbContext(typeof(CurrencyLayerWebClientService))]
    [Migration("20210513052257_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.6")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Remetee_Challenge.Core.Entities.CurrencyLayer", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("privacy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("source")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("success")
                        .HasColumnType("bit");

                    b.Property<string>("terms")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("timestamp")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("CurrencyLayerResponse");
                });

            modelBuilder.Entity("Remetee_Challenge.Core.Entities.Quote", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("CurrencyLayerId")
                        .HasColumnType("bigint");

                    b.Property<string>("Key")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("valor")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("CurrencyLayerId");

                    b.ToTable("Quotes");
                });

            modelBuilder.Entity("Remetee_Challenge.Core.Entities.Quote", b =>
                {
                    b.HasOne("Remetee_Challenge.Core.Entities.CurrencyLayer", "CurrencyLayer")
                        .WithMany("quotes")
                        .HasForeignKey("CurrencyLayerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CurrencyLayer");
                });

            modelBuilder.Entity("Remetee_Challenge.Core.Entities.CurrencyLayer", b =>
                {
                    b.Navigation("quotes");
                });
#pragma warning restore 612, 618
        }
    }
}
