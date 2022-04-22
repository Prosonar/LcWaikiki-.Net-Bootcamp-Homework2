using EntityFrameworkMigration.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EntityFrameworkMigration.DataAccess.Mapping
{
    public class SchoolTypeMapping : IEntityTypeConfiguration<SchoolType>
    {
        public void Configure(EntityTypeBuilder<SchoolType> builder)
        {
            builder.ToTable("SchoolType", "dbo");
            builder.HasKey(b => b.Id);

            builder.Property(b => b.Id).HasColumnName("Id");
            builder.Property(b => b.Name).HasColumnName("Name");
        }
    }
}
