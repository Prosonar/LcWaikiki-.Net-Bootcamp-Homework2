using EntityFrameworkMigration.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EntityFrameworkMigration.DataAccess.Mapping
{
    public class UserMapping : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("User", "dbo");
            builder.HasKey(b => b.Id);

            builder.Property(b => b.Id).HasColumnName("Id");
            builder.Property(b => b.FirstName).HasColumnName("Name");
            builder.Property(b => b.LastName).HasColumnName("LastName");
            builder.Property(b => b.Email).HasColumnName("Email");
            builder.Property(b => b.PhoneNumber).HasColumnName("PhoneNumber");
            builder.Property(b => b.SchoolId).HasColumnName("SchoolId");
        }
    }
}
