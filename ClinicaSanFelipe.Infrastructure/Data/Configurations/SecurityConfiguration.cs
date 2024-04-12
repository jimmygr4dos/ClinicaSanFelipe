﻿using ClinicaSanFelipe.Core.Entities;
using ClinicaSanFelipe.Core.Enumerations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaSanFelipe.Infrastructure.Data.Configurations
{
    public class SecurityConfiguration : IEntityTypeConfiguration<Security>
    {
        public void Configure(EntityTypeBuilder<Security> builder)
        {
            builder.ToTable("Seguridad");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
                .HasColumnName("IdSeguridad");

            builder.Property(e => e.User)
                .IsRequired()
                .HasColumnName("Usuario")
                .HasMaxLength(50)
                .IsUnicode(false);

            builder.Property(e => e.UserName)
                .IsRequired()
                .HasColumnName("NombreUsuario")
                .HasMaxLength(100)
                .IsUnicode(false);

            builder.Property(e => e.Password)
                .IsRequired()
                .HasColumnName("Contrasena")
                .HasMaxLength(200)
                .IsUnicode(false);

            builder.Property(e => e.Role)
                .IsRequired()
                .HasColumnName("Rol")
                .HasMaxLength(15)
                .HasConversion
                (
                    x => x.ToString(),
                    x => (RoleType)Enum.Parse(typeof(RoleType), x)
                );
        }
    }
}
