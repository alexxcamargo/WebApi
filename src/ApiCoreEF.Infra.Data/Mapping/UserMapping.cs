using ApiCoreEF.Domain.User;
using ApiCoreEF.Infra.Data.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApiCoreEF.Infra.Data.Mapping
{
    public class UserMapping : EntityTypeConfiguration<User>
    {
        public override void Map(EntityTypeBuilder<User> builder)
        {
            builder.Property(e => e.Nome)
                .HasColumnType("varchar(100)")
                .IsRequired();

            builder.Property(e => e.Login)
                .HasColumnType("varchar(10)")
                .IsRequired();

            builder.Property(e => e.Email)
                .HasColumnType("varchar(50)")
                .IsRequired();

            builder.Property(e => e.Senha)
                .HasColumnType("varchar(50)")
                .IsRequired();

            builder.Ignore(c => c.ValidationResult);

            builder.Ignore(c => c.CascadeMode);

            builder.ToTable("Users");
        }
    }
}
