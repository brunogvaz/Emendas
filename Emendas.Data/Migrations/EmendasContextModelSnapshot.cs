﻿// <auto-generated />
using System;
using Emendas.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Emendas.Data.Migrations
{
    [DbContext(typeof(EmendasContext))]
    partial class EmendasContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("EmendasModel.Beneficiario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CNPJ");

                    b.Property<string>("Nome");

                    b.HasKey("Id");

                    b.ToTable("Beneficiarios");
                });

            modelBuilder.Entity("EmendasModel.Emenda", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CodEmenda");

                    b.Property<int>("ParlamentarId");

                    b.Property<int?>("PlanoTrabalhoId");

                    b.Property<decimal>("Valor")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("ParlamentarId");

                    b.HasIndex("PlanoTrabalhoId");

                    b.ToTable("Emendas");
                });

            modelBuilder.Entity("EmendasModel.EmendaEmpenho", b =>
                {
                    b.Property<int>("EmendaId");

                    b.Property<int>("EmpenhoId");

                    b.Property<int>("BeneficiarioId");

                    b.Property<decimal>("ValorEmpenhado")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("ValorPago")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("EmendaId", "EmpenhoId", "BeneficiarioId");

                    b.HasIndex("BeneficiarioId");

                    b.HasIndex("EmpenhoId");

                    b.ToTable("EmendaEmpenhos");
                });

            modelBuilder.Entity("EmendasModel.Empenho", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CodigoEmpenho");

                    b.HasKey("Id");

                    b.ToTable("Empenhos");
                });

            modelBuilder.Entity("EmendasModel.Indicacao", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("BeneficiarioId");

                    b.Property<int>("EmendaId");

                    b.Property<decimal>("ValorBloqueado");

                    b.Property<decimal>("ValorImpedido");

                    b.Property<decimal>("ValorIndicado");

                    b.Property<decimal>("ValorPriorizado");

                    b.HasKey("Id");

                    b.HasIndex("BeneficiarioId");

                    b.HasIndex("EmendaId");

                    b.ToTable("Indicacao");
                });

            modelBuilder.Entity("EmendasModel.Parlamentar", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CodParlamentar");

                    b.Property<string>("Name");

                    b.Property<int>("PartidoId");

                    b.Property<int>("TipoParlamentar");

                    b.Property<string>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("PartidoId");

                    b.HasIndex("UserId");

                    b.ToTable("Parlamentars");
                });

            modelBuilder.Entity("EmendasModel.Partido", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Codigo");

                    b.Property<string>("Name");

                    b.Property<string>("Sigla");

                    b.HasKey("Id");

                    b.ToTable("Partidos");
                });

            modelBuilder.Entity("EmendasModel.PlanoTrabalho", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Codigo");

                    b.Property<string>("Descricao");

                    b.HasKey("Id");

                    b.ToTable("PlanoTrabalhos");
                });

            modelBuilder.Entity("EmendasModel.User", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("EmendasModel.Emenda", b =>
                {
                    b.HasOne("EmendasModel.Parlamentar", "Parlamentar")
                        .WithMany("Emendas")
                        .HasForeignKey("ParlamentarId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("EmendasModel.PlanoTrabalho", "PlanoTrabalho")
                        .WithMany("Emendas")
                        .HasForeignKey("PlanoTrabalhoId");
                });

            modelBuilder.Entity("EmendasModel.EmendaEmpenho", b =>
                {
                    b.HasOne("EmendasModel.Beneficiario", "Beneficiario")
                        .WithMany("EmendaEmpenho")
                        .HasForeignKey("BeneficiarioId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("EmendasModel.Emenda", "Emenda")
                        .WithMany("EmendaEmpenho")
                        .HasForeignKey("EmendaId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("EmendasModel.Empenho", "Empenho")
                        .WithMany("EmendaEmpenhos")
                        .HasForeignKey("EmpenhoId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("EmendasModel.Indicacao", b =>
                {
                    b.HasOne("EmendasModel.Beneficiario", "Beneficiario")
                        .WithMany()
                        .HasForeignKey("BeneficiarioId");

                    b.HasOne("EmendasModel.Emenda", "Emenda")
                        .WithMany("Indicacaos")
                        .HasForeignKey("EmendaId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("EmendasModel.Parlamentar", b =>
                {
                    b.HasOne("EmendasModel.Partido", "Partido")
                        .WithMany("Parlamentars")
                        .HasForeignKey("PartidoId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("EmendasModel.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("EmendasModel.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("EmendasModel.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("EmendasModel.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("EmendasModel.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
